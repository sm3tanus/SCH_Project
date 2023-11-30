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
    /// Логика взаимодействия для MyGroupsUsersPage.xaml
    /// </summary>
    public partial class MyGroupsUsersPage : Page
    {
        public static List<Team> Teams { get; set; }
        public MyGroupsUsersPage()
        {
            InitializeComponent();
            Teams = Connection.taskManager.Team.Where(i=>i.IdLeader==AuthorizationPage.user.ID && i.ID!=1).ToList();
            DataContext = this;
        }



    }
}
