   M S B A M L   `   `   `  ����K  GOrderEntrySystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:OrderEntrySystemOrderEntrySystem  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� DataType&     OrderEntrySystem.LaptopViewModel"   OrderEntrySystem.ProductView%   OrderEntrySystem.OrderViewModel    OrderEntrySystem.OrderView(   "OrderEntrySystem.CustomerViewModel#   OrderEntrySystem.CustomerView(   "OrderEntrySystem.LocationViewModel#   OrderEntrySystem.LocationView(   "OrderEntrySystem.CategoryViewModel#	   OrderEntrySystem.CategoryView&
    OrderEntrySystem.ReportViewModel!   OrderEntrySystem.ReportView   ListViewStyle �� 
TargetType �� Property �� Value �� Path �� Mode �� Triggers ]� 
Conditions �� Property	 �� Value  WorkspacesTemplate$
 �� IsSynchronizedWithCurrentItem � Cursor  NestedCommandTemplate �� Orientation �� 	IsDefault �� IsCancel  CommandGroups �� Source �� GroupDescriptions2  ,System.Windows.Data.PropertyGroupDescription   PropertyName  CommandsTemplate �� Source �� 
GroupStyle(  "System.Windows.Controls.GroupStyle   ContainerStyle �� 
TargetType 9� 
IsExpanded  MainHeaderStyle  Brush_HeaderBackground �� CornerRadius �� Padding J� SnapsToDevicePixels  ValidationStyleTextBox P� Property P� Value �� RelativeSource �� ElementName  PagingButton 	 PagingTextBlock�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      %vmclr-namespace:OrderEntrySystem  5      %m  (��       5      *,  +)(�� 7     5	      *, +)(�� n     5      *, +)(�� �     5      *, +)(�� �     5      *, +)(��     5      *,
 +)&	  J    &	 �    &	 y    &	 �    &	 X    7  &	 �    7  &	 
    &	 A    &		      �� 5      "    6   .R�5   
     6   5      �� 5	      "   6   .R�5
   
     6   5      �� 5      "   6   .R�5   
     6   5      �� 5      "   6   .R�5   
     6   5      �� 5      "   6   .R�5   
   	  6   5      �� 5      "  
 6   .R�5   
     6   5      �� 5      " ��6"   .�5   
   ��  � ��$ Stretch=�67   �� 5   
    �@��
IsSelected 6'   �� $ 
IsSelected�$ TwoWay=� 5    
   ]� 5!       5"      �� 5#       �@��AlternationIndex$	 1��6I   �� 5$       �@��
IsSelected	 .  66   �� 5%       �@J�IsMouseOver	 .  67   ./�5'      ��  � �� �	#EEEEEEEE6/   5(      5*      �� 5,      .R�5-   
   �� $

 TrueY�6   $��4q�6R   ��6:   �� ��5.      �� 5/      .R�50      ]� .+�51      �� $��X��6!   $��Right=�6-   $
 Hand��6D   $��4,0,0,0q�52   !   $
��Bold"�62   $��16��6D   $��16��6P   $��Courier)�53   !   $��9(�66   ��6C   �� $ CloseCommand��� 54      $��Center=�6P   ��6+   �� $ DisplayName�6P   55      56      58      59      �� 5;      .R�5<   
   �� $��Right=�6/   ��6   �� ��5=      �� 5>      .R�5?      �� $ 
Horizontal=�6!   5@      ��5B      �� 5C      .R�5D      �� $��23��6�   $��75��6�   $��4,4,0,0q�6�   ��6   �� $ Command���6>   �� $ DisplayName� 6c   �� $ 	IsDefault� 6�   �� $ IsCancel�6�   5E      5G      5H      �� 5J       61   �� $ Commands� 5K   
     5L      $ 	GroupName��6'   5N      �� 5P      .R�5Q   
   �� ��6   �� 8   ��5R      �� 5S      .R�5T      �� ��6   �� $ Command���6>   �� $ DisplayName�5U       5W        5X       5Y      �� 5Z      " ��6    .�5[      ��  � �� 5\   "   �� 5]   &   " ��66   .R�5^   *   9�  . ��63   �� $
 Name�.��5_   .   �� 5`   +   5a   '   5c      5d      5f      5h      5i      �� 5k      " ��6$   .�5l   
   ��  � �� 5m      �� 5n      .R�5o      �� 8��  
�������$��1q�6j   $ 5��5p      $��4q�6.   $ 4q�69    . ._�5q      �� $��14(�6$   $
��Bold"�62   
�������$��Center=�6W   #��z��6t   5r      5s      5u      �� 5v   
    � �� .  6&   �� 5w   
    � �� 5x      �� 5z      " ��6"   .R�5{      ]� .+�5|      �� $	��Top=�6+   $��Header��6@   #��z��6W   �� 5}      $��Content��6+   #��z��6C   5~      5      5�      5�      �� 5�      " ��6+    5�   
   P� 5�       �@=�HasError . . �5�      ��  �@�ToolTip 6,   ��  �� *Self+$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 5�       �@=�ErrorTemplate 5�      �� 5�      .R�5�      ]� ��. .+�5�   "   �� $��Right=�6,   $��Center=�6C   $��5,0,0,0q�6^   ��6o   �� $ customAdorner��$A ;AdornedElement.(Validation.Errors).CurrentItem.ErrorContent��� 5�   "   
���  ��$��right=�6:   $��5,0,0,0q�6Q   $��20��6b   $��20��6m   $ 10��6y   ._�5�   &   �� $��!��60   $��center=�69   $��center=�6T   $
��Bold"�6q   
�������6�   5�   #   �� 5�   "   $��customAdorner��6<   $��Center=�6Q   .v�5�   &   �� 
���  ��$��1q�6?   5�   #   5�      5�      5�      5�      5�      �� 5�      " ��6!   .�5�   
   ��  � ��$ Webdings)�6'   �� 5�   
    � ��$ 23��6#   �� 5�   
    � ��$ 45��6"   �� 5�   
    � ��$ 4,0,4,0q�6#   5�      �� 5�      " ��6$   .�5�   
   ��  � ��$ 4,0,4,0q�6#   �� 5�   
    � ��$ Center=�6.   5�      5�      