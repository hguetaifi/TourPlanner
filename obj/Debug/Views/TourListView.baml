   M S B A M L   `   `   `  ����F  BTourPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TourPlanner.ViewsTourPlanner.Views  5      $    TourPlanner.Views.TourListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:TourPlanner.Views     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � $��5q�6   $��0��6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� 
����  � �� CornerRadius$ 10��6'   $��0��69   ._�5      �� $��Tours��6   
�������$��16(�6;   $
��Bold"�6I   $��Center=�6[   5      �� 5      $��2��6   $��+��6%   
�������
����  �$��25��5      $��25��6    $��0, -5, 0, 0q�6-   $��25(�5      $��	0,0,0,-10q�6#   $��Center=�66   $��Center=�6Q   
����  ���5   1   �� *AddTourCommand+5      5       �� 5"   
   $��3��6   $��0��6'   $��1��67   $��5,-5,5,5q�6n   
����  �$��3q�5#      ��5"   D   �� *FilteredToursList+ �� SelectedItem 5#   2   �� *SelectedTour+ �� Mode$ TwoWay=���5$      �� 5%       �� 
TargetType" ��6    �� Triggers 5&      P� 5'       P� Property �@J�IsMouseOver P� Value . . �5(      �� 	 �� Property	 � ��
 �� Value
 �#DDD6;   5)      .�5+      �� 	 � ��$
 5q�60   �� 5,      	 � ��$
 5q�6/   �� 5-      	 � ��
 �#DDD64   �� 5.      	 � ��$
 1q�68   5/      ��51      �� 52      .R�53      ��  �� Padding$ 5q�6=   $��14(�6I   $��Arial)�6W   
���   ���6    �� *Target.Name+ � ContextMenu 54      �� 55      .@�56   "   m� $
��Edit��6+    m� Command 69   ��  �� Path$ EditTourCommand� m� CommandParameter 6b   �� m� 57   "   $��Delete��6+    6;   �� $ DeleteTourCommand� 6f   �� 58      5:      5;       �� AlternationCount$ 2��5@   )    � 	Resources 5A      ��%�   '��       �� 5B      " ��6    5C      P� 5D       �@��AlternationIndex$ 1��6K   . �5E      �� 	 � ��
 �#F5F5F56;   5F      5H      5I      5J      5L      5N      