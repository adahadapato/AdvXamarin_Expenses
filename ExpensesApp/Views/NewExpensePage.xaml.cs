using System;
using System.Collections.Generic;
using ExpensesApp.ViewModels;
using Xamarin.Forms;

namespace ExpensesApp.Views
{
    public partial class NewExpensePage : ContentPage
    {
        NewExpensesVM ViewModel;
        public NewExpensePage()
        {
            InitializeComponent();

            ViewModel = Resources["vm"] as NewExpensesVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.GetExpenseStatus();
            int count = 0;
            foreach(var es in ViewModel._expenseStatus)
            {
                var cell = new SwitchCell { Text = es.Name };
                Binding binding = new Binding();
                binding.Source = ViewModel._expenseStatus[count];
                binding.Path = "Status";
                binding.Mode = BindingMode.TwoWay;
                cell.SetBinding(SwitchCell.OnProperty, binding);

                var section = new TableSection("Status");
                section.Add(cell);
                tbv.Root.Add(section);
                count++;
            }
        }
    }
}
