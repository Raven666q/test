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
using GreatMedic.classes;

namespace GreatMedic
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Sign(object sender, RoutedEventArgs e)
        {
            var clients = DBClass.medEntities.Clients.ToList();
            foreach (var client in clients)
            {
                if (client.Login == LoginCheck.Text && client.Password == PasswordCheck.Password)
                {
                    var user = new User()
                    {
                        Login = client.Login,
                        Passwod = client.Password,
                        Email = client.Email,
                        Root = client.Root
                    };
                    MedicWindow medicWindow = new MedicWindow(user);
                    medicWindow.Show();
                    SignWidnow.Close();
                }
                else
                    IncorretPass.Visibility = Visibility;
            }
        }
    }
}
