using System.Text;
using Acando.CodeCamp.Realtime;
using Microsoft.Owin;
using Owin;
using XSockets.Owin.Host;

[assembly: OwinStartup(typeof(Startup))]

namespace Acando.CodeCamp.Realtime
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //StringBuilder sb = new StringBuilder(100);
            //sb.AppendLine("Hi.");
            //sb.AppendLine("");
            //sb.AppendLine("");
            //sb.AppendLine("Listening on endpoints:");
            //sb.AppendLine("");

            app.UseXSockets();
            //using (var container = Composable.GetExport<IXSocketServerContainer>())
            //{
            //    container.OnStarted += (sender, args) =>
            //    {

            //    };
            //    container.Start();

            //    foreach (var server in container.Servers)
            //    {
            //        sb.AppendLine(server.ConfigurationSetting.Endpoint.ToString());
            //    }
            //}

            //app.Run(context =>
            //{
            //    context.Response.ContentType = "text/plain";
            //    return context.Response.WriteAsync(sb.ToString());
            //});
        }
    }
}
