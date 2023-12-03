using SCH_Project.Dbconnection;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
namespace SCH_Project.Pages
{
    /// <summary>
    /// Логика взаимодействия для TeamTaskPage.xaml
    /// </summary>
    public partial class TeamTaskPage : Page
    {
        public TeamTaskPage()
        {
            InitializeComponent();



            ListTeamTask.ItemsSource = Connection.taskManager.Task.Where(i => i.UserTeam.IdUser == AuthorizationPage.user.ID && i.UserTeam.IdTeam != 1 || i.UserTeam.Team.IdLeader == AuthorizationPage.user.ID).ToList();

            TeamCbUser.ItemsSource = Connection.taskManager.UserTeam.Where(i => i.IdUser == AuthorizationPage.user.ID && i.IdTeam != 1).ToList();

            TeamCbLeader.ItemsSource = Connection.taskManager.Team.Where(i => i.IdLeader == AuthorizationPage.user.ID && i.ID != 1).ToList();

            if (Connection.taskManager.UserTeam.Where(i => i.Team.IdLeader == AuthorizationPage.user.ID).Count() != 0)
            {
                TeamCbLeader.Visibility = Visibility.Visible;
            }
            else
            {
                TeamCbUser.Visibility = Visibility.Visible;
            }

            MainMenuPage.CountTeamTasks = ListTeamTask.Items.Count.ToString();
            DataContext = this;
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTeamTaskPage(1));
        }
        private void TeamCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListTeamTask.ItemsSource = Connection.taskManager.Task.Where(i => i.UserTeam.IdUser == AuthorizationPage.user.ID && i.UserTeam.IdTeam != 1 && i.UserTeam.IdTeam == (TeamCbLeader.SelectedItem as Team).ID || i.UserTeam.IdTeam == (TeamCbUser.SelectedItem as UserTeam).IdTeam).ToList();
        }

        private void ListTeamTask_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Task selectedTask = ListTeamTask.SelectedItem as Task;
            ListSubtask.ItemsSource = Connection.taskManager.Subtask.Where(i => i.IdTask == selectedTask.ID).ToList();
        }

        private void AddSubtaskBt_Click(object sender, RoutedEventArgs e)
        {
            Task selectedTask = ListTeamTask.SelectedItem as Task;
            Subtask subtask = new Subtask();
            subtask.IdTask = selectedTask.ID;
            subtask.Name = SubtaskNameTb.Text;
            Connection.taskManager.Subtask.Add(subtask);
            Connection.taskManager.SaveChanges();
            ListSubtask.ItemsSource = Connection.taskManager.Subtask.Where(i => i.IdTask == selectedTask.ID).ToList();
        }

        private void AddTaskBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTeamTaskPage(0));
        }
    }
}