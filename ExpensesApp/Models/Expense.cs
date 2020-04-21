using System;
using System.Collections.Generic;
using SQLite;
using System.Linq;
namespace ExpensesApp.Models
{
    public class Expense
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public float Amount { get; set; }

        [MaxLength(25)]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Category { get; set; }

        public Expense()
        {
        }

        public static int InsertExpense(Expense expense)
        {
            using(SQLite.SQLiteConnection connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Expense>();
                return connection.Insert(expense);
            }
        }

        public static List<Expense> GetExpenses()
        {
            using (SQLite.SQLiteConnection connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Expense>();
                return connection.Table<Expense>().ToList();
            }
        }

        public static float TotalexpenseAmount()
        {
            using (SQLite.SQLiteConnection connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Expense>();
                return connection.Table<Expense>().ToList().Sum(e => e.Amount);
            }
        }

        public static List<Expense> GetExpenses(string category)
        {
            using (SQLite.SQLiteConnection connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Expense>();
                return connection.Table<Expense>().Where(e=> e.Category==category).ToList();
            }
        }
    }
}
