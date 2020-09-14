using System;
using System.Linq;
using System.Threading.Tasks;
using ATAGroupDemo.Interface;
using ATAGroupDemo.Model;
using SQLite;
using Xamarin.Forms;

namespace ATAGroupDemo.Services
{
    public class AddressService
    {
       
        protected readonly SQLiteAsyncConnection Connection;
        public AddressService()
        {
            string dbPath = DependencyService.Get<IFileHelper>().GetDbPath();
            Connection = new SQLiteAsyncConnection(dbPath);
            //Connection.CreateTableAsync<UserTable>().Wait();
        }

        public async Task SaveAddress(AddressTable address)
        {
            try
            {
                var data = await Connection.InsertAsync(address);
            }
            catch (Exception e)
            {

            }
        }

        public async Task<AddressTable> GetAddress(int addressid)
        {
            try
            {
                var data = await Connection.Table<AddressTable>().ToListAsync();
                return data.Where(x=>x.AddressId== addressid).FirstOrDefault();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
