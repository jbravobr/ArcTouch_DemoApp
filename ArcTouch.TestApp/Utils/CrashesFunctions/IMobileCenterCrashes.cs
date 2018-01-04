namespace ArcTouch.TestApp
{
    public interface IMobileCenterCrashes
    {
        void DidAppCrash();
        void AskBeforeSendCrashReport();
    }
}