using Microsoft.Phone.Tasks;
using StorageHelper.WindowsPhoneSilverlight;
using System.Threading.Tasks;
using System.Windows;

namespace ReviewNotifier.WindowsPhoneSilverlight
{
    public static partial class ReviewNotification
    {
        /// <summary>
        /// Trigger the ReviewNotifier helper. A message will be displayed with the passed title and message text after the specified number of app launches.
        /// </summary>
        /// <param name="message">The message text of the message pop-up to be displayed to the user</param>
        /// <param name="title">The title of the message pop-up to be displayed to the user</param>
        /// <param name="count">The number of app launches before displaying the message pop-up</param>
        public async static Task TriggerAsync(string message, string title, int count = DefaultCount)
        {
            var startupCounter = await Storage.LoadAsync<int>("StartupCounter");
            var notifyReview = false;
            if (startupCounter != count) return;

            if (!await Storage.LoadAsync<bool>("ReviewNotified"))
                notifyReview = true;

            if (!notifyReview) return;
            if (MessageBox.Show(message, title, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                new MarketplaceReviewTask().Show();

            Storage.SaveAsync("ReviewNotified", true);
        }
    }
}
