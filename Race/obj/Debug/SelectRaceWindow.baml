   M S B A M L   `   `   `  ����  Race    Race.SelectRaceWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Races��5   	   $	��300��6   $	��300��6$    � 	Resources 5       �� 
TargetType �� Property �� Value��%W   '��       �� 5   
   " ��6   .�5      ��  � ��$ 4,4,4,4q�6'   5      5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Select Existing��6   &   System.Windows.Controls.DataGrid  5   
   -   5        $��mRaces��5      $��1��6!   $��2��6.      SelectionMode$ Single=�6B      
IsReadOnly .    VerticalGridLinesBrush
 �����	   HorizontalGridLinesBrush
	 �������6�   �� 
 �� Path$
 LoadDataBinding�6�   � 5   
   $��3��6    � ColumnDefinitions 5      �� 5      $��6* �6#   �� 5      $	��23* �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� -   5        $��mCreate��5      $	��New��6$   $��2��63   �� 5      -   5        $��mOpen��5      $
��Open��6"   $��3��61   �� 5      -   5        $��mClose��5      $��Close��6#   $��4��63   6C   5      5!      5"      