using System;
using System.Collections.ObjectModel;
using ExpensesApp.Models;
using System.Linq;
using ExpensesApp.Interfaces;
using Xamarin.Forms;
using PCLStorage;
using System.IO;

namespace ExpensesApp.ViewModels
{
    public class CategoriesVM
    {
        public ObservableCollection<string> Categories { get; set; }
        public ObservableCollection<CategoryExpenses> _categoryExpenses { get; set; }
        public Command ExportCommand { get; set; }
        public CategoriesVM()
        {
            ExportCommand = new Command(ShareReport);
            Categories = new ObservableCollection<string>();
            _categoryExpenses = new ObservableCollection<CategoryExpenses>();
            GetCategories();
            GetExpensesPerCategory();
        }

        private void GetCategories()
        {
            Categories.Clear();
            Categories.Add("Housing");
            Categories.Add("Debt");
            Categories.Add("Health");
            Categories.Add("Food");
            Categories.Add("Personal");
            Categories.Add("Travel");
            Categories.Add("Other");
        }

        public void GetExpensesPerCategory()
        {
            _categoryExpenses.Clear();
            float totalExpenseAmount = Expense.TotalexpenseAmount();
            foreach(string c in Categories)
            {
                var expense = Expense.GetExpenses(c);
                float expenseAmountIncategory = expense.Sum(e => e.Amount);

                CategoryExpenses ce = new CategoryExpenses
                {
                    Category = c,
                    ExpensePercentage = expenseAmountIncategory / totalExpenseAmount
                };

                _categoryExpenses.Add(ce);
            }
        }

        public class CategoryExpenses
        {
            public string Category { get; set; }
            public float ExpensePercentage { get; set; }
        }

        public async void ShareReport()
        {
            IFileSystem fileSystem = FileSystem.Current;
            IFolder rootFolder = fileSystem.LocalStorage;
            IFolder reportsFolder = await rootFolder.CreateFolderAsync("reports", CreationCollisionOption.OpenIfExists);

            var txtFile = await reportsFolder.CreateFileAsync("reports.txt", CreationCollisionOption.ReplaceExisting);

            using(StreamWriter sw=new StreamWriter(txtFile.Path))
            {
                foreach(var ce in _categoryExpenses)
                {
                    sw.WriteLine($"{ce.Category} - {ce.ExpensePercentage}");
                }
            }

            IShare sharedDependency = DependencyService.Get<IShare>();
            await sharedDependency.Show("Expense report", "Here is your Expense report", txtFile.Path);
        }
    }
}
