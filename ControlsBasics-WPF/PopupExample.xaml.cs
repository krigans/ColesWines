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
    /// Interaction logic for PopupExample.xaml
    /// </summary>
    /// 
  
    public partial class PopupExample : Window
    {
        //Temp Help = new Temp();
        
        public PopupExample()
        {
            InitializeComponent();
        }

        
        private void PopUpButton_MouseEnter(object sender, MouseEventArgs e)
        {
           
           // Help.Show();

        }

        private void PopUpButton_MouseLeave(object sender, MouseEventArgs e)
        {
           // Help.Hide();
           
        }

       
    }
}
