   M S B A M L   `   `   `  ����L  HCarDealer-desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CarDealer.WindowsCarDealer.Windows  5   	   ?$clr-namespace:CarDealer.UserControlsCarDealer.UserControls  5   	   (    "CarDealer.Windows.AnswerCallWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:CarDealer.Windows     5   	   9controls$clr-namespace:CarDealer.UserControls     5   	     � Title$  Заявка��5	   	   $	��450��6   $	��780��6%   .��5
      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $
��auto��6   $��Center=�6"   $��Center=�6?   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ NumCallReq_Label��5      �� 5      -   5        $��StatusCallReq_Label��5      �� 5      -   5        $��
Name_Label��5   5   $��Center=�6   65   �� 5      -   5        $��Phone_Label��5      $��Center=�6,   5      � 5       � ColumnDefinitions 5      �� 5      $
��auto �6'   �� 5      $��* �6'   �� 5      $��* �6'   .+�5      �� $��1q�6   
���   �$��10q�6A   ._�5      �� -   5         ��Name$ 	Car_Image��5      $
��auto��6/   $	��150��6<   $��5q�6L   5       �� 5!      $��1��6   .+�5"      �� -   5        $��
Mark_Label��5"      $��5,10,5,0q�6.   �� 5#      -   5        $��ModelName_Label��5#      $��14(�63   $��5,0,5,0q�6A   $��Britannic Bold)�6R   �� 5$      -   5        $��Country_Label��5$      $��5,0,5,0q�61   �� 5%      -	   5        $��HorsePower_Label��5%      $��5,0,5,0q�64   5&      �� 5'      $��2��6   .+�5(      �� -
   5        $��Color_Label��5(      �� 5)      -   5        $��BodyType_Label��5)      �� 5*      -   5        $��EngineType_Label��5*      �� 5+      -   5        $��
Cost_Label��5+      $��24(�6.   $
��Bold"�6<   5,      5-      5.      �� 5/   
   -   5         ��Name$ isAvailableCar_Stackpanel��5/   "   $��1��6   $��Center=�6E   $ 
Horizontal=�6b   .+�50      �� -   5        $��	Vin_Label��50      �� 51      -   5        $��MileAge_Lable��51      �� 52      -   5        $��Owners_Label��52      53      �� 54   
   -   5         ��Name$ SetManager_Border��54      $��2��6,   $��Center=�69   $��Center=�6V   
������� �� CornerRadius$ 10��6�   ._�55      �� .+�56      �� $��Менеджер:��6   �� 57      -   5        $��ManagerReq_Combobox��57      	 �� SelectedIndex$	 0��66   ��58      �� 59      .R�5:      �� �� 5;   "   �6&   �� *
LastName+ �� 5<   "   $� ��6&    �� 5=   "   �6&   �� *	FirstName+ �� 5>   "   $� ��6&    �� 5?   "   �6&   �� *
Patronymic+5@      5A      5C      �� 5D      -   5        
 ��Name$
 SetManager_Button��5D   %   $	��100��6   $��Назначить��6@      myStyleButton#��[  6T   6{   5E      5F      �� 5G   
   5I      � 5J   
   $��3��6    5K      �� 5L      �� 5M      �� 5N      �� 5O      .+�5Q      �� -   5        $
 Back_Button��5Q      $��3��6*   $��
Назад��6:   #��[  6J   6q   �� 5R      -   5        $
 CloseCallReq_Button��5R   )   $y�Hidden=�6   $��2��6F   $!��Закрыть заявку��6V   #��[  6o   6�   5S      5T      5U      