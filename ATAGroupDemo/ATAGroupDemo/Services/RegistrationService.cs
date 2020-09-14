using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATAGroupDemo.Interface;
using ATAGroupDemo.Model;
using SQLite;
using Xamarin.Forms;

namespace ATAGroupDemo.Services
{
    public class RegistrationService
    {
        protected readonly SQLiteAsyncConnection Connection;
        public RegistrationService()
        {
            string dbPath = DependencyService.Get<IFileHelper>().GetDbPath();
            Connection = new SQLiteAsyncConnection(dbPath);
            //Connection.CreateTableAsync<UserTable>().Wait();
        }

        public async Task<int> SaveStudent(StudentTable studentTable)
        {
            try
            {
                var data =await Connection.InsertAsync(studentTable);
                return data;
            }
            catch(Exception e)
            {
                return 0;
            }
        }

        public async Task<List<StudentTable>> GetStudent()
        {
            try
            {
                var data = await Connection.Table<StudentTable>().ToListAsync();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<StudentTable> GetStudentbyUserId(int userid)
        {
            try
            {
                var data = await Connection.Table<StudentTable>().ToListAsync();
                return data.Where(x=>x.UserID==userid).FirstOrDefault();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<int> UpdateStudent(StudentTable studentTable)
        {
            try
            {
                studentTable.ISAuditable = "true";
               return await Connection.UpdateAsync(studentTable);
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public async void DeleteStudent(StudentTable studentTable)
        {
            try
            {
                
               var data= await Connection.DeleteAsync(studentTable);
            }
            catch (Exception e)
            {

            }
        }





    }
}
