﻿#pragma checksum "..\..\LandingPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CE1C157F26331041A8A00E5491FEFF75"
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
    /// LandingPage
    /// </summary>
    public partial class LandingPage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\LandingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Samples.Kinect.ControlsBasics.LandingPage LandingWindow;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\LandingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.KinectSensorChooserUI sensorChooserUiLanding;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\LandingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectRegion kinectRegionLanding;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\LandingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid kinectRegionGridDisplay;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\LandingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image myImage;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\LandingPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image myImage2;
        
        #line default
        #line hidden
        
        
        #line 192 "..\..\LandingPage.xaml"
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
            System.Uri resourceLocater = new System.Uri("/AugmentedRetail;component/landingpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LandingPage.xaml"
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
            this.LandingWindow = ((Microsoft.Samples.Kinect.ControlsBasics.LandingPage)(target));
            
            #line 9 "..\..\LandingPage.xaml"
            this.LandingWindow.Closing += new System.ComponentModel.CancelEventHandler(this.LandingPageClosing);
            
            #line default
            #line hidden
            
            #line 15 "..\..\LandingPage.xaml"
            this.LandingWindow.Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.sensorChooserUiLanding = ((Microsoft.Kinect.Toolkit.KinectSensorChooserUI)(target));
            return;
            case 3:
            this.kinectRegionLanding = ((Microsoft.Kinect.Toolkit.Controls.KinectRegion)(target));
            return;
            case 4:
            this.kinectRegionGridDisplay = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.myImage = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.myImage2 = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            this.lblMessageDisplay = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

