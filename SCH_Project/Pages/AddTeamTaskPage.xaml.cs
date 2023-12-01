using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddTeamTaskPage.xaml
    /// </summary>
    public partial class AddTeamTaskPage : Page
    {
        public AddTeamTaskPage()
        {
            InitializeComponent();
            
            DataContext = this;
            
        }
        public static Dbconnection.Task task = new Dbconnection.Task();

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            if (dateDp.SelectedDate >= DateTime.Today)
            {
                task.IdUserTeam = MyGroupsUsersPage.currentUserTeam.ID;
                task.Name = nameTb.Text.Trim();
                task.Status = false;
                task.FinalDate = dateDp.SelectedDate;
                task.Description = DiscriptionTb.Text.Trim();
                Connection.taskManager.Task.Add(task);
                Connection.taskManager.SaveChanges();
                MessageTb.Foreground = System.Windows.Media.Brushes.White;
                MessageTb.Text = "task added";
            }
            else
            {
                MessageTb.Text = "invalid data";
            }
        }
    }
}
