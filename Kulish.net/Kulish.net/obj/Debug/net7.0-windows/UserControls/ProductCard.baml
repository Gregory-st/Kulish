   M S B A M L   `   `   `  ����E  AKulish.net, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Kulish.net.UserControlsKulish.net.UserControls  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      )    #Kulish.net.UserControls.ProductCard   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Kulish.net.UserControls     5      6sys&clr-namespace:System;assembly=mscorlib     5      $	��150��5	      $	��100��6     � 	Resources  5
       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   	Direction   
BlurRadius	   Opacity
   ShadowDepth ]� Thumb��%  '��       �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� 
�������$ 5��5   !   $��10��5   !    5        5   "   $	 315Q�63   $ 10Q�6C   $		 0.4Q�6S   $
 2Q�6a   ._�5      ]� $��
PART_Track��6$   $
��True��66    5   "   n� 5   &   
���������5   *   �� 5   .   " n�6>   .R�5   2   �� #��z��5   5   #��z��5   5   #��z��5   5   $ 5��5   5   5   /   5!   '   5#      5$      5%      5'      5(      5)      .��5*      �� $ 10��6   
�������._�5+   
   ]� $
��True��6   .+�5,      �� -   5        $��10 5 0 0q�5-      $	��Top=�5.      $
��Left=�5/      $��20��50      $��20��51      $��60��52      $��60��53      $ 5��54      
������� 56        57      $	 315Q�58      $ 10Q�59         Color$ Black��5:      $
 2Q�5;      $		 0.5Q�5<      5>      � 5?      $��5q�6    � RowDefinitions 5@      �� 5A      �� 5B      .+�5E      �� $��0��6   
�������$ 10��69   $��80��6K   $��50��6Z    5F        5G      $ 15Q�5H      $
 3Q�5I      $ Black��5J      $		 0.5Q�5K      ._�5N      �� -   5         ��Name$ Resourse��5N      $	��5 3q�6.   5O      ]� 5Q      $
��True��6   $��1��61   $��0 5 0 0q�6>   .+�5R      (� $	��Top=�6   .��5S      �� $��0,0,0,1q�5T      
���   �$ 5��5V      $��90��5W      ._�5X      �� -   5         ��Name$ ProductName��5Y   !    �� TextAlignment$ Center=�5Z   !   $��Roboto)�5[   !   $
��Wrap=�5\   !   $��10(�65   Название5^      5_      5`      (� 5a      $��Bottom=�6   .��5b      �� $��0,1,0,0q�5c      
���   �$ 3��5e      $��90��5f      ._�5g      �� -   5        $ ProductPrice��5h   !   $ Center=�5i   !   $��Roboto)�5j   !   $
��Wrap=�5k   !   $��11(�65   
Цена5m      5n      5o      �� 5p      $
��Auto=�6#   $	��0 5q�6F   $��40��6S   .��5q      �� .+�5r      �� -   5        $ ProductDiscription��5s   %   $��11(�5t   %   $
��Wrap=�5u   %   $��Roboto)�5v   %   Описание5x      5y      5z      5{      5|      5}      5~      5      