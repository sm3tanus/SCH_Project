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
        public static int Nado = 1;
        public static List<Dbconnection.Task> tasks { get; set; }
        public static List<UserTeam> userTeams { get; set; }
        public TeamTaskPage()
        {
            InitializeComponent();
            //userTeams = Connection.taskManager.UserTeam.ToList();
            //teams = Connection.taskManager.Team.ToList();
            //tasks = Connection.taskManager.Task.ToList();
            //TeamCb.ItemsSource = userTeams.Where(i => i.IdUser == AuthorizationPage.user.ID).ToList();
            //Team trueItem = TeamCb.SelectedItem as Team;
            //if (tasks.Where(i => i.UserTeam.Team.IdLeader == AuthorizationPage.user.ID).ToList().Count >= 1)
            //{ 
            //    if (trueItem != null)
            //    {
            //        ListTeamTask.ItemsSource = tasks.Where(i => i.UserTeam.Team.IdLeader ==
            //        AuthorizationPage.user.ID && i.UserTeam.IdTeam != 1 && i.UserTeam.IdTeam == 
            //        trueItem.ID).ToList();
            //    }
            //    else
            //    {
            //        ListTeamTask.ItemsSource = tasks.Where(i => i.UserTeam.Team.IdLeader == AuthorizationPage.user.ID && i.UserTeam.IdTeam != 1).ToList();
            //    }
            //}
            //else
            //{
            //    if (trueItem != null)
            //    {
            //        ListTeamTask.ItemsSource = tasks.Where(i => i.UserTeam.IdUser == AuthorizationPage.user.ID && i.UserTeam.IdTeam != 1 
            //        && i.UserTeam.IdTeam == trueItem.ID).ToList();
            //    }
            //    else
            //    {
            //        ListTeamTask.ItemsSource = tasks.Where(i => i.UserTeam.IdUser == AuthorizationPage.user.ID && i.UserTeam.IdTeam != 1).ToList();
            //        AddBt.Visibility = Visibility.Hidden;
            //    }   
            //}
            MainMenuPage.CountTeamTasks = ListTeamTask.Items.Count.ToString();
            DataContext = this;
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTeamTaskPage());
        }

    }
}
