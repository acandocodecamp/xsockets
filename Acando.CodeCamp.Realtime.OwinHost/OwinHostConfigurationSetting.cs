using XSockets.Core.Configuration;

namespace Acando.CodeCamp.Realtime
{
    public class ConsoleHostConfigurationSetting : ConfigurationSetting
    {
        public ConsoleHostConfigurationSetting() : base("ws://127.0.0.1:4503")
        {
        }
    }
}
