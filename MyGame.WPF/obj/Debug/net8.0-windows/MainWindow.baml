   M S B A M L   `   `   `  ����  
MyGame.WPF    MyGame.WPF.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  My Game��5   	   $	��450��6   $	��800��6&    � WindowState$ 	Maximized=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Center=�6"   $��	0,10,0,10q�6?   .+�5      �� -   5         ��Name$ txtInfo��5      $��20(�5      $��Welcome to My Game!��5      5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��Center=�6X   .+�5      �� $��20q�6   .+�5      �� -   5         ��Name$ imgMage��5      $	��150��6)   $	��150��65   $��Images/Mage.png��5      $��UniformToFill=�5       �� 5!      -   5        $ txtMageInfo��5!      $��16(�61   $��Mage: HP=100, Mana=50��5"      $��0,10,0,0q�5#      5$      �� 5&      -   5         ��Name$ txtLog��5&      $��0��6&   $	��100��63    �� 
IsReadOnly$
 True��5'   
   	 �� TextWrapping$
	 Wrap=�6   "
 �� VerticalScrollBarVisibility$

 Auto=�5(   
   �� 5+      $��20q�6   .+�5,      �� -   5        $ 
imgWarrior��5,      $	��150��6,   $	��150��68   $��Images/Warrior.png��5-      $��UniformToFill=�5.      �� 5/      -   5        $ txtWarriorInfo��5/      $��16(�64   $��Warrior: HP=120��50      $��0,10,0,0q�51      52      53      �� 56   
   $��2��6   $ 
Horizontal=�6"   $��Center=�6;   $��	0,10,0,10q�6X   .+�57      �� -   5         ��Name$ 	btnAttack��57      $��Attack��6(   $	��120��69   $��5q�6E   6P   �� 58      -   5        $ 
btnAbility��58      $��Use Ability��6)   $	��120��6?   $��5q�6K   6V   �� 59      -	   5        $ btnHeal��59      $
��Heal��6&   $	��120��65   $��5q�6A   6L   5:      5;      5<      