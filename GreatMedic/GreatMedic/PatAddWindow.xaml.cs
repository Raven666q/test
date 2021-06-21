using GreatMedic.classes;
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

namespace GreatMedic
{
    /// <summary>
    /// Логика взаимодействия для PatAddWindow.xaml
    /// </summary>
    public partial class PatAddWindow : Window
    {
        public PatAddWindow()
        {
            InitializeComponent();
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
            if (tbId.Text == string.Empty || tbLastname.Text == string.Empty || tbName.Text == string.Empty || tbPatronymic.Text == string.Empty || tbBirthday.Text == string.Empty || tbAddress.Text == string.Empty)
            {
                btnAddPat.IsEnabled = false;
            }
            else
                btnAddPat.IsEnabled = true;
        }

        private void AddPat(object sender, RoutedEventArgs e)
        {
            try
            {
                var pat = new Пациенты
                {
                    Фамилия_пациента = tbName.Text,
                    Имя_пациента = tbLastname.Text,
                    Отчество_пациента = tbPatronymic.Text,
                    Адрес = tbAddress.Text,
                    Код_пациента = int.Parse(tbId.Text),
                    Дата_рождения_пациента = Convert.ToDateTime(tbBirthday.Text)
                };
                DBClass.medEntities.Пациенты.Add(pat);
                DBClass.medEntities.SaveChanges();
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Шо ты натворил?");
            }
        }
    }
}
