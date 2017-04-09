using System.Collections.Generic;

namespace ArcTouch.TestApp
{
    public interface IMobileAnalyticsFunctions
    {
        void TrackEvent(AnalitycsEventsName eventName, Dictionary<string, string> properties);
    }
}