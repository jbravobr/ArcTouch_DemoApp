using Acr.Settings;

namespace ArcTouch.TestApp
{
    public class DefaultSettings : IDefaultSettings
    {
        readonly ISettings settingsService;

        public DefaultSettings(ISettings setService)
        {
            settingsService = setService;
        }

        /// <summary>
        /// Configures the initial settings.
        /// </summary>
        public void ConfigureInitialSettings()
        {
            if (string.IsNullOrEmpty(settingsService.Get<string>("APIKEY")))
                settingsService.Set("APIKEY", "1f54bd990f1cdfb230adb312546d765d");
        }
    }
}