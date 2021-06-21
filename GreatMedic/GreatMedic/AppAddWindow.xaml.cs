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
    /// Логика взаимодействия для AppAddWindow.xaml
    /// </summary>
    public partial class AppAddWindow : Window
    {
        public AppAddWindow()
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
            if (tbAppId.Text == string.Empty || tbDocId.Text == string.Empty || tbPatId.Text == string.Empty || tbPrice.Text == string.Empty)
            {
                btnAddApp.IsEnabled = false;
            }
            else
                btnAddApp.IsEnabled = true;
        }

        private void AddApp(object sender, RoutedEventArgs e)
        {
            try
            {
                var app = new Прием_пациентов
                {
                    Код_врача = int.Parse(tbDocId.Text),
                    Код_пациента = int.Parse(tbPatId.Text),
                    Код_приема = int.Parse(tbAppId.Text),
                    Дата_приема = DateTime.Now,
                    Стоимость_приема = decimal.Parse(tbPrice.Text)
                };
                DBClass.medEntities.Прием_пациентов.Add(app);
                DBClass.medEntities.SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
