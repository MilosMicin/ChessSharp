   M S B A M L   `   `   `  ���� E  AChessSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ChessSharp.ModelChessSharp.Model      ChessSharp.NovaIgraDialog   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5
ChessSharpclr-namespace:ChessSharp.Model       � Title$  NovaIgraDialog��$	��200��$	��350�� � 
ResizeMode$ NoResize=�.��]� .+��� $��Bottom=� �� Orientation$ 
Horizontal=�.+��� -   $��btnOk�� �� 	IsDefault . .��Ok��  �� IsCancel . .��Cancle�  � RowDefinitions �� $��* ��� $��* �.+�� $��0��$��0,1,0,0q�$��2�� � ColumnDefinitions �� $
��auto ��� $��* � �� $
��auto �.+��� $��0��$��	15,20,0,0q�.��Vreme igranja:�� $��1��$	��100��$��	30,20,0,0q�$
��Left=�    ChessSharp.Model.Stoperica   Vremena#��Z  �� SelectedItem �� *Igra.StopericaPublic.MaxVreme+	 �� UpdateSourceTrigger$	 Explicit=��� $��2��$��Stretch=�� $��2�� �� $
��auto ��� $��* �.+��� -   $��	groupBox1��$��0��$��Igrac��.���� -   $��stackPanel1��$
��Left=�$��15,0,0,0q�.+�	� -   $��rbBeli��$
��Beli��$
��Left=�$��5q�
 d� 	IsChecked$

 TrueY�	� -   $��rbCrni��$
��Crni��$
��Left=�$��5,0,0,0q��� $��1��$��Tezina igre��.��A�  A� Columns$ 3�� A� Rows$ 2��$
��10,0q�.+�	� -   $��
rbNajlakse��$��Najlakse��$��5,5,0,0q�$

 TrueY�	� -   $��rbLako��$
��Lako��$��5,5,0,0q�	� -   $��	rbSrednje��$��Srednje��$��0,5,0,0q�	� -	   $��rbTesko��$��Tesko��$��30,5,0,0q�	� -
   $��	rbNajteze��$��Najteze��$��20,5,0,0q�