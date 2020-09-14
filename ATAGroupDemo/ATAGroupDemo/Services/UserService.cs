using System;
using System.Threading.Tasks;
using ATAGroupDemo.Interface;
using ATAGroupDemo.Model;
using SQLite;
using Xamarin.Forms;

namespace ATAGroupDemo.Services
{
    public class UserService
    {
        protected readonly SQLiteAsyncConnection Connection;
        public UserService()
        {
            string dbPath = DependencyService.Get<IFileHelper>().GetDbPath();
            Connection = new SQLiteAsyncConnection(dbPath);
            //Connection.CreateTableAsync<UserTable>().Wait();
        }

        public async Task<UserTable> GetUserByUserName(String UserName,String Password)
        {
            UserTable _UserTable = await Connection.Table<UserTable>().Where(x=>x.UserName==UserName && x.Psssword==Password).FirstOrDefaultAsync();
            return _UserTable;
        }
    }
}
