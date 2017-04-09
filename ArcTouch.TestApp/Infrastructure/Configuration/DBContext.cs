using Xamarin.Forms;

namespace ArcTouch.TestApp
{
    /// <summary>
    /// Singleton for connection with SQLite Database.
    /// </summary>
    public sealed class DBContext
    {
        static volatile DBContext instance;
        static readonly object syncLock = new object();
        static SQLite.SQLiteConnection conn;

        DBContext()
        {
            conn = DependencyService.Get<ISQLite>(DependencyFetchTarget.GlobalInstance).GetConn();
        }

        public static SQLite.SQLiteConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                            instance = new DBContext();
                    }
                }
                return conn;
            }
        }
    }
}