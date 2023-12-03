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
using SCH_Project;
using SCH_Project.Dbconnection;

namespace SCH_Project.Pages
{
    /// <summary>
    /// Логика взаимодействия для ViewingApplicationPage.xaml
    /// </summary>
    public partial class ViewingApplicationPage : Page
    {
        public static Dbconnection.Application selectedApplication;
        public ViewingApplicationPage()
        {
            InitializeComponent();
            ListApplication.ItemsSource = Connection.taskManager.Application.Where(i=>i.IdTeam == MyGroupsPage.currentTeam.ID).ToList();
        }

        private void AcceptBt_Click(object sender, RoutedEventArgs e)
        {
            UserTeam userTeam = new UserTeam();
            userTeam.IdTeam = selectedApplication.IdTeam;
            userTeam.IdUser = selectedApplication.IdUser;
            Connection.taskManager.UserTeam.Add(userTeam);
            Connection.taskManager.Application.Remove(selectedApplication);
            Connection.taskManager.SaveChanges();
            ListApplication.ItemsSource = Connection.taskManager.Application.Where(i => i.IdTeam == MyGroupsPage.currentTeam.ID).ToList();
        }

        private void RejectBt_Click(object sender, RoutedEventArgs e)
        {
            Connection.taskManager.Application.Remove(selectedApplication);
            Connection.taskManager.SaveChanges();
            ListApplication.ItemsSource = Connection.taskManager.Application.Where(i => i.IdTeam == MyGroupsPage.currentTeam.ID).ToList();
        }

        private void ListApplication_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedApplication = ListApplication.SelectedItem as Dbconnection.Application;
        }
    }
}