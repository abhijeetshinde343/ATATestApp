using System;
using System.Collections.Generic;
using ATAGroupDemo.ViewModel;
using Xamarin.Forms;

namespace ATAGroupDemo.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        void OnColorsRadioButtonCheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
        }
    }
}
