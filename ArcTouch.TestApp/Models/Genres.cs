using SQLiteNetExtensions.Attributes;

namespace ArcTouch.TestApp
{
    /// <summary>
    /// Genres.
    /// </summary>
    public class Genres : BaseEntity
    {
        public string Name { get; set; }

        [ForeignKey(typeof(Results))]
        public int ResultId { get; set; }
    }
}