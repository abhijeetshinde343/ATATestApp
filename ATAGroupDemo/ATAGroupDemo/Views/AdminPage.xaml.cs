using System;
using System.Collections.Generic;
using ATAGroupDemo.ViewModel;
using Xamarin.Forms;

namespace ATAGroupDemo.Views
{
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new AdminViewModel();
        }
    }
}
