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
using SCH_Project.Dbconnection;

namespace SCH_Project.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddTeamTaskPage.xaml
    /// </summary>
    public partial class AddTeamTaskPage : Page
    {
        public static List<UserTeam> userTeams {  get; set; }
        public static List<Dbconnection.Task> tasks { get; set; }
        public static Dbconnection.Task task = new Dbconnection.Task();
        public AddTeamTaskPage()
        {
            InitializeComponent();
            userTeams = Connection.taskManager.UserTeam.ToList();
            tasks = Connection.taskManager.Task.ToList();
            GroupCb.ItemsSource = userTeams.Where(i => i.IdUser == AuthorizationPage.user.ID && i.IdTeam != 1);
            task.Name = nameTb.Text.Trim();
            task.FinalDate = dateDp.SelectedDate;
            task.Description = DiscriptionTb.Text.Trim();
            
            DataContext = this;
        }

        private void GroupCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
