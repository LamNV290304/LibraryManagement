   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LibraryLibrary  5          Library.ManageAuthor   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Library     5        N� 
Background  �#F5DEB3 N� Title$ 
Add Author��5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   $��109.96��6*   �� 5       � ColumnDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $��1* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��2��6;   $��40,40,40,40q�6O   .+�5      �� -   5         ��Name$ SearchTextBox��5      $	��200��6-   $��5q�69   $��Search by Author Name��6D   
�������6a   �� 5      -   5         ��Name$ SearchButton��5      $��Search��6+   $��5q�6W   5      � 5"   
   $��1��6   $��2��6   $��0,10,0,0q�60   $	��390��6B   $	��Top=�6O    5#      �� 5$      $	��49* �6#   �� 5%      $	��47* �6#   �� 5'      $	��64* �6#   .+�5,      &   System.Windows.Controls.DataGrid  -   5          Name$ AuthorDataGrid��5,         AutoGenerateColumns$ False��5-      	   CanUserAddRows$	 False��5.      
   CanUserDeleteRows$
 False��5/         CanUserSortColumns$
 True��50      $��10,-10,10,81q�51         GridLinesVisibility$	 All=�52         
IsReadOnly$
 True��53         SelectionMode$ Single=�54      $��0��55       �� SelectedValuePath$ AuthorId��56      $��2��57   I      Columns 58      0  *System.Windows.Controls.DataGridTextColumn  59      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6)      
Visibility$ 	Collapsed=�6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *
AuthorId+6R     5:      $ Author name��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6W    6>   �� *Name+6W     5;      $ Birthday��6)   $ * 6Y    6;   �� *	Birthdate+6Y     5<      $ Nation��6)   $ * 6Y    69   �� *Nationality+6Y   5>      �� 5A      $��2��6   $��
10,0,10,20q�6)   .+�5C      �� $ Vertical=�6   $��10,10,10,10q�64   .+�5E      �� $ 
Horizontal=�6!   $	��0,5q�6:   .+�5F      �� $
��Name��6$   $��Center=�60   $��80��6K   �� 5G      -   5        $ AuthorNameTextBox��5G   "   $	��Top=�6=   $��5q�6U   $	��194��6`   $��21��6l   5H      �� 5K      $ 
Horizontal=�6!   $	��0,5q�6:   .+�5L      �� $��Birthday��6$   $��Center=�64   $��80��6O   (  "System.Windows.Controls.DatePicker  5M      -   5          Name$ AuthorBirthdatePicker��5M   %   $	��Top=�6D   $��5q�6\   $��30��6g   $	��196��6s   5N      �� 5Q      $ 
Horizontal=�6!   $	��0,5q�6:   .+�5R      �� $��Nation��6$   $��Center=�62   $��80��6M   �� 5S      -   5        $ AuthorNationalityTextBox��5S   "   $	��Top=�6D   $��5q�6\   $	��191��6g   $��21��6s   5T      5U      �� 5Y      $ 
Horizontal=�6   $	��194��66   $
��0,10q�6B   .+�5Z      �� -   5        $ 	AddButton��5Z      $��Add New Author��60   $��5q�6I   $	��163��6l   5[      5\      5]      5^      5_      