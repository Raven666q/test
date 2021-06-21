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
    /// Логика взаимодействия для DoctorEditWindow.xaml
    /// </summary>
    public partial class DoctorEditWindow : Window
    {
        Врачи doc = new Врачи();
        public DoctorEditWindow(Врачи doctor)
        {
            InitializeComponent();
            doc = doctor;
            tbId.Text = Convert.ToString(doctor.Код_врача);
            tbLastname.Text = doctor.Фамилия_врача;
            tbName.Text = doctor.Имя_врача;
            tbPatronymic.Text = doctor.Отчество_врача;
            tbSpecialty.Text = doctor.Специальность_врача;
            tbPrecent.Text = Convert.ToString(doctor.Процент);
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
                btnEditDoctor.IsEnabled = false;
            }
            else
                btnEditDoctor.IsEnabled = true;
        }

        private void EditDoctor(object sender, RoutedEventArgs e)
        {
            try
            {
                doc.Код_врача = int.Parse(tbId.Text);
                doc.Фамилия_врача = tbLastname.Text;
                doc.Имя_врача = tbName.Text;
                doc.Отчество_врача = tbPatronymic.Text;
                doc.Специальность_врача = tbSpecialty.Text;
                doc.Процент = int.Parse(tbPrecent.Text);
                DBClass.medEntities.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Шо ты натворил?");
            }
        }
    }
}
