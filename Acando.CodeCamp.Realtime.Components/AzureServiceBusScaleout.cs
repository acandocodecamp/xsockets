using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using XSockets.Core.Common.Enterprise;
using XSockets.Core.Common.Protocol;
using XSockets.Core.Common.Socket;
using XSockets.Core.Common.Socket.Event.Interface;
using XSockets.Core.Common.Utility.Logging;
using XSockets.Core.Common.Utility.Serialization;
using XSockets.Core.XSocket.Model;
using XSockets.Enterprise.Scaling;
using XSockets.Plugin.Framework;
using XSockets.Protocol;

namespace Acando.CodeCamp.Realtime
{
    public class AzureServiceBusScaleout : BaseScaleOut
    {
        private readonly string _sid = Guid.NewGuid().ToString();
        private string _connectionString;
        private IXSocketJsonSerializer _jsonSerializer;
        private NamespaceManager _namespaceManager;
        private SubscriptionClient _subscriptionClient;
        private TopicClient _topicClient;
        private const string TopicPath = "XSocketTopic";
        private const string DataAttributeName = "JSON";
        private const string SidAttributeName = "SID";

        public override void Init()
        {
            Composable.GetExport<IXLogger>().Information("Scaling INIT");
            _connectionString = "<connection>";
            _jsonSerializer = Composable.GetExport<IXSocketJsonSerializer>();
            SetupAzureServiceBus();
        }

        public override async Task Publish(MessageDirection messageDirection, IMessage message, ScaleOutOrigin scaleOutOrigin)
        {
            Composable.GetExport<IXLogger>().Information("Scaling PUBLISH");
            await _topicClient.SendAsync(GetBrokerMessage(message));
        }

        public override async Task Subscribe()
        {
            Composable.GetExport<IXLogger>().Information("Scaling SUBSCRIBE");
            var options = new OnMessageOptions { AutoComplete = false, AutoRenewTimeout = TimeSpan.FromMinutes(30), MaxConcurrentCalls = 8 };
            await Task.Run(() => _subscriptionClient.OnMessage(OnBrokerMessage, options)).ConfigureAwait(false);
        }

        private void OnBrokerMessage(BrokeredMessage brokeredMessage)
        {
            try
            {
                //Ignore messages from self
                if (brokeredMessage.Properties[SidAttributeName].ToString() == _sid)
                {
                    brokeredMessage.Complete();
                    return;
                }

                var json = brokeredMessage.Properties[DataAttributeName].ToString();
                var message = _jsonSerializer.DeserializeFromString<Message>(json);

                var pipeline = Composable.GetExport<IXSocketPipeline>();
                var controller = Composable.GetExports<IXSocketController>().First(p => p.Alias == message.Controller);
                controller.ProtocolInstance = new XSocketInternalProtocol();
                pipeline.OnIncomingMessage(controller, message);
                brokeredMessage.Complete();
            }
            catch (Exception ex)
            {
                Composable.GetExport<IXLogger>().Error(ex.ToString());

                // Indicates a problem
                if (brokeredMessage.DeliveryCount > 3)
                {
                    brokeredMessage.DeadLetter();
                }
                else
                {
                    brokeredMessage.Abandon();
                }
            }
        }

        private BrokeredMessage GetBrokerMessage(IMessage message)
        {
            var brokeredMessage = new BrokeredMessage();
            brokeredMessage.Properties[DataAttributeName] = _jsonSerializer.SerializeToString(message);
            brokeredMessage.Properties[SidAttributeName] = _sid;
            return brokeredMessage;
        }

        private void SetupAzureServiceBus()
        {
            Composable.GetExport<IXLogger>().Debug("Azure ServiceBus Scaling - INIT");
            _namespaceManager = NamespaceManager.CreateFromConnectionString(_connectionString);

            if (!_namespaceManager.TopicExists(TopicPath))
            {
                Composable.GetExport<IXLogger>().Debug("Creating Topic for Azure Service Bus");
                TopicDescription td = _namespaceManager.CreateTopic(TopicPath);
            }
            if (!_namespaceManager.SubscriptionExists(TopicPath, _sid))
            {
                _namespaceManager.CreateSubscription(TopicPath, _sid);
                Composable.GetExport<IXLogger>().Debug("Creating Subscription for Azure Service Bus");
            }
            _topicClient = TopicClient.CreateFromConnectionString(_connectionString, TopicPath);
            _subscriptionClient = SubscriptionClient.CreateFromConnectionString(_connectionString, TopicPath, _sid);
        }
    }
}
