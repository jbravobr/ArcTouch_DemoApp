using System.Collections.Generic;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ArcTouch.TestApp
{
    /// <summary>
    /// Images.
    /// </summary>
    public class Images : BaseEntity
    {
        [JsonProperty("base_url")]
        public string BaseUrl { get; set; }

        [JsonProperty("secure_base_url")]
        public string SecureBaseUrl { get; set; }

        [JsonProperty("backdrop_sizes")]
        [JsonIgnore]
        [Ignore]
        public List<string> BackdropSizes { get; set; }

        [JsonProperty("logo_sizes")]
        [JsonIgnore]
        [Ignore]
        public List<string> LogoSizes { get; set; }

        [JsonProperty("poster_sizes")]
        [JsonIgnore]
        [Ignore]
        public List<string> PosterSizes { get; set; }

        [JsonProperty("profile_sizes")]
        [JsonIgnore]
        [Ignore]
        public List<string> ProfileSizes { get; set; }

        [JsonProperty("still_sizes")]
        [JsonIgnore]
        [Ignore]
        public List<string> StillSizes { get; set; }
    }
}
