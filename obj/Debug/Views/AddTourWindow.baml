   M S B A M L   `   `   `  ����F  BTourPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TourPlanner.ViewsTourPlanner.Views  5   	   %    TourPlanner.Views.AddTourWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:TourPlanner.Views     5   	     � Title$  Add Tour��5   	   $	��550��6   $	��500��6'    � 	Resources 5
       �� 
TargetType �� Property �� Value    BooleanToVisibilityConverter��%�  '��       '�� n     '�� �     &	  n    �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   �� 5       � ��$
 Bold"�6+   5      �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   �� 5       � ��$	 0,5q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$	 0,5q�6'   5      �� 5   
   6'   5      .��5      � .+�5   
   � $��10q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5       $
��Auto �6    �� 5!      $
��Auto �6    �� 5"      $
��Auto �6    �� 5#      $
��Auto �6    �� 5$      $
��Auto �6    �� 5%      $
��Auto �6    �� 5&      $
��Auto �6    �� 5'      $
��Auto �6    �� 5(      $
��Auto �6    �� 5)      $
��Auto �6    �� 5*      $
��Auto �6    �� 5+      $
��Auto �6    �� 5,      $
��Auto �6    �� 5-      $
��Auto �6    �� 5.      $
��Auto �6    �� 5/      $
��Auto �6    .+�52      �� $
��Name��6   $��0��6#   �� 53      $��1��63   ��6   �� *Target.Name+63   �� 55      $��Description��6   $��2��6*   �� 56      $��3��6:   ��6   �� *Target.Description+6:   �� 58      $
��From��6   $��4��6#   �� 59      $��5��63   ��6   �� *Target.From+63   �� 5;      $��To��6   $��6��6!   �� 5<      $��7��61   ��6   �� *	Target.To+61   �� 5>      $��Transport Type��6   $��8��6-   �� 5?      $��9��5A      ��5?      �� *TransportTypes+ �� SelectedItem 5@      �� *Target.TransportType+5A      �� 5C      $��Distance��6   $��10��6'   �� 5D      {�.   �� 
IsReadOnly . $��11��6h   ��6   �� *Target.Distance+ �� Mode$ TwoWay=�6h   �� 5F      $��Estimated Time��6   $��12��6-   �� 5G      {�.   . $��13��6m   ��6   �� *Target.EstimatedTime+$ TwoWay=�6m   �� 5I      $��Route Information��6   $��14��60   �� 5J      {�.   . $��15��6p   ��6   �� *Target.RouteInformation+$ TwoWay=�6p   �� 5L      -   5        	 ��Name$	 AddEditTourButton��5L      $��Add Tour��60   $��16��6h   $��
0, 5, 0, 0q�6v   ��6C   �� *SaveTourCommand+6v   5N      � 5P   
   
������ y�6(   �� *	IsLoading+
 �� 	Converter#
 [  .+�5Q      �� ���	#800000006   � 5R       � IsIndeterminate . $	��100��61   $	��100��6=   $��Center=�6J   $��Center=�6e   5S      5U      5W      