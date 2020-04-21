using System;
using Xamarin.Forms;
using ExpensesApp.Models;
using ExpensesApp.Views;

namespace ExpensesApp.Behaviors
{
    public class ListViewBehavior:Behavior<ListView>
    {
        ListView listView;
        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            listView = bindable;
            listView.ItemSelected += ListView_Itemselected;
        }

        private void ListView_Itemselected(object sender, SelectedItemChangedEventArgs e)
        {
            Expense selectedExpense = (listView.SelectedItem) as Expense;
            Application.Current.MainPage.Navigation.PushAsync(new ExpenseDetailsPage(selectedExpense));
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            listView.ItemSelected -= ListView_Itemselected;
        }
    }
}
