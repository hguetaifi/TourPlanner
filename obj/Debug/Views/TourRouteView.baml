   M S B A M L   `   `   `  ����F  BTourPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TourPlanner.ViewsTourPlanner.Views  5      %    TourPlanner.Views.TourRouteView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:TourPlanner.Views     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6O   $
��Fill=�6\   $	��250��6k   ��6   �� *-+Parent.SelectedTour.Target.RouteInformation+6k   � 5   
   $��5q�6   $��1��6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� 
����  � �� CornerRadius$ 10��6'   $��0��69   ._�5      �� $��	Tour Logs��6   
�������$
��Bold"�6?   $��Center=�6Q   5      �� 5      $��2��6   $��+��6%   
�������
����  �$��20��5      $��20��6    $��0, -5, 0, 0q�6-   $��20(�5       $��0,0,0,-6q�6#   $��Center=�65   $��Center=�6P   
����  ���5   1   �� *AddTourLogCommand+5"      5#      �� 5%   
   
����  �$��3q�6$   $��2��68   $��5,-5,5,5q�6E   ._�5&      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .   �� AlternationCount$ 2��6\      
IsReadOnly . ��6   �� *Parent.ToursLogs+   ColumnHeaderStyle 5'      �� 5(       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5)      ��  �� Property � ��	 �� Value$	 Center=�6G   �� 5*       � ��
	 � � �67   �� 5+       � ��
	 �����67   �� 5,       � ��$	 14(�65   �� 5-       � ��$
	 Bold"�67   �� 5.       � ��$	 5q�64   5/      
   RowStyle
 51      �� 52      )  #System.Windows.Controls.DataGridRow"  6   .�53      ��  � ��$	 14(�65   �� 54       � ��$	 5q�64   �� 55       � ��$	 Center=�6@   �� 56       �@�ContextMenu	 57      �� 58   "   .@�59   &   m� $
��Edit��6/    m� Command 6=   �� *EditTourLogCommand+m� 5:   &   $��Delete��6/    6?   �� *DeleteTourLogCommand+5;   #   5=       �� Triggers 5>      P� 5?       P� Property �@ AlternationIndex P� Value$ 0��6B   . �5@   "   ��  � ��
	 �����6?   5A      P� 5B       �@ AlternationIndex$ 1��6B   . �5C   "   ��  � ��
	 ����6?   5D      5F         Columns 5H      0  *System.Windows.Controls.DataGridTextColumn  5I      ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Target.Date+6W     5J      $ Comment��6)   $ * 6]    6:   �� *Target.Comment+6]     5K      $ 
Difficulty��6)   $ * 6c    6=   �� *Target.Difficulty+6c     5L      $ 
Total Time��6)   $ * 6b    6=   �� *Target.TotalTime+6b     5M      $ Rating��6)   $ * 6[    69   �� *Target.Rating+6[   5O      5P      5Q      5S      