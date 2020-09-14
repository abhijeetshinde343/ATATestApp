using System;
using System.Collections.Generic;
using ATAGroupDemo.Model;
using ATAGroupDemo.ViewModel;
using Xamarin.Forms;

namespace ATAGroupDemo.Views
{
    public partial class StudentPage : ContentPage
    {
        public StudentPage(StudentTable studentTable)
        {
            InitializeComponent();
            this.BindingContext = new StudentViewModel(studentTable);
        }
    }
}
