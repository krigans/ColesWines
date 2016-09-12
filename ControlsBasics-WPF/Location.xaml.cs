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

namespace Microsoft.Samples.Kinect.ControlsBasics
{
    /// <summary>
    /// Interaction logic for Location.xaml
    /// </summary>
    public partial class Location : Window
    {
        public static readonly DependencyProperty PageLeftEnabledProperty = DependencyProperty.Register(
           "PageLeftEnabled", typeof(bool), typeof(Location), new PropertyMetadata(false));

        public static readonly DependencyProperty PageRightEnabledProperty = DependencyProperty.Register(
            "PageRightEnabled", typeof(bool), typeof(Location), new PropertyMetadata(false));

        private const double ScrollErrorMargin = 0.001;

        private const int PixelScrollByAmount = 20;

        private readonly KinectSensorChooser sensorChooser;

        ////New Constants/Variable Declaration Starts
        private const int _elevationAngle = 0;
        private KinectSensor sensor;
        private byte[] photoPixelData;
        private BitmapSource photoSource;


        private DepthImagePixel[] depthImagePixels;

        public Location()
        {
            InitializeComponent();


            this.sensorChooser = new KinectSensorChooser();
            this.sensorChooser.KinectChanged += SensorChooserOnKinectChanged;
            this.sensorChooserLocation.KinectSensorChooser = this.sensorChooser;
            this.sensorChooser.Start();

            //Bind the sensor chooser's current sensor to the KinectRegion
            var regionSensorBinding = new Binding("Kinect") { Source = this.sensorChooser };
            BindingOperations.SetBinding(this.kinectRegionLocation, KinectRegion.KinectSensorProperty, regionSensorBinding);
        }

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
                        //args.NewSensor.SkeletonStream.EnableTrackingInNearRange = true;

                        //-------------------[C003] starts----------------------------
                        //Subscribe to all frames event to start using the depth streams
                        args.NewSensor.AllFramesReady += NewSensor_AllFramesReady;
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


                var mapper = new CoordinateMapper(sensor);
                var colorPoint = mapper.MapSkeletonPointToColorPoint(joint_position, ColorImageFormat.RgbResolution640x480Fps30);
                var left_colorPoint = mapper.MapSkeletonPointToColorPoint(left_joint_position, ColorImageFormat.RgbResolution640x480Fps30);


                var left_elbow_point = mapper.MapSkeletonPointToColorPoint(elbow_left_joint_position, ColorImageFormat.RgbResolution640x480Fps30);
                var right_elbow_point = mapper.MapSkeletonPointToColorPoint(elbow_right_joint_position, ColorImageFormat.RgbResolution640x480Fps30);
                var head_point = mapper.MapSkeletonPointToColorPoint(head_joint_position, ColorImageFormat.RgbResolution640x480Fps30);
                var left_shoulder_point = mapper.MapSkeletonPointToColorPoint(left_shoulder_joint_position, ColorImageFormat.RgbResolution640x480Fps30);
                var right_shoulder_point = mapper.MapSkeletonPointToColorPoint(right_shoulder_joint_position, ColorImageFormat.RgbResolution640x480Fps30);
                var hip_point = mapper.MapSkeletonPointToColorPoint(hip_joint_position, ColorImageFormat.RgbResolution640x480Fps30);


            }

        }

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

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.sensorChooser.Stop();
        }

        /// <summary>
        /// Handle paging right (next button).
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void PageRightButtonClick(object sender, RoutedEventArgs e)
        {

            //scrollViewerLocation.ScrollToHorizontalOffset(scrollViewerLocation.HorizontalOffset + PixelScrollByAmount);

        }

        /// <summary>
        /// Handle paging left (previous button).
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void PageLeftButtonClick(object sender, RoutedEventArgs e)
        {

            //scrollViewerLocation.ScrollToHorizontalOffset(scrollViewerLocation.HorizontalOffset - PixelScrollByAmount);
        }

        /// <summary>
        /// Change button state depending on scroll viewer position
        /// </summary>
        private void UpdatePagingButtonState()
        {
            //this.PageLeftEnabled = scrollViewerLocation.HorizontalOffset > ScrollErrorMargin;
            //this.PageRightEnabled = scrollViewerLocation.HorizontalOffset < scrollViewerLocation.ScrollableWidth - ScrollErrorMargin;
        }

        private void unregisterEvents()
        {

            this.sensorChooser.KinectChanged -= SensorChooserOnKinectChanged;
            this.sensorChooserLocation.KinectSensorChooser = this.sensorChooser;
            this.sensorChooser.Stop();
        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            unregisterEvents();
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            unregisterEvents();
            var displayWineDetails = new DisplayWineDetails();
            displayWineDetails.Show();
            this.Close();
        }
    }
}
