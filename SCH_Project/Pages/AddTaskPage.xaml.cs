using System;
using System.Collections.Generic;
using System.Data.Common;
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
    /// Логика взаимодействия для AddTaskPage.xaml
    /// </summary>
    public partial class AddTaskPage : Page
    {
        public AddTaskPage()
        {
            InitializeComponent();
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            //Dbconnection.Task task = new Dbconnection.Task();
            //task.User = AuthorizationPage.user;
            //task.Status = false;
            //task.FinalDate = TaskDP.SelectedDate;
            //task.Name = NameTb.Text;
            //task.Description = DescriptionTb.Text;
            //task.IdType = 2;
            //Connection.taskManager.Task.Add(task);
            //Connection.taskManager.SaveChanges();
            //NavigationService.Navigate(new MyDayPage());
        }
    }
}