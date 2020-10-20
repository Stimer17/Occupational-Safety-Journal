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
    /// Логика взаимодействия для InstructorXAML.xaml
    /// </summary>
    public partial class InstructorXAML : Window
    {
        gr691_fnvEntities db;
        public InstructorXAML()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new gr691_fnvEntities();
            DGridInstructor.ItemsSource = db.Instructors.ToList();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.ViewModelInstructor viewModelInstructor = new ViewModel.ViewModelInstructor();
                viewModelInstructor.AddInstructor(Convert.ToInt32(txtIdInstructor.Text), Convert.ToString(txtNameInstructor.Text));
                DGridInstructor.ItemsSource = db.Instructors.ToList();
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
                int num = Convert.ToInt32(txtIdInstructor.Text);
                var DRow = db.Instructors.Where(w => w.Номер_инструктора == num).FirstOrDefault();
                db.Instructors.Remove(DRow);
                db.SaveChanges();
                DGridInstructor.ItemsSource = db.Instructors.ToList();
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
                int num = Convert.ToInt32(txtIdInstructor.Text);
                var URow = db.Instructors.Where(w => w.Номер_инструктора == num).FirstOrDefault();
                URow.Номер_инструктора = Convert.ToInt32(txtIdInstructor.Text);
                URow.ФИО_инструктора = Convert.ToString(txtNameInstructor.Text);
                db.SaveChanges();
                DGridInstructor.ItemsSource = db.Instructors.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
