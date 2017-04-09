using SQLiteNetExtensions.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using System;

namespace ArcTouch.TestApp
{
    /// <summary>
    /// Results.
    /// </summary>
    public class Results : BaseEntity
    {
        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        /// <summary>
        /// Gets the release date formatted string.
        /// </summary>
        /// <value>The release date formatted string.</value>
        [JsonIgnore]
        [Ignore]
        public string ReleaseDateFormattedString
        {
            get
            {
                if (!string.IsNullOrEmpty(ReleaseDate))
                    return Convert.ToDateTime(ReleaseDate).Year.ToString();

                return "Undefined";
            }
        }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("genre_ids")]
        [Ignore]
        public List<int> GenresIds { get; set; }

        [OneToMany]
        public List<Genres> Genres { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonIgnore]
        public string FullImagePath { get; set; }

        /// <summary>
        /// Gets the genres formatted string.
        /// </summary>
        /// <value>The genres formatted string.</value>
        [JsonIgnore]
        [Ignore]
        public string GenresFormattedString
        {
            get
            {
                return Genres.Any() && Genres != null ? Genres.Select(g => g.Name).Aggregate((c, n) => $"{c}, {n}")
                             : "Undefined";
            }
        }
    }
}