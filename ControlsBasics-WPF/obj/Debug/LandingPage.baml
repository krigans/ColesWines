   M S B A M L   `   `   `  ����J  FAugmentedRetail, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Microsoft.Samples.Kinect.ControlsBasics'Microsoft.Samples.Kinect.ControlsBasics  5   	   9    3Microsoft.Samples.Kinect.ControlsBasics.LandingPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   \ XMicrosoft.Kinect.Toolkit.Controls, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullS OMicrosoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=null2k(http://schemas.microsoft.com/kinect/2013   5   	   <d2http://schemas.microsoft.com/expression/blend/2008   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   	   Clocal5clr-namespace:Microsoft.Samples.Kinect.ControlsBasics   5   	   -   5        $��LandingWindow��5   	     � Title$  AugmentTrial��5
   	   $	��500��5   	   $	��700��5   	   $��Segoe UI)�5   	    � Icon$ Images/LoquorLand.png��6    � WindowState$ 	Maximized=�6<   
�������$
��1124��5   3   $��693.233��6@    � 	Resources 5         ChevronGeometry  	ChevronUp �� Stretch
 �� Top �� FallbackValue �� Path �� RelativeSource	 �� AncestorType?  9Microsoft.Samples.Kinect.ControlsBasics.KinectHoverButton
 J� RenderTransformOrigin �� Angle  ChevronRight  ChevronDown  KinectHoverButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value " KinectHoverButtonScrollUpStyle �� BasedOn % !KinectHoverButtonScrollRightStyle $  KinectHoverButtonScrollDownStyle $  KinectHoverButtonScrollLeftStyle 	 ChevronLeft 

 FadeIn g� Duration �� TargetProperty W� From	 W� To  FadeOut��%�  &	       &	 �    7   &	 Y   7   &	 .   7   &	     &	      7  7  &	 i    7  7  &	 �    7  7  &	 �    7  7 	 &	
 D    &	 �    B�5   
   miF1M150.001,146.9932L126.565,169.3822L126.565,153.5962L150.001,130.6182L173.435,153.5962L173.435,169.3822z�5      F� 5   
   $��48��6!   $��48��6-   $ Uniform=�68   $ 0��6J   8��  ��5      �� $ Black��$ 
Foreground� �� "	  $
 0.5,0.5&�5   M   z�5      �� 5      $ 0Q�6"   5      F� 5   
   $��48��6$   $��48��60   $ Uniform=�6;   $ 0��6M   8��  ��5!      �� $ Black��$ 
Foreground� �� "	  $
 0.5,0.5&�5"   M   z�5#      �� 5$      $ 90Q�6"   5&      F� 5(   
   $��48��6#   $��48��6/   $ Uniform=�6:   $ 0��6L   8��  ��5*      �� $ Black��$ 
Foreground� �� "	  $
 0.5,0.5&�5+   M   z�5,      �� 5-      $	 180Q�6"   5/      �� 50   
   "  6/   .�51      ��  � ��
 �����6+   �� 52       � ��
 �����6,   �� 53       � ��$ 0q�60   6<   �� 54       � ��
 �����6;   �� 55       � �� 56      �� 57      "  6&   .R�58      � $��Stretch=�6   $��Stretch=�6=   #��z��6Y   #��z��6�   #��z��6�   .+�59      �� #��z��6%   #��z��6Y   ._�5:   "   �� $��Stretch=�63   $��Stretch=�6Q   #��z��6m   6�   5;      5<      5=      5?       5@      P� 5A       � {� .  . �5B      ��  � ��
 �����63   �� 5C       � ��
 �����64   �� 5D       � ��
 ���� 6I   5E      P� 5F       �@ IsHandPointerOver . . �5G      ��  � �� �#5A5B5B63   �� 5H       � ��
 �����63   5I      5K      �� 5M   
   "  67   8   .�5N      ��  � ��8  6(   5O      �� 5Q   
   "  6:   8   .�5R      ��  � ��8  6(   5S      �� 5U   
   "  69   8   .�5V      ��  � ��8  6(   5W      �� 5Y   
   "  69   8   .�5Z      ��  � ��8  6(   5[      �� 5]   
   .��5^      W� $ 0:0:.25D�6   $ Opacity�61   $ 0X�6U   $ 1X�6^   5_      �� 5`   
   .��5a      W� $ 0:0:.5D�6   $ Opacity�60   $ 0X�6T   5b      5d      .��5e      � $��	0,0,-3,-2q�6   $	��671��6   $	��Top=�6+    � ColumnDefinitions 5f   
   �� 5g      �� 5h      $��0* �6    � RowDefinitions 5j   
   �� 5k      $
��Auto �6   �� 5l      $��* �6   .+�5u   
   � $��0��6   $��
10,568,0,0q�6   $	��100��61   $	��Top=�6>   $��2��6V    5v      �� 5w      $
��615* �6#   �� 5x      $
��494* �6#   .+�5|      8  2Microsoft.Kinect.Toolkit.Controls.KinectUserViewer  $	��100��6i   $��Center=�6v   $	��Top=�6�   $y�Hidden=�6�   $��2��6�   $��488,0q�6�   4  .Microsoft.Kinect.Toolkit.Controls.KinectRegion   KinectRegion 6!   ��  �� ElementName$ kinectRegionLanding��6�   4  .Microsoft.Kinect.Toolkit.KinectSensorChooserUI  5~      -   5          Name$ sensorChooserUiLanding��5~   [   $��Center=�6&   $	��Top=�6C   $��515,0,-21,0q�6{   $��1��6�   6�   5�        5�   
   -   5          Name$ kinectRegionLanding��5�      $��	0,-6,-1,0q�66   $	��671��6I   $	��Top=�6V   $��1��6n   $
 0.513,0.509&�6{   $��2��6�   .��5�      � -   5         �Name$ kinectRegionGridDisplay��5�      $��
-15,0,10,0q�64   $	��670��6H    5�      �� 5�      $	��86* �6'   �� 5�      $
��419* �6'   �� 5�      $
��667* �6'    5�      �� 5�      $��* �6$   �� 5�      $	��170 �6$   .+�5�      �� $��Stretch=�6   $��Bottom=�66   $��Images/Image2.png��6Q   $��UniformToFill=�6l   $��
13,0,-5,-7q�6�   $��93��6�   $��3��6�   $��1��6�   �� 5�      $��0q�6   $	��Top=�6$   .+�5�      �� -   5         ��Name$ myImage��5�      $��UniformToFill=�6-   $
 0.5,0.5&�6E   $
��1493��6e   $	��580��6r   z�5�      V� 5�      .~�5�   "   T�   T� X$  0Q�65   ! T� Y$! 0Q�6;   5�      5�      �� 5�      -   5        $ myImage2��5�      $��UniformToFill=�6.   $
 0.5,0.5&�6F   $
��1493��6f   $	��580��6s   z�5�      V� 5�      .~�5�   "   T� $  0Q�65   $! 0Q�6;   5�      5�      5�      � 5�      $��1��6   $��Stretch=�6$   $��Stretch=�6B   $��0, 10, 0, 10q�6^   $��3��6t    5�      �� 5�      $��* �6+   �� 5�      $��10 �6+   �� 5�      $��* �6+   .+�5�        $��0��6.   #��[ 6>   $	��150��6�   $	��200��6�   $��55,53,51,-103q�6�   $y�Hidden=�6�   {�6x   �� *PageLeftEnabled+$ LandingWindow��.��5�        $��KinectHoverButton��62   $
��Left=�6N   $��	89,61,0,0q�6i   $	��Top=�6|   5�        5�      $��2��6.   #��[ 6>   $	��150��6�   $	��200��6�   $��49,53,58,-103q�6�   $y�Hidden=�6�   {�6y   �� *PageRightEnabled+$ LandingWindow��6�   5�      5�      5�      �� 5�   
   -   5        " ��Name$" lblMessageDisplay��5�      $�� ��6+   $
��Left=�66   $��	14,44,0,0q�6Q   $��1��6d   $	��Top=�6q   $��75��6�   $	��290��6�   $��22(�6�   $��Showcard Gothic)�6�   5�      5�      