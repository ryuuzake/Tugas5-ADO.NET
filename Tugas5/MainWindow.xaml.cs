using System.Windows;

namespace Tugas5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GoToTodoPage();
        }

        private void GoToTodoPage()
        {
            mainFrame.Navigate(new TodoPage());
        }
    }
}
