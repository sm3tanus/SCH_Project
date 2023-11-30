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
    /// Логика взаимодействия для AddTeamTaskPage.xaml
    /// </summary>
    public partial class AddTeamTaskPage : Page
    {
        public static List<Team> teams {  get; set; }
        public AddTeamTaskPage()
        {
            InitializeComponent();
            teams = Connection.taskManager.Team.ToList();
            GroupCb.ItemsSource = teams.;
        }

        private void GroupCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
