   M S B A M L   `   `   `  ����E  AChessSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ChessSharp.ModelChessSharp.Model  5   	       ChessSharp.NovaIgraDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   5
ChessSharpclr-namespace:ChessSharp.Model     5   	     � Title$  NovaIgraDialog��5   	   $	��200��6    $	��350��6-    � 
ResizeMode$ NoResize=�69   .��5      ]� .+�5   
   �� $��Bottom=�6    �� Orientation$ 
Horizontal=�6-   .+�5      �� -   5        $��btnOk��5       �� 	IsDefault . .��6G   Ok6K   �� 5	       �� IsCancel . .��6&   Cancle6.   5
      � 5   
    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    .+�5      � $��0��6   $��0,1,0,0q�6    $��2��61    � ColumnDefinitions 5      �� 5      $
��auto �6'   �� 5      $��* �6'    5      �� 5      $
��auto �6$   .+�5      �� $��0��6   $��	15,20,0,0q�6(   .��6<   Vreme igranja:6L   �� 5      $��1��6   $	��100��6+   $��	30,20,0,0q�67   $
��Left=�6J       ChessSharp.Model.Stoperica   Vremena#��Z 6e    �� SelectedItem 6�   �� *Igra.StopericaPublic.MaxVreme+	 �� UpdateSourceTrigger$	 Explicit=�5      �� 5      $��2��6   $��Stretch=�6(   � 5      $��2��6    5      �� 5      $
��auto �6'   �� 5      $��* �6'   .+�5!      �� -   5        $��	groupBox1��5!   :   $��0��6   $��Igrac��6+   .��5"      �� -   5        $��stackPanel1��5"   !   $
��Left=�64   $��15,0,0,0q�6O   .+�5#      	� -   5        $��rbBeli��5#   &   $
��Beli��64   $
��Left=�6C   $��5q�6^   
 d� 	IsChecked$

 TrueY�6j   	� 5$      -   5        $��rbCrni��5$   &   $
��Crni��64   $
��Left=�6C   $��5,0,0,0q�6^   5%      5&      �� 5'      $��1��6   $��Tezina igre��6+   .��5(      A�  A� Columns$ 3��6"    A� Rows$ 2��6.   $
��10,0q�67   .+�5)      	� -   5        $��
rbNajlakse��5)   &   $��Najlakse��68   $��5,5,0,0q�6K   $

 TrueY�6\   	� 5*      -   5        $��rbLako��5*   &   $
��Lako��64   $��5,5,0,0q�6C   	� 5+      -   5        $��	rbSrednje��5+   &   $��Srednje��67   $��0,5,0,0q�6I   	� 5,      -	   5        $��rbTesko��5,   &   $��Tesko��65   $��30,5,0,0q�6E   	� 5-      -
   5        $��	rbNajteze��5-   &   $��Najteze��67   $��20,5,0,0q�6I   5.      5/      50      51      52      53      