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
    /// Логика взаимодействия для MyDayPage.xaml
    /// </summary>
    public partial class MyDayPage : Page
    {
        public static List<Dbconnection.Task> Tasks { get; set; }
        public MyDayPage()
        {
            InitializeComponent();
            Tasks = Connection.taskManager.Task.ToList();
        }
    }
}