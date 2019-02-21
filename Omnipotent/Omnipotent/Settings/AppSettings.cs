using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Omnipotent.Settings
{
    public class AppSettings
    {
        private const string DefaultBaseEndpoint = "https://omnipotent-2414e.firebaseio.com/users/CUdDVxqii8PemLc1bc8E.json";
        private static ISettings Settings => CrossSettings.Current;



        // API Endpoints
        public static string BaseEndpoint
        {
            get => Settings.GetValueOrDefault(nameof(BaseEndpoint), DefaultBaseEndpoint);

            set => Settings.AddOrUpdateValue(nameof(BaseEndpoint), value);
        }

        public static string Token
        {
            get => Settings.GetValueOrDefault(nameof(Token), default(string));

            set => Settings.AddOrUpdateValue(nameof(Token), value);
        }


        public static Guid UserId
        {
            get => Settings.GetValueOrDefault(nameof(UserId), default(Guid));

            set => Settings.AddOrUpdateValue(nameof(UserId), value);
        }

        public static void RemoveUserId()
        {
            Settings.Remove(nameof(UserId));
        }

        public static void RemoveToken()
        {
            Settings.Remove(nameof(Token));
        }
    }
}
