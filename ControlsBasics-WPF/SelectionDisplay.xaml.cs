namespace Microsoft.Samples.Kinect.ControlsBasics
{
    using System;
    using System.Globalization;
    using System.Windows.Controls;
    using System.Windows;
    using System.Windows.Data;
    using Microsoft.Kinect;
    using Microsoft.Kinect.Toolkit;
    using Microsoft.Kinect.Toolkit.Controls;
    using System.Windows.Media.Imaging;
    using System.Windows.Media;
    using System.Windows.Shapes;
    

    /// <summary>
    /// Interaction logic
    /// </summary>
    public partial class SelectionDisplay : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectionDisplay"/> class. 
        /// </summary>
        /// <param name="itemId">ID of the item that was selected</param>
        //public SelectionDisplay(string itemId)
        public SelectionDisplay()
        {
            this.InitializeComponent();

           //this.messageTextBlock.Text = string.Format(CultureInfo.CurrentCulture, Properties.Resources.SelectedMessage, itemId);
        }

        /// <summary>
        /// Called when the OnLoaded storyboard completes.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
       private void OnLoadedStoryboardCompleted(object sender, System.EventArgs e)
        {
            //var parent = (Panel)this.Parent;
            //parent.Children.Remove(this);
        }
    }
}
