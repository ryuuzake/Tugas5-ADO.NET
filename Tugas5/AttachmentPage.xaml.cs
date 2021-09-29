using System;
using System.Windows.Controls;
using Tugas5.Config;
using Tugas5.Model;
using Tugas5.Repository;

namespace Tugas5
{
    /// <summary>
    /// Interaction logic for AttachmentPage.xaml
    /// </summary>
    public partial class AttachmentPage : Page
    {
        private int TodoId;
        private int AttachmentId;
        private string AttachmentUrl;
        private AttachmentRepository Repository;

        public AttachmentPage(int todoId)
        {
            InitializeComponent();
            TodoId = todoId;
            Repository = new AttachmentRepository(new Database());
            RefreshData();
        }

        private void AttachmentIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            try
            {
                AttachmentId = int.Parse(textBox.Text);
            }
            catch (Exception)
            {
                AttachmentId = 1;
            }
        }

        private void AttachmentUrlTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            AttachmentUrl = textBox.Text;
        }

        private void Create_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var attachment = new Attachment() { Id = AttachmentId, TodoId = TodoId, Url = AttachmentUrl };
            Repository.CreateAttachment(attachment);
            ClearTextBox();
        }

        private void Update_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var attachment = new Attachment() { Id = AttachmentId, TodoId = TodoId, Url = AttachmentUrl };
            Repository.UpdateAttachment(AttachmentId, attachment);
            ClearTextBox();
        }

        private void Delete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Repository.DeleteAttachment(AttachmentId);
            ClearTextBox();
        }

        private void Refresh_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            var result = Repository.FindAllAttachmentByTodoId(TodoId);
            AttachmentDataGrid.ItemsSource = result;
        }

        private void ClearTextBox()
        {
            AttachmentIdTextBox.Text = "Attachment Id";
            AttachmentUrlTextBox.Text = "Attachment Url";
        }

        private void AttachmentDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var row = sender as DataGrid;
            var rowTodo = row.SelectedItem as Attachment;

            if (rowTodo != null)
            {
                AttachmentIdTextBox.Text = rowTodo.Id.ToString();
                AttachmentUrlTextBox.Text = rowTodo.Url;
            }
        }
    }
}
