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
    /// Логика взаимодействия для AppointmentsPage.xaml
    /// </summary>
    public partial class AppointmentsPage : Page
    {
        public AppointmentsPage()
        {
            InitializeComponent();
            dgAppointments.ItemsSource = DBClass.medEntities.Прием_пациентов.ToList();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            dgAppointments.ItemsSource = DBClass.medEntities.Прием_пациентов.ToList();
        }

        private void OpenAppAdd(object sender, RoutedEventArgs e)
        {
            AppAddWindow addWindow = new AppAddWindow();
            addWindow.Show();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var pat = dgAppointments.SelectedItem as Прием_пациентов;
            DBClass.medEntities.Прием_пациентов.Remove(pat);
            DBClass.medEntities.SaveChanges();
            dgAppointments.ItemsSource = DBClass.medEntities.Прием_пациентов.ToList();
        }
    }
}
