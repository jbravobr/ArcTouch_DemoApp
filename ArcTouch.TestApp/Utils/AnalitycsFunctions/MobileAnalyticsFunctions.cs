using System.Collections.Generic;
using Microsoft.Azure.Mobile.Analytics;

namespace ArcTouch.TestApp
{
    public class MobileAnalyticsFunctions : IMobileAnalyticsFunctions
    {
        /// <summary>
        /// Tracks the event.
        /// </summary>
        /// <param name="eventName">Event name.</param>
        /// <param name="properties">Properties.</param>
        public void TrackEvent(AnalitycsEventsName eventName, Dictionary<string, string> properties)
        {
            Analytics.TrackEvent(eventName.GetDescription(), properties);
        }
    }
}