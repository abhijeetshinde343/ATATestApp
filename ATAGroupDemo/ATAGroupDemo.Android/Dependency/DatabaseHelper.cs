using System;
using System.IO;
using ATAGroupDemo.Droid.Dependency;
using ATAGroupDemo.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseHelper))]

namespace ATAGroupDemo.Droid.Dependency
{
    public class DatabaseHelper : IFileHelper
    {
        public DatabaseHelper()
        {
        }

        public string GetDbPath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbPath = Path.Combine(path, "ATGGroupDatabase.db");
            CopyDatabaseIfNotExists(dbPath);
            return dbPath;
        }
        private void CopyDatabaseIfNotExists(string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                using (var br = new BinaryReader(Android.App.Application.Context.Assets.Open("ATGGroupDatabase.db")))
                {
                    using (var bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, length);
                        }
                    }
                }
            }
        }
    }
}
