   M S B A M L   `   `   `  ����G  CMedia_Player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Media_Player.UserControlsMedia_Player.UserControls  5      (    "Media_Player.UserControls.SongItem   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Media_Player.UserControls     5      _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        $��songItem��5      .��5	      �� -   5          ��Name$  border��5	       �� CornerRadius$ 5��6   $��Disabled=�6�   ._�5   
   �  � ColumnDefinitions 5      �� 5      $
��1.3* �6#   �� 5      $��* �6#   �� 5      $	��130 �6#   .+�5      �� $P��J                                                                          ��6   $��2��6j   �� 5       �� Orientation$ 
Horizontal=�6   .+�5      � .+�5       �� -   5         ��Name$ Picture��5       $��50��6H   $��50��6T   $
��Fill=�6_   ��6-   �� *	linkanh+6_   �� 5"      -   5         ��Name$ BtnPlay��5"      
������ 
������ $��50��6b   $y�Hidden=�6n   ��6�   �� *getPL+��5#      �� 5$      .R�5%   "   �� $
 play��6(   $��Center=�66   $��Center=�6Q   $��20��5&   ,   $��20��68   $
��Fill=�6_   ��6C   �� *
Linkicon+6_   5'      5)      5*      � 5,       � RowDefinitions 5-      �� 5.      $��* �6(   �� 5/      $��* �6(   .+�51      ��  �� Padding$ 5 7 0 0q�52       
�������$��14(�54       ��51       �� *
songName+54       �� 56      -   5        $��1��56         letterButton#���   6*   $	��5 0q�58      $��12(�59      ��57      �� *
singerName+59      5:      5;      � 5<      $��1��6   .+�5=      �� -   5        #���   5=      $
��Left=�5?      $��Center=�5@      $��14(�5A      ��5>      �� *album+5B      5C      � 5D      $��2��6   .+�5E      �� $ 
Horizontal=�6   .+�5F      �� -   5        $ LibHeart��5G   0     MaterialDesignIconButton#��[ 5F      $��20��5G      $��20��6%   ��5H      �� 5I       �� 
TargetType" ��6.   .R�5J   "   �� ��6(   �� *LinkLikeIcon+5K      5M      �� 5N      $ 10q�5O       $
��42 0q�5P       $��Center=�5Q       
�������$��16(�5S       ��5N       �� *time+5S       5T      5U      5V      	 � ContextMenu	 5X   
   �� 5Y      -   5        
 ��Name$
 songItemContextMenu��5Y      ���#000020
�������$y�Hidden=�6`   .@�5Z      m� -	   5         m�Name$ deleteSongFromPL��5Z      $��Xóa khỏi playlist này��66    m� Icon 5[      '  !MaterialDesignThemes.Wpf.PackIcon  5\         Kind$ DeleteOutline=�62   $��18��6G   $��18��6S   
�������6^   5^      m� 5_      -
   5        $ userPlaylistMenuItem��5_      $��Thêm vào playlist��69   ���#000020
������� 5`        5a      $ 
PlusCircle=�62   $��17��6D   $��17��6P   
�������6[   ��5c      �� 5d      .R�5e      �� -   5        $ 
Horizontal=�5e   )   .+�5f   "     $ PlaylistMusic=�6:   
�������$��20��6b   $��20��6m   � 5g   "   .+�5h   &   �� $&��                                 ��60   $��14(�6X   $
��15 0q�6f   �� 5i   &   
�������$��14(�6Z   $
��15 0q�6h   ��60   �� *title+6h   5j   #   5k      5l      5n      m� 5o      -   5        $ addSongToPlayingList��5o      $!��Thêm vào danh sách phát��6:    5p        5q      $ PlaylistPlus=�62   $��19��6F   $��18��6R   
�������6]   5s      m� 5t      -   5        $ addSongToPlayNext��5t      $��Phát tiếp theo��67    5u        5v      $ ChevronRight=�62   $��19��6F   $��19��6R   
�������6]   5x      5y      5{      5|      