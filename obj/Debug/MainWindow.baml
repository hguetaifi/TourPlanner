   M S B A M L   `   `   `  ����F  BTourPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TourPlannerTourPlanner  5   	   5clr-namespace:TourPlanner.ViewsTourPlanner.Views  5   	       TourPlanner.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TourPlanner     5   	   1viewsclr-namespace:TourPlanner.Views     5   	     � Title$  Tour Planner��5	   	   $	��450��6   $	��800��6+    � WindowState$ 	Maximized=�5
   	    � 
ResizeMode$ 	CanResize=�5   	    � DataContext 5      "   TourPlanner.ViewModelLocator  5   
    � 	Resources 5      8   2TourPlanner.StringNullOrEmptyToVisibilityConverter *  &StringNullOrEmptyToVisibilityConverter �� 
TargetType �� Property �� Value   BooleanToVisibilityConverter��%�  &	        'm�      '�� �     &	 N      5   
   67   �� 5   
   " m�6   .�5      ��  � ��$ 16(�6)   �� 5       � ��$
 10,0q�6(   5      �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      .R�5      �� $
��Bold"�65   $��16(�6G   ��6$   �� 6G   5      5      �� 5       � ��$ 10q�6(   5       �� 5!   
   6'   5"      .��5$      � .+�5&   
   ]� .+�5(      o� $	��Top=�6   .@�5)      m� $
��File��6   .@�5*      m� $��Import��6    m� Command 6/   �� *ToursVM.ImportCommand+m� 5+      $��Export��6    6/   �� *ToursVM.ExportCommand+5,      m� 5-      $
��Edit��6   .@�5.      m� $
��Undo��6   m� 5/      $
��Redo��6   50      m� 51      $��Options��6   .@�52      m� $��Generate Summarize Report��6    6B   �� *(&ToursVM.GenerateSummarizeReportCommand+53      m� 54      $
��Help��6   55      � 56      $	��Top=�6   $��5q�6(   .+�57      �� -   5        	 ��Name$	 	SearchBox��57      
������ $��Center=�6�   ��6-   �� 
 �� Path$
 ToursVM.SearchText� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 58      $��Search tours...��6   
������� J� IsHitTestVisible .  y�5:      ��  �� ElementName$ 	SearchBox��$

 Text� �� 	Converter# [  ��5;      u� 5<       u� Left$ 5Q�6$    u� Right$ 0Q�6-   
 u� Top$ 0Q�67    u� Bottom$ 0Q�6?   5>      �� 5?      $��search_icon.png��6   $��Right=�61   $��20��6M   $��0,0,10,0q�6X   5@      $   TourPlanner.Views.TourListView  5A      $
��Left=�6!   $	��350��67    6C   �� *	ToursVM+�� 5B      .@�5C      �� $��General��6   .��5D      '   !TourPlanner.Views.TourGeneralView   6,   �� *	ToursVM+5E      �� 5F      $��Route��6    6)   �� *
TourLogsVM+.��5G      %   TourPlanner.Views.TourRouteView  5H      5I      5J      � 5L   
   
������ y�6(   �� *ToursVM.IsLoading+# [ .+�5M      �� ���	#800000006   � 5N       � IsIndeterminate . $	��100��61   $	��100��6=   $��Center=�6J   $��Center=�6e   5O      5Q      5S      