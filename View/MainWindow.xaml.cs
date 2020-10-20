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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Journal.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Instruct_Click(object sender, RoutedEventArgs e)
        {
            InstructXAML istructXAML = new InstructXAML();
            istructXAML.Show();
        }

        private void Instructed_Click(object sender, RoutedEventArgs e)
        {
            InstructedXAML instructedXAML = new InstructedXAML();
            instructedXAML.Show();

        }

        private void Instructor_Click(object sender, RoutedEventArgs e)
        {
            InstructorXAML instructorXAML = new InstructorXAML();
            instructorXAML.Show();
        }

        private void Date_Click(object sender, RoutedEventArgs e)
        {
            DateXAML dateXAML = new DateXAML();
            dateXAML.Show();
        }

        private void Vio_Click(object sender, RoutedEventArgs e)
        {
            ViolationXAML violationXAML = new ViolationXAML();
            violationXAML.Show();
        }

        private void NumbViewInstruct_Click(object sender, RoutedEventArgs e)
        {
            NumberViewInstruct numberViewInstruct = new NumberViewInstruct();
            numberViewInstruct.Show();
        }
    }
}
