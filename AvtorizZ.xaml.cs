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
using System.Windows.Shapes;
using System.Security;



namespace WpfApp1
{
    //SecureString secureString = new SecureString();
    /// <summary>
    /// Логика взаимодействия для AvtorizZ.xaml
    /// </summary>
    public partial class AvtorizZ : Window
    {
        public AvtorizZ()
        {
            InitializeComponent();
        }

        private void TextReg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

            string login = Loginbox.Text;
            var pass = Passwordbox.Password;

            

        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            var login = Loginbox.Text ;
            var email = Loginbox.Text.Trim();
            var pass = Passwordbox.Password;
            var context = new AppDbContext();
            var user = new User { Login = login,Email= email, Password = pass };
            MessageBox.Show("Вы успешно зашли в аккаунт");
        }

        private void EyeBtn_Click(object sender, RoutedEventArgs e)
        {

            Passwordbox.IsPasswordRevealed = !Passwordbox.IsPasswordRevealed;
        }
    }
}
