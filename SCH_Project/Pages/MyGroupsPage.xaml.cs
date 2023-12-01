using SCH_Project.Dbconnection;
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

namespace SCH_Project.Pages
{
    /// <summary>
    /// Логика взаимодействия для MyGroupsPage.xaml
    /// </summary>
    public partial class MyGroupsPage : Page
    {
        public static string GroupCount;
        public static Team currentTeam;
        public static List<UserTeam> userTeams {  get; set; }
        public MyGroupsPage()
        {
            InitializeComponent();
            userTeams = Connection.taskManager.UserTeam.Where(i => i.IdUser == AuthorizationPage.user.ID && i.IdTeam!=1).ToList();
            ListGroup.ItemsSource = userTeams;
            GroupCount = userTeams.Count.ToString();
            DataContext = this;
        }

        private void ListGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (userTeams.Where(i => i.Team.IdLeader == AuthorizationPage.user.ID && i.IdTeam != 1).ToList().Count == 1)
            {
                currentTeam = (ListGroup.SelectedItem as UserTeam).Team;
                NavigationService.Navigate(new MyGroupsUsersPage());
            }
        }
    }
}
