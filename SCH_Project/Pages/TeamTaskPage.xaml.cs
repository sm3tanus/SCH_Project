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
        public TeamTaskPage()
        {
            InitializeComponent();
            List<UserTeam> userTeams = Connection.taskManager.UserTeam.ToList();
            ListTeamTask.ItemsSource = Connection.taskManager.Task.Where(i => i.UserTeam.IdUser == AuthorizationPage.user.ID && i.UserTeam.IdTeam != 1).ToList();
            teams = Connection.taskManager.Team.ToList();
            TeamCb.ItemsSource = teams.Where(i => i.IdLeader== AuthorizationPage.user.ID).ToList(); //очень сильно доработать
            var teamsSort = teams.Where(i => i.IdLeader == AuthorizationPage.user.ID).ToList();
            if (teamsSort.Count == 0)
            {
                VisibStack.Visibility = Visibility.Hidden;
                ErrorTb.Visibility = Visibility.Visible;
            }
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
