   M S B A M L   `   `   `  ����J  FAugmentedRetail, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Microsoft.Samples.Kinect.ControlsBasics'Microsoft.Samples.Kinect.ControlsBasics  5   	   >    8Microsoft.Samples.Kinect.ControlsBasics.DisplayWhiteWine   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   \ XMicrosoft.Kinect.Toolkit.Controls, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullS OMicrosoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=null2k(http://schemas.microsoft.com/kinect/2013   5   	   Clocal5clr-namespace:Microsoft.Samples.Kinect.ControlsBasics   5   	   <d2http://schemas.microsoft.com/expression/blend/2008   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   
   -   5        $��DisplayWhiteWineWindow��5   	     � Title$  DisplayWhiteWine��5	   	   $	��500��5   	   $	��700��5   	   $��Segoe UI)�5   	    � Icon$ Images/LoquorLand.png��6    � WindowState$ 	Maximized=�6<   
������� � 	Resources 5         ChevronGeometry  	ChevronUp �� Stretch
 �� Top �� FallbackValue �� Path �� RelativeSource	 �� AncestorType?  9Microsoft.Samples.Kinect.ControlsBasics.KinectHoverButton
 J� RenderTransformOrigin �� Angle  ChevronRight  ChevronDown  KinectHoverButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value " KinectHoverButtonScrollUpStyle �� BasedOn % !KinectHoverButtonScrollRightStyle $  KinectHoverButtonScrollDownStyle $  KinectHoverButtonScrollLeftStyle 	 ChevronLeft��%�  &	       &	 �    7   &	 Y   7   &	 .   7   &	     &	      7  7  &	 i    7  7  &	 �    7  7  &	 �    7  7 	 B�5   
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
   "  6/   .�53      ��  � ��
 �����6+   �� 54       � ��
 �����6,   �� 55       � ��$ 0q�60   6<   �� 56       � ��
 �����6;   �� 57       � �� 58      �� 59      "  6&   .R�5:      � $��Stretch=�6   $��Stretch=�6=   #��z��6Y   #��z��6�   #��z��6�   .+�5;      �� #��z��6%   #��z��6Y   ._�5<   "   �� $��Stretch=�63   $��Stretch=�6Q   #��z��6m   6�   5=      5>      5?      5A       5B      P� 5C       � {� .  . �5G      ��  � ��
 �����63   �� 5H       � ��
 �����64   �� 5I       � ��
 �����5J      5K      P� 5L       �@ IsHandPointerOver . . �5O      ��  � ��
 �����63   �� 5P       � ��
 �����63   5Q      5S      �� 5U   
   "  67   8   .�5V      ��  � ��8  6(   5W      �� 5Y   
   "  6:   8   .�5Z      ��  � ��8  6(   5[      �� 5]   
   "  69   8   .�5^      ��  � ��8  6(   5_      �� 5a   
   "  69   8   .�5b      ��  � ��8  6(   5c      5e      .��5f      �  � ColumnDefinitions 5g   
   �� 5h      $��1069* �6   �� 5i      $
��123* �6    � RowDefinitions 5k   
   �� 5l      $
��Auto �6   �� 5m      $��* �6   .+�5p   
   �� -   5         ��Name$ imgCanvasDisplay��5p      $	��480��6+   $��320,0,109,189q�68   $	��Top=�6O   $��2��6g   .+�5q      � -   5         �Name$ KinectViewGridDisplay��5q      $��325,10,109,189q�62   $	��100��6J   $��Center=�6W   .+�5r      �� $��Center=�6   $	��Top=�65   $��Uniform=�6M   $	��277��6_   5s      5t      � 5v   
   $��0��6   $��10,0,0,0q�6   $��2��6/   $	��100��6C   $	��Top=�6P   .+�5y      8  2Microsoft.Kinect.Toolkit.Controls.KinectUserViewer  $	��100��6i   $��Center=�6v   $	��Top=�6�   $y�Hidden=�6�   4  .Microsoft.Kinect.Toolkit.Controls.KinectRegion   KinectRegion 6!   ��  �� ElementName$ kinectRegionDisplay��6�   4  .Microsoft.Kinect.Toolkit.KinectSensorChooserUI  5{      -   5          Name$ sensorChooserUiDisplay��5{   [   $��Center=�6&   $	��Top=�6C   $��
1150,0,0,0q�6{   
�������
�������6�   5}      �� 5   
   $
��Left=�6   $��Center=�6+   $��Images/Red_Wine_Desc.png��6G   $��5,-220,0,-40q�6i   $��Uniform=�6   $
��1160��6�   $	��245��6�   $��2��6�     5�   
   -   5          Name$ kinectRegionDisplay��5�      $��1,0,116,-111q�66   $	��756��6L   $��2��6Y   $��Bottom=�6j   $��2��6�   
�������
�������.��5�      � -   5        $ kinectRegionGridDisplay��5�      $��5,0,15,0q�64    5�      �� 5�      $	��73* �6'   �� 5�      $
��326* �6'   �� 5�      $	��35* �6'   �� 5�      $
��565* �6'    5�      �� 5�      $��* �6$   �� 5�      $	��170 �6$   .+�5�      �� $��Stretch=�6   $��Bottom=�66   $��Images/Image2.png��6Q   $��UniformToFill=�6l   $��-10,0,-130,121q�6�   $��89��6�   $��4��6�   $��2��6�   8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  5�      -   5          Name$ homeChoiceButton��5�   %   $�� ��6?   $
��Left=�6J   $��462,556,0,0q�6e   $	��Top=�6z   $��75��6�   $��85��6�   
�������
�������$��3��6�   $��2��6�   ��5�      �� 5�       �� ImageSource$ Images/home_button.png��6%   5�        5�      -   5        $ backChoiceButton��5�   %   $�� ��6?   $
��Left=�6J   $��587,554,-107,0q�6e   $	��Top=�6}   $��75��6�   $��85��6�   
�������
�������$
 0.479,0.273&�6�   $��3��6�   $��2��6'  ��5�      �� 5�      $ /Images/back_button.png��6%   5�      � 5�      $��1��6   $��Stretch=�6$   $��Stretch=�6B   $��0,12,0,8q�6^   $��4��6p    5�      �� 5�      $��* �6+   �� 5�      $��10 �6+   �� 5�      $��* �6+   .+�5�        ?   9Microsoft.Samples.Kinect.ControlsBasics.KinectHoverButton   Click$ PageLeftButtonClick��6x   $��0��6.   #��[ 6>   $	��150��6�   $	��200��6�   $��55,53,51,-103q�6�   
�������{�6�   �� *PageLeftEnabled+$ DisplayWineWindow��.��5�        $��KinectHoverButton��62   $
��Left=�6N   $��	89,61,0,0q�6i   $	��Top=�6|   5�        5�      $ PageRightButtonClick��6y   $��2��6.   #��[ 6>   $	��150��6�   $	��200��6�   $��49,53,58,-103q�6�   {�6�   �� *PageRightEnabled+$ DisplayWineWindow��6�   5�      :  4Microsoft.Kinect.Toolkit.Controls.KinectScrollViewer  5�      -	   5          Name$ scrollViewerDisplay��5�   4   $��0��6'   $��Disabled=�6Q   $��Visible=�6{   $��176,2,110,40q�6�   $��1��6�   $��3��6�   
�������.��5�      � -
   5          �Name$  wrapPanelDisplay��5�   9   $	��Top=�6    ! � Orientation$! Vertical=�6S   
�������.+�5�        -   5        $ AmberleyEstateButton��5�   -   $�� ��6K   $
��Left=�6V   $	��Top=�6r   $	��200��6�   $	��700��6�   
�������
�������$
 0.479,0.273&�6�   ��5�      �� 5�   "   $> 8/Images/WhiteWine/Amberley Estate Chenin Blanc 750mL.png��6-   5�        5�      -   5        $ ValleyChardonnayButton��5�   -   $�� ��6M   $
��Left=�6X   $	��Top=�6t   $	��200��6�   $	��700��6�   
�������
���������5�      �� 5�   "   $E ?Images/WhiteWine/Annie's Lane Clare Valley Chardonnay 750mL.png��6-   5�        5�      -   5        $ ValleyRieslingButton��5�   -   $�� ��6K   $
��Left=�6V   $	��Top=�6r   $	��200��6�   $	��700��6�   
�������
���������5�      �� 5�   "   $C =Images/WhiteWine/Annie's Lane Clare Valley Riesling 750mL.png��6-   5�        5�      -   5        $ BanrockMoscatoButton��5�   -   $�� ��6K   $
��Left=�6V   $	��Top=�6r   $	��200��6�   $	��700��6�   
�������
���������5�      �� 5�   "   $8 2Images/WhiteWine/Banrock Station Moscato 750mL.png��6-   5�      5�      5�      � 5�      $��1��6   $��Stretch=�6$   $��Stretch=�6B   $��0, 10, 0, 10q�6^   $��3��6t    5�      �� 5�      $��* �6+   �� 5�      $��10 �6+   �� 5�      $��* �6+   .+�5�        $ PageLeftButtonClick��6x   $��0��6.   #��[ 6>   $	��150��6�   $	��200��6�   $��29,70,33,-120q�6�   {�6�   �� *PageLeftEnabled+$ DisplayWineWindow��.��5�        $��KinectHoverButton��62   $
��Left=�6N   $��	89,61,0,0q�6i   $	��Top=�6|   5�        5�      $ PageRightButtonClick��6y   $��2��6.   #��[ 6>   $	��150��6�   $	��200��6�   $��32,85,30,-135q�6�   {�6�   �� *PageRightEnabled+$ DisplayWineWindow��6�   5�      5�      5�      �� 5�   
   -   5        " ��Name$" lblMessageDisplay��5�      $�� ��6+   $
��Left=�66   $��	14,44,0,0q�6Q   $��1��6d   $	��Top=�6q   $��75��6�   $	��290��6�   $��22(�6�   $��Showcard Gothic)�6�   5�      5�      