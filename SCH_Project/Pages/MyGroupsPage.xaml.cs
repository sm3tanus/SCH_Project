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
        public static List<Team> teams = Connection.taskManager.Team.ToList();
        public static List<UserTeam> userTeams = Connection.taskManager.UserTeam.ToList();
        public MyGroupsPage()
        {
            InitializeComponent();
            try
            {
                if (teams.Where(i => i.IdLeader == AuthorizationPage.user.ID).ToList().Count >= 1)
                {
                    ListGroupLeader.ItemsSource = Connection.taskManager.Team.Where(i => i.IdLeader == AuthorizationPage.user.ID && i.ID != 1).ToList();
                    GroupCount = ListGroupLeader.Items.Count.ToString();
                }
                else
                {
                    ListGroupUser.Visibility = Visibility.Visible;
                    ListGroupUser.ItemsSource = Connection.taskManager.UserTeam.Where(i => i.IdUser == AuthorizationPage.user.ID && i.IdTeam != 1).ToList();
                    GroupCount = ListGroupUser.Items.Count.ToString();
                }
                if (teams.Where(i => i.IdLeader == AuthorizationPage.user.ID).Count() == 0)
                {
                    SubmitAdd.Visibility = Visibility.Visible;
                }
                DataContext = this;
            }
            catch
            { }
        }

        private void ListGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                currentTeam = (ListGroupLeader.SelectedItem as Team);
                NavigationService.Navigate(new MyGroupsUsersPage());
            }
            catch
            { }

        }

        private void SubmitAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SubmitAnApplicationPage()); 
        }
    }
}
