using SCH_Project.Dbconnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace SCH_Project.Pages
{
    /// <summary>
    /// Логика взаимодействия для SubmitAnApplicationPage.xaml
    /// </summary>
    public partial class SubmitAnApplicationPage : Page
    {
        public static List<UserTeam> userTeams = Connection.taskManager.UserTeam.Where(i => i.IdTeam != 1).ToList();
        public SubmitAnApplicationPage()
        {
            InitializeComponent();
            List<Team> sortTeam = new List<Team>(); 
            List<Team> teams = new List<Team>();
            List<Dbconnection.Application> applications = Connection.taskManager.Application.ToList();
            foreach (UserTeam team in userTeams)
            {
                    if (team.IdUser == AuthorizationPage.user.ID && !teams.Contains(team.Team))
                    {
                        teams.Add(team.Team);
                    }
            }
            foreach (Dbconnection.Application application in applications)
            {
                if (!teams.Contains(application.Team))
                {
                    teams.Add(application.Team);
                }
            }
            foreach (UserTeam teamItem in userTeams)
            {
                if (!(teams.Contains(teamItem.Team)))
                {
                    sortTeam.Add(teamItem.Team);
                }
            }
            ListApplication.ItemsSource = sortTeam;
            DataContext = this;
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            Dbconnection.Application application = new Dbconnection.Application();
            application.Team = ListApplication.SelectedItem as Team;
            application.User = AuthorizationPage.user;
            Connection.taskManager.Application.Add(application);
            Connection.taskManager.SaveChanges();
            ListApplication.Items.Refresh();
        }
    }
}
