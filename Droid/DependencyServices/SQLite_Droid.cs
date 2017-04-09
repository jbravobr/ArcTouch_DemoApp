using System;
using System.IO;
using ArcTouch.TestApp.Droid;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Droid))]
namespace ArcTouch.TestApp.Droid
{
    public class SQLite_Droid : ISQLite
    {
        public SQLiteConnection GetConn()
        {
            var sqliteFilename = "ArcTouchAppDB.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}