﻿using ControlzEx.Standard;
using SCH_Project.Dbconnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
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
    /// Логика взаимодействия для AddGroupPage.xaml
    /// </summary>
    public partial class AddGroupPage : System.Windows.Controls.Page
    {
        public static List<User> users = Connection.taskManager.User.Where(i => i.ID != AuthorizationPage.user.ID).ToList();
        public static List<Otdel> otdels { get; set; }
        public static List<User> list = new List<User>();
        public static List<Team> teams { get; set; }

        public AddGroupPage()
        {
            InitializeComponent();
            try
            {
                teams = Connection.taskManager.Team.ToList();
                otdels = Connection.taskManager.Otdel.ToList();
                foreach (Team team in teams)
                {
                    if (users.Contains(team.User))
                    {
                        users.Remove(team.User);
                    }
                }
                ListUsers.ItemsSource = users;
                DataContext = this;
            }
            catch
            { }
        }
        public static Team team = new Team();
        public static UserTeam userTeam = new UserTeam();
        private void CreateBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                team.Name = nameTb.Text.Trim();
                team.IdLeader = AuthorizationPage.user.ID;
                Connection.taskManager.Team.Add(team);
                Connection.taskManager.SaveChanges();
                teams = Connection.taskManager.Team.ToList();
                foreach (User user in list)
                {
                    userTeam.IdUser = user.ID;
                    userTeam.IdTeam = teams.Last().ID;
                    Connection.taskManager.UserTeam.Add(userTeam);
                    Connection.taskManager.SaveChanges();
                }
                NavigationService.Navigate(new MyGroupsPage());
            }
            catch
            { }
        }

        private void departCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ListUsers.ItemsSource = users.Where(i => i.IdOtdel == (departCb.SelectedItem as Otdel).ID).ToList();
            }
            catch
            { }
        }

        private void ListUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var currentUser = (ListUsers.SelectedItem as User);
                list.Add(currentUser);
                users.Remove(currentUser);
                ListUsers.Items.Refresh();
            }
            catch
            { }

        }
    }
}