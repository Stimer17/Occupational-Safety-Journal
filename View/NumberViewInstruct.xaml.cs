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
    /// Логика взаимодействия для NumberViewInstruct.xaml
    /// </summary>
    public partial class NumberViewInstruct : Window
    {
        gr691_fnvEntities db;
        public NumberViewInstruct()
        {
            InitializeComponent();
        }

         private void Window_Loaded(object sender, RoutedEventArgs e)
         {
            db = new gr691_fnvEntities();
            DGridViewInstruct.ItemsSource = db.ViewInstructs.ToList();
         }
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.ViewModelNumberViewInstruct viewModelNumberViewInstruct = new ViewModel.ViewModelNumberViewInstruct();
                viewModelNumberViewInstruct.AddViewInstruct(Convert.ToInt32(txtIdViewInstruct.Text), 
                    Convert.ToString(txtNameViewInstruct.Text));
                DGridViewInstruct.ItemsSource = db.ViewInstructs.ToList();
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
                int num = Convert.ToInt32(txtIdViewInstruct.Text);
                var DRow = db.ViewInstructs.Where(w => w.Номер_вида_инструктажа == num).FirstOrDefault();
                db.ViewInstructs.Remove(DRow);
                db.SaveChanges();
                DGridViewInstruct.ItemsSource = db.ViewInstructs.ToList();
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
                int num = Convert.ToInt32(txtIdViewInstruct.Text);
                var URow = db.ViewInstructs.Where(w => w.Номер_вида_инструктажа == num).FirstOrDefault();
                URow.Номер_вида_инструктажа = Convert.ToInt32(txtIdViewInstruct.Text);
                URow.Наименование = Convert.ToString(txtNameViewInstruct.Text);
                db.SaveChanges();
                DGridViewInstruct.ItemsSource = db.ViewInstructs.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}
