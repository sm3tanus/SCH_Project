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
            LoginTb.Text = AuthorizationPage.user.Login;
            DataContext = this;
        }
        public User user = new User();
        private void AcceptBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LoginTb.Text.Length != 0 && passwordTb.Password.Length != 0)
                {
                    AuthorizationPage.user.Login = LoginTb.Text.Trim().ToLower();
                    AuthorizationPage.user.Password = passwordTb.Password.Trim().ToLower();
                    Connection.taskManager.SaveChanges();
                    MessageTb.Foreground = System.Windows.Media.Brushes.White;
                    MessageTb.Text = "сhanges saved";
                }
                else
                {
                    MessageTb.Text = "fill in the details";
                }
            }
            catch
            {
                throw;
            }
        }

        private void OtdelCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AuthorizationPage.user.Otdel = OtdelCb.SelectedItem as Otdel;
        }
    }
}