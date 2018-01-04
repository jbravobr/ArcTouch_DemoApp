using System;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace ArcTouch.TestApp
{
    public class UIFunctions : IUIFunctions
    {
        readonly IUserDialogs _userDialogService;

        public UIFunctions(IUserDialogs userDialogService)
        {
            _userDialogService = userDialogService;
        }

        /// <summary>
        /// Hides the loading.
        /// </summary>
        public void HideLoading()
        {
            Device.BeginInvokeOnMainThread(_userDialogService.HideLoading);
        }

        /// <summary>
        /// Shows the alert.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="title">Title.</param>
        public void ShowAlert(string message, string title = "")
        {
            Device.BeginInvokeOnMainThread(() => _userDialogService.Alert(message, title));
        }

        /// <summary>
        /// Shows the loading.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="timeout">Timeout.</param>
        public void ShowLoading(string title = "", int timeout = 5000)
        {
            Device.BeginInvokeOnMainThread(() => _userDialogService.ShowLoading(title));
        }

        /// <summary>
        /// Shows the toast.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="type">Type.</param>
        /// <param name="timeout">Timeout.</param>
        public void ShowToast(string message, ToastType type, int timeout = 5000)
        {
            ToastConfig toastConfig = new ToastConfig(message)
            {
                BackgroundColor = type == ToastType.Error ? System.Drawing.Color.Crimson :
                                                    type == ToastType.Info || type == ToastType.Warning ? System.Drawing.Color.Goldenrod :
                                                    System.Drawing.Color.Green,
                MessageTextColor = System.Drawing.Color.White,
                Duration = TimeSpan.FromMilliseconds(timeout)
            };

            Device.BeginInvokeOnMainThread(() => _userDialogService.Toast(toastConfig));
        }
    }
}