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
        public static List<UserTeam> userTeams {  get; set; }
        public static List<Team> teams = Connection.taskManager.Team.ToList();

        public static Dbconnection.Task task = new Dbconnection.Task();
        public AddTeamTaskPage(int value)
        {
            InitializeComponent();
            if (value == 1)
            {
                userTeams = Connection.taskManager.UserTeam.ToList();
                selectGroup.Visibility = Visibility.Visible;
                TeamCb.Visibility = Visibility.Visible;
                TeamCb.ItemsSource = teams.Where(i => i.ID != 1);
                task.Name = nameTb.Text.Trim();
                task.FinalDate = dateDp.SelectedDate;
                if (TeamCb.SelectedItem != null)
                {
                    selectUser.Visibility = Visibility.Visible;
                    UserCb.Visibility = Visibility.Visible;
                    UserCb.ItemsSource = userTeams.Where(i => i.IdTeam != 1 && i.IdTeam == (TeamCb.SelectedItem as Team).ID);
                    task.Description = DiscriptionTb.Text.Trim();
                    task.IdUserTeam = (UserCb.SelectedItem as UserTeam).ID;
                }
            }
            else if (value == 0) 
            {
                task.IdUserTeam = MyGroupsUsersPage.currentUserTeam.ID;
                task.Name = nameTb.Text.Trim();
                task.Status = false;
                task.FinalDate = dateDp.SelectedDate;
                task.Description = DiscriptionTb.Text.Trim();
            }
            DataContext = this; 
        }
        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            if (dateDp.SelectedDate >= DateTime.Today)
            {
                MessageTb.Foreground = System.Windows.Media.Brushes.White;
                MessageTb.Text = "task added";
                Connection.taskManager.Task.Add(task);
                Connection.taskManager.SaveChanges();
            }
            else
            {
                MessageTb.Text = "invalid data";
            }

        }
    }
}
