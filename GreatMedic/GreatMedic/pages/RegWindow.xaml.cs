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

namespace GreatMedic.pages
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Page
    {
        public RegWindow(Brush brush)
        {
            InitializeComponent();
            dgClients.ItemsSource = DBClass.medEntities.Clients.ToList();
            btnReg.Background = brush;
        }

        private void RegClient(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text != string.Empty || pbPassword.Password != string.Empty)
            {
                try
                {
                    var client = new Clients
                    {
                        Login = tbLogin.Text,
                        Password = pbPassword.Password,
                        Email = tbEmail.Text,
                        Root = 0
                    };
                    DBClass.medEntities.Clients.Add(client);
                    DBClass.medEntities.SaveChanges();
                    MessageBox.Show("Пользователь успешно зарегестрирован");
                    tbEmail.Text = string.Empty;
                    tbLogin.Text = string.Empty;
                    pbPassword.Password = string.Empty;
                    dgClients.ItemsSource = DBClass.medEntities.Clients.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }
            else
                MessageBox.Show("Не все поля заполнены");
        }
    }
}
