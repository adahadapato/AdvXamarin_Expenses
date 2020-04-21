using System;
using System.Collections.ObjectModel;
using ExpensesApp.Models;
using ExpensesApp.Views;
using Xamarin.Forms;
using ExpensesApp.Interfaces;

namespace ExpensesApp.ViewModels
{
    public class ExpenseVM
    {
        public ObservableCollection<Expense> _expense { get; set; }
        public Command AddExpenseCommand { get; set; }
        public ExpenseVM()
        {
            _expense = new ObservableCollection<Expense>();
            AddExpenseCommand = new Command(AddExpense);
            GetExpenses();
        }

        public void GetExpenses()
        {
            var expenses = Expense.GetExpenses();
            _expense.Clear();

            foreach (var expese in expenses)
                _expense.Add(expese);
        }

        public async void AddExpense()
        {
              await Application.Current.MainPage.Navigation.PushAsync(new NewExpensePage());
        }

       
    }
}
