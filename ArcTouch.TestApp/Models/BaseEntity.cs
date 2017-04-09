using SQLite;

namespace ArcTouch.TestApp
{
    /// <summary>
    /// Base entity.
    /// </summary>
    public class BaseEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}