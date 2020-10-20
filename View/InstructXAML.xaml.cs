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
    /// Логика взаимодействия для InstructXAML.xaml
    /// </summary>
    public partial class InstructXAML : Window
    {
       
        gr691_fnvEntities db;
        public InstructXAML()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new gr691_fnvEntities();
            DGridInstruct.ItemsSource = db.OSJs.ToList();
        }

        public void Insert_Click212(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.ViewModelInstruct viewModelInstruct = new ViewModel.ViewModelInstruct();
                viewModelInstruct.AddInstruct(Convert.ToInt32(txtIdInstruct.Text), Convert.ToString(txtNameInstruct.Text),
                    Convert.ToInt32(txtIdInstructed.Text), Convert.ToInt32(txtIdInstructor.Text), Convert.ToInt32(txtIdPassage.Text),
                    Convert.ToInt32(txtIdViolation.Text), Convert.ToInt32(txtIdViewInstruct.Text));
                db.SaveChanges();
                DGridInstruct.ItemsSource = db.OSJs.ToList();
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
                int num = Convert.ToInt32(txtIdInstruct.Text);
                var DRow = db.OSJs.Where(w => w.Номер_инструктажа == num).FirstOrDefault();
                db.OSJs.Remove(DRow);
                db.SaveChanges();
                DGridInstruct.ItemsSource = db.OSJs.ToList();
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
                int num = Convert.ToInt32(txtIdInstruct.Text);
                var URow = db.OSJs.Where(w => w.Номер_инструктажа == num).FirstOrDefault();
                URow.Номер_инструктажа = Convert.ToInt32(txtIdInstruct.Text);
                URow.Название_инструктажа = Convert.ToString(txtNameInstruct.Text);
                URow.Номер_инструктурируемого = Convert.ToInt32(txtIdInstructed.Text);
                URow.Номер_инструктора = Convert.ToInt32(txtIdInstructor.Text);
                URow.Номер_прохождения = Convert.ToInt32(txtIdPassage.Text);
                URow.Номер_нарушения = Convert.ToInt32(txtIdViolation.Text);
                URow.Номер_вида_инструктажа = Convert.ToInt32(txtIdViewInstruct.Text);
                db.SaveChanges();
                DGridInstruct.ItemsSource = db.OSJs.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
