   M S B A M L   `   `   `  ����J  FAugmentedRetail, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Microsoft.Samples.Kinect.ControlsBasics'Microsoft.Samples.Kinect.ControlsBasics  5   	   8    2Microsoft.Samples.Kinect.ControlsBasics.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   \ XMicrosoft.Kinect.Toolkit.Controls, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullS OMicrosoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=null2k(http://schemas.microsoft.com/kinect/2013   5   	   <d2http://schemas.microsoft.com/expression/blend/2008   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   	   Clocal5clr-namespace:Microsoft.Samples.Kinect.ControlsBasics   5   	   -   5        $��ControlsBasicsWindow��5   	     � Title$  Cols Liquor Land��5	   	   $	��500��5   	   $	��700��5   	   $��Segoe UI)�5   	    � Icon$ Images/LoquorLand.png��6    � WindowState$ 	Maximized=�6<   
������� � 	Resources 5         ChevronGeometry  	ChevronUp �� Stretch
 �� Top �� FallbackValue �� Path �� RelativeSource	 �� AncestorType?  9Microsoft.Samples.Kinect.ControlsBasics.KinectHoverButton
 J� RenderTransformOrigin �� Angle  ChevronRight  ChevronDown  KinectHoverButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value " KinectHoverButtonScrollUpStyle �� BasedOn % !KinectHoverButtonScrollRightStyle $  KinectHoverButtonScrollDownStyle $  KinectHoverButtonScrollLeftStyle 	 ChevronLeft��%�  &	       &	 �    7   &	 Y   7   &	 .   7   &	     &	      7  7  &	 i    7  7  &	 �    7  7  &	 �    7  7 	 B�5   
   miF1M150.001,146.9932L126.565,169.3822L126.565,153.5962L150.001,130.6182L173.435,153.5962L173.435,169.3822z�5      F� 5   
   $��48��6!   $��48��6-   $ Uniform=�68   $ 0��6J   8��  ��5      �� $ Black��$ 
Foreground� �� "	  $
 0.5,0.5&�5   M   z�5      �� 5      $ 0Q�6"   5       F� 5"   
   $��48��6$   $��48��60   $ Uniform=�6;   $ 0��6M   8��  ��5$      �� $ Black��$ 
Foreground� �� "	  $
 0.5,0.5&�5%   M   z�5&      �� 5'      $ 90Q�6"   5)      F� 5+   
   $��48��6#   $��48��6/   $ Uniform=�6:   $ 0��6L   8��  ��5-      �� $ Black��$ 
Foreground� �� "	  $
 0.5,0.5&�5.   M   z�5/      �� 50      $	 180Q�6"   52      �� 54   
   "  6/   .�55      ��  � ��
 �����6+   �� 56       � ��
 �����6,   �� 57       � ��$ 0q�60   6<   �� 58       � ��
 �����6;   �� 59       � �� 5:      �� 5;      "  6&   .R�5<      � $��Stretch=�6   $��Stretch=�6=   #��z��6Y   #��z��6�   #��z��6�   .+�5=      �� #��z��6%   #��z��6Y   ._�5>   "   �� $��Stretch=�63   $��Stretch=�6Q   #��z��6m   6�   5?      5@      5A      5C       5D      P� 5E       � {� .  . �5F      ��  � ��
 �����63   �� 5G       � ��
 �����64   �� 5H       � ��
 ���� 6I   5I      P� 5J       �@ IsHandPointerOver . . �5K      ��  � �� �#5A5B5B63   �� 5L       � ��
 �   �63   5M      5O      �� 5Q   
   "  67   8   .�5R      ��  � ��8  6(   5S      �� 5U   
   "  6:   8   .�5V      ��  � ��8  6(   5W      �� 5Y   
   "  69   8   .�5Z      ��  � ��8  6(   5[      �� 5]   
   "  69   8   .�5^      ��  � ��8  6(   5_      5a      .��5c      �  � ColumnDefinitions 5d   
   �� 5e      $��1069* �6   �� 5f      $
��123* �6    � RowDefinitions 5h   
   �� 5i      $
��Auto �6   �� 5j      $��* �6   .+�5m   
   �� -   5         ��Name$ 	imgCanvas��5m      $	��480��6$   $��320,0,109,189q�61   $��Bottom=�6H   $��2��6c   .+�5n      � -   5         �Name$ KinectViewGrid��5n      $��325,10,109,189q�6+   $	��100��6C   $��Center=�6P   .+�5o      �� $��Center=�6   $	��Top=�65   $��Uniform=�6M   $	��277��6_   5p      5q      � 5s   
   $��0��6   $��10,0,0,0q�6   $��2��6/   $	��100��6C   $	��Top=�6P   .+�5u      8  2Microsoft.Kinect.Toolkit.Controls.KinectUserViewer  $	��100��6b   $��Center=�6o   $	��Top=�6�   $y�Hidden=�6�   4  .Microsoft.Kinect.Toolkit.Controls.KinectRegion   KinectRegion 6!   ��  �� ElementName$ kinectRegion��6�   4  .Microsoft.Kinect.Toolkit.KinectSensorChooserUI  5w      -   5          Name$ sensorChooserUi��5w   [   $��Center=�6&   $	��Top=�6C   $��
1150,0,0,0q�6t   6�   5y        5|   
   -   5          Name$ kinectRegion��5|      $��0,10,-23,-230q�6/   $��2��6F   $��2��6Z   
�������.��5~      � -   5        $ kinectRegionGrid��5~      $��10,20,10,20q�6-    5      �� 5�      $	��86* �6'   �� 5�      $
��419* �6'   �� 5�      $
��667* �6'    5�      �� 5�      $��* �6$   �� 5�      $	��170 �6$   .+�5�      � .+�5�      �� -   5        $ MyCanvas��5�      $��Center=�6/   $��-10,100,10,50q�6J    � Triggers 5�      :� 5�       :� RoutedEvent$ FrameworkElement.Loaded��6+    :� 
SourceName$ MyCanvas��6Q   .[�5�   "   �� .��5�   &   ��  �� 
TargetName$ panel��61     g� RepeatBehavior$  Forever��6O   .��5�   *   W� ! W� From$	! 1.0X�6:   	" W� To$	" 0.0X�6E   # g� Duration$# 0:0:10D�6N   $ �� TargetProperty$$ Opacity�6`   5�   '   5�   #   5�      .+�5�      �� -   5        % ��Name$% panel��5�   %   & �� Orientation$& Vertical=�64   ' �� Left$' 15��6K   $
 -250��6\   .+�5�      �� -	   5        ( ��Name$
( img1��5�   $   $��/Images/offers/Offer1.png��62   $	��426��6U   $	��240��6b   5�      5�      5�      � 5�      5�      :  4Microsoft.Kinect.Toolkit.Controls.KinectScrollViewer  5�      -
   5        )  Name$) scrollViewer��5�   4   $��0��6'   $	��Top=�6J   $��Disabled=�6b   $��Disabled=�6�   $��186,0,10,22q�6�   $��1��6�   $��2��6�   .��5�      � -   5        * �Name$* 	wrapPanel��5�   <   $��Center=�6    + � Orientation$+ 
Horizontal=�6O   
�������.+�5�      8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  ,   Label$, 1��6-   
�������67     5�      $, 2��6-   $	��223��67     5�      $, 3��6-     5�      $, 4��6-     5�      $, 5��6-     5�      $, 6��6-     5�      $, 7��6-     5�      $, 8��6-     5�      $, 9��6-     5�      $, 10��6-   5�      5�      �� 5�      $
��Left=�6   $��Bottom=�63   $��Images/Image2.png��6N   $��UniformToFill=�6i   $��-10,0,-320,52q�6�   $	��100��6�   $��3��6�   $
��1525��6�   � 5�      $��1��6   $��Stretch=�6$   $��Stretch=�6B   $��0, 10, 0, 10q�6^   $��3��6t    5�      �� 5�      $��* �6+   �� 5�      $��10 �6+   �� 5�      $��* �6+   .+�5�        ?   9Microsoft.Samples.Kinect.ControlsBasics.KinectHoverButton-   Click$- PageLeftButtonClick��6x   $��0��6.   #��[ 6>   $	��150��6�   $	��200��6�   {�6�   �� *PageLeftEnabled+$ ControlsBasicsWindow��.��5�        $��KinectHoverButton��62   $
��Left=�6N   $��	89,61,0,0q�6i   $	��Top=�6|   5�        5�      $- PageRightButtonClick��6y   $��2��6.   #��[ 6>   $	��150��6�   $	��200��6�   {�6�   �� *PageRightEnabled+$ ControlsBasicsWindow��6�   5�      �� 5�      -   5        . ��Name$. txtRecommendation��5�      $��2��67   $
��Left=�6G   $��135,560,0,0q�6b   $
��Wrap=�6w   $�� ��6�   
���E��$��22(�6�   $��	ExtraBold"�6�   $	��Top=�6�   $��60��6�   $	��520��6�   5�      5�      �� 5�   
   -   5        / ��Name$/ 
lblMessage��5�      $�� ��6$   $
��Left=�6/   $��	14,44,0,0q�6J   $��1��6]   $	��Top=�6j   $��75��6�   $	��290��6�   $��22(�6�   $��Showcard Gothic)�6�   5�      5�      