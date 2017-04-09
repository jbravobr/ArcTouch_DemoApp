using System.Collections.Generic;
using Newtonsoft.Json;
using SQLiteNetExtensions.Attributes;

namespace ArcTouch.TestApp
{
    /// <summary>
    /// Root object.
    /// </summary>
    public class RootObject : BaseEntity
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("results")]
        public List<Results> Results { get; set; }

        [JsonProperty("images")]
        public Images Image { get; set; }

        [ForeignKey(typeof(Images))]
        public int ImageId { get; set; }

        [JsonProperty("dates")]
        public Dates Date { get; set; }

        [ForeignKey(typeof(Dates))]
        public int DateId { get; set; }

        [JsonProperty("genres")]
        public List<Genres> Genres { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
    }
}