   M S B A M L   `   `   `  ����G  CMedia_Player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Media_Player.ViewMedia_Player.View  5   	   (    "Media_Player.View.CustomMessageBox   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Media_Player.View     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��200��5	   	   $	��300��6     � WindowStartupLocation$  CenterScreen=�5
   	    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	   
������ .��5      ��  �� CornerRadius$ 20��6   ��5   
   �� 5       �� EndPoint$	 0 1&�6"   .��5      �  � Color$ #000015��6    � Offset$ 1Q�6/   � 5      $ #003366��6   $	 0.1Q�6/   5      ._�5   
   �� .+�5      �� -   5         ��Name$ notificationtxt��5      $��Success��61   $��20(�5      $��
20 30 0 15q�6"   
�������$��
Sitka Text)�5   '   $��Heavy"�6?   �� 5      -   5        $ 
messagetxt��5      $��Center=�6,   $��15(�5      $
��20 0q�6"   
�������60   �� 5      -   5        $��2��5       %  !MaterialDesignOutlinedLightButton#��[  5      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 8��5      $	��100��5      $��OK��6%   
�������$��14(�6E   $	�� 30q�6S   ��5      �� 5       .��5!      � $ #0222��6'   $ 1Q�65   � 5"      $ #003366��6'   $ 0Q�67   5#      5%      5&      5'      5(      