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
    /// Логика взаимодействия для ViolationXAML.xaml
    /// </summary>
    public partial class ViolationXAML : Window
    {
        
        gr691_fnvEntities db;
        public ViolationXAML()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new gr691_fnvEntities();
            DGridVIO.ItemsSource = db.Violations.ToList();
        }

        private void Button_Insert(object sender, RoutedEventArgs e)
        {
            ViewModel.ViewModelViolation viewModelViolation = new ViewModel.ViewModelViolation();
            try
            {
                viewModelViolation.AddViolation(Convert.ToInt32(txtIdVio.Text), Convert.ToString(txtNameVio.Text));
                DGridVIO.ItemsSource = db.Violations.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(txtIdVio.Text);
                var DRow = db.Violations.Where(w => w.Номер_нарушения == num).FirstOrDefault();
                db.Violations.Remove(DRow);
                db.SaveChanges();
                DGridVIO.ItemsSource = db.Violations.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button_Update(object sender, RoutedEventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(txtIdVio.Text);
                var URow = db.Violations.Where(w => w.Номер_нарушения == num).FirstOrDefault();
                URow.Номер_нарушения = Convert.ToInt32(txtIdVio.Text);
                URow.Название = Convert.ToString(txtNameVio.Text);
                db.SaveChanges();
                DGridVIO.ItemsSource = db.Violations.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
