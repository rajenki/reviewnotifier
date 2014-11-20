using System.Threading.Tasks;
using System.Windows;

#if WINDOWS_PHONE
using StorageHelper.WindowsPhoneSilverlight;

namespace ReviewNotifier.WindowsPhoneSilverlight
#elif WINDOWS_PHONE_APP
using StorageHelper.WindowsStore;

namespace ReviewNotifier.WindowsStore
#elif WINDOWS_APP
using StorageHelper.WindowsStore;

namespace ReviewNotifier.WindowsStore
#elif NETFX_CORE
using StorageHelper.WindowsStore;

namespace ReviewNotifier.WindowsStore
#endif
{
    public static partial class ReviewNotification
    {
        private const int DefaultCount = 5;

        /// <summary>
        /// Initialize the ReviewNotifier helper by increasing the startup counter.
        /// </summary>
        public async static Task InitializeAsync()
        {
            var startupCounter = await Storage.LoadAsync<int>("StartupCounter").ConfigureAwait(false);
            startupCounter++;
            await Storage.SaveAsync("StartupCounter", startupCounter);
        }
    }
}
