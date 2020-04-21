using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ExpensesApp.Models;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class NewExpensesVM:INotifyPropertyChanged
    {
        private string _expenseName;
        public string ExpenseName
        {
            get { return _expenseName; }
            set
            {
                _expenseName = value;
                OnPropertyChanged("ExpenseName");
            }
        }

        private string _expensedescription;
        public string ExpenseDescription
        {
            get { return _expensedescription; }
            set
            {
                _expensedescription = value;
                OnPropertyChanged("Expensedescription");
            }
        }

        private float _expenseAmount;
        public float ExpenseAmount
        {
            get { return _expenseAmount; }
            set
            {
                _expenseAmount = value;
                OnPropertyChanged("ExpenseAmount");
            }
        }

        private DateTime _expenseDate;
        public DateTime ExpenseDate
        {
            get { return _expenseDate; }
            set
            {
                _expenseDate = value;
                OnPropertyChanged("ExpenseDate");
            }
        }

        private string _expenseCategory;
        public string ExpenseCategory
        {
            get { return _expenseCategory; }
            set
            {
                _expenseCategory = value;
                OnPropertyChanged("ExpenseCategory");
            }
        }

        public Command SaveExpenseCommand { get; set; }
        public ObservableCollection<string> _categories { get; set; }
        public ObservableCollection<ExpenseStatus> _expenseStatus { get; set; }
        public NewExpensesVM()
        {
            _categories = new ObservableCollection<string>();
            _expenseStatus = new ObservableCollection<ExpenseStatus>();
            ExpenseDate = DateTime.Today;
            SaveExpenseCommand = new Command(InsetExpense);
            GetCategories();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InsetExpense()
        {
            Expense expense = new Expense()
            {
                Name = ExpenseName,
                Amount = ExpenseAmount,
                Category = ExpenseCategory,
                Date = ExpenseDate,
                Description = ExpenseDescription
            };

           int response = Expense.InsertExpense(expense);

            if (response > 0)
                Application.Current.MainPage.Navigation.PopAsync();
            else
                Application.Current.MainPage.DisplayAlert("Error", "No items were inserted", "OK");
        }

        private void GetCategories()
        {
            _categories.Clear();
            _categories.Add("Housing");
            _categories.Add("Debt");
            _categories.Add("Health");
            _categories.Add("Food");
            _categories.Add("Personal");
            _categories.Add("Travel");
            _categories.Add("Other");
        }

        public void GetExpenseStatus()
        {
            _expenseStatus.Clear();
            _expenseStatus.Add(new ExpenseStatus
            {
                Name="Random",
                Status = true
            });
            _expenseStatus.Add(new ExpenseStatus
            {
                Name = "Random 2",
                Status = true
            });
            _expenseStatus.Add(new ExpenseStatus
            {
                Name = "Random 3",
                Status = false
            });
        }
        

        public class ExpenseStatus
        {
            public string Name { get; set; }
            public bool Status { get; set; }
        }
    }
}
