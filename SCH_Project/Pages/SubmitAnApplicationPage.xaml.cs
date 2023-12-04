using SCH_Project.Dbconnection;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //ListApplication.ItemsSource = userTeams.Where(i => i.IdTeam != (userTeams.First(x => x.IdUser == AuthorizationPage.user.ID && x.IdTeam != 1) as UserTeam).IdTeam && i.IdTeam != 1).ToList();
            List<Team> sortTeam = new List<Team>(); 
            List<Team> teams = new List<Team>();
            foreach (UserTeam team in userTeams)
            {
                if (team.IdUser == AuthorizationPage.user.ID && !teams.Contains(team.Team))
                {
                    teams.Add(team.Team);
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

        private void ListApplication_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
