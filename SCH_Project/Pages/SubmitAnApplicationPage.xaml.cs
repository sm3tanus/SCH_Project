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
        public SubmitAnApplicationPage()
        {
            InitializeComponent();
            try
            {
                List<UserTeam> userTeams = Connection.taskManager.UserTeam.Where(i => i.IdUser == AuthorizationPage.user.ID).ToList();
                List<Team> teams = Connection.taskManager.Team.Where(i => i.ID != 1).ToList();
                List<Dbconnection.Application> applications = Connection.taskManager.Application.ToList();
                foreach (UserTeam userTeam in userTeams)
                {
                    if (teams.Contains(userTeam.Team))
                    {
                        teams.Remove(userTeam.Team);
                    }
                }
                foreach (Dbconnection.Application application in applications)
                {
                    if (teams.Contains(application.Team))
                    {
                        teams.Remove(application.Team);
                    }
                }
                ListApplication.ItemsSource = teams;
                DataContext = this;
            }
            catch
            { }
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dbconnection.Application application = new Dbconnection.Application();
                application.Team = ListApplication.SelectedItem as Team;
                application.User = AuthorizationPage.user;
                Connection.taskManager.Application.Add(application);
                Connection.taskManager.SaveChanges();
                MessageTb.Text = "successfully";
                ListApplication.Items.Refresh();
            }
            catch
            { }
        }
    }
}