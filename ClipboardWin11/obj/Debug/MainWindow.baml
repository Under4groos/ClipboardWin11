   M S B A M L   `   `   `  ����I  EClipboardWin11, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClipboardWin11ClipboardWin11  5   	   A%clr-namespace:ClipboardWin11.ControlsClipboardWin11.Controls  64       ClipboardWin11.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ClipboardWin11     5   	   :controls%clr-namespace:ClipboardWin11.Controls     64     � WindowStyle$
  None=�5       � AllowsTransparency .  � ShowInTaskbar .   � Title$ 
MainWindow��5   	   $	��170��6   $	��800��6)   ��5	      �� 5
   
   6    � 	Resources 5         IcoLabel �� 
TargetType �� Property �� Value  borderhover �� Triggers	 P� Property
 P� Value��%�  &	        &	 .    �� 5   
   " ��6!   .�5      ��  � ��$ Segoe Fluent Icons)�6+   6I   �� 5       � ��
 �����6<   �� 5       � ��$ 15(�6)   67   �� 5       � ��$ Center=�64   6F   �� 5       � ��$ Center=�62   6D   �� 5       � ��$ 0q�6'   64   5      �� 5   
   " ��6$   .�5      ��  � �� �	#19FFFFFF6@   �� 5       �@��CornerRadius$ 7��6-   6:   �� 5       � ��$ 5q�6'   64   �� 5       � ��$ 45��6&   64    5      P� 5      	 �@J�IsMouseOver
 . . �5      ��  � �� �	#33FFFFFF6H   5      5       5!      .��5"      � ���	#CC212121.+�5#   
   �  � RowDefinitions 5$      �� 5%      $��40 �6    �� 5&      $��1* �6    .+�5(      �� $��10,0,0,0q�6    �� Orientation$ 
Horizontal=�6+   $
��Left=�6D   .+�5)      �� -   5        #��[ 5)      ._�5*      �� #��[  6   $	����6>   6S   5+      �� 5,      -   5        #��[ 5,      ._�5-      �� #��[  6   $	����6>   6S   5.      51      � 53      $��1��6   $��0,0,0,10q�6    .+�54      ,   &ClipboardWin11.Controls.VCScrollViewer  -   5          Name$
 list��54   +   55      56      5<      5=      