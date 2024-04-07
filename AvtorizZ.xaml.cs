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
            
            Crazy crazy = new Crazy();
            crazy.Show();
            this.Close();
        }

        private bool _suspendChangeHandlers = false;

        #region string Password dependency property
        public static DependencyProperty PasswordProperty = DependencyProperty.Register(
            "Password",
            typeof(string),
            typeof(WpfApp1.AvtorizZ),
            new FrameworkPropertyMetadata(
                (string)null,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                (obj, args) =>
                {
                    ((WpfApp1.AvtorizZ)obj).OnPasswordChanged(args);
                }));
        public string Password
        {
            get
            {
                return (string)GetValue(PasswordProperty);
            }
            set
            {
                SetValue(PasswordProperty, value);
            }
        }
        private void OnPasswordChanged(DependencyPropertyChangedEventArgs args)
        {
            if (_suspendChangeHandlers)
                return;
            _suspendChangeHandlers = true;
            this._visible.Text = args.NewValue as string;
            this.Passwordbox.Password = args.NewValue as string;
            _suspendChangeHandlers = false;
        }



        #endregion

        private void _isVisible_Click(object sender, RoutedEventArgs e)
        {
            if (_isVisible.IsChecked == true)
            {
                this.Passwordbox.Visibility = Visibility.Collapsed;
                this._visible.Visibility = Visibility.Visible;
            }
            else
            {
                this.Passwordbox.Visibility = Visibility.Visible;
                this._visible.Visibility = Visibility.Collapsed;
            }
        }

        private void _visible_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_suspendChangeHandlers)
                return;
            _suspendChangeHandlers = true;
            this.SetCurrentValue(PasswordProperty, _visible.Text);
            this.Passwordbox.Password = _visible.Text;
            _suspendChangeHandlers = false;
        }
    }
}
