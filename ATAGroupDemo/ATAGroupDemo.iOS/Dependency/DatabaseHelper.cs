using System;
using System.IO;
using ATAGroupDemo.Interface;
using ATAGroupDemo.iOS.Dependency;
using Foundation;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseHelper))]
namespace ATAGroupDemo.iOS.Dependency
{
    public class DatabaseHelper: IFileHelper
    {
        public DatabaseHelper()
        {
        }


        public string GetDbPath()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            string dbPath = Path.Combine(libFolder, "ATGGroupDatabase.db");
            CopyDatabaseIfNotExists(dbPath);
            return dbPath;
        }

        private static void CopyDatabaseIfNotExists(string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                var existingDb = NSBundle.MainBundle.PathForResource("ATGGroupDatabase", "db");
                File.Copy(existingDb, dbPath);
            }
        }
    }
}
