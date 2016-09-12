﻿using System;
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
using System.Windows.Input;

namespace Microsoft.Samples.Kinect.ControlsBasics
{

    /// <summary>
    /// Interaction logic for DisplaySpirit.xaml
    /// </summary>
    public partial class DisplaySpirit : Window
    {
        public static readonly DependencyProperty PageLeftEnabledProperty = DependencyProperty.Register(
           "PageLeftEnabled", typeof(bool), typeof(DisplaySpirit), new PropertyMetadata(false));

        public static readonly DependencyProperty PageRightEnabledProperty = DependencyProperty.Register(
            "PageRightEnabled", typeof(bool), typeof(DisplaySpirit), new PropertyMetadata(false));


        public static readonly RoutedEvent HandPointerEnterEvent = EventManager.RegisterRoutedEvent(
        "HandPointerEnter", RoutingStrategy.Direct, typeof(EventHandler<HandPointerEventArgs>), typeof(DisplaySpirit));

        public static readonly RoutedEvent HandPointerLeaveEvent = EventManager.RegisterRoutedEvent(
            "HandPointerLeave", RoutingStrategy.Direct, typeof(EventHandler<HandPointerEventArgs>), typeof(DisplaySpirit));

        private const double ScrollErrorMargin = 0.001;

        private const int PixelScrollByAmount = 20;

        private readonly KinectSensorChooser sensorChooser;

        ////New Constants/Variable Declaration Starts
        private const int _elevationAngle = 0;
        private KinectSensor sensor;
        private byte[] photoPixelData;
        private BitmapSource photoSource;


        private DepthImagePixel[] depthImagePixels;

        //Temp Help = new Temp();
        public DisplaySpirit()
        {
            InitializeComponent();

            this.sensorChooser = new KinectSensorChooser();
            this.sensorChooser.KinectChanged += SensorChooserOnKinectChanged;
            this.sensorChooserUiDisplay.KinectSensorChooser = this.sensorChooser;
            this.sensorChooser.Start();

            //KinectRegion.AddHandPointerEnterHandler(this.infoHelpButton, this.OnHandPointerEnter);
            //KinectRegion.AddHandPointerLeaveHandler(this.infoHelpButton, this.OnHandPointerLeave);


            //Bind the sensor chooser's current sensor to the KinectRegion
            var regionSensorBinding = new Binding("Kinect") { Source = this.sensorChooser };
            BindingOperations.SetBinding(this.kinectRegionDisplay, KinectRegion.KinectSensorProperty, regionSensorBinding);
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

        

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            unregisterEvents();
        }

        /// <summary>
        /// Handle paging right (next button).
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void PageRightButtonClick(object sender, RoutedEventArgs e)
        {

            scrollViewerDisplay.ScrollToHorizontalOffset(scrollViewerDisplay.HorizontalOffset + PixelScrollByAmount);

        }

        /// <summary>
        /// Handle paging left (previous button).
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void PageLeftButtonClick(object sender, RoutedEventArgs e)
        {
            scrollViewerDisplay.ScrollToHorizontalOffset(scrollViewerDisplay.HorizontalOffset - PixelScrollByAmount);

        }

        /// <summary>
        /// Change button state depending on scroll viewer position
        /// </summary>
        private void UpdatePagingButtonState()
        {
            this.PageLeftEnabled = scrollViewerDisplay.HorizontalOffset > ScrollErrorMargin;
            this.PageRightEnabled = scrollViewerDisplay.HorizontalOffset < scrollViewerDisplay.ScrollableWidth - ScrollErrorMargin;
        }

       

       

        private void homeChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            unregisterEvents();
            var homedisplay = new MainWindow();
            this.Close();
            homedisplay.Show();
            

        }

        private void backChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            unregisterEvents();
            var homedisplay = new MainWindow();
            this.Close();
            homedisplay.Show();
            
        }


        private void unregisterEvents()
        {

            this.sensorChooser.KinectChanged -= SensorChooserOnKinectChanged;
            this.sensorChooserUiDisplay.KinectSensorChooser = this.sensorChooser;
            this.sensorChooser.Stop();
        }

        

        private void KinectTileButtonEnter(object sender, RoutedEventArgs e)
        {
            var button = (KinectTileButton)e.OriginalSource;
            string btnName = button.Label.ToString();

            if (btnName == "infoHelpButton")
            {
                //Help.Show();
            }
            e.Handled = true;
        }

        private void KinectTileButtonLeave(object sender, RoutedEventArgs e)
        {
           // Help.Hide();
            e.Handled = true;
        }

        private void OnHandPointerEnter(object sender, HandPointerEventArgs handPointerEventArgs)
        {
           // Help.Show();
        }
        private void OnHandPointerLeave(object sender, HandPointerEventArgs handPointerEventArgs)
        {
           // Help.Hide();
        }

        private void GalwayPipeButton_Click(object sender, RoutedEventArgs e)
        {
            unregisterEvents();
            var displayGalPipe = new DisplayGalawayPipe();
            this.Close();
            displayGalPipe.Show();
            
        }

        private void BrownBrothersButton_Click(object sender, RoutedEventArgs e)
        {
            unregisterEvents();
            var displayDetails = new DisplaySpiritDetails();
            this.Close();
            displayDetails.Show();
            
        }

        private void McWilliamsHanwoodButton_Click(object sender, RoutedEventArgs e)
        {
            unregisterEvents();
            var dipslayMcWill = new DisplayMcWilliamsHanwood();
            this.Close();
            dipslayMcWill.Show();
            
        }

        private void DeBortoliButton_Click(object sender, RoutedEventArgs e)
        {
            unregisterEvents();
            var displayDeBorto = new DisplayDeBortoli();
            this.Close();
            displayDeBorto.Show();
            
        }

        private void PenfoldsClubButton_Click(object sender, RoutedEventArgs e)
        {
            unregisterEvents();
            var displayPenFold = new DisplayPenfoldsClub();
            this.Close();
            displayPenFold.Show();
            
        }
    }
}
