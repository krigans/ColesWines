﻿#pragma checksum "..\..\DisplayWhiteWine.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0633E6A46FF237BA2E94F8317E2C3F68"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using Microsoft.Samples.Kinect.ControlsBasics;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Microsoft.Samples.Kinect.ControlsBasics {
    
    
    /// <summary>
    /// DisplayWhiteWine
    /// </summary>
    public partial class DisplayWhiteWine : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\DisplayWhiteWine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Samples.Kinect.ControlsBasics.DisplayWhiteWine DisplayWhiteWineWindow;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\DisplayWhiteWine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas imgCanvasDisplay;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\DisplayWhiteWine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid KinectViewGridDisplay;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\DisplayWhiteWine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.KinectSensorChooserUI sensorChooserUiDisplay;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\DisplayWhiteWine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectRegion kinectRegionDisplay;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\DisplayWhiteWine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid kinectRegionGridDisplay;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\DisplayWhiteWine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectTileButton homeChoiceButton;
        
        #line default
        #line hidden
        
        
        #line 154 "..\..\DisplayWhiteWine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectTileButton backChoiceButton;
        
        #line default
        #line hidden
        
        
        #line 186 "..\..\DisplayWhiteWine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectScrollViewer scrollViewerDisplay;
        
        #line default
        #line hidden
        
        
        #line 188 "..\..\DisplayWhiteWine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel wrapPanelDisplay;
        
        #line default
        #line hidden
        
        
        #line 190 "..\..\DisplayWhiteWine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectTileButton AmberleyEstateButton;
        
        #line default
        #line hidden
        
        
        #line 197 "..\..\DisplayWhiteWine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectTileButton ValleyChardonnayButton;
        
        #line default
        #line hidden
        
        
        #line 202 "..\..\DisplayWhiteWine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectTileButton ValleyRieslingButton;
        
        #line default
        #line hidden
        
        
        #line 207 "..\..\DisplayWhiteWine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectTileButton BanrockMoscatoButton;
        
        #line default
        #line hidden
        
        
        #line 228 "..\..\DisplayWhiteWine.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMessageDisplay;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AugmentedRetail;component/displaywhitewine.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DisplayWhiteWine.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.DisplayWhiteWineWindow = ((Microsoft.Samples.Kinect.ControlsBasics.DisplayWhiteWine)(target));
            
            #line 10 "..\..\DisplayWhiteWine.xaml"
            this.DisplayWhiteWineWindow.Closing += new System.ComponentModel.CancelEventHandler(this.WindowClosing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.imgCanvasDisplay = ((System.Windows.Controls.Canvas)(target));
            return;
            case 3:
            this.KinectViewGridDisplay = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.sensorChooserUiDisplay = ((Microsoft.Kinect.Toolkit.KinectSensorChooserUI)(target));
            return;
            case 5:
            this.kinectRegionDisplay = ((Microsoft.Kinect.Toolkit.Controls.KinectRegion)(target));
            return;
            case 6:
            this.kinectRegionGridDisplay = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.homeChoiceButton = ((Microsoft.Kinect.Toolkit.Controls.KinectTileButton)(target));
            
            #line 148 "..\..\DisplayWhiteWine.xaml"
            this.homeChoiceButton.Click += new System.Windows.RoutedEventHandler(this.homeChoiceButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.backChoiceButton = ((Microsoft.Kinect.Toolkit.Controls.KinectTileButton)(target));
            
            #line 154 "..\..\DisplayWhiteWine.xaml"
            this.backChoiceButton.Click += new System.Windows.RoutedEventHandler(this.backChoiceButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.scrollViewerDisplay = ((Microsoft.Kinect.Toolkit.Controls.KinectScrollViewer)(target));
            return;
            case 10:
            this.wrapPanelDisplay = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 11:
            this.AmberleyEstateButton = ((Microsoft.Kinect.Toolkit.Controls.KinectTileButton)(target));
            
            #line 190 "..\..\DisplayWhiteWine.xaml"
            this.AmberleyEstateButton.Click += new System.Windows.RoutedEventHandler(this.AmberleyEstateButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.ValleyChardonnayButton = ((Microsoft.Kinect.Toolkit.Controls.KinectTileButton)(target));
            
            #line 197 "..\..\DisplayWhiteWine.xaml"
            this.ValleyChardonnayButton.Click += new System.Windows.RoutedEventHandler(this.ValleyChardonnayButton_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.ValleyRieslingButton = ((Microsoft.Kinect.Toolkit.Controls.KinectTileButton)(target));
            
            #line 202 "..\..\DisplayWhiteWine.xaml"
            this.ValleyRieslingButton.Click += new System.Windows.RoutedEventHandler(this.ValleyRieslingButton_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.BanrockMoscatoButton = ((Microsoft.Kinect.Toolkit.Controls.KinectTileButton)(target));
            
            #line 207 "..\..\DisplayWhiteWine.xaml"
            this.BanrockMoscatoButton.Click += new System.Windows.RoutedEventHandler(this.BanrockMoscatoButton_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.lblMessageDisplay = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

