   M S B A M L   `   `   `  ����  Race'    !Race.UserControls.RaceUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � .+�5   
   �   � ColumnDefinitions  5	      �� 5
      $��* �6#   �� 5      $
��Auto �6#    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��Recent Riders��6   $��0��6-   �� 5      $��Leader Board��6   $��2��6,   &   System.Windows.Controls.DataGrid  5      -   5        $��mRiders��5      $	��200��6&   $	��400��66   $��1��6E      VerticalGridLinesBrush
 �����   HorizontalGridLinesBrush
 �������6S   ��  �� Path$ LoadDataBinding�5        5      -   5        $��
mPositions��5      $	��200��6)   $	��400��69   $��3��6H   
 �����
 �������6V   �� $ LoadDataBinding�5      � 5      $��0��6   $��4��6    $��1��61   $	��Top=�6A   $��5q�6Y    5      �� 5      $
��Auto �6$   �� 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5       $
��Auto �6$   �� 5!      $
��Auto �6$     5#      �� 5$      $
��Auto �6'   �� 5%      $
��Auto �6'   �� 5&      $
��Auto �6'   .+�5)      �� $��Start��6   $��0��6)   $��0��66   $	��Top=�6F   $
��Left=�6^   �� 5*      -   5        $��mStart��5*      $��00:00:00��6(   $��0��68   $��1��6E   $��2��6U   $��30(�6j   $��Right=�6x   $��Center=�6�   �� 5,      $��Duration��6   $��1��6,   $��0��69   $	��Top=�6I   $
��Left=�6a   �� 5-      -   5        $��	mTimeText��5-      $��00:34:56��6-   $��1��6=   $��1��6J   $��3��6Z   $��30(�6o   $��Right=�6}   �� 5/      -   5        $��mRiderNumber��5/      $��2��6.   $��0��6;   $��3��6K   $�� ��6_   $	��100(�6g   $	��200��6v   $
��Left=�6�   6�   5A      5C      5D      5E      