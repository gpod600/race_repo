   M S B A M L   `   `   `  ����?  ;Race, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Race.UserControlsRace.UserControls  5   	       Race.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   2raceucclr-namespace:Race.UserControls     5   	     � Title$  
MainWindow��5   	    � SizeToContent$ WidthAndHeight=�5   	    � IsSharedSizeScope . $	��600��5      $	��600��5	      $	��800��5
   	    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��$ 4,4,4,4q�6'   �� 5       � ��$ 30��6*   �� 5       � ��$ 50��6)   5      5      .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      �� $��0��6   .@�5      �� -   5        $��mRace��5   (   $
��Race��6   .��5      '   !Race.UserControls.RaceUserControl  -   5          Name$ mRaceUserControl��5   -   5      �� 5      $��League��6   �� 5      $��Riders��6   .��5      )   #Race.UserControls.RidersUserControl  -   5        	  Name$	 mRidersUserControl��5   /   5      �� 5       $��Clubs��6   .��5!      (   "Race.UserControls.ClubsUserControl  -   5        
  Name$
 mClubsUserControl��5!   .   5"      5#      � 5$      $��1��6    � ColumnDefinitions 5%      �� 5&      $��* �6'   �� 5'      $
��Auto �6'    z� SharedSizeGroup$ Button��64   �� 5(      $
��Auto �6'   $ Button��64   �� 5)      $
��Auto �6'   $ Button��64   .+�5+      �� -   5        $��mSave��5+   8   $��2��6   $
��Save��6)   6E   �� 5,      -   5        $��mClose��5,   9   $��3��6   $��Close��6)   6G   5-      5.      50      51      