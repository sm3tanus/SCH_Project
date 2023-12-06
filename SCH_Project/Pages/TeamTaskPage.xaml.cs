using SCH_Project.Dbconnection;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
        public static List<Subtask> subtasks = new List<Subtask>();
        public TeamTaskPage()
        {
            InitializeComponent();

            ListTeamTask.ItemsSource = Connection.taskManager.Task.Where(i => i.UserTeam.IdUser == AuthorizationPage.user.ID && i.UserTeam.IdTeam != 1 || i.UserTeam.Team.IdLeader == AuthorizationPage.user.ID).ToList();

            TeamCbUser.ItemsSource = Connection.taskManager.UserTeam.Where(i => i.IdUser == AuthorizationPage.user.ID && i.IdTeam != 1).ToList();

            TeamCbLeader.ItemsSource = Connection.taskManager.Team.Where(i => i.IdLeader == AuthorizationPage.user.ID && i.ID != 1).ToList();

            if (Connection.taskManager.UserTeam.Where(i => i.Team.IdLeader == AuthorizationPage.user.ID).Count() != 0)
            {
                TeamCbLeader.Visibility = Visibility.Visible;
                AddTaskBt.Visibility = Visibility.Visible;
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
            int selectedIdTeam = 1;
            if(TeamCbUser.SelectedItem != null)
                selectedIdTeam = Convert.ToInt32((TeamCbUser.SelectedItem as UserTeam).IdTeam);
            else if(TeamCbLeader.SelectedItem != null)
                selectedIdTeam = Convert.ToInt32((TeamCbLeader.SelectedItem as Team).ID);
            ListTeamTask.ItemsSource = Connection.taskManager.Task.Where(i => i.UserTeam.IdUser == AuthorizationPage.user.ID && i.UserTeam.IdTeam != 1 && i.UserTeam.IdTeam == selectedIdTeam || i.UserTeam.IdTeam == selectedIdTeam).ToList();
        }
        public static Task selectedTask;
        private void ListTeamTask_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTask = ListTeamTask.SelectedItem as Task;
            ListSubtask.ItemsSource = Connection.taskManager.Subtask.Where(i => i.IdTask == selectedTask.ID).ToList();
            if (ListSubtask.Items.Count == 0)
            {
                var task = ListTeamTask.SelectedItem as Dbconnection.Task;
                task.Status = !(task.Status);
                Connection.taskManager.Task.AddOrUpdate(task);
                Connection.taskManager.SaveChanges();
                ListTeamTask.Items.Refresh();
            }
        }
       
        private void AddSubtaskBt_Click(object sender, RoutedEventArgs e)
        {
            selectedTask = ListTeamTask.SelectedItem as Task;
            Subtask subtask = new Subtask();
            subtask.IdTask = selectedTask.ID;
            subtask.Name = SubtaskNameTb.Text;
            Connection.taskManager.Subtask.Add(subtask);
            Connection.taskManager.SaveChanges();
            subtasks = Connection.taskManager.Subtask.Where(i => i.IdTask == selectedTask.ID).ToList();
            ListSubtask.ItemsSource = subtasks;
        }
        private void AddTaskBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTeamTaskPage(1));
        }

        private void ListSubtask_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTask = ListTeamTask.SelectedItem as Task;
            var task = ListSubtask.SelectedItem as Dbconnection.Subtask;
            task.Status = !(task.Status);
            Connection.taskManager.Subtask.AddOrUpdate(task);
            Connection.taskManager.SaveChanges();
            ListSubtask.Items.Refresh();
            if (subtasks.Where(i => i.Status == true).Count() == ListSubtask.Items.Count)
            {
                selectedTask.Status = true;
                Connection.taskManager.SaveChanges();
                ListTeamTask.Items.Refresh();
            }
        }
    }
}