   M S B A M L   `   `   `  ����D  @Mini_Uber, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Mini_Uber	Mini_Uber  5   	       Mini_Uber.Searching   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Mini_Uber     5   	     � Title$  	Searching��5   	   $	��800��6   $	��650��6(    � WindowStartupLocation$ CenterScreen=�64   
�������.��5
      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5        $��ride_border��5      $��0��5      $��0q�5       �� CornerRadius$ 20��5      ���	#FFD9E2F4���#0536FF$��	0,-15,0,0q�5      ._�5      �� -   5        $��select_destination_lb��5      $��Searching For a Driver ��5      $��
Nirmala UI)�5      $��45(�5      $
��Bold"�5      $��0,0,0,0q�5       $
��auto��5!      $	��514��5"      $��Center=�5#      $��Center=�5$      
�������5%      5'      �� 5(   
   $��1��6   $��2��6"   .+�5)      r� -   5        $��myGif��5)       r� LoadedBehavior$
 Play=�6)   $	��450��6?   $	��350��6K    r� UnloadedBehavior$ Manual=�6X    r� Source$. (E:\Mini uber\Mini_Uber\Resources\car.gif?�6�   $��0,0,0,0q�6�   �� 5+      -   5        $��
cancel_btn��5+      $	��250��5-      $��40��5.      $��
Nirmala UI)�5/      $��0,60,0,0q�50       � Cursor$
 Hand��51      
����  �$��Cancel��53      $��1��54      ��57      �� 58       �� 
TargetType" ��6&   .R�59      �� $ 12��6!   #��z��5:      #��z��5;      #��z��5<      ._�5=      �� $��Center=�6/   $��Center=�6L   5>      	 �� Triggers	 5?      P� 5@      
 P� Property
 �@J�IsMouseOver P� Value . . �5A   "   ��  �� Property � �� �� Value �#0536FF6?   �� 5B   "    � ��
 �����6?   �� 5C   "    � ��$ 16(�6=   �� 5D   "    � ��$
 Bold"�6?   5E      P� 5F      
 �@J�IsMouseOver .  . �5G   "   ��  � �� �#2662FF6?   �� 5H   "    � ��
 �����6?   �� 5I   "    � ��$ 16(�6=   5J      5L      5N      5P      5R      5S      