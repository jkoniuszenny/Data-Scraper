   M S B A M L   `   `   `  ���� F  BWeb Scraper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Web_ScraperWeb_Scraper      Web_Scraper.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:Web_Scraper       � Title$  NPB Currency Scraper��$	��421��$	��680��$	��680�� � 
ResizeMode$ NoResize=� � WindowStyle$ 
ToolWindow=� � Icon$ Resources/Pig.png�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 15Q�   
BlurRadius$ 50Q�.��� $	��400��$	��Top=�$��0,0,0,0q� � RowDefinitions ��  � ColumnDefinitions �� .+��� -   	 ��Name$	 exportExcel��$��Export Excel file��$��0,344,32,26q�
 J� RenderTransformOrigin$
 -0.08,0&�$��Right=�$	��103������  �� Color$ 	#FFDDDDDD�� �� Opacity$	 0.5Q��� -   $	 collectData��$��Start scraping��$��	32,0,0,26q�$
 -0.08,0&�$
��Left=�$	��103��$��30��$��Bottom=����� $ 	#FFDDDDDD��$	 0.5Q�&   System.Windows.Controls.DataGrid  -     Name$ dataGrid��$��32,142,32,68q�   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ *    CanUserResizeRows .     CanUserAddRows .     
IsReadOnly . (  "System.Windows.Controls.DatePicker  -     Name$ dataPic��$	��Top=�   FirstDayOfWeek$ Monday=�   SelectedDateFormat$ Short=�$��	73,84,0,0q�$
��Left=�$	��175���� -    ��Name$ label��$��Wybierz datę��$��Center=�$	��Top=�$��	73,57,0,0q�$
��Left=�$	��175���� -   $ label1��$��Wybierz tabelę��$��Center=�$	��175��$��0,57,73,317q�$��Right=��� -    ��Name$ 	tableList��$	��175��$��0,83,73,291q�$��Right=�.@��� $��Tabela A��$
��Left=�$	��175��$��0,0,-2,0q��� $��Tabela C��$
��Left=�$	��175��$��0,0,-2,0q��� $��Tabela H��$
��Left=�$	��175��$
 	0.508,2.7&�$��0,0,-2,0q��� -   $ 	tableName��$��Pick data and table type��$��Center=�$
��Left=�$��
32,109,0,0q�$	��Top=�$	��608��$��14(��� -	    ��Name$
 logo��$��Resources/nbp.jpg��$��48��$��73,4,0,0q�$	��Top=� J� OpacityMask �	#FFFFFBFB$
��Left=�$	��229���� -
   $ label2��$��Download exchange tabel�����#065552$��Right=�$��	0,11,73,0q�$	��Top=�$��34��$	��272��$��20(�$��Times New Roman)�&   System.Windows.Media.TextOptions   TextHintingMode$ Animated=�
���   ���Z� 