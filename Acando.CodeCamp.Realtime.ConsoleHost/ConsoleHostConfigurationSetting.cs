using XSockets.Core.Configuration;

namespace Acando.CodeCamp.Realtime
{
    internal class ConsoleHostConfigurationSetting : ConfigurationSetting
    {
        public ConsoleHostConfigurationSetting() : base("ws://localhost:4502")
        {
        }
    }
}
