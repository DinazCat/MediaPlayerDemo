   M S B A M L   `   `   `  ����G  CMedia_Player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Media_Player.ViewMedia_Player.View  5   	   *    $Media_Player.View.ConfirmationDialog   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Media_Player.View     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��140��5	   	   $	��600��6     � WindowStartupLocation$  CenterScreen=�5
   	    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	   
������ .��5      ��  �� CornerRadius$ 20��6   ��5   
   �� 5       �� EndPoint$	 0 1&�6"   .��5      �  � Color$ #000020��6    � Offset$ 1Q�6/   � 5      $ #003366��6   $	 0.1Q�6/   5      ._�5   
   �� .+�5      �� -   5         ��Name$ Header��5      $��20(�5      $��	20 30 0 8q�6"   
�������$��
Sitka Text)�5   '   $��Heavy"�6?   �� 5      -   5        $ Confirmquestion��5      $��15(�5      $
��20 0q�6"   
�������60   � 5       � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $	��120 �6'   �� 5      $	��120 �6'   .+�5!      �� -   5        $��1��5!       %  !MaterialDesignOutlinedLightButton#��[  5"      +  %MaterialDesignThemes.Wpf.ButtonAssist	   CornerRadius$	 8��5#      $	��100��5$      $��Không��6%   
�������$��14(�6H   $
��0 12q�6V   5%      �� 5&      -   5        $��2��5&      #��[  5'      $	 8��5(      $	��100��5)      $	��Có��6%   
�������$��14(�6E   $
��0 12q�6S   ��5*      �� 5+      .��5,      � $ #0222��6+   $ 1Q�69   � 5-      $ #003366��6+   $ 0Q�6;   5.      50      51      52      53      54      