   M S B A M L   `   `   `  ����J  FAugmentedRetail, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Microsoft.Samples.Kinect.ControlsBasics'Microsoft.Samples.Kinect.ControlsBasics  5   	   2    ,Microsoft.Samples.Kinect.ControlsBasics.Help   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   \ XMicrosoft.Kinect.Toolkit.Controls, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullS OMicrosoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=null2k(http://schemas.microsoft.com/kinect/2013   5   	   <d2http://schemas.microsoft.com/expression/blend/2008   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   	   Clocal5clr-namespace:Microsoft.Samples.Kinect.ControlsBasics   5   	   -   5        $��
HelpWindow��5   	     � Title$  HelpDetails��5	   	   $	��500��5   	   $	��700��5   	   $��Segoe UI)�5   	    � Icon$ Images/LoquorLand.png��6    � WindowState$ 	Maximized=�6<   
������� � 	Resources 5         ChevronGeometry  	ChevronUp �� Stretch
 �� Top �� FallbackValue �� Path �� RelativeSource	 �� AncestorType?  9Microsoft.Samples.Kinect.ControlsBasics.KinectHoverButton
 J� RenderTransformOrigin �� Angle  ChevronRight  ChevronDown  KinectHoverButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value " KinectHoverButtonScrollUpStyle �� BasedOn % !KinectHoverButtonScrollRightStyle $  KinectHoverButtonScrollDownStyle $  KinectHoverButtonScrollLeftStyle 	 ChevronLeft��%�  &	       &	 �    7   &	 Y   7   &	 .   7   &	     &	     7  7  &	 e    7  7  &	 �    7  7  &	 �    7  7 	 B�5   
   miF1M150.001,146.9932L126.565,169.3822L126.565,153.5962L150.001,130.6182L173.435,153.5962L173.435,169.3822z�5      F� 5   
   $��48��6!   $��48��6-   $ Uniform=�68   $ 0��6J   8��  ��5      �� $ Black��$ 
Foreground� �� "	  $
 0.5,0.5&�5   M   z�5      �� 5      $ 0Q�6"   5      F� 5   
   $��48��6$   $��48��60   $ Uniform=�6;   $ 0��6M   8��  ��5       �� $ Black��$ 
Foreground� �� "	  $
 0.5,0.5&�5!   M   z�5"      �� 5#      $ 90Q�6"   5%      F� 5'   
   $��48��6#   $��48��6/   $ Uniform=�6:   $ 0��6L   8��  ��5)      �� $ Black��$ 
Foreground� �� "	  $
 0.5,0.5&�5*   M   z�5+      �� 5,      $	 180Q�6"   5.      �� 5/   
   "  6/   .�50      ��  � ��
 �����6+   �� 51       � ��
 �����6,   �� 52       � ��$ 0q�60   6<   �� 53       � ��
 �����6;   �� 54       � �� 55      �� 56      "  6&   .R�57      � $��Stretch=�6   $��Stretch=�6=   #��z��6Y   #��z��6�   #��z��6�   .+�58      �� #��z��6%   #��z��6Y   ._�59   "   �� $��Stretch=�63   $��Stretch=�6Q   #��z��6m   6�   5:      5;      5<      5>       5?      P� 5@       � {� .  . �5A      ��  � ��
 �����63   �� 5B       � ��
 �����64   �� 5C       � ��
 ���� 6I   5D      P� 5E       �@ IsHandPointerOver . . �5G      ��  � ��
 �����63   �� 5H       � ��
 �����63   5I      5K      �� 5M   
   "  67   8   .�5N      ��  � ��8  6(   5O      �� 5Q   
   "  6:   8   .�5R      ��  � ��8  6(   5S      �� 5U   
   "  69   8   .�5V      ��  � ��8  6(   5W      �� 5Y   
   "  69   8   .�5Z      ��  � ��8  6(   5[      5]      .��5^      � $��-2,0,2,0q�6    � ColumnDefinitions 5_   
   �� 5`      $
��230* �6   �� 5a      $
��839* �6   �� 5b      $
��123* �6    � RowDefinitions 5d   
   �� 5e      $
��Auto �6   �� 5f      $��* �6   .+�5i   
   �� -   5         ��Name$ imgCanvasHelp��5i      $	��480��6(   $��90,0,109,189q�65   $��Bottom=�6K   $��2��6f   $��1��6w   .+�5j      � -   5         �Name$ KinectViewGridHelp��5j      $��325,10,109,189q�6/   $	��100��6G   $��Center=�6T   .+�5k      �� $��Center=�6   $	��Top=�65   $��Uniform=�6M   $	��277��6_   5l      5m      � 5o   
   $��0��6   $��10,0,0,0q�6   $��3��6/   $	��100��6C   $	��Top=�6P   .+�5q      8  2Microsoft.Kinect.Toolkit.Controls.KinectUserViewer  $	��100��6b   $��Center=�6o   $	��Top=�6�   $y�Hidden=�6�   4  .Microsoft.Kinect.Toolkit.Controls.KinectRegion   KinectRegion 6!   ��  �� ElementName$ kinectRegion��6�   4  .Microsoft.Kinect.Toolkit.KinectSensorChooserUI  5s      -   5          Name$ sensorChooserLocation��5s   [   $��Center=�6&   $	��Top=�6C   $��
1150,0,0,0q�6z   6�   5u        5w   
   -   5          Name$ kinectRegionHelp��5w      $��
0,0,-8,-71q�63   $	��716��6G   $��2��6T   $��Bottom=�6e   $��3��6�   .��5z      � -   5        $ kinectRegionGridHelp��5z      $
��10,0q�61   $	��735��6?    5{      �� 5|      $	��74* �6'   �� 5}      $
��363* �6'   �� 5~      $
��518* �6'   �� 5      $��0* �6'   �� 5�      $	��60* �6'    5�      �� 5�      $��* �6$   �� 5�      $	��170 �6$   .+�5�      �� $��Stretch=�6   $��Bottom=�66   $��Images/Image2.png��6Q   $��UniformToFill=�6l   $��-10,0,-146,110q�6�   $	��100��6�   $��5��6�   $��2��6�   8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  5�      -   5          Name$ 
homeButton��5�   %   $�� ��69   $
��Left=�6D   $��378,540,0,0q�6_   $	��Top=�6t   $��75��6�   $��85��6�   
�������
�������$��2��6�   $��2��6�   ��5�      �� 5�       �� ImageSource$ Images/home_button.png��6%   5�      �� 5�      $��Images/help.png��6   $��UniformToFill=�61   $��5��6I   $��0,-44,-31,65q�6]   � 5�      $��1��6   $��Stretch=�6$   $��Stretch=�6B   $��0, 10, 0, 10q�6^   $��5��6t    5�      �� 5�      $��* �6+   �� 5�      $��10 �6+   �� 5�      $��* �6+   5�      5�      5�      �� 5�   
   -   5         ��Name$ lblMessageHelp��5�      $�� ��6(   $
��Left=�63   $��	14,44,0,0q�6N   $��1��6a   $	��Top=�6n   $��75��6�   $	��290��6�   $��22(�6�   $��Showcard Gothic)�6�   $��2��6�   5�      5�      