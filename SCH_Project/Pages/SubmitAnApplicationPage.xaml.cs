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
    /// Логика взаимодействия для SubmitAnApplicationPage.xaml
    /// </summary>
    public partial class SubmitAnApplicationPage : Page
    {
        public static List<UserTeam> userTeams = Connection.taskManager.UserTeam.ToList();
        public SubmitAnApplicationPage()
        {
            InitializeComponent();
            List<Team> team = new List<Team>();
            //сделать фор
            ListApplication.ItemsSource = userTeams.Where(i => i.IdUser != AuthorizationPage.user.ID && i.IdTeam != 1).ToList();
            DataContext = this;
        }
    }
}
