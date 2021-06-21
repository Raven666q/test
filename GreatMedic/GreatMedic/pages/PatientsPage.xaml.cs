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
    /// Логика взаимодействия для PatientsPage.xaml
    /// </summary>
    public partial class PatientsPage : Page
    {
        public PatientsPage()
        {
            InitializeComponent();
            dgPatients.ItemsSource = DBClass.medEntities.Пациенты.ToList();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            dgPatients.ItemsSource = DBClass.medEntities.Пациенты.ToList();
        }

        private void OpenPatAdd(object sender, RoutedEventArgs e)
        {
            PatAddWindow addWindow = new PatAddWindow();
            addWindow.Show();
        }

        private void Edit_click(object sender, RoutedEventArgs e)
        {
            var pat = dgPatients.SelectedItem as Пациенты;
            PatEdit editWindow = new PatEdit(pat);
            editWindow.Show();
        }
    }
}
