   M S B A M L   `   `   `  ����G  CMedia_Player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Media_Player.UserControlsMedia_Player.UserControls  5      *    $Media_Player.UserControls.ResultView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Media_Player.UserControls     5      .��5	      �� -   5          ��Name$  scrollViewer��5	   {   $��1��6   $��1��6    ���	#FFCBD0D4.��5
   
   � .+�5      ]� ���#000020.+�5      � $	��Top=�6   .+�5      �� -   5         ��Name$ txtKQ��5       $��Center=�60   $��8q�6K   
�������$��20(�6j   $��Medium"�6x   6�   5      �� 5      ��5      �� 5       �� EndPoint$	 0 1&�6.   .��5      �  � Color$ #000015��6+    � Offset$	 0.6Q�6;   � 5      $ #003366��6+   $	 0.1Q�6;   5      .+�5      �� -   5        $ Nghesi��5       
�������$��20(�6C   $��5q�6Q   �� 5      -   5         ��Name$ ListArtistResult��5      ��5      �� 5      .R�5   "   ��  �� Orientation$ 
Horizontal=�6-   5      ��5      �� 5      .R�5    "   ]� $	��6 4q�6,   .+�5!   &   � $	��190��6+   $	��190��69   $	��Top=�6E   ��5"   *   �� 5#   .    �� 
TargetType" �64    �� Triggers 5$   2   P� 5%   6   	 P� Property	 �@J�IsMouseOver
 P� Value$

 True��6U   . �5&   :   ��  �� Property �@J�Opacity �� Value$	 0.6Q�6T   5'   7   5)   /   .+�5+   *   ��  �� CornerRadius$	 100��61    �� Padding$ 3q�6D   ._�5,   .   �� -   5        $	��190��5,   5   
������ 
������ 6u   ��5-   .   �� 5.   2   Picture�� j� Stretch$
 Fill=�6n    �� ImageSource 6N   �� *	picture+6n   50   +   51   '   �� 52   &   $��2q�6G   
�������$��14(�6e   $��Medium"�6s   $��Center=�6�   ��60   �� *title+6�   53   #   54      56      �� 58      -   5        $ Baihat��58       
�������$��20(�6C   $��5 10 5 5q�6Q   �� 59      -   5        $ ListSongResult��59      $��Stretch=�67   ��5:      �� 5;      .R�5<   "   (   "Media_Player.UserControls.SongItem  5=      5?      �� 5A      -   5        $ PlaylistAlbum��5A       
�������$��20(�6J   $��5q�6X   �� 5B      -	   5        $ ListPLResult��5B      ��5C      �� 5D      .R�5E   "   �� $ 
Horizontal=�6-   5F      ��5H      �� 5I      .R�5J   "   ]� $��4q�6,   .+�5K   &   � $	��180��6+   $	��230��68   $	��Top=�6D   ��5L   *   �� 5M   .   " �64   .�5N   2   ��  �@J�Opacity$ 1Q�6L    5O   2   P� 5P   6   	 �@J�IsMouseOver$

 True��6U   . �5Q   :   ��  �@J�Opacity$	 0.6Q�6T   5R   7   5T   /   .+�5V   *   �� $ 15��61   ._�5W   .   �� -
   5        $	��180��5W   5   
������ 
������ 6u   ��5X   .   �� 5Y   2   Picture��$
 Fill=�6n    6N   �� *	picture+6n   5[   +   5\   '   �� 5]   &   $��2q�6G   
�������$��15(�6e   $��Medium"�6s   ��60   �� *title+6s   5^   #   5_      5a      5b      5c      5d      5e      5f      