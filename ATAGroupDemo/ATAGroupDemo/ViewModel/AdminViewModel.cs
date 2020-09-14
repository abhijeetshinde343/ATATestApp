using System;
using System.Collections.Generic;
using System.Windows.Input;
using ATAGroupDemo.Model;
using ATAGroupDemo.Services;
using ATAGroupDemo.Views;
using Xamarin.Forms;

namespace ATAGroupDemo.ViewModel
{
    public class AdminViewModel :BaseViewModel
    {
        private List<StudentTable> _StudentList;
        public List<StudentTable> StudentList
        {
            get
            {
                return _StudentList;
            }
            set
            {
                _StudentList = value;
                OnPropertyChanged("StudentList");
            }
        }

        public ICommand AuditCommand { get; set; }
        public ICommand StudentCommand { get; set; }
        
        RegistrationService registrationService = new RegistrationService();
        public AdminViewModel()
        {
            AuditCommand = new Command(ExecuteAuditCommand);
            StudentCommand= new Command(ExecuteStudentCommand);
            GetStudentData();
        }

        private void ExecuteStudentCommand(object obj)
        {
            StudentTable studentTable = obj as StudentTable;
            Application.Current.MainPage.Navigation.PushAsync(new StudentPage(studentTable));
        }

        private void ExecuteAuditCommand(object obj)
        {
            StudentTable studentTable = obj as StudentTable;
            registrationService.UpdateStudent(studentTable);
            this.StudentList = new List<StudentTable>();
            GetStudentData();
        }

        private async void GetStudentData()
        {
           
            this.StudentList = await registrationService.GetStudent();
        }
    }
}
