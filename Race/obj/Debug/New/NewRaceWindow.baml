   M S B A M L   `   `   `  ����  Race    Race.NewRaceWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  NewRaceWindow��5   	   $	��300��6   $	��300��6,    � IsSharedSizeScope . .��5      �  � ColumnDefinitions 5   
   �� 5       z� SharedSizeGroup$ G1��6   �� 5      $ G2��6   �� 5	      $ G3��6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $
��Name��6   $��0��6    $��0��6-   �� 5   
   $
��Type��6   $��0��6    $��1��6-   �� 5   
   $
��Laps��6   $��0��6    $��2��6-   �� 5   
   -   5        $��mName��5   /   $��1��6   $��0��6   6/   �� 5   
   -   5        $��mType��5   0   $��1��6   $��1��6    ��6=   ��  �� Path$ 
Categories� �� SelectedItem 6e   �� $ SelectedCategory��� 5   
   -   5        $��mLaps��5   /   $��1��6   $��2��6   $��3��6<   � 5   
   $��3��6   $��0��6   $��3��6,    5      �� 5      $��* �6#   �� 5      $ T1��6#   �� 5      $ T2��6#   .+�5      �� -   5        $��mCreateButton��5   &   $��Create��6   $��1��6;   �� 5       -   5        $��mCancelButton��5    &   $��Cancel��6   $��2��6;   5!      5"      5#      