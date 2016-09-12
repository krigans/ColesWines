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
using System.Windows.Media.Animation;
using System.Configuration;
using Microsoft.Kinect;
using System.Globalization;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.IO;


namespace Microsoft.Samples.Kinect.ControlsBasics
{
    /// <summary>
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : Window
    {

        public static readonly DependencyProperty PageLeftEnabledProperty = DependencyProperty.Register(
           "PageLeftEnabled", typeof(bool), typeof(LandingPage), new PropertyMetadata(false));

        public static readonly DependencyProperty PageRightEnabledProperty = DependencyProperty.Register(
            "PageRightEnabled", typeof(bool), typeof(LandingPage), new PropertyMetadata(false));

        private readonly KinectSensorChooser sensorChooser;
        private const int _elevationAngle = 0;
        private KinectSensor sensor; 
        private DispatcherTimer timerImageChange;
        private Image[] ImageControls;
        private List<ImageSource> Images = new List<ImageSource>();
        private static string[] ValidImageExtensions = new[] { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };
        private static string[] TransitionEffects = new[] { "Fade" };
        private string TransitionType, strImagePath = "";
        private int CurrentSourceIndex, CurrentCtrlIndex, EffectIndex = 0, IntervalTimer = 1;
        private byte[] photoPixelData;
        private BitmapSource photoSource;
        private DepthImagePixel[] depthImagePixels;
        private bool bMainWindowInitalized = false;

        public LandingPage()
        {
            InitializeComponent();

            this.sensorChooser = new KinectSensorChooser();
            this.sensorChooser.KinectChanged += SensorChooserOnKinectChanged;
            this.sensorChooserUiLanding.KinectSensorChooser = this.sensorChooser;
            this.sensorChooser.Start();

            //Bind the sensor chooser's current sensor to the KinectRegion
            var regionSensorBinding = new Binding("Kinect") { Source = this.sensorChooser };
            BindingOperations.SetBinding(this.kinectRegionLanding, KinectRegion.KinectSensorProperty, regionSensorBinding);

            //Initialize Image control, Image directory path and Image timer.
            IntervalTimer = Convert.ToInt32(ConfigurationManager.AppSettings["IntervalTime"]);
            strImagePath = ConfigurationManager.AppSettings["ImagePath"];
            ImageControls = new[] { myImage, myImage2 };

            LoadImageFolder(strImagePath);

            timerImageChange = new DispatcherTimer();
            timerImageChange.Interval = new TimeSpan(0, 0, IntervalTimer);
            timerImageChange.Tick += new EventHandler(timerImageChange_Tick);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PlaySlideShow();
            timerImageChange.IsEnabled = true;
        }

        private void LoadImageFolder(string folder)
        {
            //ErrorText.Visibility = Visibility.Collapsed;
            var sw = System.Diagnostics.Stopwatch.StartNew();
            if (!System.IO.Path.IsPathRooted(folder))
                folder = System.IO.Path.Combine(Environment.CurrentDirectory, folder);
            if (!System.IO.Directory.Exists(folder))
            {
                //ErrorText.Text = "The specified folder does not exist: " + Environment.NewLine + folder;
                //ErrorText.Visibility = Visibility.Visible;
                return;
            }
            Random r = new Random();
            var sources = from file in new System.IO.DirectoryInfo(folder).GetFiles().AsParallel()
                          where ValidImageExtensions.Contains(file.Extension, StringComparer.InvariantCultureIgnoreCase)
                          orderby r.Next()
                          select CreateImageSource(file.FullName, true);
            Images.Clear();
            Images.AddRange(sources);
            sw.Stop();
            Console.WriteLine("Total time to load {0} images: {1}ms", Images.Count, sw.ElapsedMilliseconds);
        }

        private ImageSource CreateImageSource(string file, bool forcePreLoad)
        {
            if (forcePreLoad)
            {
                var src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri(file, UriKind.Absolute);
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.EndInit();
                src.Freeze();
                return src;
            }
            else
            {
                var src = new BitmapImage(new Uri(file, UriKind.Absolute));
                src.Freeze();
                return src;
            }
        }

        private void timerImageChange_Tick(object sender, EventArgs e)
        {
            
                PlaySlideShow();
            

            
        }

        private void PlaySlideShow()
        {
            try
            {
                if (Images.Count == 0)
                    return;
                var oldCtrlIndex = CurrentCtrlIndex;
                CurrentCtrlIndex = (CurrentCtrlIndex + 1) % 2;
                CurrentSourceIndex = (CurrentSourceIndex + 1) % Images.Count;

                Image imgFadeOut = ImageControls[oldCtrlIndex];
                Image imgFadeIn = ImageControls[CurrentCtrlIndex];
                ImageSource newSource = Images[CurrentSourceIndex];
                imgFadeIn.Source = newSource;

                TransitionType = TransitionEffects[EffectIndex].ToString();

                Storyboard StboardFadeOut = (Resources[string.Format("{0}Out", TransitionType.ToString())] as Storyboard).Clone();
                StboardFadeOut.Begin(imgFadeOut);
                Storyboard StboardFadeIn = Resources[string.Format("{0}In", TransitionType.ToString())] as Storyboard;
                StboardFadeIn.Begin(imgFadeIn);
            }
            catch (Exception ex) { }
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
                        //args.NewSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Default;                        
                        args.NewSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Seated;

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
                var skeletonid = (from s in skeletonData
                                where s.TrackingState == SkeletonTrackingState.Tracked
                                select s).FirstOrDefault();
                //var skeleton = skeletons[0];
                if (skeletonid == null)
                    return;
              

               
                

                //Take all the joints details of the player
                var joint_position = skeletonid.Joints[JointType.HandRight].Position;
                var left_joint_position = skeletonid.Joints[JointType.HandLeft].Position;
                var elbow_left_joint_position = skeletonid.Joints[JointType.ElbowLeft].Position;
                var elbow_right_joint_position = skeletonid.Joints[JointType.ElbowRight].Position;
                var head_joint_position = skeletonid.Joints[JointType.Head].Position;
                var left_shoulder_joint_position = skeletonid.Joints[JointType.ShoulderLeft].Position;
                var right_shoulder_joint_position = skeletonid.Joints[JointType.ShoulderRight].Position;
                var hip_joint_position = skeletonid.Joints[JointType.HipCenter].Position;
                var righ_hand_position = skeletonid.Joints[JointType.WristRight].Position;
                var left_hand_position = skeletonid.Joints[JointType.WristLeft].Position;


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


                if (skeletonid != null)
                {
                    unregisterEvents();
                    if (!bMainWindowInitalized)
                    {
                        bMainWindowInitalized = true;
                        //var mainwindow = new MainWindow();
                        //mainwindow.Show();

                        var helpwindow = new Help();
                        helpwindow.Show();
                        skeletonid = null;
                    }
                    this.Close();
                }                
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

        private void unregisterEvents()
        {

            this.sensorChooser.KinectChanged -= SensorChooserOnKinectChanged;
            //this.sensorChooserUiLanding.KinectSensorChooser = this.sensorChooser;
            this.sensorChooserUiLanding.KinectSensorChooser = null;
            this.sensorChooser.Stop();
        }

        //private void homeButton_Click(object sender, RoutedEventArgs e)
        //{
        //    unregisterEvents();
        //    var mainwindow = new MainWindow();
        //    mainwindow.Show();
        //    this.Close();
        //}

        private void LandingPageClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.sensorChooser.Stop();
            
        }
    }
}
