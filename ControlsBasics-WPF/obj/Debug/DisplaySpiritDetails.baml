   M S B A M L   `   `   `  ����J  FAugmentedRetail, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Microsoft.Samples.Kinect.ControlsBasics'Microsoft.Samples.Kinect.ControlsBasics  5   	   B    <Microsoft.Samples.Kinect.ControlsBasics.DisplaySpiritDetails   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   \ XMicrosoft.Kinect.Toolkit.Controls, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullS OMicrosoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=null2k(http://schemas.microsoft.com/kinect/2013   5   	   <d2http://schemas.microsoft.com/expression/blend/2008   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   	   Clocal5clr-namespace:Microsoft.Samples.Kinect.ControlsBasics   5   	   -   5        $��SpiritDescriptionWindow��5   	     � Title$  FortifiedDetails��5	   	   $	��500��5   	   $	��700��5   	   $��Segoe UI)�5   	    � Icon$ Images/LoquorLand.png��6    � WindowState$ 	Maximized=�6<   
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
   �� -   5         ��Name$ imgCanvasDisplay��5i      $	��480��6+   $��90,0,109,189q�68   $��Bottom=�6N   $��2��6i   $��1��6z   .+�5j      � -   5         �Name$ KinectViewGridDisplay��5j      $��325,10,109,189q�62   $	��100��6J   $��Center=�6W   .+�5k      �� $��Center=�6   $	��Top=�65   $��Uniform=�6M   $	��277��6_   5l      5m      � 5o   
   $��0��6   $��10,0,0,0q�6   $��3��6/   $	��100��6C   $	��Top=�6P   .+�5r      8  2Microsoft.Kinect.Toolkit.Controls.KinectUserViewer  $	��100��6b   $��Center=�6o   $	��Top=�6�   $y�Hidden=�6�   4  .Microsoft.Kinect.Toolkit.Controls.KinectRegion   KinectRegion 6!   ��  �� ElementName$ kinectRegion��6�   4  .Microsoft.Kinect.Toolkit.KinectSensorChooserUI  5t      -   5          Name$# sensorChooserUiDisplayDetails��5t   [   $��Center=�6&   $	��Top=�6C   $��
1150,0,0,0q�6�   6�   5v        5{   
   -   5          Name$ kinectRegionDisplay��5{      $��
0,0,0,-106q�66   $	��751��6J   $��2��6W   $��Bottom=�6h   $��2��6�   
�������.��5~      � -   5        $ kinectRegionGridDisplay��5~      $��10,20,10,20q�64    5      �� 5�      $	��74* �6'   �� 5�      $
��363* �6'   �� 5�      $
��518* �6'   �� 5�      $��0* �6'   �� 5�      $	��60* �6'    5�      �� 5�      $��* �6$   �� 5�      $	��170 �6$   .+�5�      �� $��Stretch=�6   $��Bottom=�66   $��Images/Image2.png��6Q   $��UniformToFill=�6l   $��-10,0,-161,94q�6�   $	��100��6�   $��5��6�   $��2��6�   8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  5�      -   5          Name$ homeChoiceButton��5�   %   $�� ��6?   $
��Left=�6J   $��417,533,0,0q�6e   $	��Top=�6z   $��75��6�   $��85��6�   
�������
�������$��2��6�   $��2��6�   $��3��6  ��5�      �� 5�       �� ImageSource$ Images/home_button.png��6%   5�        5�      -   5        $ backChoiceButton��5�   %   $�� ��6?   $
��Left=�6J   $��534,532,-22,0q�6e   $	��Top=�6|   $��75��6�   $��85��6�   
�������
�������$
 0.479,0.273&�6�   $��2��6�   $��2��6&  $��3��67  ��5�      �� 5�      $ /Images/back_button.png��6%   5�        5�      -	   5        $ locationButton��5�   %   $�� ��6=   $
��Left=�6H   $��518,421,-21,0q�6c   $	��Top=�6z   $��79��6�   $	��100��6�   
�������
�������$
 0.479,0.273&�6�   $��2��6�   $��3��6#  ��5�      �� 5�      $! /Images/location_button.png��6%   5�      :  4Microsoft.Kinect.Toolkit.Controls.KinectScrollViewer  5�      -
   5          Name$ scrollViewerDisplay��5�   4   $��0��6'   $��Disabled=�6Q   $��Disabled=�6{   $��0,-41,-136,97q�6�   $��5��6�   .��5�      �� $
��Left=�6   $	��Top=�67   $H��BImages/Fortified/Brown Brothers Australian Tawny 750mL_Details.png��6O   $
��Fill=�6�   $	��507��6�   $
��1025��6�   5�      � 5�      $��1��6   $��Stretch=�6$   $��Stretch=�6B   $��0, 10, 0, 10q�6^   $��5��6t    5�      �� 5�      $��* �6+   �� 5�      $��10 �6+   �� 5�      $��* �6+   .+�5�        ?   9Microsoft.Samples.Kinect.ControlsBasics.KinectHoverButton   Click$ PageLeftButtonClick��6x   $��0��6.   #��[ 6>   $	��150��6�   $	��200��6�   $��185,85,185,-135q�6�   {�6�   �� *PageLeftEnabled+$ WineDescriptionWindow��.��5�        $��KinectHoverButton��62   $
��Left=�6N   $��	89,61,0,0q�6i   $	��Top=�6|   5�        5�      $ PageRightButtonClick��6y   $��2��6.   #��[ 6>   $	��150��6�   $	��200��6�   $��180,75,189,-125q�6�   {�6�   �� *PageRightEnabled+$ WineDescriptionWindow��6�   5�      5�      5�      �� 5�   
   -   5          ��Name$  lblMessageDisplay��5�      $�� ��6+   $
��Left=�66   $��	14,44,0,0q�6Q   $��1��6d   $	��Top=�6q   $��75��6�   $	��290��6�   $��22(�6�   $��Showcard Gothic)�6�   $��2��6�   5�      5�      