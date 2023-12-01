using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для TeamTaskPage.xaml
    /// </summary>
    public partial class TeamTaskPage : Page
    {
        public static List<Team> teams { get; set; }
        public static List<Dbconnection.Task> tasks { get; set; }
        public TeamTaskPage()
        {
            InitializeComponent();
            List<UserTeam> userTeams = Connection.taskManager.UserTeam.ToList();
            teams = Connection.taskManager.Team.ToList();
            tasks = Connection.taskManager.Task.ToList();
            TeamCb.ItemsSource = userTeams.Where(i => i.IdUser == AuthorizationPage.user.ID && i.IdTeam != 1).ToList();
            if (teams.Where(i => i.IdLeader == AuthorizationPage.user.ID).ToList().Count == 1)
            {
                ListTeamTask.ItemsSource = tasks.Where(i => i.UserTeam.Team.IdLeader == AuthorizationPage.user.ID && i.UserTeam.IdTeam != 1).ToList();
            }
            else
            {
                ListTeamTask.ItemsSource = tasks.Where(i => i.UserTeam.IdUser == AuthorizationPage.user.ID && i.UserTeam.IdTeam != 1).ToList();
                AddBt.Visibility = Visibility.Hidden;
            }
            MainMenuPage.CountTeamTasks = ListTeamTask.Items.Count.ToString();
            DataContext = this;
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTeamTaskPage());
        }

        private void TeamCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ListTeamTask.ItemsSource = tasks.Where(i => i.IdTeam == (TeamCb.SelectedItem as Team).ID).ToList();
        }
    }
}
