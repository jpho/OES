   M S B A M L   `   `   `  ����K  GOrderEntrySystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:OrderEntrySystemOrderEntrySystem  5      "    OrderEntrySystem.ProductView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:OrderEntrySystem     5        � 	Resources  5	       �� Source�� 5
   
   $ SharedResources.xaml?�6   %    .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � $��4q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��4 �6#   �� 5      $	��200 �6#    5      �� 5      $
��Auto �6    �� 5      $��4 �6    �� 5      $
��Auto �6    �� 5      $��4 �6    �� 5      $
��Auto �6    �� 5      $��4 �6    �� 5      $
��Auto �6    �� 5      $��4 �6    �� 5       $
��Auto �6    �� 5!      $��4 �6    �� 5"      $
��Auto �6    �� 5#      $��4 �6    �� 5$      $
��Auto �6    .+�5&      �� $��0��6   $��0��6!   $��Name:��61   $��Right=�6A    �� Target 6]   ��  �� ElementName$ nameTextBox���� 5'      -   5         ��Name$ nameTextBox��5'      $��0��6+   $��2��68      ValidationStyleTextBox#��[  6�   ��6H   ��  �� Path$
 Name� �� ValidatesOnDataErrors . 	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   �� 5(      $��2��6   $��0��6!   $��Description:��61   $��Right=�6H    6d   �� $ descriptionTextBox���� 5)      -   5        $ descriptionTextBox��5)      $��2��62   $��2��6?   #��[  6�   ��6O   �� $ Description� . $	 PropertyChanged=�6�   �� 5*      $��4��6   $��0��6!   $��Price:��61   $��Right=�6B    6^   �� $ priceTextBox���� 5+      -   5        $ priceTextBox��5+      $��4��6,   $��2��69   #��[  6�   ��6I   �� $ Price� . $	 PropertyChanged=�6�   �� 5,      $��6��6   $��0��6!   $��	Location:��61   $��Right=�6E    6a   �� $ locationComboBox���� 5-      -   5        
 ��Name$
 locationComboBox��5-      $��6��61   $��2��6>   ��6N   �� $ 	Locations� �� SelectedItem 6u   �� $ Location��� 5.      $��8��6   $��0��6!   $��
Condition:��61   $��Right=�6F    6b   �� $ conditionComboBox���� 5/      -   5        $
 conditionComboBox��5/      $��8��62   $��2��6?   ��6O   �� $ 
Conditions� 6w   �� $ 	Condition��� 50      $��10��6   $��0��6"   $��	Quantity:��62   $��Right=�6F    6b   �� $ quantityTextBox���� 51      -   5        $ quantityTextBox��51      $��10��6/   $��2��6=   #��[  6�   ��6M   �� $ Quantity� . $	 PropertyChanged=�6�   (   "OrderEntrySystem.MultiCategoryView  52      $��12��6&   $��2��64    � DataContext 6D   �� $ FilteredCategoryViewModel�53      �� 54   
   $��1��6   $��2��6&     NestedCommandTemplate#��[ 6X   $��Bottom=�6�   $��0,0,4,4q�6�   ��66   �� $ Commands�6�   55      56      