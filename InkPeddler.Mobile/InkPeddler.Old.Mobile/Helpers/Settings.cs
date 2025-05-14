using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace InkPeddler.Mobile.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings { get => CrossSettings.Current; }

        public static string Email { get => GetAppSetting("email"); set => SetAppSetting("email", value); }
        public static string AccountId { get => GetAppSetting("account_id"); set => SetAppSetting("account_id", value); }
        public static string AccessToken { get => GetAppSetting("access_token"); set => SetAppSetting("access_token", value); }
        public static string RefreshToken { get => GetAppSetting("refresh_token"); set => SetAppSetting("refresh_token", value); }

        private static string GetAppSetting(string value) => AppSettings.GetValueOrDefault(value, "");
        private static void SetAppSetting(string key, string value) => AppSettings.AddOrUpdateValue(key, value);
    }
}