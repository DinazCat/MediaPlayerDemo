   M S B A M L   `   `   `  ����G  CMedia_Player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Media_Player.ViewMedia_Player.View  5   	   &     Media_Player.View.ChangePassword   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Media_Player.View     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��270��5	   	   $	��320��6     � WindowStartupLocation$  CenterScreen=�5
   	    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	   
������ .��5      �� -   5         �� CornerRadius$ 20��5      $��2q�6   
���������5   
   �� 5       �� EndPoint$	 0 1&�6"   .��5      �  � Color$ #000015��6    � Offset$ 1Q�6/   � 5      $ #003366��6   $	 0.1Q�6/   5      ._�5   
   �� .+�5      �� -   5           MaterialDesignIconButton#��[  5      $��Right=�5      $��0 5 7 15q�69   $��25��5      $��25��6)    � ToolTip$ Close��64   .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
CloseThick=�6*   
�������6<   5      �� 5      -   5        	 ��Name$	 Errortxt��5      ���#FF0000$��Center=�6?   G� 5      -   5        
 G�Name$
 PasswordBox��5      
�������
�������$y�	Collapsed=�6V   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Mật khẩu cũ��5   "      
Foreground
 �����.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 ����� / +MaterialDesignFloatingHintRevealPasswordBox#��[ 5    "   $	��215��5!   "   $��14(�6.   5"      G� 5#      -   5        $
 PasswordBox1��5#      
�������
�������$ Mật khẩu mới��5$   "   
 �����
 �����#��[ 5'   "   $	��215��5(   "   $��14(�6.   5)      G� 5*      -   5        $
 PasswordBox2��5*      
�������
�������$��	0 10 0 25q�6W   $$ Xác nhận lại mật khẩu��5+   "   
 �����
 �����#��[ 5.   "   $	��215��5/   "   $��14(�6.   50      �� 51      -   5         ��Name$ btnsendcode��51       " MaterialDesignRaisedDarkButton#��[ 6*   $��35��52      $	��140��6!   
�������$��Đổi mật khẩu��6A   $��15(�6X   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15��53      ��54      �� 55      .��56      � $ #0222��6+   $ 1Q�69   � 57      $ #003366��6+   $ 0Q�6;   58      5:      5;      5<      5=      