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
    /// Логика взаимодействия для InstructedXAML.xaml
    /// </summary>
    public partial class InstructedXAML : Window
    {
        gr691_fnvEntities db;
        public InstructedXAML()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new gr691_fnvEntities();
            DGridInstructed.ItemsSource = db.Instructeds.ToList();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.ViewModelInstructed model = new ViewModel.ViewModelInstructed();
                model.AddInstructed(Convert.ToInt32(txtIdInstructed.Text), Convert.ToString(txtNameInstructed.Text));
                DGridInstructed.ItemsSource = db.Instructeds.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(txtIdInstructed.Text);
                var DRow = db.Instructeds.Where(w => w.Номер_инструктурируемого == num).FirstOrDefault();
                db.Instructeds.Remove(DRow);
                db.SaveChanges();
                DGridInstructed.ItemsSource = db.Instructeds.ToList();
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
                int num = Convert.ToInt32(txtIdInstructed.Text);
                var URow = db.Instructeds.Where(w => w.Номер_инструктурируемого == num).FirstOrDefault();
                URow.Номер_инструктурируемого = Convert.ToInt32(txtIdInstructed.Text);
                URow.ФИО_инструктурируемого = Convert.ToString(txtNameInstructed.Text);
                db.SaveChanges();
                DGridInstructed.ItemsSource = db.Instructeds.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
