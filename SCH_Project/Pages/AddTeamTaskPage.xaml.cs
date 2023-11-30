using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public static List<UserTeam> userTeams {  get; set; }
        public static UserTeam selectedUserTeam = new UserTeam();
        public static List<User> users { get; set; }
        public static Dbconnection.Task task = new Dbconnection.Task();
        public AddTeamTaskPage()
        {
            InitializeComponent();
            users = Connection.taskManager.User.ToList();
            userTeams = Connection.taskManager.UserTeam.ToList();
            UserCb.ItemsSource = users;
            DataContext = this;
            
        }


        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            task.Name = nameTb.Text.Trim();
            task.FinalDate = dateDp.SelectedDate;
            task.Description = DiscriptionTb.Text.Trim();
            Connection.taskManager.Task.Add(task);
            Connection.taskManager.SaveChanges();
        }

        private void UserCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedUserTeam = userTeams.First(i => i.User == (UserCb.SelectedItem as User));
        }
    }
}
