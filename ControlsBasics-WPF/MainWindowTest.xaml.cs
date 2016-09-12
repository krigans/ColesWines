namespace Microsoft.Samples.Kinect.ControlsBasics
{
    using System;
    using System.Linq;   
    using System.Windows;
    using System.Windows.Data;
    using Microsoft.Kinect;
    using System.Globalization;
    using Microsoft.Kinect.Toolkit;
    using Microsoft.Kinect.Toolkit.Controls;
    using System.Windows.Media.Imaging;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using System.Collections.Generic;
    using System.Windows.Threading;
    using System.Windows.Input;
    using System.Windows.Media.Animation;
    using System.IO;
    
    
    //using System.Drawing;
    
    
    
    /// <summary>
    /// Interaction logic for MainWindow
    /// </summary>
    public partial class MainWindowTest 
    {
      

        public static readonly DependencyProperty PageLeftEnabledProperty = DependencyProperty.Register(
            "PageLeftEnabled", typeof(bool), typeof(MainWindowTest), new PropertyMetadata(false));

        public static readonly DependencyProperty PageRightEnabledProperty = DependencyProperty.Register(
            "PageRightEnabled", typeof(bool), typeof(MainWindowTest), new PropertyMetadata(false));

       // public static readonly RoutedEvent HandPointerEnterEvent = EventManager.RegisterRoutedEvent(
       //"HandPointerEnter", RoutingStrategy.Direct, typeof(EventHandler<HandPointerEventArgs>), typeof(MainWindowTest));

       // public static readonly RoutedEvent HandPointerLeaveEvent = EventManager.RegisterRoutedEvent(
       //     "HandPointerLeave", RoutingStrategy.Direct, typeof(EventHandler<HandPointerEventArgs>), typeof(MainWindowTest));

        private const double ScrollErrorMargin = 0.001;

        private const int PixelScrollByAmount = 10;

        private readonly KinectSensorChooser sensorChooser;

       // private readonly DispatcherTimer _activityTimer;
       // private Point _inactiveMousePosition = new Point(0, 0);

       // Temp Help = new Temp();

        //New Constants/Variable Declaration Starts
        private const int _elevationAngle = 0;
        private KinectSensor sensor; 
        //Change the array length portion to the number of shorts your have for each
        private String[] _wineArray = new String[8];


        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class. 
        /// </summary>
        public MainWindowTest()
        {
            
                InitializeComponent();
            
          
                // initialize the sensor chooser and UI
                this.sensorChooser = new KinectSensorChooser();
                this.sensorChooser.KinectChanged += SensorChooserOnKinectChanged;
                this.sensorChooserUi.KinectSensorChooser = this.sensorChooser;
                this.sensorChooser.Start();

               // KinectRegion.AddHandPointerEnterHandler(this.infoHelpButton, this.OnHandPointerEnter);
               // KinectRegion.AddHandPointerLeaveHandler(this.infoHelpButton, this.OnHandPointerLeave);

                // Bind the sensor chooser's current sensor to the KinectRegion
                var regionSensorBinding = new Binding("Kinect") { Source = this.sensorChooser };
                BindingOperations.SetBinding(this.kinectRegion, KinectRegion.KinectSensorProperty, regionSensorBinding);

           
                //InputManager.Current.PreProcessInput += OnActivity;
                //_activityTimer = new DispatcherTimer { Interval = TimeSpan.FromMinutes(2), IsEnabled = true };
                /*_activityTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(30), IsEnabled = true };
                _activityTimer.Tick += OnInactivity;*/

            

               //UpdateContentBinding("M");
               UpdateContentBinding();

                
            

           //myGif.Visibility = Visibility.Visible;
            
        }

        /// <summary>
        /// CLR Property Wrappers for PageLeftEnabledProperty
        /// </summary>
        public bool PageLeftEnabled
        {
            get
            {
                return (bool)GetValue(PageLeftEnabledProperty);
            }

            set
            {
                this.SetValue(PageLeftEnabledProperty, value);
            }
        }

        /// <summary>
        /// CLR Property Wrappers for PageRightEnabledProperty
        /// </summary>
        public bool PageRightEnabled
        {
            get
            {
                return (bool)GetValue(PageRightEnabledProperty);
            }

            set
            {
                this.SetValue(PageRightEnabledProperty, value);
            }
        }

        /// <summary>
        /// Called when the KinectSensorChooser gets a new sensor
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="args">event arguments</param>
        //private static void SensorChooserOnKinectChanged(object sender, KinectChangedEventArgs args)
        private void SensorChooserOnKinectChanged(object sender, KinectChangedEventArgs args)
        {   
            if (args.OldSensor != null)
            {
                try
                {
                    args.OldSensor.DepthStream.Range = DepthRange.Default;
                    args.OldSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    args.OldSensor.DepthStream.Disable();
                    args.OldSensor.SkeletonStream.Disable();
                }
                catch (InvalidOperationException)
                {
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features.
                    // E.g.: sensor might be abruptly unplugged.
                }
            }

            if (args.NewSensor != null)
            {

                try
                {
                    //Change the elevation angle
                    args.NewSensor.ElevationAngle = _elevationAngle;
                    sensor = args.NewSensor;
                    args.NewSensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);                    
                    args.NewSensor.SkeletonStream.Enable();
                    args.NewSensor.ColorStream.Enable();
                 
                    try
                    {                   
                        //args.NewSensor.DepthStream.Range = DepthRange.Near; ///Applied when using kinect for windows 
                        //args.NewSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Default;                        
                        args.NewSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Seated;
                        
                        //args.NewSensor.SkeletonStream.EnableTrackingInNearRange = true;

                        //-------------------[C003] starts----------------------------
                        //Subscribe to all frames event to start using the depth streams
                        //args.NewSensor.AllFramesReady += NewSensor_AllFramesReady;  
                        //------------------[C003] ends-------------------------------

                    }
                    catch (InvalidOperationException)
                    {
                        // Non Kinect for Windows devices do not support Near mode, so reset back to default mode.
                        args.NewSensor.DepthStream.Range = DepthRange.Default;
                        args.NewSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    }
                }
                catch (InvalidOperationException)
                {
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features.
                    // E.g.: sensor might be abruptly unplugged.
                }
            }
            
        }


        /// <summary>
        /// Execute shutdown tasks
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            unregisterEvents();
            
            
        }

        /// <summary>
        /// Handle a button click from the wrap panel.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void KinectTileButtonClick(object sender, RoutedEventArgs e)
        {
           
            var button = (KinectTileButton)e.OriginalSource;
            if ((string)button.Label=="Red Wine")
            
            {
                try
                {
                    //unregisterEvents();

                    MainPanel.Visibility = Visibility.Hidden;

                    //Wines.win2 = new DisplayWine();
                    ////getMainWindow();
                    //Wines.win2.ShowDialog();

                    WinePanel.Visibility = Visibility.Visible;

                    //this.Hide();
                }
                catch (Exception ex)
                {
                    
                   
                }
                finally
                {
                    GC.SuppressFinalize(this);

                }
                
                
            }

            if ((string)button.Label == "White Wine")
            
            {
                unregisterEvents();
                var displaywhitewine = new DisplayWhiteWine();
                displaywhitewine.Show();

                this.Close();
            }

            if ((string)button.Label == "Fortified")
            
            {
                unregisterEvents();
                var displaySpirit = new DisplaySpirit();
                displaySpirit.Show();
                
                this.Close();
            }

            //e.Handled = true;
        }

        /// <summary>
        /// Handle paging right (next button).
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void PageRightButtonClick(object sender, RoutedEventArgs e)
        {
           
            scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + PixelScrollByAmount);
           
        }

        /// <summary>
        /// Handle paging left (previous button).
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void PageLeftButtonClick(object sender, RoutedEventArgs e)
        {
            scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - PixelScrollByAmount);
        }

        /// <summary>
        /// Change button state depending on scroll viewer position
        /// </summary>
        private void UpdatePagingButtonState()
        {
            this.PageLeftEnabled = scrollViewer.HorizontalOffset > ScrollErrorMargin;
            this.PageRightEnabled = scrollViewer.HorizontalOffset < scrollViewer.ScrollableWidth - ScrollErrorMargin;
        }

          
        private void UpdateContentBinding()
        {
            string _initialURI = String.Empty;
            int arrayLength = 0;            
            _initialURI = "./Images/Wines/";
            arrayLength = _wineArray.Length;                        
            // Clear out placeholder content
            this.wrapPanel.Children.Clear();

            // Add in display content
            for (var index = 0; index < arrayLength; ++index)
            {
                var brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri(_initialURI + "Wine"+(index+1)+".png", UriKind.Relative));
                string buttonname=string.Empty;
                
               // buttonname = Convert.ToString(index + 1);
                //var button = new KinectTileButton { Label = (index + 1).ToString(CultureInfo.CurrentCulture), Background = brush };
               // var button = new KinectTileButton { Label = buttonname.ToString(CultureInfo.CurrentCulture), Background = brush };
                if(Convert.ToString(brush.ImageSource)== Convert.ToString("./Images/Wines/Wine1.png"))
                {
                
                buttonname="Wine Case";
                }
                if (Convert.ToString(brush.ImageSource) == Convert.ToString("./Images/Wines/Wine2.png"))
                {

                    buttonname = "White Wine";
                    
                }
                if (Convert.ToString(brush.ImageSource) == Convert.ToString("./Images/Wines/Wine3.png"))
                {

                    buttonname = "Red Wine";
                }
                if (Convert.ToString(brush.ImageSource) == Convert.ToString("./Images/Wines/Wine4.png"))
                {

                    buttonname = "Sparkling Wine";
                }
                if (Convert.ToString(brush.ImageSource) == Convert.ToString("./Images/Wines/Wine5.png"))
                {

                    buttonname = "Fortified";
                }
                if (Convert.ToString(brush.ImageSource) == Convert.ToString("./Images/Wines/Wine6.png"))
                {

                    buttonname = "Spirits";
                }
                if (Convert.ToString(brush.ImageSource) == Convert.ToString("./Images/Wines/Wine7.png"))
                {

                    buttonname = "Gifts";
                }
                if (Convert.ToString(brush.ImageSource) == Convert.ToString("./Images/Wines/Wine8.png"))
                {

                    buttonname = "Specials";
                }
                var button = new KinectTileButton { Label= buttonname.ToString(CultureInfo.CurrentCulture), Background = brush };
                button.FontSize = 18;
                
                this.wrapPanel.Children.Add(button);
            }
            
            // Bind listner to scrollviwer scroll position change, and check scroll viewer position
            this.UpdatePagingButtonState();
            scrollViewer.ScrollChanged += (o, e) => this.UpdatePagingButtonState();
        }

    

        private void unregisterEvents()
        {
            
            //this.sensorChooser.KinectChanged -= SensorChooserOnKinectChanged;
            //this.sensorChooserUi.KinectSensorChooser = this.sensorChooser;
            this.sensorChooserUi.KinectSensorChooser = null;
            this.sensorChooser.Stop();
            
            
        }



       
      
        //---------------------------[C009] ends------------------------------------------  

        private void OnHandPointerEnter(object sender, HandPointerEventArgs handPointerEventArgs)
        {
            //Help.Show();
        }
        private void OnHandPointerLeave(object sender, HandPointerEventArgs handPointerEventArgs)
        {
            //Help.Hide();
        }

        

    }
}
