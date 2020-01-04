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
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;

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
            Full.MaxLength = 70;
            if (Regex.IsMatch(Full.Text, "^[a-zA-Z ]*$"))
            {
                name_label.Content = Full.Text;
            }
            else
            {
                MessageBox.Show("Invalid Input, only letters are acceptable!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Full.Text = "";
                name_label.Content = "Firstname Lastname";
            }

        }

        private void position_TextChanged(object sender, TextChangedEventArgs e)
        {
            position.MaxLength = 40;
            if (Regex.IsMatch(position.Text, "^[a-zA-Z ]*$"))
            {
                pos_label.Content = position.Text;
            }
            else
            {
                MessageBox.Show("Invalid Input, only letters are acceptable!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                position.Text = "";
                pos_label.Content = "Position";
            }
        }



        private void type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (type.SelectedIndex > -1)
            {                
                switch(type.SelectedIndex)
                {
                    case 0:
                        type_label.Content = "Admin";
                        ID.Source  = new BitmapImage(new Uri("Template_RAW_2.png", UriKind.Relative));
                       
                        break;

                    case 1:
                        type_label.Content = "Support";
                        ID.Source = new BitmapImage(new Uri("Template_RAW_3.png", UriKind.Relative));  
                       
                        break;

                    case 2:
                        type_label.Content = "Agent";                                             
                        ID.Source = new BitmapImage(new Uri("Template_RAW_1.png", UriKind.Relative));

                        break;
                }
            }
        }

        private void department_TextChanged(object sender, TextChangedEventArgs e)
        {
            department.MaxLength = 35;
            if (Regex.IsMatch(department.Text, "^[a-zA-Z ]*$"))
            {
                department_label.Content = department.Text;
            }
            else
            {
                MessageBox.Show("Invalid Input, only letters are acceptable!","Error", MessageBoxButton.OK, MessageBoxImage.Error);
                department.Text = "";
                department_label.Content = "Department";
            }
        }

        private void hrm_id_TextChanged(object sender, TextChangedEventArgs e)
        {
            hrm_id.MaxLength = 6;
            if (Regex.IsMatch(hrm_id.Text, "^[0-9]*$"))
            {
                hrm_label.Content = hrm_id.Text;
            }
            else
            {
                MessageBox.Show("Invalid Input, only digits are acceptable!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                hrm_id.Text = "";
                hrm_label.Content = "000000";
            }         
        }

        private void i_date_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (i_date.SelectedDate != null)
            {
                date_label.Content = i_date.SelectedDate.ToString();                
                DateTime exp = i_date.SelectedDate.Value;
                exp.AddYears(2);
                exdate_label.Content = exp.ToString("MM/dd/yyyy");
            }
            else
                date_label.Content = getDate();
        }

        private void image_Click(object sender, RoutedEventArgs e)
        {

            //Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            openFileDlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDlg.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            openFileDlg.RestoreDirectory = true;

            //Launch dialog by calling ShowDialog method.
            Nullable<bool> result = openFileDlg.ShowDialog();

            //Get the filename and display in a textBox
            //Load content of file in a TextBlock
            if (result == true)
            {
                file.Text = openFileDlg.FileName;
                user_image.Source = new BitmapImage(new Uri(file.Text, UriKind.RelativeOrAbsolute));
            }
            
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

        private void i_date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (i_date.SelectedDate != null)
            {
                DateTime i_d = i_date.SelectedDate.Value;
                date_label.Content = i_d.ToString("MM/dd/yyyy");

                DateTime exp = i_date.SelectedDate.Value;
                exdate_label.Content = exp.AddYears(2).ToString("MM/dd/yyyy");
            }
            else
            {
                date_label.Content = getDate();
            }
        }

        private void print_button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure ?","",MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch(result)
            {
                case MessageBoxResult.Yes:
                    SaveFileDialog s = new SaveFileDialog();
                    s.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    s.FileName = department.Text + " - " + Full.Text;
                    s.DefaultExt = ".png";
                    s.Filter = "Image Files (.png)|*.png";

                    

                    if ((Full.Text != ""))
                    {
                        s.ShowDialog();

                        //Creats image from the preview grid and creates a Bitmap
                        RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(630, 990, 140, 140, PixelFormats.Pbgra32);
                        renderTargetBitmap.Render(ID_card);

                        String filename = s.FileName;
                        PngBitmapEncoder pngImage = new PngBitmapEncoder();                        
                        pngImage.Frames.Add(BitmapFrame.Create(renderTargetBitmap));                                    

                        using (FileStream fileStream = File.Create(filename))
                        {
                            pngImage.Save(fileStream);
                        }
                        
                        MessageBox.Show("ID Saved as " + filename, "Saved", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    } else
                    {
                        MessageBox.Show("Please enter the employee's name","Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                   
                    break;

                case MessageBoxResult.No:
                    MessageBox.Show("Print Canceled !!","", MessageBoxButton.OK, MessageBoxImage.Information);
                    guiReset();

                    break;
            }
            
        }

        private void guiReset()
        {
            Full.Text = "";
            hrm_id.Text = "";
            department.Text = "";
            i_date.Text = "";
            file.Text = "";
            position.Text = "";
            user_image = null;
        }

    }
}
