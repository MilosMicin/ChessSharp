   M S B A M L   `   `   `  ���� E  AChessSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ChessSharp.ChessLogicFChessSharp.ChessLogicF  ,    &ChessSharp.ChessLogicF.frmLoadPGNGames   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6local$clr-namespace:ChessSharp.ChessLogicF       � Title$  wndPGNParsing�� � WindowStartupLocation$ CenterOwner=� � 
ResizeMode$ NoResize=� � ShowInTaskbar .   � WindowStyle$
 None=�$	��418��$	��315��.����  �� Orientation$ Vertical=�$��Center=�.+��� $!��Parsing PGN Games from file��$��16(�$��Center=�$��Center=��� $�� ��$��16(��� $ 
Horizontal=�$��Center=�.+��� $��Processing file:��$��12(�$��Center=�$��Center=��� -    ��Name$ ctlFileBeingProcessed��$��File123.png��$��12(�$��Center=�$��Center=��� $ 
Horizontal=�$��Center=�.+��� $��Phase:��$��12(�$��Center=�$��Center=��� -   $ ctlPhase��$��Reading Data in memory��$��12(�$��Center=�$��Center=��� -   $ ctlStep��$��0 / 0��$��12(�$��Center=�$��Center=�0   *ChessSharp.ChessLogicF.CircularProgressBar  -     Name$ ProgressBar��$��10q�$	��120��$	��120���� -    ��Name$ 	butCancel��$��Cancel��$��75��$��10q�