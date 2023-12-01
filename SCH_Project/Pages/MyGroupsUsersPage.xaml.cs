﻿using System;
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
    /// Логика взаимодействия для MyGroupsUsersPage.xaml
    /// </summary>
    public partial class MyGroupsUsersPage : Page
    {
        public static List<UserTeam> userTeams {  get; set; }
        public MyGroupsUsersPage()
        {
            InitializeComponent();
            userTeams = Connection.taskManager.UserTeam.ToList();
            ListUsers.ItemsSource = userTeams.Where(i => i.IdTeam == MyGroupsPage.currentTeam.ID);
            NameTeamTb.Text = MyGroupsPage.currentTeam.Name;
            DataContext = this;
        }

        private void ViewApplicateBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewingApplicationPage());
        }
    }
}
