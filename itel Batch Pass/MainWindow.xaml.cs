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

namespace itel_Batch_Pass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Full_TextChanged(object sender, TextChangedEventArgs e)
        {
            name_label.Content = Full.Text;
        }

        private void position_TextChanged(object sender, TextChangedEventArgs e)
        {
             pos_label.Content = position.Text;
        }



        private void type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void department_TextChanged(object sender, TextChangedEventArgs e)
        {
            department_label.Content = department.Text;
        }

        private void hrm_id_TextChanged(object sender, TextChangedEventArgs e)
        {
            hrm_label.Content = hrm_id.Text;
        }
    }
}
