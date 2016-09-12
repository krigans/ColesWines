using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Microsoft.Samples.Kinect.ControlsBasics
{
    /// <summary>
    /// Interaction logic for Temp.xaml
    /// </summary>
    public partial class Temp : Window
    {
        public Temp()
        {
            InitializeComponent();
        }

        private void myGif1_MediaEnded(object sender, RoutedEventArgs e)
        {
            myGif_1.Position = new TimeSpan(0, 0, 1);
            myGif_1.Play();
        }

        private void myGif2_MediaEnded(object sender, RoutedEventArgs e)
        {
            myGif_2.Position = new TimeSpan(0, 0, 1);
            myGif_2.Play();

        }

        private void myGif3_MediaEnded(object sender, RoutedEventArgs e)
        {
            myGif_3.Position = new TimeSpan(0, 0, 1);
            myGif_3.Play();

        }

        private void myGif4_MediaEnded(object sender, RoutedEventArgs e)
        {
            myGif_4.Position = new TimeSpan(0, 0, 1);
            myGif_4.Play();

        }

        public void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
