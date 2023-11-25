using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SCH_Project.Dbconnection;

namespace SCH_Project.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static List<User> users { get; set; }
        public AuthorizationPage()
        {
            InitializeComponent();
        }
        public User newUser = new User();
        private void EnterBt_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            {
                NavigationService.Navigate(new MainMenuPage());
                //try
                //{
                //    string login = loginTb.Text.Trim();
                //    string password = PasswordTb.Password.Trim();
                //    var user = Connection.taskManager.User.Where(i => i.Login == login && i.Password == password).ToList();
                //    if (user != null)
                //    {
                //        MessageBox.Show("Welcome");
                //        NavigationService.Navigate(new MainMenuPage());
                //    }
                //}
                //catch
                //{
                //    MessageBox.Show("Error");
                //}
            }
        }

        private void Regbt_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (PasswordReg.Password.Trim() == PasswordConfirmReg.Password.Trim())
                {
                    newUser.Login = LoginReg.Text.Trim();
                    newUser.Password = PasswordReg.Password.Trim();
                    Connection.taskManager.User.Add(newUser);
                    Connection.taskManager.SaveChanges();
                    MessageBox.Show("Welcome");
                    NavigationService.Navigate(new MainMenuPage());
                }
                else
                {
                    LoginReg.Text = " ";
                    PasswordReg.Password = " ";
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

    }
}
