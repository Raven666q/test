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
using GreatMedic.classes;
using GreatMedic.pages;

namespace GreatMedic
{
    /// <summary>
    /// Логика взаимодействия для MedicWindow.xaml
    /// </summary>
    public partial class MedicWindow : Window
    {
        User user = new User();
        public MedicWindow(User u)
        {
            InitializeComponent();
            user = u;
            Login.Text = user.Login;
            if (user.Root == 0)
            {
                Role.Text = "Poor";
                Role.Foreground = Brushes.LightBlue;
            }
            else
            {
                Role.Text = "Admin";
                Role.Foreground = Brushes.Purple;
            }
            if (user.Root == 1)
                btnRegister.Visibility = Visibility.Visible;
        }

        private void ToDoctors(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new DoctorsPage());
        }

        private void ToPatients(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PatientsPage());
        }

        private void ToAppointments(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AppointmentsPage());
        }

        private void ChangeThemeTF(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            MedCenter.Background = (Brush)bc.ConvertFrom("#5885A2");
            btnOpenDoctors.Background = (Brush)bc.ConvertFrom("#256D8D");
            btnOpenPatients.Background = (Brush)bc.ConvertFrom("#256D8D");
            btnOpenAppointments.Background = (Brush)bc.ConvertFrom("#256D8D");
            btnReport.Background = (Brush)bc.ConvertFrom("#256D8D");
            btnRegister.Background = (Brush)bc.ConvertFrom("#256D8D");
        }

        private void ChangeThemeBiscuit(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            MedCenter.Background = (Brush)bc.ConvertFrom("#C5AF91");
            btnOpenDoctors.Background = (Brush)bc.ConvertFrom("#A57545");
            btnOpenPatients.Background = (Brush)bc.ConvertFrom("#A57545");
            btnOpenAppointments.Background = (Brush)bc.ConvertFrom("#A57545");
            btnReport.Background = (Brush)bc.ConvertFrom("#A57545");
            btnRegister.Background = (Brush)bc.ConvertFrom("#A57545");
        }

        private void ChangeThemeDark(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            MedCenter.Background = (Brush)bc.ConvertFrom("#384248");
            btnOpenDoctors.Background = (Brush)bc.ConvertFrom("#7E7E7E");
            btnOpenPatients.Background = (Brush)bc.ConvertFrom("#7E7E7E");
            btnOpenAppointments.Background = (Brush)bc.ConvertFrom("#7E7E7E");
            btnReport.Background = (Brush)bc.ConvertFrom("#7E7E7E");
            btnRegister.Background = (Brush)bc.ConvertFrom("#7E7E7E");
        }

        private void ToReg(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RegWindow(btnRegister.Background));
        }
    }
}
