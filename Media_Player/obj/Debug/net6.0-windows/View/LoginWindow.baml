   M S B A M L   `   `   `  ����G  CMedia_Player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Media_PlayerMedia_Player  5   	       Media_Player.LoginWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Media_Player     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   -   5        $��loginWindow��5   	   
�������$��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   
������    MaterialDesignFont#���   5   	    � WindowStartupLocation$ CenterScreen=�5   	   $	��470��5      $	��630��6)    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	     LoginVM � DataContext# [ 5   	   .��5      �� -   5        ��5   
   �� 5       �� 
StartPoint$	 0 0&�6"    �� EndPoint$	 0 1&�63   .��5      �  � Color$ #000010��6   	 � Offset$	 1Q�6/   � 5      $ #003366��6   $		 0.1Q�6/   5      ._�5   
   � ��5      �� 5       
 �� ImageSource$!
 /Images/loginbackground.png��6    j� Stretch$
 Fill=�5!       �� Opacity$	 0.8Q�6,   .+�5$      �� .+�5%      �� .+�5&      �� -   5          MaterialDesignIconButton#��[ 5&      $��Right=�5'      $��	0 5 10 45q�69   $��25��5(      $��25��6)    � ToolTip$ Close��5)       � OverridesDefaultStyle$
 True��6G   .��5*      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
CloseThick=�62   
�������5+   2   5,      �� 5-      $��Đăng Nhập��6     �� TextAlignment$ Center=�5.       $��40(�5/       $
��Bold"�50       $��
Sitka Text)�51       52      �� 53      -   5         ��Name$ 	txblError��53       
���  ��$��0 2 0 1q�6E   $��Center=�6V   $��Medium"�6s   54      �� 55      $	��250��6    �� Orientation$ 
Horizontal=�6)   .+�56        $ Account=�6.   $��25��6=   $��25��6H   $��	0 18 10 0q�6T   �� 57      -   5         ��Name$ UserName��57      
�������)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Email/Tên đăng nhập��59       % !MaterialDesignFloatingHintTextBox#��[ 5:         
Foreground
 �����.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �����$��Center=�5=      $��14(�69   $	��215��6G   ��58      �� *
UserName+5=   G   5>      �� 5?      $	��250��6   $ 
Horizontal=�6)   .+�5@        $
 Lock=�6.   $��25��6:   $��25��6E   $��	0 15 10 0q�6Q   G� 5A      -   5         G�Name$ PasswordBox��5A   "   
�������$ Mật khẩu��5B   "   
 �����
 ����� / +MaterialDesignFloatingHintRevealPasswordBox#��[ 5E   "   $	��215��5F   "   $��14(�6.   .  (System.Windows.Interactivity.Interaction   Triggers 5G      /  )System.Windows.Interactivity.EventTrigger  5H         	EventName$ PasswordChanged��6-   .  (System.Windows.Interactivity.TriggerBase   Actions. 5I   "   6  0System.Windows.Interactivity.InvokeCommandAction     Command 68   �� *PasswordChangedCommand+   CommandParameter 5J   $   ��  �� ElementName$ PasswordBox��5K      5M      5N      �� 5O      .+�5P      �� -   5        $��Right=�5P   c   $��Quên mật khẩu?��6   $��0,0,0,0q�6�   $��
0 10 190 5q�6�   ��66   Z� ��6L   Z� ��5Q      �� 5R       �� 
TargetType" ��6$   .�5S   "   ��  �� Property � ��  �� Value
  �����6O   �� 5T   "    � ��  5U   &   �� 5V   *   ! �� 
TargetType"! ��6:   .R�5W   .   �� #��z��65   
���   �$��0q�6s   ._�5X   2   �� $��Center=�6C   $��Center=�6`   5Y   /   5Z   +   5\   #   " �� Triggers" 5]   "   P� 5^   &   # P� Property# �@J�IsMouseOver$ P� Value$
$ True��6E   . �5_   *   ��  � ��  �#CCCCCC6G   �� 5`   *    �@�Cursor$
  Hand��6C   �� 5a   *    � ��  5b   .   �� 5c   2   "! ��6B   .R�5d   6   �� #��z��6=   $��0q�6g   ._�5e   :   �� $��	Underline{�6D   �� 5f   :   $��Center=�6K   $��Center=�6h   5g   ;   5h   7   5i   3   5k   +   5l   '   5n      5p      5q      �� 5r      .+�5s      ��  % !MaterialDesignOutlinedLightButton#��[ 5t      +	  %MaterialDesignThemes.Wpf.ButtonAssist% 	  CornerRadius$% 5��5u      $	��100��5v      $��Đăng nhập��6)   
�������$��14(�6P   $
��0 20q�6^   ��5s      �� *LoginCommand+��6>   �� $ loginWindow����5w      �� 5x      .��5y   "   � $ #0222��6/   $	 1Q�6=   � 5z   "   $ #000022��6/   $	 0Q�6?   5{      5}      �� 5      -   5        $��Center=�5   J   $3��-Bạn chưa có tài khoản? Đăng ký ngay��6g   $��0,0,0,0q�6�   ��6   Z� ��63   Z� ��5�      �� 5�      " ��6$   .�5�   "   ��  � ��
  �����6O   �� 5�   "    � ��  5�   &   �� 5�   *   "! ��6:   .R�5�   .   �� #��z��65   
���   �$��0q�6s   ._�5�   2   �� $��Center=�6C   $��Center=�6`   5�   /   5�   +   5�   #   " 5�   "   P� 5�   &   # �@J�IsMouseOver$
$ True��6E   . �5�   *   ��  � ��  �#CCCCCC6G   �� 5�   *    �@�Cursor$
  Hand��6C   �� 5�   *    � ��  5�   .   �� 5�   2   "! ��6B   .R�5�   6   �� #��z��6=   $��0q�6g   ._�5�   :   �� $��	Underline{�6D   �� 5�   :   $��Center=�6K   $��Center=�6h   5�   ;   5�   7   5�   3   5�   +   5�   '   5�      5�      �� 5�      -	   5        & ��Name$& SkipBtn��5�      $��Center=�6[   $,��&Bỏ qua bước này và bắt đầu��6x   $��0,0,0,0q�6�   $��15q�6�   ��6.   Z� ��6D   Z� ��5�   !   �� *SkipCommand+��6A   �� $ loginWindow����5�      �� 5�      " ��6$   .�5�   "   ��  � ��
  �����6O   �� 5�   "    � ��  5�   &   �� 5�   *   "! ��6:   .R�5�   .   �� #��z��65   
���   �$��0q�6s   ._�5�   2   �� $��Center=�6C   $��Center=�6`   5�   /   5�   +   5�   #   " 5�   "   P� 5�   &   # �@J�IsMouseOver$
$ True��6E   . �5�   *   ��  � ��  �#CCCCCC6G   �� 5�   *    �@�Cursor$
  Hand��6C   �� 5�   *    � ��  5�   .   �� 5�   2   "! ��6B   .R�5�   6   �� #��z��6=   $��0q�6g   ._�5�   :   �� $��	Underline{�6D   �� 5�   :   $��Center=�6K   $��Center=�6h   5�   ;   5�   7   5�   3   5�   +   5�   '   5�      5�      5�      5�      5�      5�      5�      