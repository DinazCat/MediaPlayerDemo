   M S B A M L   `   `   `  ����G  CMedia_Player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Media_Player.UserControlsMedia_Player.UserControls  5      '    !Media_Player.UserControls.LibView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Media_Player.UserControls     5      _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6D   .��5	      �� -   5          ��Name$  scrollViewer��5	   {   $��1��6   $��1��6    ���	#FFCBD0D4.��5
   
   � .+�5      �� ���#000020.+�5      �� $��Đã nghe gần đây��6   
�������$��20(�6F   $��10q�6T   �� 5      -   5         ��Name$ listListened��5      ���#252525$��Disabled=�6G   $��Hidden=�5      ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6)   5      ��5      �� 5      .R�5      )   #Media_Player.UserControls.SongItem2  5      5      � 5      $
��0 10q�6    � ColumnDefinitions 5      �� 5      $��* �6+   �� 5      $	��100 �6+   .+�5!      �� $��Đã thích��6    
�������$��20(�6C   $��10q�6Q   �� 5"      -   5        $��1��5"         letterButton#���   6-   
�������$��Hiện tất cả��5$      $��15(�60   $��Regular"�6>   5%      �� 5&      -   5        $ 	listLiked��5&      ���#252525$��Stretch=�6C   $��Hidden=�5'      ��5(      �� 5)      .R�5*      (   "Media_Player.UserControls.SongItem  5+      5-      � 5.      $
��0 10q�6    5/      �� 50      $��* �6+   �� 51      $	��100 �6+   .+�53      �� $��Đã tải lên��6    
�������$��20(�6E   $��10q�6S   �� 54      -   5        $��1��54      #���   6-   
�������$��Hiện tất cả��56      $��15(�60   $��Regular"�6>   57      �� 58      -   5        $ 
listUpLoad��58      ���#252525$��Stretch=�6D   $��Hidden=�59      ��5:      �� 5;      .R�5<      �  5=   "   �� 5>   &   $��* �67   �� 5?   &   $��50 �67   .+�5A   "     �� 5B   "    ��Name$ DeleteUpLoad��6�   -   5        $��1��5B   )   $��25��69   $��25��6D   $��Right=�6P   $��10q�6l     MaterialDesignToolButton#��[ 6x   .��5C   &   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Delete=�6>   
�������6L   5D   #   5E      5F      5H      �� 5J      $"��Danh sách phát của bạn��6   
�������$��20(�6M   $��10q�6[   � 5K       5L      �� 5M      $��* �6+   �� 5N      $��50 �6+   .+�5P      � $��0��6    5Q      �� 5R      $��50 �6/   �� 5S      $��* �6/   .+�5U      �� -   5        $ 
LYourPLBtn��5U   �   $
��Left=�6!   $��0��6<   $��Center=�6L   #��[ 6g   $��50��6�   $��50��6�   .��5V        $ ChevronLeft=�66   
�������$��50��6]   $��50��6h   $��0q�6t   5W      �� 5X      -	   5        $  scrollYourPL��5X   �   $��1��6'   $��1��67   $��Hidden=�6K   $��Hidden=�6r   .��5Y      �� -
   5        $ DanhSachPhatlist��5Y   '   ���#252525$��Disabled=�6V   ��5Z   "   �� 5[   &   .R�5\   *   �� $ 
Horizontal=�65   5]   '   ��5_   "   �� 5`   &   .R�5a   *   ,   &Media_Player.UserControls.PlaylistItem  5b   '   5d      5e      5f      �� 5g      -   5        $ 
RYourPLBtn��5g   �   $��1��6   $��Right=�6-   $��Center=�6I   #��[ 6d   $��50��6�   $��50��6�   .��5h        $ ChevronRight=�62   
�������$��50��6Z   $��50��6e   $��0q�6q   5i      5j      �� 5m      $"��Danh sách phát đã thích��6   
�������$��20(�6N   $��10q�6\   � 5n       5o      �� 5p      $��* �6+   �� 5q      $��50 �6+   .+�5s      � $��0��6    5t      �� 5u      $��50 �6/   �� 5v      $��* �6/   .+�5x      �� -   5        $ 
LLikedPLtn��5x   �   $
��Left=�6!   $��0��6<   $��Center=�6L   #��[ 6g   $��50��6�   $��50��6�   .��5y        $ ChevronLeft=�66   
�������$��50��6]   $��50��6h   $��0q�6t   5z      �� 5{      -   5        $  scrollLikedPL��5{   �   $��1��6'   $��1��67   $��Hidden=�6K   $��Hidden=�6r   .��5|      �� -   5        $ DanhSachPhatDaThichlist��5|   '   ���#252525$��Disabled=�6]   ��5}   "   �� 5~   &   .R�5   *   �� $ 
Horizontal=�65   5�   '   ��5�   "   �� 5�   &   .R�5�   *   ]� $��4q�64   .+�5�   .   � $	��180��63   $	��230��6@   $	��Top=�6L   ��5�   2   �� 5�   6    �� 
TargetType" �6<   .�5�   :   ��  �� Property �@J�Opacity �� Value$ 1Q�6T   	 �� Triggers	 5�   :   P� 5�   >   
 P� Property
 �@J�IsMouseOver P� Value$
 True��6]   . �5�   B   ��  �@J�Opacity$	 0.6Q�6\   5�   ?   5�   7   .+�5�   2   ��  �� CornerRadius$ 15��69   ._�5�   6   �� -   5        $	��180��5�   =   
������ 
������ 6}   ��5�   6   �� 5�   :   Picture�� j� Stretch$
 Fill=�6v    �� ImageSource 6V   �� *	picture+6v   5�   3   5�   /   �� 5�   .   $��2q�6O   
�������$��15(�6m   $��Medium"�6{   ��68   �� *title+6{   5�   +   5�   '   5�      5�      5�      �� 5�      -   5        $ RLikedPLBtn��5�   �   $��1��6   $��Right=�6-   $��Center=�6I   #��[ 6d   $��50��6�   $��50��6�   .��5�        $ ChevronRight=�62   
�������$��50��6Z   $��50��6e   $��0q�6q   5�      5�      �� 5�      $��
Nghệ sĩ��6   
�������$��20(�6>   $��10q�6L   � 5�       5�      �� 5�      $��* �6+   �� 5�      $��50 �6+   .+�5�      � $��0��6    5�      �� 5�      $��50 �6/   �� 5�      $��* �6/   .+�5�      �� -   5        $ 
LNghesiBtn��5�   �   $
��Left=�6!   $��0��6<   $��Center=�6L   #��[ 6g   $��50��6�   $��50��6�   .��5�        $ ChevronLeft=�66   
�������$��50��6]   $��50��6h   $��0q�6t   5�      �� 5�      -   5        $  scrollNghesi��5�   �   $��1��6'   $��1��67   $��Hidden=�6K   $��Hidden=�6r   .��5�      �� -   5        $ ArtistsList��5�   '   ��5�   "   �� 5�   &   .R�5�   *   �� $ 
Horizontal=�65   5�   '   ��5�   "   �� 5�   &   .R�5�   *   ]� $	��6 4q�64   .+�5�   .   � $	��190��63   $	��190��6A   $	��Top=�6M   ��5�   2   �� 5�   6   " �6<   	 5�   :   P� 5�   >   
 �@J�IsMouseOver$
 True��6]   . �5�   B   ��  �@J�Opacity$	 0.6Q�6\   5�   ?   5�   7   .+�5�   2   �� $	 100��69    �� Padding$ 3q�6L   ._�5�   6   �� -   5        $	��190��5�   =   
������ 
������ 6}   ��5�   6   �� 5�   :   Picture��$
 Fill=�6v    6V   �� *	picture+6v   5�   3   5�   /   �� 5�   .   $��2q�6O   
�������$��14(�6m   $��Medium"�6{   $��Center=�6�   ��68   �� *title+6�   5�   +   5�   '   5�      5�      5�      �� 5�      -   5        $ 
RNghesiBtn��5�   �   $��1��6   $��Right=�6-   $��Center=�6I   #��[ 6d   $��50��6�   $��50��6�   .��5�        $ ChevronRight=�62   
�������$��50��6Z   $��50��6e   $��0q�6q   5�      5�      �� 5�      $��Album��6   
�������$��20(�6<   $��10q�6J   � 5�       5�      �� 5�      $��* �6+   �� 5�      $��50 �6+   .+�5�      � $��0��6    5�      �� 5�      $��50 �6/   �� 5�      $��* �6/   .+�5�      �� -   5        $ 	LAlbumBtn��5�   �   $
��Left=�6!   $��0��6<   $��Center=�6L   #��[ 6g   $��50��6�   $��50��6�   .��5�        $ ChevronLeft=�66   
�������$��50��6]   $��50��6h   $��0q�6t   5�      �� 5�      -   5        $  scrollAlbum��5�   �   $��1��6'   $��1��67   $��Hidden=�6K   $��Hidden=�6r   .��5�      �� -   5        $ 
Albumslist��5�   '   ���#252525$��Disabled=�6P   ��5�   "   �� 5�   &   .R�5�   *   �� $ 
Horizontal=�65   5�   '   ��5�   "   �� 5�   &   .R�5�   *   ]� $��4q�64   .+�5�   .   � $	��180��63   $	��230��6@   $	��Top=�6L   ��5�   2   �� 5�   6   " �6<   .�5�   :   ��  �@J�Opacity$ 1Q�6T   	 5�   :   P� 5�   >   
 �@J�IsMouseOver$
 True��6]   . �5�   B   ��  �@J�Opacity$	 0.6Q�6\   5�   ?   5�   7   .+�5�   2   �� $ 15��69   ._�5�   6   �� -   5        $	��180��5�   =   
������ 
������ 6}   ��5   6   �� 5  :   Picture��$
 Fill=�6v    6V   �� *	picture+6v   5  3   5  /   �� 5  .   $��2q�6O   
�������$��15(�6m   $��Medium"�6{   ��68   �� *title+6{   5  +   5  '   5	     5
     5     �� 5     -   5        $ 	RAlbumBtn��5  �   $��1��6   $��Right=�6-   $��Center=�6I   #��[ 6d   $��50��6�   $��50��6�   .��5       $ ChevronRight=�62   
�������$��50��6Z   $��50��6e   $��0q�6q   5     5     5     5     5     5     