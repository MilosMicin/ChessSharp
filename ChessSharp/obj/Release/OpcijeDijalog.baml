   M S B A M L   `   `   `  ���� E  AChessSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ChessSharp.ModelChessSharp.Model      ChessSharp.OpcijeDijalog   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5
ChessSharpclr-namespace:ChessSharp.Model       � Title$  Opcije��$	��400��$	��350�� � 
ResizeMode$ NoResize=� � 	Resources  	  Tabla j� Stretch j� TileMode j� Viewport j� ViewportUnits L� Drawing � Brush	 � Geometry
 �� Rect  SahovskeFigurice �� 
TargetType �� Triggers ^� 
Conditions   ChessSharp.Model.Figurice   Kralj �� Value �� Binding   ChessSharp.Model.Igrac   Beli �� Property �� Value��%�  &	        &	 �     L� $
 None=�$
 Tile=�$ 0,0,2,2�$ Absolute=� I� .���  �� *Igra.PoljeSvetlo.Boja+	 �� $
 0,0,2,2��  �� *Igra.PoljeTamno.Boja+	 � .���� $
 0,0,1,1��� $
 1,1,1,1��� " �� ^�  �� # Z  �� *TipFigurice+�� # Z  �� *Igrac+0���  � �� �� *" SetFiguricaPublic.PutanjaPublic0+.��]� .+��� $��Bottom=� �� Orientation$ 
Horizontal=�.+��� -   $��btnOk�� �� 	IsDefault . .��Ok��  �� IsCancel . .��Cancle�  � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $��* �.+�� $��0��.+��� -   $��cbZvuk��$��Zvuk:��$��0��$
��Left=�$��	26,25,0,0q�$	��Top=� d� 	IsChecked$
 TrueY����� *Mute+� $��1�� �� $
��auto � � ColumnDefinitions �� $��33 ��� $��81 ��� $��* �.+��� $��0��$��Brzina racunara:��$��	20,15,0,0q�$��2���� $��0��$��2��$��Center=�$��10q�.+��� $��150px��$
��Left=� � Maximum$ 2Q� �� TickPlacement$ BottomRight=� �� IsSnapToTickEnabled . $��	20,10,0,0q�� $��2�� �� $
��auto ��� $
��auto � �� $
��auto ��� $��* �.+��� $��0��$��Set figurica:��$��	20,10,0,0q��� $��1��$��0��$	��100��$��
25,15,0,10q�$
��Left=�� $��1��$��1��.+��� $��2������ *Igra.KolekcijaFigurica+���� .R��� $	��1.5��$	��1.5�� J� 	AllowDrop . z���  �� CenterX$
 6.25Q� �� CenterY$
 8.25Q�  �� ScaleX$  30Q�! �� ScaleY$! 30Q����� .R��� .+��� $��2��$��2��#��[ 
" � Tag" �� ���� .���  �@��Left �� *
Pozicija.X+��  �@��Top �� *
Pozicija.Y+� $��3�� �� $
��auto ��� $
��auto ��� $
��auto � �� $
��auto ��� $��* �.+��� $��0��$��Sahovska tabla:��$��	20,10,0,0q��� $��1��$��0��$	��100��$��
25,20,0,10q�$
��Left=�!   ChessSharp.Model.PoljeTamno#   Boje2#��Z# $ �� SelectedItem$ �� *Igra.PoljeTamno+�� $��2��$��0��$	��100��$��
25,20,0,10q�$
��Left=�"   ChessSharp.Model.PoljeSvetlo%   Boje1#��Z% $ �� *Igra.PoljeSvetlo+�� -   $��SahowskaTabla��$��1��$��1������ .R��� $��2��$��2�� . #��[  z��� $	 1.5Q�$	 0.4Q�$  50Q�$! 50Q�