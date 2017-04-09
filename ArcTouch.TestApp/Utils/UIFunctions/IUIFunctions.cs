namespace ArcTouch.TestApp
{
    public interface IUIFunctions
    {
        void ShowAlert(string message, string title = "");
        void ShowToast(string message, ToastType type, int timeout = 5000);
        void ShowLoading(string title = "", int timeout = 5000);
        void HideLoading();
    }
}