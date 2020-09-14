using System;
using System.Linq;
using System.Threading.Tasks;
using ATAGroupDemo.Interface;
using ATAGroupDemo.Model;
using SQLite;
using Xamarin.Forms;

namespace ATAGroupDemo.Services
{
    public class DocumentService
    {
        protected readonly SQLiteAsyncConnection Connection;
        public DocumentService()
        {
            string dbPath = DependencyService.Get<IFileHelper>().GetDbPath();
            Connection = new SQLiteAsyncConnection(dbPath);
            //Connection.CreateTableAsync<UserTable>().Wait();
        }

        public async Task SaveDocument(DocumentTable  documentTable)
        {
            try
            {
                var data = await Connection.InsertAsync(documentTable);
            }
            catch (Exception e)
            {

            }
        }

        public async Task<DocumentTable> GetDocument(int documentid)
        {
            try
            {
                var data = await Connection.Table<DocumentTable>().ToListAsync();
                return data.Where(x => x.DocumentId == documentid).FirstOrDefault();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
