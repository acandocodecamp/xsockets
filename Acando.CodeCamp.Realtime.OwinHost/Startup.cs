using System.Text;
using Acando.CodeCamp.Realtime;
using Microsoft.Owin;
using Owin;
using XSockets.Core.Common.Configuration;
using XSockets.Core.Common.Enterprise;
using XSockets.Owin.Host;
using XSockets.Plugin.Framework;

[assembly: OwinStartup(typeof(Startup))]

namespace Acando.CodeCamp.Realtime
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            StringBuilder sb = new StringBuilder(100);
            sb.AppendLine("Hi.");
            sb.AppendLine("");
            sb.AppendLine("Listening on endpoints:");
            sb.AppendLine("");

            app.UseXSockets(new OwinHostConfiguration());

            //Composable.GetExport<IXSocketsScaleOut>().AddScaleOut("ws://127.0.0.1:4502");

            var configurationSetting = Composable.GetExport<IConfigurationSetting>();

            sb.AppendLine(configurationSetting.Uri.ToString());

            app.Run(context =>
            {
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync(sb.ToString());
            });
        }
    }
}
