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

namespace SCH_Project.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public static string MyDayTbValue;
        public static string CountTeamTasks;
        public MainMenuPage()
        {
            InitializeComponent();
            loginTb.Text = AuthorizationPage.user.Login;
            MainMenuFrame.Navigate(new MyDayPage());
            MainMenuFrame.Navigate(new MyGroupsPage());
            MainMenuFrame.Navigate(new TeamTaskPage());
            this.DataContext = this;
        }

        private void ProfileBt_Click(object sender, RoutedEventArgs e)
        {
            MainMenuFrame.Navigate(new ProfilePage());
        }

        private void MydayBt_Click(object sender, RoutedEventArgs e)
        {
            MainMenuFrame.Navigate(new MyDayPage());
            MyDayTb.Text = MyDayTbValue;
        }

        private void AddGroupBt_Click(object sender, RoutedEventArgs e)
        {
            MainMenuFrame.Navigate (new AddGroupPage());
        }

        private void TeamTasksBt_Click(object sender, RoutedEventArgs e)
        {
            MainMenuFrame.Navigate(new TeamTaskPage());
            CountTaskTb.Text = CountTeamTasks;
        }

        private void MyGroupsBt_Click(object sender, RoutedEventArgs e)
        {
            MainMenuFrame.Navigate(new MyGroupsPage());
            MyGroupCountTb.Text = MyGroupsPage.GroupCount;
        }
    }
}
