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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Crazy.xaml
    /// </summary>
    public partial class Crazy : Window
    {
        public Crazy()
        {
            InitializeComponent();
            AppDbContext context = new AppDbContext();
            List<User> users = context.Users.ToList();

            Loginlist.ItemsSource = users;
        }

        
    }
}
