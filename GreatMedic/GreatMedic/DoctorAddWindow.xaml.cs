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

namespace GreatMedic
{
    /// <summary>
    /// Логика взаимодействия для DoctorAddWindow.xaml
    /// </summary>
    public partial class DoctorAddWindow : Window
    {
        public DoctorAddWindow()
        {
            InitializeComponent();
        }

        private void AddDoctor(object sender, RoutedEventArgs e)
        {
            try
            {
                var doctor = new Врачи
                {
                    Код_врача = int.Parse(tbId.Text),
                    Фамилия_врача = tbLastname.Text,
                    Имя_врача = tbName.Text,
                    Отчество_врача = tbPatronymic.Text,
                    Специальность_врача = tbSpecialty.Text,
                    Процент = int.Parse(tbPrecent.Text)
                };
                DBClass.medEntities.Врачи.Add(doctor);
                DBClass.medEntities.SaveChanges();
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Шо ты натворил?");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            if (tbId.Text == string.Empty || tbLastname.Text == string.Empty || tbName.Text == string.Empty || tbPatronymic.Text == string.Empty || tbSpecialty.Text == string.Empty || tbPrecent.Text == string.Empty)
            {
                btnAddDoctor.IsEnabled = false;
            }
            else
                btnAddDoctor.IsEnabled = true;
        }
    }
}
