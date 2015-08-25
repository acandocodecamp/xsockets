using XSockets.Core.Configuration;

namespace Acando.CodeCamp.Realtime
{
    public class ConsoleHostConfigurationSetting : ConfigurationSetting
    {
        public ConsoleHostConfigurationSetting() : base("ws://localhost:4502")
        {
        }
    }
}
