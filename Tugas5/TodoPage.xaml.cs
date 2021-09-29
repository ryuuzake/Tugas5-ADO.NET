using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tugas5.Config;
using Tugas5.Model;
using Tugas5.Repository;

namespace Tugas5
{
    /// <summary>
    /// Interaction logic for StartupPage.xaml
    /// </summary>
    public partial class TodoPage : Page
    {
        private TodoRepository Repository;
        private int TodoId;
        private string TodoTitle;
        private string TodoBody;

        public TodoPage()
        {
            InitializeComponent();
            Repository = new TodoRepository(new Database());
            RefreshData();
        }

        private void TodoIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            try
            {
                TodoId = int.Parse(textBox.Text);
            }
            catch (Exception)
            {
                TodoId = 1;
            }
        }

        private void TodoTitleTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            TodoTitle = textBox.Text;
        }

        private void TodoBodyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            TodoBody = textBox.Text;
        }

        private void CreateTodo_Click(object sender, RoutedEventArgs e)
        {
            var todo = new Todo() { Id = TodoId, Title = TodoTitle, Body = TodoBody };
            Repository.CreateTodo(todo);
            ClearTextBox();
        }

        private void UpdateTodo_Click(object sender, RoutedEventArgs e)
        {
            var todo = new Todo() { Id = TodoId, Title = TodoTitle, Body = TodoBody };
            Repository.UpdateTodo(TodoId, todo);
            ClearTextBox();
        }

        private void DeleteTodo_Click(object sender, RoutedEventArgs e)
        {
            Repository.DeleteTodo(TodoId);
            ClearTextBox();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            var result = Repository.FindAllTodo();
            TodoDataGrid.ItemsSource = result;
        }

        private void ClearTextBox()
        {
            TodoIdTextBox.Text = "Todo Id";
            TodoTitleTextBox.Text = "Todo Title";
            TodoBodyTextBox.Text = "Todo Body";
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = sender as DataGridRow;
            var rowTodo = row.Item as Todo;

            this.NavigationService.Navigate(new AttachmentPage(rowTodo.Id));
        }

        private void TodoDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var row = sender as DataGrid;
            var rowTodo = row.SelectedItem as Todo;

            if (rowTodo != null)
            {
                TodoIdTextBox.Text = rowTodo.Id.ToString();
                TodoTitleTextBox.Text = rowTodo.Title;
                TodoBodyTextBox.Text = rowTodo.Body;
            }
        }
    }
}
