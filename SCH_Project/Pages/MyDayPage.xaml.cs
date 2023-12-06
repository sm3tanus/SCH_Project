using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SCH_Project.Dbconnection;

namespace SCH_Project.Pages
{
    /// <summary>
    /// Логика взаимодействия для MyDayPage.xaml
    /// </summary>
    public partial class MyDayPage : Page
    {
        public static string MyDayTbValue;
        public static List<Dbconnection.Task> tasks { get; set; }
        public MyDayPage()
        {
            InitializeComponent();
            try
            {
                ListTask.ItemsSource = Connection.taskManager.Task.Where(i => i.UserTeam.IdUser == AuthorizationPage.user.ID && i.UserTeam.IdTeam == 1).ToList();
                MyDayTbValue = ListTask.Items.Count.ToString();
                DataContext = this;
            }
            catch
            { }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTaskPage());
        }

        private void ListTask_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var task = ListTask.SelectedItem as Dbconnection.Task;
                task.Status = !(task.Status);
                Connection.taskManager.Task.AddOrUpdate(task);
                Connection.taskManager.SaveChanges();
                ListTask.Items.Refresh();
            }
            catch
            { }
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListTask.ItemsSource = Connection.taskManager.Task.Where(i => i.UserTeam.IdUser == AuthorizationPage.user.ID && i.UserTeam.IdTeam == 1 && i.FinalDate == DateTaskTb.SelectedDate.Value).ToList();
            }
            catch
            { }

        }
    }
}