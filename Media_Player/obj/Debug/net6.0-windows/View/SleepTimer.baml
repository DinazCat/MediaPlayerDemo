   M S B A M L   `   `   `  ����G  CMedia_Player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Media_Player.ViewMedia_Player.View  5   	   "    Media_Player.View.SleepTimer   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Media_Player.View     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � Title$  
SleepTimer��5
   	   $	��320��6   $	��450��6)    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	   
������ .��5      ��  �� CornerRadius$ 25��6   ��5   
   �� 5       �� EndPoint$	 0 1&�6"   .��5      �  � Color$ #000015��6    � Offset$ 1Q�6/   � 5      $ #003366��6   $	 0.1Q�6/   5      ._�5   
   �� .+�5      �� $%��Hẹn giờ dừng phát nhạc��6   $��25(�5      $��30q�6"   
������� �� TextAlignment$ Center=�5   '   $��
Sitka Text)�6>   $��Heavy"�6V   �� 5      	 �� Orientation$	 
Horizontal=�6   $��90��62   .+�5      �� -   5        
 ��Name$
 hourtxb��5      
�������
�������$
��20 0q�6R   $	��100��6a   $��Medium"�6m   $��Center=�6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Giờ��5      .  (MaterialDesignThemes.Wpf.TextFieldAssist   TextBoxViewMargin$ 1 0 1 0q�5         FloatingScale$
 0.30Q�5      $��00��5       %  !MaterialDesignFloatingHintTextBox#��[  5       $��45(�5!      ���#0033666)   �� 5"      $��:��6   
�������$��70(�68   �� 5#      -   5        $
 	minutetxb��5#      
�������
�������$
��20 0q�6T   $	��100��6c   $��Medium"�6o   $��Center=�6�   $ Phút��5$      $ 1 0 1 0q�5%      $	 0.3Q�5&      $��00��5'      #��[  5(      $��45(�5)      ���#0033666)   �� 5*      $��:��6   
�������$��70(�68   �� 5+      -   5        $
 	secondtxb��5+      
�������
�������$
��20 0q�6T   $	��100��6c   $��Medium"�6o   $��Center=�6�   $ Giây��5,      $ 1 0 1 0q�5-      $
 0.30Q�5.      $��00��5/      #��[  50      $��45(�51      ���#0033666)   52      �� 53      -   5         ��Name$ 	errortxbl��53      ���#CCCCCC$��11(�6@   $��Center=�6N   $��0 3 0 0q�6k   �� 54      -   5         " MaterialDesignRaisedDarkButton#��[ 54      $��35��55      $	��200��6!   
�������$
��Lưu��6A   $
��0 20q�6O   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15��56      ��57      �� 58      .��59      � $ #0222��6'   $ 1Q�65   � 5:      $ #003366��6'   $ 0Q�67   5;      5=      �� 5>      -   5        $��Center=�5>   Z   $��HỦY��6w   $��0,0,0,0q�6�   $��14(�6�   $��Medium"�6�   ��6-   Z� ��6C   Z� ��5?      �� 5@       �� 
TargetType" ��6   .�5A      ��  �� Property � �� �� Value
 �����67   �� 5B       � �� 5C      �� 5D   "    �� 
TargetType" ��62   .R�5E   &   �� #��z��6-   
���   �$��0q�6k   ._�5F   *   �� $��Center=�6;   $��Center=�6X   5G   '   5H   #   5J       �� Triggers 5K      P� 5L       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �5M   "   ��  � �� �#CCCCCC6?   �� 5N   "    �@�Cursor$
 Hand��6;   �� 5O   "    � �� 5P   &   �� 5Q   *   " ��6:   .R�5R   .   �� #��z��65   $��0q�6_   ._�5S   2   �� $��	Underline{�6<   �� 5T   :   $��Center=�6K   $��Center=�6h   5U   3   5V   /   5W   +   5Y   #   5Z      5\      5^      5_      5`      5a      