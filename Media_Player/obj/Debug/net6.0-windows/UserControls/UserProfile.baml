   M S B A M L   `   `   `  ����G  CMedia_Player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Media_Player.UserControlsMedia_Player.UserControls  5      +    %Media_Player.UserControls.UserProfile   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Media_Player.UserControls     5      _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      � ���#000020  � ColumnDefinitions  5   
   �� 5      $	��350 �6   �� 5      $��* �6   .+�5   
   �� .+�5      � $	��250��6   $	��250��6!   $��	0 40 0 30q�6-   ��5      �� 5       �� 
TargetType" �6    �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �5   "   ��  �� Property �@J�Opacity �� Value$	 0.6Q�6<   5      5      .+�5      ��  �� CornerRadius$	 140��6    �� Padding$ 3q�6,   ._�5      �� -   5        $	��250��5      
������ 
������ ��5      �� 5      .R�5   "   �� $��Bottom=�6(   $��Right=�6C   $��60��6_   $��60��6k   $��/Images/camera.png��6v   $
��Fill=�6�   $��0 0 5 5q�6�   5      5!      ��5"      �� 5#      -   5        Picture��	 j� Stretch$
	 Fill=�5#   V   
 �� ImageSource
 66   �� *	picture+6V   5%      5&      �� 5'      
�������$��Center=�6H   $��30(�6e   $��Segoe Print)�6s   ��6   �� *displayName+6s   5(      �� 5)   
   $��1��6   .+�5*      ]� $��
30 80 30 0q�6   .+�5+      �� $��Tên hiển thị��6   
�������$��17(�6C   $��Cambria Math)�6Q   $	��170��6k   $��Center=�6w   �� 5,      -   5         ��Name$ DName��5,      ���#BBBBBB$��17(�6[   $��Cambria Math)�6i    �� 
IsReadOnly$
 True��6�   ��6)   �� *displayName+6�   �� 5-      -   5           MaterialDesignIconButton#��[  5-      $��Right=�6K    � ToolTip$ Chỉnh sửa��6g   $��22��5.      $��40��6%   .��5/      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Pencil=�6.   
�������6<   50      51      �� 52      -   5         ��Name$ 
panelDName��52       �� Orientation$ 
Horizontal=�6.   $y�	Collapsed=�6G   $��0 8 0 0q�6^   .+�53      �� -   5         # MaterialDesignRaisedLightButton#��[ 53      $��
Đồng ý��6R   $	��100��6c   $��
140 0 20 0q�6o   6�   �� 54      -   5         % !MaterialDesignOutlinedLightButton#��[ 54      $��Hủy��6T   $��70��6b   6m   55      �� 56      $��0 1 0 0q�6   
�������$��30 20q�6B   ]� 58      $
��30 0q�6   .+�59      �� $��Tên đăng nhập��6   
�������$��17(�6D   $��Cambria Math)�6R   $	��170��6l   $��Center=�6x   �� 5:      ���#BBBBBB$��17(�6I   $��Cambria Math)�6W   $
 True��6q   ��6   �� *
userName+6q   �� 5;      5<      �� 5=      $��0 1 0 0q�6   
�������$��30 20q�6B   ]� 5?      $
��30 0q�6   .+�5@      �� $��Email��6   
�������$��17(�6<   $��Cambria Math)�6J   $	��170��6d   $��Center=�6p   �� 5A      -   5        $ Email��5A      ���#BBBBBB$��17(�6U   $��Cambria Math)�6c   $
 True��6}   ��6)   �� *email+6}   �� 5B      -	   5        #��[  5B      $��Right=�6K   $ Chỉnh sửa��6g   $��22��5C      $��40��6%   .��5D        $ Pencil=�6.   
�������6<   5E      5F      �� 5G      -
   5        $ 
panelEmail��5G      $ 
Horizontal=�6.   $y�	Collapsed=�6G   $��0 8 0 0q�6^   .+�5H      �� -   5         ��Name$ 	txblError��5H      $��20 5 0 0q�6/   
���  ��$��Medium"�6S   �� 5I      -   5        #��[ 5I      $��
Đồng ý��6R   $	��100��6c   $��
140 0 20 0q�6o   6�   �� 5J      -   5        #��[ 5J      $��Hủy��6T   $��70��6b   6m   5K      �� 5L      $��0 1 0 0q�6   
�������$��30 20q�6B   ]� 5N      $
��30 0q�6   .+�5O      �� $��Mật khẩu��6   
�������$��17(�6?   $��Cambria Math)�6M   $	��170��6g   $��Center=�6s   �� 5P      $��(Không hiển thị)��6   ���#BBBBBB$��17(�6I   $��Cambria Math)�6W   �� 5Q      -   5        #��[  5Q      $��Right=�6K   $ Đổi mật khẩu��6g   $��22��5R      $��40��6%   .��5S        $ Pencil=�6.   
�������6<   5T      5U      5V      5W      5X      