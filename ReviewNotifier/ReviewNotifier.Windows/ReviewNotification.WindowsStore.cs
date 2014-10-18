using StorageHelper.WindowsStore;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Store;
using Windows.System;
using Windows.UI.Popups;

namespace ReviewNotifier.WindowsStore
{
    public static partial class ReviewNotification
    {
        private const string DefaultOKString = "OK";
        private const string DefaultCancelString = "Cancel";

        /// <summary>
        /// Trigger the ReviewNotifier helper. A message will be displayed with the passed title and message text after the specified number of app launches.
        /// </summary>
        /// <param name="message">The message text of the message pop-up to be displayed to the user</param>
        /// <param name="title">The title of the message pop-up to be displayed to the user</param>
        /// <param name="count">The number of app launches before displaying the message pop-up</param>
        public static Task TriggerAsync(string message, string title, int count)
        {
            return TriggerAsync(message, title, DefaultOKString, DefaultCancelString, count);
        }

        /// <summary>
        /// Trigger the ReviewNotifier helper. A message with custom button texts will be displayed with the passed title and message text after 5 app launches.
        /// </summary>
        /// <param name="message">The message text of the message pop-up to be displayed to the user</param>
        /// <param name="title">The title of the message pop-up to be displayed to the user</param>
        /// <param name="ok">The text of the accept button</param>
        /// <param name="cancel">The text of the cancel button</param>
        public static Task TriggerAsync(string message, string title, string ok, string cancel)
        {
            return TriggerAsync(message, title, ok, cancel, DefaultCount);
        }

        /// <summary>
        /// Trigger the ReviewNotifier helper. A message with custom button texts will be displayed with the passed title and message text after the specified number of app launches.
        /// </summary>
        /// <param name="message">The message text of the message pop-up to be displayed to the user</param>
        /// <param name="title">The title of the message pop-up to be displayed to the user</param>
        /// <param name="ok">The text of the accept button</param>
        /// <param name="cancel">The text of the cancel button</param>
        /// <param name="count">The number of app launches before displaying the message pop-up</param>
        public async static Task TriggerAsync(string message, string title, string ok = DefaultOKString, string cancel = DefaultCancelString, int count = DefaultCount)
        {
            var startupCounter = await Storage.LoadAsync<int>("StartupCounter");
            var notifyReview = false;
            if (startupCounter != count) return;

            if (!await Storage.LoadAsync<bool>("ReviewNotified"))
                notifyReview = true;

            if (!notifyReview) return;
            var messageDialog = new MessageDialog(message, title);
            messageDialog.Commands.Add(new UICommand(ok));
            messageDialog.Commands.Add(new UICommand(cancel));
            if ((await messageDialog.ShowAsync()).Label == ok)
            {
#if WINDOWS_APP
                await Launcher.LaunchUriAsync(new Uri(string.Format("ms-windows-store:REVIEW?PFN={0}", Package.Current.Id.FamilyName)));
#elif WINDOWS_PHONE_APP
                await Launcher.LaunchUriAsync(new Uri(string.Format("ms-windows-store:reviewapp?appid={0}", CurrentApp.AppId)));
#endif
            }

            Storage.SaveAsync("ReviewNotified", true);
        }
    }
}
