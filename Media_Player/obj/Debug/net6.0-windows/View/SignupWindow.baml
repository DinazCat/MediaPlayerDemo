   M S B A M L   `   `   `  ����G  CMedia_Player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Media_PlayerMedia_Player  5   	   ?$clr-namespace:Media_Player.ViewModelMedia_Player.ViewModel  5   	   $    Media_Player.View.SignupWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Media_Player     5   	   3vm$clr-namespace:Media_Player.ViewModel     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   -   5        $��signupWindow��5   	   
�������$��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   
������    MaterialDesignFont#���   5   	    � WindowStartupLocation$ CenterScreen=�5   	   $	��560��5      $	��500��6*    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   .��5      �� -   5        ��5   
   �� 5       �� 
StartPoint$	 0 0&�6"    �� EndPoint$	 0 1&�63   .��5      �  � Color$ #000010��6    � Offset$ 1Q�6/   � 5      $ #003366��6   $	 0.1Q�6/   5      ._�5   
   � ��5      �� 5       	 �� ImageSource$!	 /Images/loginbackground.png��6   
 j� Stretch$

 Fill=�5!       �� Opacity$	 0.8Q�6,   .+�5$      �� .+�5%      �� .+�5&      ��  �� Orientation$ 
Horizontal=�6!   $��Right=�6:   .+�5'      �� -   5          MaterialDesignIconButton#��[ 5'   !   $��	0 5 10 40q�6T   $��25��5(      $��25��6)    � ToolTip$ Go Back��5)       � OverridesDefaultStyle$
 True��6/   .��5*      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=�66   
�������5+   2   5,      �� 5-      -   5        #��[ 5-   !   $��	0 5 10 40q�6T   $��25��5.      $��25��6)   $ Close��5/      $
 True��6-   .��50        $ Close=�66   
�������51   2   52      53      �� 54      $��
Đăng Ký��6     �� TextAlignment$ Center=�55       $��40(�56       $
��Bold"�57       $��
Sitka Text)�58       59      �� 5:      -   5         ��Name$ 	txblError��5:       
���  ��$��0 3 0 1q�6E   $��Center=�6V   $��Medium"�6s   5;      �� 5<      $	��250��6   $ 
Horizontal=�6)   $��5q�6B   .+�5=        $ Email=�6.   $��25��6;   $��25��6F   $��	0 10 10 0q�6R   $��Center=�6e   �� 5>      -   5         ��Name$ Email��5>      
�������)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Email��5?       % !MaterialDesignFloatingHintTextBox#��[ 5@         
Foreground
 �����.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �����$��Center=�5C      $��14(�69   $	��215��6G   5D      �� 5E      $	��250��6   $ 
Horizontal=�6)   $��5q�6B   .+�5F        $ Account=�6.   $��25��6=   $��25��6H   $��	0 10 10 0q�6T   $��Center=�6g   �� 5G      -   5        $ Username��5G      
�������$ Tên đăng nhập��5I      #��[ 5J      
 �����
 �����$��Center=�5M      $��14(�69   $	��215��6G   ��5H      �� *
UserName+5M   G   5N      �� 5O      $	��250��6   $ 
Horizontal=�6)   $��5q�6B   .+�5P        $ AccountEdit=�6.   $��25��6A   $��25��6L   $��	0 10 10 0q�6X   $��Center=�6k   �� 5Q      -   5        $ Displayname��5Q      
�������$ Tên hiển thị��5R      #��[ 5S      
 �����
 �����$��Center=�5V      $��14(�69   $	��215��6G   5W      �� 5X      $	��250��6   $ 
Horizontal=�6)   $��5q�6B   .+�5Y        $
 Lock=�6.   $��25��6:   $��25��6E   $��	0 10 10 0q�6Q   $��Center=�6d   G� 5Z      -	   5         G�Name$ PasswordBox1��5Z   "   
�������$ Mật khẩu��5[   "   
 �����
 ����� / +MaterialDesignFloatingHintRevealPasswordBox#��[ 5^   "   $	��215��5_   "   $��14(�6.   5`      5a      �� 5b      $	��250��6   $ 
Horizontal=�6)   $��5q�6B   .+�5c        $
 Lock=�6.   $��25��6:   $��25��6E   $��	0 10 10 0q�6Q   $��Center=�6d   G� 5d      -
   5        $ PasswordBox2��5d   "   
�������$$ Xác nhận lại mật khẩu��5e   "   
 �����
 �����#��[ 5h   "   $	��215��5i   "   $��14(�6.   5j      5k      �� 5l      .+�5m      �� -   5         % !MaterialDesignOutlinedLightButton#��[ 5m      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 5��5n      $	��100��5o      $��
Đăng ký��6)   
�������$��14(�6N   $
��0 30q�6\   ��5p      �� 5q      .��5r   "   � $ #0222��6/   $ 1Q�6=   � 5s   "   $ #000022��6/   $ 0Q�6?   5t      5v      5w      5x      5y      5z      5{      