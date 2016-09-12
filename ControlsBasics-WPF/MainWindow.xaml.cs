//------------------------------------------------------------------------------------------------------
// Author : Nikhil Malhotra Date: February 13th 2016
//Application: Augmented Trial Room
//File: MainWindow XAML for the application
/***********************************Change History*********************************************************
 * ControlsBasics-WPF
 *  Label               Description                                                         Author
 *  C001                Manual Change to change the array length of shirts                  Nikhil Malhotra  
 *  C002                Commented region to show kinecttilebutton as this has to be
 *                      a user function now                                                 Nikhil Malhotra
 * C003                 Change to take all frames of Kinect to draw shirts                  Nikhil Malhotra
 * C004                 Function to take all frames of video                                ----do------
 * C005                 Function to draw clothes                                            ----do------
 * C006                 Function to grab bit map from video source                          ----do------    
 * C007                 Changed function to draw short on the body rather                   ----do------
 *                      than showing the usual label text                                   
 * C008                 Male and Female Kinect tile buttons added to reflect choice         ----do------             
 * C009                 Function to take images of shorts from Images folder and            Nikhil Malhotra
 *                      draw it as kinect tile buttons                              
 * ********************************************************************************************************/
//---------------------------------------------------------------------------------------------------------

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
    public partial class MainWindow 
    {
      // public static DisplayWine displayWine;
      //public static  DisplayWineDetails displayDetails;
      //public static  MainWindow mainWindow;
      

     //public static MainWindow getMainWindow()
                 

     // {
     //     if (Wines.win1!= null)
     //         return Wines.win1;
     //     else
     //     {
     //         Wines.win1 = new MainWindow();
     //         return Wines.win1;
     //     }
     // } 


        public static readonly DependencyProperty PageLeftEnabledProperty = DependencyProperty.Register(
            "PageLeftEnabled", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));

        public static readonly DependencyProperty PageRightEnabledProperty = DependencyProperty.Register(
            "PageRightEnabled", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));

        public static readonly RoutedEvent HandPointerEnterEvent = EventManager.RegisterRoutedEvent(
       "HandPointerEnter", RoutingStrategy.Direct, typeof(EventHandler<HandPointerEventArgs>), typeof(MainWindow));

        public static readonly RoutedEvent HandPointerLeaveEvent = EventManager.RegisterRoutedEvent(
            "HandPointerLeave", RoutingStrategy.Direct, typeof(EventHandler<HandPointerEventArgs>), typeof(MainWindow));

        private const double ScrollErrorMargin = 0.001;

        private const int PixelScrollByAmount = 10;

        private readonly KinectSensorChooser sensorChooser;

       // private readonly DispatcherTimer _activityTimer;
        private Point _inactiveMousePosition = new Point(0, 0);

       // Temp Help = new Temp();

        //New Constants/Variable Declaration Starts
        private const int _elevationAngle = 0;
        private KinectSensor sensor; 
        private byte[] photoPixelData;
        private BitmapSource photoSource;
       // private bool _drawClothes = false;
        /**************[C001] starts*************************/
        //Change the array length portion to the number of shorts your have for each
        private String[] _menClothesArray = new String[8];
        private String[] _womenClothesArray = new String[24];
        MainViewModel mainViewModel;
        /****************[C001] ends*******************************************/
        //private Rectangle shirt_rect;  
        private DepthImagePixel[] depthImagePixels;
       // private ImageSource _contentSource;
        //New Constants/Variable Declaration Ends

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class. 
        /// </summary>
        public MainWindow()
        {
            
                InitializeComponent();


                // initialize the sensor chooser and UI
                this.sensorChooser = new KinectSensorChooser();
                this.sensorChooser.KinectChanged += SensorChooserOnKinectChanged;
                this.sensorChooserUi.KinectSensorChooser = this.sensorChooser;
                this.sensorChooser.Start();

                //KinectRegion.AddHandPointerEnterHandler(this.infoHelpButton, this.OnHandPointerEnter);
                //KinectRegion.AddHandPointerLeaveHandler(this.infoHelpButton, this.OnHandPointerLeave);

                // Bind the sensor chooser's current sensor to the KinectRegion
                var regionSensorBinding = new Binding("Kinect") { Source = this.sensorChooser };
                BindingOperations.SetBinding(this.kinectRegion, KinectRegion.KinectSensorProperty, regionSensorBinding);


                //InputManager.Current.PreProcessInput += OnActivity;
                //_activityTimer = new DispatcherTimer { Interval = TimeSpan.FromMinutes(2), IsEnabled = true };
                /*_activityTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(30), IsEnabled = true };
                _activityTimer.Tick += OnInactivity;*/



                UpdateContentBinding("M");
                mainViewModel = new MainViewModel();
                mainViewModel.UpdateRecommendation();
                txtRecommendation.Text = mainViewModel.Recommendation;

                
            

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
                        args.NewSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Default;                        
                        //args.NewSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Seated;
                        
                        //args.NewSensor.SkeletonStream.EnableTrackingInNearRange = true;

                        //-------------------[C003] starts----------------------------
                        //Subscribe to all frames event to start using the depth streams
                       // args.NewSensor.AllFramesReady += NewSensor_AllFramesReady;  
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
            if (args.NewSensor == null)
            { 
            
            }
        }

        //----------------------[C004] starts---------------------------------------------
        private void NewSensor_AllFramesReady(object sender, AllFramesReadyEventArgs e)
        {

            depthImagePixels = new DepthImagePixel[sensor.DepthStream.FramePixelDataLength];
            using (var frame = e.OpenDepthImageFrame())
            {
                if (frame == null)
                {
                    return;
                }
                frame.CopyDepthImagePixelDataTo(depthImagePixels);

            }
            using (var frame = e.OpenColorImageFrame())
            {
                if (frame == null)
                {
                    return;
                }
                var bitmap = CreateBitmap(frame);
                //imgCanvas.Background = new ImageBrush(bitmap);
                if (photoPixelData == null)
                {
                    photoPixelData = new byte[frame.PixelDataLength];
                    frame.CopyPixelDataTo(photoPixelData);
                    var stride = frame.Width * frame.BytesPerPixel;
                    photoSource = BitmapSource.Create(frame.Width, frame.Height, 96, 96, PixelFormats.Bgr32, null, photoPixelData, stride);
                }

            }
            using (var frame = e.OpenSkeletonFrame())
            {
                if (frame == null)
                {
                    return;
                }

                var skeletonData = new Skeleton[frame.SkeletonArrayLength];
                frame.CopySkeletonDataTo(skeletonData);
                //var skeleton = skeletons.FirstOrDefault(s => s.TrackingState == SkeletonTrackingState.Tracked);
                var skeleton = (from s in skeletonData
                                    where s.TrackingState == SkeletonTrackingState.Tracked
                                select s).FirstOrDefault();
                //var skeleton = skeletons[0];
                if (skeleton == null)
                    return;

                //Take all the joints details of the player
                var joint_position = skeleton.Joints[JointType.HandRight].Position;
                var left_joint_position = skeleton.Joints[JointType.HandLeft].Position;
                var elbow_left_joint_position = skeleton.Joints[JointType.ElbowLeft].Position;
                var elbow_right_joint_position = skeleton.Joints[JointType.ElbowRight].Position;
                var head_joint_position = skeleton.Joints[JointType.Head].Position;
                var left_shoulder_joint_position = skeleton.Joints[JointType.ShoulderLeft].Position;
                var right_shoulder_joint_position = skeleton.Joints[JointType.ShoulderRight].Position;
                var hip_joint_position = skeleton.Joints[JointType.HipCenter].Position;
                var righ_hand_position = skeleton.Joints[JointType.WristRight].Position;
                var left_hand_position = skeleton.Joints[JointType.WristLeft].Position;


                var mapper = new CoordinateMapper(sensor);
                var colorPoint = mapper.MapSkeletonPointToColorPoint(joint_position, ColorImageFormat.RgbResolution640x480Fps30);
                var left_colorPoint = mapper.MapSkeletonPointToColorPoint(left_joint_position, ColorImageFormat.RgbResolution640x480Fps30);


                var left_elbow_point = mapper.MapSkeletonPointToColorPoint(elbow_left_joint_position, ColorImageFormat.RgbResolution640x480Fps30);
                var right_elbow_point = mapper.MapSkeletonPointToColorPoint(elbow_right_joint_position, ColorImageFormat.RgbResolution640x480Fps30);
                var head_point = mapper.MapSkeletonPointToColorPoint(head_joint_position, ColorImageFormat.RgbResolution640x480Fps30);
                var left_shoulder_point = mapper.MapSkeletonPointToColorPoint(left_shoulder_joint_position, ColorImageFormat.RgbResolution640x480Fps30);
                var right_shoulder_point = mapper.MapSkeletonPointToColorPoint(right_shoulder_joint_position, ColorImageFormat.RgbResolution640x480Fps30);
                var hip_point = mapper.MapSkeletonPointToColorPoint(hip_joint_position, ColorImageFormat.RgbResolution640x480Fps30);
                var right_hand = mapper.MapSkeletonPointToColorPoint(righ_hand_position, ColorImageFormat.RgbResolution640x480Fps30);
                var left_hand = mapper.MapSkeletonPointToColorPoint(left_hand_position, ColorImageFormat.RgbResolution640x480Fps30);

                //if (_drawClothes)
                //{
                //    DrawClothes(colorPoint, head_point, right_elbow_point, left_elbow_point, hip_point, _contentSource);                    
                //}
            }

        }
        //----------------------[C004] ends---------------------------------------------

       
        //----------------------[C006] starts---------------------------------------------
        private BitmapSource CreateBitmap(ColorImageFrame frame)
        {
            var pixelData = new byte[frame.PixelDataLength];
            frame.CopyPixelDataTo(pixelData);
            // GrayscaleData(pixelData);
            var stride = frame.Width * frame.BytesPerPixel;
            var bitmap = BitmapSource.Create(frame.Width, frame.Height, 96, 96, PixelFormats.Bgr32,
                                             null, pixelData, stride);
            return bitmap;
        }
        //----------------------[C006] starts---------------------------------------------
       

        /// <summary>
        /// Execute shutdown tasks
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.sensorChooser.Stop();
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
                    unregisterEvents();

                    Wines.win2 = new DisplayWine();
                    //getMainWindow();
                    this.Close();
                    Wines.win2.ShowDialog();

                    
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
                this.Close();
                displaywhitewine.Show();

                
            }

            if ((string)button.Label == "Fortified")
            
            {
                unregisterEvents();
                var displaySpirit = new DisplaySpirit();
                this.Close();
                displaySpirit.Show();
                
                
            }
           
            

            

            //---------------------------[C007] ends------------------------------------------
           // e.Handled = true;
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

        //---------------------------[C008] starts------------------------------------------           
       
        //---------------------------[C008] ends------------------------------------------           

        //---------------------------[C009] starts------------------------------------------           
        private void UpdateContentBinding(String choice)
        {
            string _initialURI = String.Empty;
            int arrayLength = 0;
            switch (choice)
            {
                //Taking choice to the Men folder
                case "M":
                    _initialURI = "./Images/Wines/";
                    arrayLength = _menClothesArray.Length;
                    break;
               
            }
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

            this.sensorChooser.KinectChanged -= SensorChooserOnKinectChanged;
            //this.sensorChooserUi.KinectSensorChooser = this.sensorChooser;
            this.sensorChooserUi.KinectSensorChooser = null;
            this.sensorChooser.Stop();

            
        }

        /*void OnInactivity(object sender, EventArgs e)
        {
            // remember mouse position
            _inactiveMousePosition = Mouse.GetPosition(scrollViewer);
            unregisterEvents();
            
            var landingpage = new LandingPage();
            landingpage.Show();
            this.Close();
        }*/

        void OnActivity(object sender, PreProcessInputEventArgs e)
        {
            InputEventArgs inputEventArgs = e.StagingItem.Input;

            if (inputEventArgs is MouseEventArgs || inputEventArgs is KeyboardEventArgs)
            {
                if (e.StagingItem.Input is MouseEventArgs)
                {
                    MouseEventArgs mouseEventArgs = (MouseEventArgs)e.StagingItem.Input;
                   

                    // no button is pressed and the position is still the same as the application became inactive
                    if (mouseEventArgs.LeftButton == MouseButtonState.Released &&
                        mouseEventArgs.RightButton == MouseButtonState.Released &&
                        mouseEventArgs.MiddleButton == MouseButtonState.Released &&
                        mouseEventArgs.XButton1 == MouseButtonState.Released &&
                        mouseEventArgs.XButton2 == MouseButtonState.Released &&
                        _inactiveMousePosition == mouseEventArgs.GetPosition(scrollViewer))
                    
                         return;
                    
                       
                }
                

                // set UI on activity
                scrollViewer.Visibility = Visibility.Visible;
                MyCanvas.Visibility = Visibility.Visible;
                

                //_activityTimer.Stop();
                //_activityTimer.Start();
            }
        }

        private void mainWindowActiveh_Click(object sender, RoutedEventArgs e)
        {
            scrollViewer.Visibility = Visibility.Visible;
            MyCanvas.Visibility = Visibility.Visible;
        }

        //private void ShowHideHelp(object sender, HandPointerEventArgs e)
        //{
        //    Temp Help = new Temp();

        //    if(e.HandPointer.GetIsOver(infoHelpButton))
                       
        //    {
        //        Help.Show();
        //    }
        //   else
        //    {
        //        Help.Close();
        //    }

        //}
      
        //---------------------------[C009] ends------------------------------------------  

        private void OnHandPointerEnter(object sender, HandPointerEventArgs handPointerEventArgs)
        {
            //ShowHideHelp(sender,handPointerEventArgs);
        }
        private void OnHandPointerLeave(object sender, HandPointerEventArgs handPointerEventArgs)
        {
            //ShowHideHelp(sender, handPointerEventArgs);
        }

        private void ControlsBasicsWindow_Activated(object sender, EventArgs e)
        {
            mainViewModel.UpdateRecommendation();

        }

        

    }
}
