   M S B A M L   `   `   `  ����F  BTourPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TourPlanner.ViewsTourPlanner.Views  5   	   (    "TourPlanner.Views.AddTourLogWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:TourPlanner.Views     5   	     � Title$  Add Tour Log��5   	   $	��400��6   $	��500��6+    � 	Resources 5
       �� 
TargetType �� Property �� Value��%�  '��       '�� n     '�� �     �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   �� 5       � ��$
 Bold"�6+   5      �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   �� 5       � ��$	 0,5q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$	 0,5q�6'   5      5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       $
��Auto �6   �� 5!      $
��Auto �6   �� 5"      $
��Auto �6   �� 5#      $
��Auto �6   �� 5$      $
��Auto �6   �� 5%      $
��Auto �6   �� 5&      $
��Auto �6   �� 5'      $
��Auto �6   .+�5*   
   �� $
��Date��6   $��0��6   (  "System.Windows.Controls.DatePicker  5+   
   $��1��6:      SelectedDate 6   �� *Target.Date+6:   �� 5-   
   $��Comment��6   $��2��6"   �� 5.   
   $��3��62   ��6   �� *Target.Comment+62   �� 50   
   $��
Difficulty��6   $��4��6%   �� 51   
   $��5��6c   ��6   �� *Difficulties+ �� SelectedItem 68   �� *Target.Difficulty+6c   �� 53   
   $��
Total Time��6   $��6��6%   �� 54   
   $��7��64   ��6   �� *Target.TotalTime+64   �� 56   
   $��Rating��6   $��8��6!   �� 57   
   $��9��61   ��6   �� *Target.Rating+61   �� 59   
   -   5         ��Name$ AddEditTourLogButton��59      $��Add Tour Log��6/   $��10��6m   $��
0, 5, 0, 0q�6{   ��6F   �� *SaveTourLogCommand+6{   5:      5<      