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
        public static int TypeUser;
        public AddTeamTaskPage(int value)
        {
            TypeUser = value;
            InitializeComponent();
            if (TypeUser == 1)
            {
                userTeams = Connection.taskManager.UserTeam.ToList();
                selectGroup.Visibility = Visibility.Visible;
                TeamCb.Visibility = Visibility.Visible;
                TeamCb.ItemsSource = teams.Where(i => i.ID != 1);
            }
            DataContext = this; 
        }
        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(TypeUser.ToString());
            if (dateDp.SelectedDate >= DateTime.Today && UserCb.SelectedItem != null && TypeUser == 1)
            {
                task.IdUserTeam = (UserCb.SelectedItem as UserTeam).ID;
                task.Name = nameTb.Text.Trim();
                task.Status = false;
                task.FinalDate = dateDp.SelectedDate;
                task.Description = DiscriptionTb.Text.Trim();
                nameTb.Clear();
                DiscriptionTb.Clear();
                dateDp.SelectedDate = null;
                UserCb.SelectedItem = null;
                TeamCb.SelectedItem = null;
                UserCb.Visibility = Visibility.Hidden;
                selectUser.Visibility = Visibility.Hidden;
                MessageTb.Foreground = System.Windows.Media.Brushes.White;
                MessageTb.Text = "task added";
                Connection.taskManager.Task.Add(task);
                Connection.taskManager.SaveChanges();
            }
            
            else if (dateDp.SelectedDate >= DateTime.Today && TypeUser == 0)
            {
                task.IdUserTeam = MyGroupsUsersPage.currentUserTeam.ID;
                task.Name = nameTb.Text.Trim();
                task.Status = false;
                task.FinalDate = dateDp.SelectedDate;
                task.Description = DiscriptionTb.Text.Trim();
                nameTb.Clear();
                DiscriptionTb.Clear();
                dateDp.SelectedDate = null;
                MessageTb.Foreground = System.Windows.Media.Brushes.White;
                MessageTb.Text = "task added";
                Connection.taskManager.Task.Add(task);
                Connection.taskManager.SaveChanges();
                
            }
            else
            {
                MessageTb.Foreground = System.Windows.Media.Brushes.Red;
                MessageTb.Text = "invalid data";
            }
        }

        private void TeamCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                UserCb.ItemsSource = userTeams.Where(i => i.IdTeam != 1 && i.IdTeam == (TeamCb.SelectedItem as Team).ID);
                selectUser.Visibility = Visibility.Visible;
                UserCb.Visibility = Visibility.Visible;
        }
    }
}
