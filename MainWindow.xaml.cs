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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AvtorizZ avtoriz = new AvtorizZ();
            avtoriz.Show();
            this.Close();
           
          
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {

            string login = Loginbox.Text.Trim();
            var pass = Passwordbox.Password.Trim();
            var email = Emailbox.Text.Trim().ToLower();
            var pass_2= RepeatPasswordbox.Password.Trim();
            var context = new AppDbContext();



            //var user_exists = context.Users.FirstOrDefault(x => x.Login == login);
            // if (user_exists is not null)
            // {
            //    MessageBox.Show("Такой пользовтель уже был");
            //   return;
            // }
            if (login.Length < 5)
            {
                Loginbox.ToolTip = "Это поле введено не корректно";
                Loginbox.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                Passwordbox.ToolTip = "Это поле введено не корректно";
                Passwordbox.Background = Brushes.DarkRed;
            }
            else if (pass != pass_2)
            {
                RepeatPasswordbox.ToolTip = "Это поле введено не корректно";
                Passwordbox.Background = Brushes.DarkRed;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                Emailbox.ToolTip = "Это поле введено не корректно";
                Emailbox.Background = Brushes.DarkRed;
            }
            else
            {
                Loginbox.Background = Brushes.White;
                Passwordbox.Background = Brushes.White;
                RepeatPasswordbox.Background = Brushes.White;
                Emailbox.Background = Brushes.White;


                var user = new User { Login=login, Email=email, Password= pass };
                context.Users.Add(user);
                context.SaveChanges();
                MessageBox.Show("Welcome");
                AvtorizZ avtorizZ = new AvtorizZ();
                avtorizZ.Show();
                this.Close();
            }
        }
    }
}
