   M S B A M L   `   `   `  ����G  CMedia_Player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Media_Player.UserControlsMedia_Player.UserControls  5      )    #Media_Player.UserControls.LikedView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6uc'clr-namespace:Media_Player.UserControls     5      _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      �� -   5          ��Name$  scrollViewer��5
   {   $��1��6   $��1��6    ���	#FFCBD0D4.��5   
   � ��5      �� 5       �� EndPoint$	 0 1&�6&   .��5      �  � Color$ #000020��6#    � Offset$	 0.9Q�63   � 5      $ #003366��6#   $	 0.1Q�63   5      .+�5      �� $	��650��6   $
��Fill=�6$   $��/Images/HeartIcon.png��64    J� Opacity$	 0.6Q�6S   $	��Top=�6a   �� 5      .+�5      � $	��Top=�6   .+�5      �� -   5         ��Name$ txtTitle��5       $��Bài Hát Đã Thích��62   $��15 180 0 50q�6K   
�������$��50(�6t   $��Heavy"�6�   �� 5      -   5        $ txtDescription��5       $��Bottom=�68   $��20q�6S   
�������$��17(�6s   5      �� 5      $��0 1 0 0q�6   
�������63   � 5      $
��0 10q�6    � ColumnDefinitions 5      �� 5      $
��1.3* �6+   �� 5      $��* �6+   �� 5      $	��130 �6+   .+�5      �� $��	BÀI HÁT��6     �� Padding$
 10 0q�5       
�������$��16(�5"      �� 5#      $��1��6    $��ALBUM��60   
�������$��16(�5%      �� 5&      $��2��6    $��THỜI LƯỢNG��5'       $��Right=�5(       $
 10 0q�5)       
�������$��16(�5+       5,      �� 5.      -   5         ��Name$ 	listLiked��5.      $��Stretch=�6.   $��Hidden=�5/      ��50      �� 51      .R�52      (   "Media_Player.UserControls.SongItem  53      55      56      57      58      59      