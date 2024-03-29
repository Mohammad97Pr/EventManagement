using EventManagement.Debugging;

namespace EventManagement
{
    public class EventManagementConsts
    {
        public const string LocalizationSourceName = "EventManagement";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = false;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "8a887c700af7468cb168312a540567dd";
    }
}
