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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public static List<Otdel> otdels { get; set; }
        public ProfilePage()
        {
            InitializeComponent();
            otdels = Connection.taskManager.Otdel.ToList();
            this.DataContext = this;
        }
        public User user = new User();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationPage.user = user;
            user.Login = LoginTb.Text.Trim();
            user.Password = passwordTb.Password.Trim();
            Connection.taskManager.SaveChanges();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            user.Otdel = OtdelCb.SelectedItem as Otdel;
        }
    }
}
