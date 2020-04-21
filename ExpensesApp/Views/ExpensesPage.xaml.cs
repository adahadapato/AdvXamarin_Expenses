using System;
using System.Collections.Generic;
using ExpensesApp.ViewModels;
using Xamarin.Forms;

namespace ExpensesApp.Views
{
    public partial class ExpensesPage : ContentPage
    {
        ExpenseVM ViewModel;

        public ExpensesPage()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as ExpenseVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.GetExpenses();
        }
    }
}
