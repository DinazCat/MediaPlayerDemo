   M S B A M L   `   `   `  ����G  CMedia_Player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Media_Player.UserControlsMedia_Player.UserControls  5      ,    &Media_Player.UserControls.PlayListView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Media_Player.UserControls     5      -   5          >�Name$  playListView��5	      .��5
      �� -   5         ��Name$ scrollViewer��5
   {   $��1��6   $��1��6    ���	#FFCBD0D4.��5   
   � ��5      �� 5       �� EndPoint$	 0 1&�6&   .��5      �  � Color$ #000015��6#    � Offset$	 0.6Q�63   � 5      $ #003366��6#   $	 0.1Q�63   5      .+�5      �� $	��350��6   $
��Fill=�6!   $��/Images/universe.png��60   $	��Top=�6N   �� 5      .+�5      � $	��Top=�6   .+�5      �� -   5         ��Name$ txtTitle��5       $��15 150 0 50q�6J   
�������$��50(�6s   $��Heavy"�6�   ��62   �� *title+6�   �� 5      -   5        $ txtDescription��5       $��Bottom=�6U   $��20q�6p   
�������$��17(�6�   ��68   �� *description+6�   5      �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ BtnPlay��5      $��
20 0 100 0q�6.   ��5      �� 5      .R�5   "   �� .+�5   &   �� $��70��6H   $��70��6T   ��6,   �� *
Linkicon+6T   5   #   5      5!      �� 5"      -   5        $ BtnLove��5"      $��0 7 0 0q�6.   ��5#      �� 5$      .R�5%   "   �� .+�5&   &   �� $��63��6L   $��63��6X   ��6,   �� *LinkLikeIcon+6X   5'   #   5(      5*      5+      � 5.      $��	0 50 0 10q�6    � ColumnDefinitions 5/      �� 50      $
��1.3* �6+   �� 51      $��* �6+   �� 52      $	��130 �6+   .+�54      �� $��	BÀI HÁT��6    	 �� Padding$
	 10 0q�55      
�������$��16(�57      �� 58      $��1��6    $��ALBUM��60   
�������$��16(�5:      �� 5;      $��2��6    $��THỜI LƯỢNG��5<       $��Right=�5=       $
	 10 0q�5>       
�������$��16(�5@       5A      �� 5B      -   5        
 ��Name$
 listSongItem��5B      $��Disabled=�61   $��Stretch=�6e   ��5C      �� 5D      .R�5E      (   "Media_Player.UserControls.SongItem  5F      5H      5I      5J      5K      5L      