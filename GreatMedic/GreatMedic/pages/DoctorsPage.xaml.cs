using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для DoctorsPage.xaml
    /// </summary>
    public partial class DoctorsPage : Page
    {
        public DoctorsPage()
        {
            InitializeComponent();
            dgDoctors.ItemsSource = DBClass.medEntities.Врачи.ToList();
        }

        private void OpenDocAdd(object sender, RoutedEventArgs e)
        {
            DoctorAddWindow addWindow = new DoctorAddWindow();
            addWindow.Show();
        }

        private void OpenDocEdit(object sender, RoutedEventArgs e)
        {
            var doctor = dgDoctors.SelectedItem as Врачи;
            DoctorEditWindow editWindow = new DoctorEditWindow(doctor);
            editWindow.Show();
            
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            dgDoctors.ItemsSource = DBClass.medEntities.Врачи.ToList();
        }
    }
}
