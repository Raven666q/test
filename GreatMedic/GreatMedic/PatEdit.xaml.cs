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
    /// Логика взаимодействия для PatEdit.xaml
    /// </summary>
    public partial class PatEdit : Window
    {
        Пациенты pat = new Пациенты();
        public PatEdit(Пациенты p)
        {
            InitializeComponent();
            pat = p;
            tbId.Text = Convert.ToString(pat.Код_пациента);
            tbLastname.Text = pat.Фамилия_пациента;
            tbName.Text = pat.Имя_пациента;
            tbPatronymic.Text = pat.Отчество_пациента;
            tbBirthday.Text = Convert.ToString(pat.Дата_рождения_пациента);
            tbAddress.Text = pat.Адрес;
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
                btnEditPat.IsEnabled = false;
            }
            else
                btnEditPat.IsEnabled = true;
        }
        private void EditPat(object sender, RoutedEventArgs e)
        {
            try
            {
                pat.Код_пациента = int.Parse(tbId.Text);
                pat.Фамилия_пациента = tbLastname.Text;
                pat.Имя_пациента = tbName.Text;
                pat.Отчество_пациента = tbPatronymic.Text;
                pat.Дата_рождения_пациента = Convert.ToDateTime(tbBirthday.Text);
                pat.Адрес = tbAddress.Text;
                DBClass.medEntities.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Шо ты натворил?");
            }
        }
    }
}
