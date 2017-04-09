using Microsoft.Azure.Mobile.Crashes;

namespace ArcTouch.TestApp
{
    public class MobileCenterCrashes : IMobileCenterCrashes
    {
        readonly IUIFunctions uiFunctionService;

        public MobileCenterCrashes(IUIFunctions uiFunc)
        {
            uiFunctionService = uiFunc;
        }

        /// <summary>
        /// Dids the app crash.
        /// </summary>
        public void DidAppCrash()
        {
            if (Crashes.HasCrashedInLastSession)
            {
                uiFunctionService.ShowAlert("", Constants.LastSessionCrashMessage);
            }
        }

        /// <summary>
        /// Asks the before send crash report.
        /// </summary>
        public void AskBeforeSendCrashReport()
        {
            Crashes.ShouldAwaitUserConfirmation = () =>
            {
                return true;
            };
        }
    }
}