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
        public static User user;
        public static List<User> users { get; set; }
        public AuthorizationPage()
        {
            InitializeComponent();
        }
        public User newUser = new User();
        private void EnterBt_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            {
                try
                {
                    string login = loginTb.Text.Trim().ToLower();
                    string password = PasswordTb.Password.Trim().ToLower();
                    user = Connection.taskManager.User.FirstOrDefault(i => i.Login == login && i.Password == password);
                    if (user != null)
                    {
                        
                        NavigationService.Navigate(new MainMenuPage());
                    }
                    else
                    {
                        MessageBoxTb.Text = "error";
                    }
                }
                catch
                {
                    MessageBoxTb.Text = "error";
                }
            }
        }

        private void Regbt_Click(object sender, RoutedEventArgs e)
        {
            try
            {   if (LoginReg.Text.Length != 0 && PasswordReg.Password.Length !=0)
                {
                    if (PasswordReg.Password.Trim() == PasswordConfirmReg.Password.Trim())
                    {
                        newUser.Login = LoginReg.Text.Trim().ToLower();
                        newUser.Password = PasswordReg.Password.Trim().ToLower();
                        Connection.taskManager.User.Add(newUser);
                        Connection.taskManager.SaveChanges();
                        MessageBoxTb.Foreground = System.Windows.Media.Brushes.White;
                        MessageBoxTb.Text = "welcome";
                    }
                    else
                    {
                        LoginReg.Text = " ";
                        PasswordReg.Password = " ";
                        MessageBoxRegTb.Text = "incorrect password";
                    }
                }
                else
                {
                    MessageBoxTb.Text = "error";
                }
            }
            catch
            {
                MessageBoxRegTb.Text = "incorrect password";
            }
        }
    }
}
