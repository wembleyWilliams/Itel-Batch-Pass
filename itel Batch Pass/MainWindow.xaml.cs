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

        private string getDate()
        {
            return DateTime.Now.ToString("mm/dd/yyyy");
        }

        private void Full_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Full.Text != "")
                name_label.Content = Full.Text;
             else
                name_label.Content = "Firstname Lastname";
            
        }

        private void position_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (position.Text != "")
                pos_label.Content = position.Text;
            else
                pos_label.Content = "Position";
        }



        private void type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (type.SelectedIndex > -1)
            {                
                switch(type.SelectedIndex)
                {
                    case 0:
                        type_label.Content = "Admin";
                        break;

                    case 1:
                        type_label.Content = "Support";
                        break;

                    case 2:
                        type_label.Content = "Agent";
                        break;
                }
            }
        }

        private void department_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (position.Text != "")
                department_label.Content = department.Text;
            else
                department_label.Content = "Department";
        }

        private void hrm_id_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (hrm_id.Text != "")
                hrm_label.Content = hrm_id.Text;
            else
                hrm_label.Content = "000000";
        }

        private void i_date_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (i_date.SelectedDate != null)
                date_label.Content = i_date.SelectedDate;
            else
                date_label.Content = getDate();

        }

        private void image_Click(object sender, RoutedEventArgs e)
        {

            //Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            //Launch dialog by calling ShowDialog method.
            Nullable<bool> result = openFileDlg.ShowDialog();
            //Get the filename and display in a textBox
            //Load content of file in a TextBlock
            if (result == true)
                file.Text = openFileDlg.FileName;
                //file.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
            

                
        }

       
        private void date_label_Initialized(object sender, EventArgs e)
        {
            date_label.Content = DateTime.Now.ToString("MM/dd/yyyy");
        }

        private void exdate_label_Initialized(object sender, EventArgs e)
        {
            DateTime theDate = DateTime.Now;
            DateTime exp = theDate.AddYears(2);
            exdate_label.Content = exp.ToString("MM/dd/yyyy");
        }
    }
}
