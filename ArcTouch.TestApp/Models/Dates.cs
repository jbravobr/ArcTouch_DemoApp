using Newtonsoft.Json;

namespace ArcTouch.TestApp
{
    /// <summary>
    /// Dates.
    /// </summary>
    public class Dates : BaseEntity
    {
        [JsonProperty("maximum")]
        public string Maximum { get; set; }

        [JsonProperty("minimum")]
        public string Minimum { get; set; }
    }
}