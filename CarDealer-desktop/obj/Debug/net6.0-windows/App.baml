   M S B A M L   `   `   `  ����L  HCarDealer-desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CarDealer_desktopCarDealer_desktop  5          CarDealer_desktop.App   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      1localclr-namespace:CarDealer_desktop     5        �� 	Resources  5       �� 
TargetType �� Property �� Value   myStyleButton �� 
TargetType �� Triggers P� Property P� Value  MaterialDesign �� MergedDictionaries	 �� Source  WindowColor  ContentAreaColorLight  ContentAreaColorDark  DisabledControlLightColor  DisabledControlDarkColor  DisabledForegroundColor  SelectedBackgroundColor 	 SelectedUnfocusedColor 
 ControlLightColor  ControlMediumColor  ControlDarkColor  ControlMouseOverColor  ControlPressedColor  
GlyphColor  GlyphMouseOver  BorderLightColor  BorderMediumColor  BorderDarkColor  PressedBorderLightColor  PressedBorderDarkColor  DisabledBorderLightColor  DisabledBorderDarkColor  DefaultBorderBrushDarkColor  HeaderTopColor " DatagridCurrentCellBorderColor  SliderTrackDarkColor  NavButtonFrameColor  MenuPopupBrush
 �� EndPoint �� 
StartPoint � Color � Offset $  ProgressBarIndicatorAnimatedFill  ComboBoxToggleButton � ColumnDefinitions'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value ��Name �� CornerRadius �� Color F�Name   ComboBoxTextBox ! myStyleCombobox R� KeyTime  System.Windows.Visibility   Visible R� Value   Hidden d�Name �� 	ClickMode  d� 	IsChecked! �� Mode" �� RelativeSource# ��Name$ J� IsHitTestVisible% �� SelectionBoxItem& �� SelectionBoxItemTemplate' ��Name( �� 
IsReadOnly) �� 
IsReadOnly* �Name+ �� IsDropDownOpen, � AllowsTransparency- �Name. J� SnapsToDevicePixels/ � ActualWidth0 �� MaxDropDownHeight1 K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation2   DirectionalNavigation3 �� 
TargetName4 P� 
SourceName5 �� Padding��%�$  '��       '�� �     '�� Z    '�� �    &	  �    &	 �    &	 �    &	 �    &	 �    &	 �    &	     &	 '    &	 H    &		 g    &	
 �    &	 �    &	 �    &	 �    &	     &	      &	 A    &	 �    &	 �    &	 �    &	 �    &	 	    &	 )	    &	 J	    &	 k	    &	 �	    &	 �	    &	 �	    &	 �	    &	 
    &	 �
    &	 �    7  7  7  7  7  &	  t    &	! �    7  7  7   '�� �    7  7 	 �� 5   
   " ��6   .�5      ��  � ��$ 5,5,5,5q�6'   �� 5	       � ��
 �   �6+   �� 5
       � ��$ 16(�6)   �� 5       � ��$ Cambria)�6+   5      �� 5   
   " ��6   .�5      ��  � ��$ 5,5,5,5q�6'   �� 5       � ��$ 16(�6)   �� 5       � ��$ Cambria)�6+   5      �� 5   
   " ��6   .�5      ��  � ��$ 5,5,5,5q�6'   �� 5       � ��$ 16(�6)   �� 5       � ��$ Cambria)�6+   5      �� 5   
   " ��6   .�5      ��  � ��$ 5,5,5,5q�6'   �� 5       � ��$ 16(�6)   �� 5       � ��$ Cambria)�6+   5       �� 5!   
   " ��6&   .�5"      ��  �@�OverridesDefaultStyle$
 True��66   �� 5#       � ��$ 5,5,5,5q�6'   �� 5$       � ��$ Cambria)�6+   �� 5%       � ��
 ��d�6+   �� 5&       � ��
 �����6+   �� 5'       � ��$ 16(�6)   �� 5(       � �� 5)      �� 5*      " ��6&   .R�5+      �� #��z��6!   
����d�$��1q�6h   ._�5,      �� $��Center=�6/   $��Center=�6L   5-       5.      P� 5/       �@J�IsMouseOver$
 True��6=   . �50   "   ��  � ��
 �   �6?   51      54      56      57      �� 59   
    5:      �� 5;      $e	 _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5<      $h	 bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5=      $t	 npack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Blue.xaml?�6%   5?      ��5C   
   	#FFE8EDF9��6/   ��5D   
   	#FFC5CBF9��69   ��5E   
   	#FF7381F9��68   ��5G   
   	#FFE8EDF9��6=   ��5H   
   	#FFC5CBF9��6<   ��5I   
   	#FF888888��6;   ��5K   
   #05ace2��69   ��5L   
   	#FFDDDDDD��6:   ��5N   
   	White��61   ��5O   
   Gray��61   ��5P   
   	#FF211AA9��64   ��5R   
   #05ace2��67   ��5S   
   #05ace2��65   ��5V   
   	#FF444444��6.   ��5W   
   /+sc#1, 0.004391443, 0.002428215, 0.242281124��6T   ��5Z   
   	#FFCCCCCC��64   ��5[   
   	#FF888888��65   ��5\   
   	#FF444444��63   ��5^   
   	#FF888888��6;   ��5_   
   	#FF444444��6:   ��5a   
   	#FFAAAAAA��6<   ��5b   
   	#FF888888��6;   ��5d   
   	Black��6;   ��5g   
   	#FFC5CBF9��62   ��5h   
   	Black��6>   ��5i   
   	#FFC5CBF9��68   ��5k   
   	#FF3843C4��67   �� 5m   
   $
 0.5,1&�5n      $ 0.5,0&�5o      .��5p      � # � 
 6   $ 0Q�5q      � 5r      # �  6   $	 0.5Q�5s      � 5t      # � 
 6   $ 1Q�5u      5v      �� 5x   
   $	 0,0&�5y      $	
 1,0&�5z      ��5|      � � 5}      $ 	#000000FF��6#   $ 0Q�5~      � 5      $ 	#600000FF��6#   $	 0.4Q�5�      � 5�      $ 	#600000FF��6#   $	 0.6Q�5�      � 5�      $ 	#000000FF��6#   $ 1Q�5�      5�      5�      �� 5�   
   " d�5�      .R�5�      �  5�      �� 5�      �� 5�      $��20 �6'    5�        5�      CommonStates��. 5�        
Normal��6&     5�      	MouseOver��. 5�      �� .��5�   "   �� $_ Y(Panel.Background).                 (GradientBrush.GradientStops)[1].(GradientStop.Color)�6?   $ Border��5�   +   .g�5�   &     $ 0��6:   8   5�   $   5�   #   5�      5�        5�      Pressed��6&     5�      Disabled��. 5�      �� .��5�   "   �� $_ Y(Panel.Background).                 (GradientBrush.GradientStops)[1].(GradientStop.Color)�6?   $ Border��5�   +   .g�5�   &     $ 0��6:   8  5�   $   5�   #   �� 5�   "   $; 5(Shape.Fill).                 (SolidColorBrush.Color)�6?   $ Arrow��5�   +   .g�5�   &     $ 0��6:   8  5�   $   5�   #   �� 5�   "   $a [(Border.BorderBrush).                 (GradientBrush.GradientStops)[1].(GradientStop.Color)�6?   $ Border��5�   +   .g�5�   &     $ 0��6:   8  5�   $   5�   #   5�      5�      5�        5�      CheckStates��. 5�        Checked��. 5�      �� .��5�   "   �� $_ Y(Panel.Background).                 (GradientBrush.GradientStops)[1].(GradientStop.Color)�6?   $ Border��5�   +   .g�5�   &     $ 0��6:   8  5�   $   5�   #   5�      5�        5�      	Unchecked��6&     5�      Indeterminate��6&   5�      .+�5�      �� $ Border��6   $��2��5�      $ 2��5�      $��1q�5�      ��5�      �� 5�      $	
 0,1&�6.   $	 0,0&�5�      .��5�      � # �  6+   $ 0Q�5�      � 5�      # �  6+   $ 1Q�5�      5�      ��5�      �� 5�      $	 0,0&�6.   $	
 0,1&�5�      ��5�   "   � � 5�   &   # � 
 63   � 5�   &   # �  63   $	 1.0Q�5�      5�   #   5�      5�      �� 5�      $��0��6   $ 2,0,0,2��5�      $��1q�5�      ��5�      �� 5�      # � 
 6*   5�      F� 5�      $ Arrow��6   $��1��5�      $��Center=�5�      $��Center=�5�      "����        � 	=  	= � z     	��5�      �� 5�      # �  6*   5�      5�      5�      �� 5�   
   " ��5�      .R�5�      �� $ PART_ContentHost��6   $|�False��5�      #��z��5�      5�      �� 5�   
   " ��6(   .�5�      ��  �@J�SnapsToDevicePixels$
 true��64   �� 5�       � ��$ 5,5,5,5q�6'   �� 5       � ��$ 16(�6)   �� 5      � ��$ Cambria)�6+   �� 5      �@�OverridesDefaultStyle$
 true��66   �� 5      � ��$
 Auto=�6K   �� 5      � ��$
 Auto=�6I   �� 5      � ��$
 true��6>   �� 5      � ��$	 120��6)   �� 5      � ��$ 20��6*   �� 5      � �� 5	     �� 5
     " ��6&   .R�5     �  5       5  "   CommonStates��. 5  &     
Normal��62     5  &   	MouseOver��62     5  &   Disabled��. 5  *   �� .��5  .   �� $ PART_EditableTextBox��6K   $6 0(TextElement.Foreground).(SolidColorBrush.Color)�5  1   .g�5  2     $ 0��6F   8   6R   5  /   5  +   5  '   5  #     5  "   
EditStates��. 5  &     Editable��. 5  *   �� .��5  .   T� $ (UIElement.Visibility)�6L   $ PART_EditableTextBox��5  2   ..�5  2   i� $ 0��6I   # Z 6U   5  /   T� 5   .   $ (UIElement.Visibility)�6L   $ ContentSite��6   ..�5!  2   i� $ 0��6I   # Z 6U   5"  /   5#  +   5$  '     5%  &   
Uneditable��62   5&  #   .+�5(     d� $ ToggleButton��6+   8�� $��2��5)  !   $|�false��5*  !   $ Press=�5+  !     5,  !   �� *IsDropDownOpen+$! TwoWay=�" �� *TemplatedParent+�� 5-     $# ContentSite��6/   $$ False��6D   #��z% 5.  !   #��z& 5/  !   #��z��50  !   $��3,3,23,3q�51  !   $��Stretch=�52  !   $
��Left=�53  !   54     �� 55     $' PART_EditableTextBox��6&   8�� $
��Left=�58      $��Bottom=�59      $��3,3,23,3q�5:      $
|�True��5;      
������ $y�Hidden=�5=      #) z( 5>      ��56      Z� 5>      � 5?     $* Popup��6$   $��Bottom=�5@  "   #��z+ 5A  "   $
, True��5B  "   $|�False��5C  "   $��Slide=�5D  "   .��5E  "   � $- DropDown��6'   $
. True��5F  #   #��z/ 5G  #   #��z0 5H  #   .+�5I  &   �� $ DropDownBorder��6-   $��1q�6E   ��5J  *   �� 5K  .   # �  6>   ��5M  *   �� 5N  .   # � 
 6>   5P  '   �� 5Q  &   $��4,6,4,6q�63   $
. True��6D   .��5R  *   �� $
1 True��65   $2 	Contained=�6H   5S  '   5T  #   5U     5V      5W     P� 5X      �@��HasItems$ false��6:   . �5Y  "   �� $3 DropDownBorder��6)    � ��$ 95��6Z   5Z     P� 5[      �@��
IsGrouping$
 true��6<   . �5\  "   ��  � ��$ false��6R   5]     P� 5^     $4 Popup��6&    �@�AllowsTransparency$
 true��6W   . �5_  "   �� $3 DropDownBorder��6)    �@��CornerRadius$ 4��6]   �� 5`  "   $3 DropDownBorder��6)    � ��$ 0,2,0,0q�6W   5a     5c     5e     5f     �� 5h  
   " ��5i     .�5j     ��  �@J�SnapsToDevicePixels$
 true��5k     �� 5l      �@�OverridesDefaultStyle$
 true��5m     �� 5n      � �� 5o     �� 5p     " ��6&   .R�5q     �� $ Border��6!   $5 2q�61   $
. true��6=   
������  5r       5s  "   SelectionStates��. 5t  &     
Unselected��62     5u  &   Selected��. 5v  *   �� .��5w  .   �� $ Border��6K   $0 *(Panel.Background).(SolidColorBrush.Color)�5x  1   .g�5y  2     $ 0��6F   8   6R   5z  /   5{  +   5|  '     5}  &   SelectedUnfocused��. 5~  *   �� .��5  .   �� $ Border��6K   $0 *(Panel.Background).(SolidColorBrush.Color)�5�  1   .g�5�  2     $ 0��6F   8  6R   5�  /   5�  +   5�  '   5�  #   ._�5�     �� 5�     5�     5�     5�     5�     5�     