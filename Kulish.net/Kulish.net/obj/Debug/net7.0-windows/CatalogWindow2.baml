   M S B A M L   `   `   `  ����E  AKulish.net, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Kulish.net.UserControlsKulish.net.UserControls  5   	   'clr-namespace:Kulish.net
Kulish.net  5   	       Kulish.net.CatalogWindow2   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >UserControls%clr-namespace:Kulish.net.UserControls     5   	   *localclr-namespace:Kulish.net     5   	     � Title$  CatalogWindow2��5	   	   $	��450��6    $	��800��6-   .��5
      � .+�5   
   �� $��Center=�6   $��42��61   $	��Top=�6=   $	��800��6U   ���	#FF3A3A3A$��0,-1,0,0q�6r   �� 5   
   -   5        $��Главная��5      $
��Left=�6#   $��86,8,0,0q�6>   $	��Top=�6P   $��18(�6h   
����������	#FF3A3A3A���	#FF3A3A3A$��Montserrat Medium)�6�   $��26��6�   $��79��6�   6�   �� 5   
   -   5        $��Каталог��5      $
��Left=�6#   $��	243,8,0,0q�6>   $	��Top=�6Q   $��18(�6i   
����������	#FF3A3A3A���	#FF3A3A3A$��Montserrat Medium)�6�   $��26��6�   $��78��6�   6�   �� 5   
   -   5        $��Контакты��5      $
��Left=�6$   $��	393,8,0,0q�6?   $	��Top=�6R   $��18(�6j   
����������	#FF3A3A3A���	#FF3A3A3A$��Montserrat Medium)�6�   $��26��6�   $��94��6�   6�   �� 5   
   -   5         ��Name$ 
SearchLine��5      $
��Left=�6&   $��32��6A    �� TextWrapping$
 Wrap=�6M   $	��Top=�6a   $	��382��6y   ���	#FFD0F7F0$��
149,53,0,0q�6�   $��Montserrat Medium)�6�   $��14(�6�   
�������6�   �� 5   
   $��
Поиск��6   $
��Left=�6    $��	74,53,0,0q�6;   $	��Top=�6N   $��Montserrat Medium)�6f   $��18(�6�   �� 5   
   -   5         ��Name$ SearchButton��5      $��540,49,219,0q�6'   $	��Top=�6=   $��42��6U   
�������
�������.��5      �� $��29��6   $��25��6    $��/search.png��6+   5      �� 5   
   -   5         ��Name$ Filter��5      $��586,59,74,0q�6#   $	��Top=�68    �� SelectedIndex$ 0��6P   .@�5      �� 
 � Tag$ 
sneakersID��6   .��6,   По умолчанию6:   �� 5      $ price��6   .��6'   
Цена6-   �� 5      $
 name��6   .��6&   Название60   5      �� 5   
   -   5        $%��Вход/регистрация��5      $��
542,8,60,0q�6,   $	��Top=�6@   $��18(�6X   
�������$��Montserrat Medium)�6y   ���	#FF3A3A3A���	#FF3A3A3A$��26��6�   6�   �� 5   
   $��0,91,0,0q�6   .��5      � -   5         �Name$ Cards��5      .+�5      )   #Kulish.net.UserControls.ProductCard  -	   5          Name$ Pattern��5      $	��150��6&   $	��250��62   $
��30 5q�6?   $y�	Collapsed=�6M   	 J� Effect	 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      
   
BlurRadius$
 15Q�6+      Opacity$	 0.5Q�6;   5"      5#      5$      5%      5&      