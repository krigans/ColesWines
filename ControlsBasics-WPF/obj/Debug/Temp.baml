   M S B A M L   `   `   `  ����J  FAugmentedRetail, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Microsoft.Samples.Kinect.ControlsBasics'Microsoft.Samples.Kinect.ControlsBasics  5   	   2    ,Microsoft.Samples.Kinect.ControlsBasics.Temp   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   \ XMicrosoft.Kinect.Toolkit.Controls, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullS OMicrosoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=null2k(http://schemas.microsoft.com/kinect/2013   5   	   <d2http://schemas.microsoft.com/expression/blend/2008   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   	   Clocal5clr-namespace:Microsoft.Samples.Kinect.ControlsBasics   5   	   -   5        $��
HelpWindow��5   	     � Title$  Help information��5	   	    � WindowState$ 	Maximized=�6#   $��Segoe UI)�5
   	    � Icon$ Images/LoquorLand.png��6   $	��600��6<   $
��1200��6I    � 	Resources 5         ChevronGeometry  	ChevronUp �� Stretch
 �� Top �� FallbackValue �� Path �� RelativeSource	 �� AncestorType?  9Microsoft.Samples.Kinect.ControlsBasics.KinectHoverButton
 J� RenderTransformOrigin �� Angle  ChevronRight  ChevronDown  KinectHoverButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value " KinectHoverButtonScrollUpStyle �� BasedOn % !KinectHoverButtonScrollRightStyle $  KinectHoverButtonScrollDownStyle $  KinectHoverButtonScrollLeftStyle 	 ChevronLeft��%�  &	       &	 �    7   &	 Y   7   &	 .   7   &	     &	     7  7  &	 e    7  7  &	 �    7  7  &	 �    7  7 	 B�5   
   miF1M150.001,146.9932L126.565,169.3822L126.565,153.5962L150.001,130.6182L173.435,153.5962L173.435,169.3822z�5      F� 5   
   $��48��6!   $��48��6-   $ Uniform=�68   $ 0��6J   8��  ��5      �� $ Black��$ 
Foreground� �� "	  $
 0.5,0.5&�5   M   z�5      �� 5      $ 0Q�6"   5      F� 5   
   $��48��6$   $��48��60   $ Uniform=�6;   $ 0��6M   8��  ��5      �� $ Black��$ 
Foreground� �� "	  $
 0.5,0.5&�5   M   z�5      �� 5      $ 90Q�6"   5!      F� 5#   
   $��48��6#   $��48��6/   $ Uniform=�6:   $ 0��6L   8��  ��5%      �� $ Black��$ 
Foreground� �� "	  $
 0.5,0.5&�5&   M   z�5'      �� 5(      $	 180Q�6"   5*      �� 5+   
   "  6/   .�5,      ��  � ��
 �����6+   �� 5-       � ��
 �����6,   �� 5.       � ��$ 0q�60   6<   �� 5/       � ��
 �����6;   �� 50       � �� 51      �� 52      "  6&   .R�53      � $��Stretch=�6   $��Stretch=�6=   #��z��6Y   #��z��6�   #��z��6�   .+�54      �� #��z��6%   #��z��6Y   ._�55   "   �� $��Stretch=�63   $��Stretch=�6Q   #��z��6m   6�   56      57      58      5:       5;      P� 5<       � {� .  . �5=      ��  � ��
 �����63   �� 5>       � ��
 �����64   �� 5?       � ��
 ���� 6I   5@      P� 5A       �@ IsHandPointerOver . . �5C      ��  � ��
 �����63   �� 5D       � ��
 �����63   5E      5G      �� 5I   
   "  67   8   .�5J      ��  � ��8  6(   5K      �� 5M   
   "  6:   8   .�5N      ��  � ��8  6(   5O      �� 5Q   
   "  69   8   .�5R      ��  � ��8  6(   5S      �� 5U   
   "  69   8   .�5V      ��  � ��8  6(   5W      5Y      .��5Z      � $��-2,0,2,0q�6    � ColumnDefinitions 5[   
   �� 5\      $
��230* �6   �� 5]      $
��839* �6   �� 5^      $
��123* �6    � RowDefinitions 5`   
   �� 5a      $
��Auto �6   �� 5b      $��* �6   .+�5e   
   �� -   5         ��Name$ imgCanvasLocation��5e      $	��480��6,   $��90,0,109,189q�69   $��Bottom=�6O   $��2��6j   $��1��6{   .+�5f      � -   5         �Name$ KinectViewGridLocation��5f      $��325,10,109,189q�63   $	��100��6K   $��Center=�6X   .+�5g      �� $��Center=�6   $	��Top=�65   $��Uniform=�6M   $	��277��6_   5h      5i      � 5k   
   $��0��6   $��10,0,0,0q�6   $��3��6/   $	��100��6C   $	��Top=�6P   .+�5m      8  2Microsoft.Kinect.Toolkit.Controls.KinectUserViewer  $	��100��6b   $��Center=�6o   $	��Top=�6�   $y�Hidden=�6�   4  .Microsoft.Kinect.Toolkit.Controls.KinectRegion   KinectRegion 6!   ��  �� ElementName$ kinectRegion��6�   4  .Microsoft.Kinect.Toolkit.KinectSensorChooserUI  5o      -   5          Name$ sensorChooserLocation��5o   [   $��Center=�6&   $	��Top=�6C   $��
1150,0,0,0q�6z   6�   5q        5s   
   -   5          Name$ kinectRegionLocation��5s      $��5,-75,-8,-107q�67   $	��751��6N   $��2��6[   $��Bottom=�6l   $��3��6�   .��5v      � -   5        $ kinectRegionGridLocation��5v      $��10,20,10,20q�65    5w      �� 5x      $	��74* �6'   �� 5y      $
��363* �6'   �� 5z      $
��518* �6'   �� 5{      $��0* �6'   �� 5|      $	��60* �6'    5~      �� 5      $��* �6$   �� 5�      $	��170 �6$   .+�5�      �� $��Stretch=�6   $��Bottom=�66   $��Images/Image2.png��6Q   $��UniformToFill=�6l   $��-10,0,-146,96q�6�   $	��100��6�   $��5��6�   $��2��6�   8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  5�      -   5          Name$ closeButton��5�   %   $�� ��6:   $
��Left=�6E   $��492,529,0,0q�6`   $	��Top=�6u   $��75��6�   $��85��6�   
�������
�������$
 0.479,0.273&�6�   $��2��6�   $��2��6   ��5�      �� 5�       �� ImageSource$ /Images/Close_button.png��6%   5�      � 5�      .+�5�      r� -   5         r�Name$ myGif_1��5�   #    r� UnloadedBehavior$ Manual=�6S     r� Source$;  5file://D:\Wines\ControlsBasics-WPF\Images\Help_01.gif?�6m   ! r� Stretch$
! None=�6�   " r� LoadedBehavior$
" Play=�6�   $��20,67,-159,255q�6�   �� 5�      $��45,295,-134,221q�6    $��16(�69   $��Callibri)�6G   Move hand to select6r   r� 5�      -	   5        $ myGif_2��5�   #   $ Manual=�6S   $;  5file://D:\Wines\ControlsBasics-WPF\Images\Help_02.gif?�6m   $! Uniform=�6�   $
" Play=�6�   $��275,70,-409,265q�6�   �� 5�      $��0,293,-414,211q�6    $��16(�68   $��Callibri)�6F   $��Right=�6\   $	��215��6x   $!��Move hand forward to select��6�   r� 5�      -
   5        $ myGif_3��5�   #   $ Manual=�6S   $;  5file://D:\Wines\ControlsBasics-WPF\Images\Help_03.gif?�6m   $! Uniform=�6�   $
" Play=�6�   $��525,71,-659,266q�6�   �� 5�      $��560,295,-639,219q�6    $��16(�6:   $��Callibri)�6H   Press to select6o   r� 5�      -   5        $ myGif_4��5�   #   $ Manual=�6S   $;  5file://D:\Wines\ControlsBasics-WPF\Images\Help_04.gif?�6m   $! Uniform=�6�   $
" Play=�6�   $��770,62,-894,261q�6�   �� 5�      $��790,290,-889,211q�6    $��16(�6:   $��Callibri)�6H   $
 0.783,0.286&�6^   $%��Make fist to scroll up and down��6�   5�      � 5�      $��1��6   $��Stretch=�6$   $��Stretch=�6B   $��0, 10, 0, 10q�6^   $��5��6t    5�      �� 5�      $
��565* �6+   �� 5�      $	��17* �6+   �� 5�      $��10 �6+   �� 5�      $
��583* �6+   5�      5�      5�      �� 5�   
   -   5        # ��Name$# lblMessageLocation��5�      $�� ��6,   $
��Left=�67   $��	14,44,0,0q�6R   $��1��6e   $	��Top=�6r   $��75��6�   $	��290��6�   $��22(�6�   $��Showcard Gothic)�6�   $��2��6�   5�      5�      