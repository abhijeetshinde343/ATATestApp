using System;
using System.Windows.Input;
using ATAGroupDemo.Interface;
using ATAGroupDemo.Model;
using ATAGroupDemo.Services;
using ATAGroupDemo.Views;
using Xamarin.Forms;

namespace ATAGroupDemo.ViewModel
{
    public class LoginViewModel :BaseViewModel
    {
        
        public ICommand LoginCommand { get; set; }
        private String username;
        public String Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                    OnPropertyChanged("Username");
            }
        }

        private String password;
        public String Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public LoginViewModel()
        {

            LoginCommand = new Command(ExceuteLoginCommand); 
        }

        private async void ExceuteLoginCommand(object obj)
        {
            UserService userService = new UserService();
           var data=await userService.GetUserByUserName(this.Username, this.Password);
            if(data!=null)
            {
                Settings.Role= data.Role.ToLower();
            }
            if(data.Role.ToLower()=="admin")
            {
               await Application.Current.MainPage.Navigation.PushAsync(new AdminPage());
            }
            else
            {
                RegistrationService registrationService = new RegistrationService();
                StudentTable studentTable =await registrationService.GetStudentbyUserId(data.UserID);
                await Application.Current.MainPage.Navigation.PushAsync(new StudentPage(studentTable));
            }

        }
    }
}
