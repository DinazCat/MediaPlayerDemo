   M S B A M L   `   `   `  ����G  CMedia_Player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Media_Player.UserControlsMedia_Player.UserControls  5      )    #Media_Player.UserControls.SongItem2   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Media_Player.UserControls     5      _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5	      �� -   5        $	��170��5	        �� CornerRadius$  10��6   ��5
   
   �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 ���� 6/   5      ._�5   
   ]� -   5         ]�Name$ ucitem2��5      $��4q�6%   .+�5      � $	��Top=�6   .+�5      �� $  10��6   ._�5      �� $	��170��6   
������ 
������ 6D   ��5      �� 5      -   5        Picture�� j� Stretch$
 Fill=�5   V    �� ImageSource 66   �� *	linkanh+6V   5      �� 5      -   5         ��Name$ BtnPlay��5      $��30��6*   $��30��66   $��Center=�6A   $��Center=�6\   $y�Hidden=�6�   ��6�   �� *getPL+��5      �� 5      .R�5      �� .+�5    "   ��  ��Name$
 play��6(   $��Center=�6R   $��Center=�6m   ��66   �� *
Linkicon+6m   5!      5"      5$      5%      � 5'      .+�5(      �� $��0,2,0,0q�6   .+�5)      �� 
�������$��12(�6M   $��Medium"�6[   ��6    �� *
songName+6[   �� 5*      -   5        $��1��5*         letterButton#���   6*   $��Medium"�6�   $��11(�6�   $��22��6�   ��6Q   �� *
singerName+6�   5+      5,      5-      	 � ContextMenu	 5/   
   �� 50      -   5        
 ��Name$
 songItemContextMenu��50      ���#000020
�������$y�Hidden=�6`   .@�51      m� -   5         m�Name$ deleteSongFromPL��51      $��Xóa khỏi playlist này��66    m� Icon 52      '  !MaterialDesignThemes.Wpf.PackIcon  53         Kind$ DeleteOutline=�62   $��18��6G   $��18��6S   
�������6^   55      m� 56      -   5        $ userPlaylistMenuItem��56      $��Thêm vào playlist��69   ���#000020
������� 57        58      $ 
PlusCircle=�62   $��17��6D   $��17��6P   
�������6[   ��5:      �� 5;      .R�5<      �� -	   5         �� Orientation$ 
Horizontal=�5<   )   .+�5=   "     $ PlaylistMusic=�6:   
�������$��20��6b   $��20��6m   � 5>   "   .+�5?   &   �� $&��                                 ��60   $��14(�6X   $
��15 0q�6f   �� 5@   &   
�������$��14(�6Z   $
��15 0q�6h   ��60   �� *title+6h   5A   #   5B      5C      5E      m� 5F      -
   5        $ addSongToPlayingList��5F      $!��Thêm vào danh sách phát��6:    5G        5H      $ PlaylistPlus=�62   $��19��6F   $��18��6R   
�������6]   5J      m� 5K      -   5        $ addSongToPlayNext��5K      $��Phát tiếp theo��67    5L        5M      $ ChevronRight=�62   $��19��6F   $��19��6R   
�������6]   5O      5P      5R      5T      