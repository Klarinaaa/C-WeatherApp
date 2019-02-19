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
using System.Net;
using System.IO;

namespace WpfApp3
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

        private string bCheckDefault = "Get Weather";
        private string bCheckReset = "Reset";

        private string tHelpDefault = "Type Your Town / City";

        private void bCheckClick(object sender, RoutedEventArgs e)
        { 
           

            if (inputField.Text != "" && bCheck.Content.ToString() == bCheckDefault)
            {
                
                bCheck.Content = bCheckReset;
                inputField.Visibility = System.Windows.Visibility.Hidden;
                titleDegree.Visibility = System.Windows.Visibility.Visible;
                titledesc.Visibility = System.Windows.Visibility.Visible;
                TitleHumid.Visibility = System.Windows.Visibility.Visible;
                titleHelp.Content = inputField.Text;
                string[] values = FindWeather.getWeather(inputField.Text);

                titleDegreeData.Content = values[0];
                TitleHumidData.Content = values[1];
                titledescData.Content = values[2];

                titleDegreeData.Visibility = System.Windows.Visibility.Visible;
                titledescData.Visibility = System.Windows.Visibility.Visible;
                TitleHumidData.Visibility = System.Windows.Visibility.Visible;


            }
            else if (bCheck.Content.ToString() == bCheckReset)
            {
                bCheck.Content = bCheckDefault;
                inputField.Text = "";
                titleHelp.Content = tHelpDefault;
                inputField.Visibility = System.Windows.Visibility.Visible;
                titleDegree.Visibility = System.Windows.Visibility.Hidden;
                titledesc.Visibility = System.Windows.Visibility.Hidden;
                TitleHumid.Visibility = System.Windows.Visibility.Hidden;

                titleDegreeData.Visibility = System.Windows.Visibility.Hidden;
                titledescData.Visibility = System.Windows.Visibility.Hidden;
                TitleHumidData.Visibility = System.Windows.Visibility.Hidden;

                titleDegreeData.Content = "";
                titledescData.Content = "";
                TitleHumidData.Content = "";


            }
        }
    }
}
