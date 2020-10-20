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

namespace Journal.View
{
    /// <summary>
    /// Логика взаимодействия для DateXAML.xaml
    /// </summary>
    public partial class DateXAML : Window
    {
        gr691_fnvEntities db;

        ViewModel.ViewModelDateOfPassege model = new ViewModel.ViewModelDateOfPassege();
        public DateXAML()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new gr691_fnvEntities();
            DGridDate.ItemsSource = db.Passages.ToList();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            model.AddDateOfPassege(Convert.ToInt32(txtIdDate.Text), Convert.ToDateTime(txtPassegeDate.Text), Convert.ToDateTime(txtRepeatPassegeDate.Text));
            DGridDate.ItemsSource = db.Passages.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(txtIdDate.Text);
                var DRow = db.Passages.Where(w => w.Номер_прохождения == num).FirstOrDefault();
                db.Passages.Remove(DRow);
                db.SaveChanges();
                DGridDate.ItemsSource = db.Passages.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(txtIdDate.Text);
                var URow = db.Passages.Where(w => w.Номер_прохождения == num).FirstOrDefault();
                URow.Номер_прохождения = Convert.ToInt32(txtIdDate.Text);
                URow.Дата_прохождения = Convert.ToDateTime(txtPassegeDate.Text);
                URow.Дата_повторного_прохождения = Convert.ToDateTime(txtRepeatPassegeDate.Text);
                db.SaveChanges();
                DGridDate.ItemsSource = db.Passages.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
