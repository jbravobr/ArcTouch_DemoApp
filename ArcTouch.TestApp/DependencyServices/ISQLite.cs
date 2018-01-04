using SQLite;

namespace ArcTouch.TestApp
{
    public interface ISQLite
    {
        SQLiteConnection GetConn();
    }
}