   M S B A M L   `   `   `  ����F  BTourPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TourPlanner.ViewsTourPlanner.Views  5      '    !TourPlanner.Views.TourGeneralView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:TourPlanner.Views     5        � 	Resources  5	       �� 
TargetType �� Property �� Value   
LabelStyle  DisabledTextStyle  ButtonStyle��%  '��       '�� H     &	  �     &	 F    &	 �    �� 5
   
   " ��6   .�5      ��  � ��$ 10q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 20(�6)   �� 5       � ��$ 10q�6'   5      �� 5   
   " ��6#   .�5      ��  � ��$ 15(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 10q�6'   5      �� 5   
   " ��6*   .�5      ��  � ��$ 15(�6)   �� 5       �@��
IsReadOnly . 6+   �� 5       � ��$ 10q�6'   5      �� 5   
   " ��6$   .�5      ��  � ��$ 16(�6)   �� 5       � ��
 �����6+   �� 5       � ��
 �   �6+   �� 5       � ��$
 12 6q�6(   �� 5        � ��$ 10q�6'   �� 5!       � ��$ Right=�64   5"      5#      .��5%      �  � ColumnDefinitions 5&   
   �� 5'      $��* �6   �� 5(      $��3* �6    � RowDefinitions 5+   
   �� 5,      $
��Auto �6   �� 5-      $
��Auto �6   �� 5.      $
��Auto �6   �� 5/      $
��Auto �6   �� 50      $
��Auto �6   �� 51      $
��Auto �6   �� 52      $
��Auto �6   �� 53      $
��Auto �6   �� 54      $
��Auto �6   �� 55      $
��Auto �6   �� 56      $
��Auto �6   �� 57      $
��Auto �6   �� 58      $
��Auto �6   �� 59      $
��Auto �6   .+�5<   
   �� $��Tour Details��6   $��0��6(   $��0��68   $��2��6E   $
��Bold"�6Y   $��20(�6k   �� 5=   
   $��0��6   $��1��6$   $��2��61   $��2��6E   
���   �$
��0,10q�6]   �� 5?   
   $��Name:��6   $��0��6!   $��2��61   #��[  6>   �� 5@   
   $��1��6<   $��2��6L   #��[ 6Y   ��6   �� *SelectedTour.Target.Name+6Y   �� 5B   
   $��Description:��6   $��0��6(   $��3��68   #��[  6E   �� 5C   
   $��1��6C   $��3��6S   #��[ 6`   ��6   �� *!SelectedTour.Target.Description+6`   �� 5E   
   $��From:��6   $��0��6!   $��4��61   #��[  6>   �� 5F   
   $��1��6<   $��4��6L   #��[ 6Y   ��6   �� *SelectedTour.Target.From+6Y   �� 5H   
   $	��To:��6   $��0��6   $��5��6/   #��[  6<   �� 5I   
   $��1��6:   $��5��6J   #��[ 6W   ��6   �� *SelectedTour.Target.To+6W   �� 5K   
   $��Transport Type:��6   $��0��6+   $��6��6;   #��[  6H   �� 5L   
   $��1��6E   $��6��6U   #��[ 6b   ��6   �� *#!SelectedTour.Target.TransportType+6b   �� 5N   
   $��	Distance:��6   $��0��6%   $��7��65   #��[  6B   �� 5O   
   $��1��6@   $��7��6P   #��[ 6]   ��6   �� *SelectedTour.Target.Distance+6]   �� 5Q   
   $��Estimated Time:��6   $��0��6+   $��8��6;   #��[  6H   �� 5R   
   $��1��6E   $��8��6U   #��[ 6b   ��6   �� *#!SelectedTour.Target.EstimatedTime+6b   �� 5T   
   $��Route Information:��6   $��0��6.   $��9��6>   #��[  6K   �� 5U   
   $��1��6H   $��9��6X   #��[ 6e   ��6   �� *&$SelectedTour.Target.RouteInformation+6e   �� 5W   
   $��Popularity:��6   $��0��6'   $��10��67   #��[  6E   �� 5X   
   $��15(�6D   $��1��6R   $��10��6b   ��6   �� * SelectedTour.Target.Popularity+6b   �� 5Z   
   $��Child Friendliness:��6   $��0��6/   $��11��6?   #��[  6M   �� 5[   
   $��15(�6K   $��1��6Y   $��11��6i   ��6   �� *'%SelectedTour.Target.ChildFriendliness+6i   �� 5]   
   $��Generate Report��6   $��1��6+   $��12��6;   #��[ 6I   ��6n   �� *GenerateReportCommand+5^      5_      