   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LibraryLibrary  5          Library.ManagePublicsher   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Library     5        N� Title$  ManagePublicsher��5	       N� 
Background �#F5DEB3.��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   $��109.96��6*   �� 5       � ColumnDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $��1* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��2��6;   $��40,40,40,40q�6O   .+�5      �� -   5         ��Name$ SearchTextBox��5      $	��200��6-   $��5q�69   $��Search by Name��6D   
�������6Z   �� 5      -   5         ��Name$ SearchButton��5      $��Search��6+   $��5q�6W   5       � 5#   
   $��1��6   $��2��6   $��0,10,0,0q�60   $	��390��6B   $	��Top=�6O    5$      �� 5%      $	��49* �6#   �� 5&      $	��47* �6#   �� 5(      $	��64* �6#   .+�5-      &   System.Windows.Controls.DataGrid  -   5          Name$ PublicsherDataGrid��5-         AutoGenerateColumns$ False��5.      	   CanUserAddRows$	 False��5/      
   CanUserDeleteRows$
 False��50         CanUserSortColumns$
 True��51      $��10,-10,10,63q�52         GridLinesVisibility$	 All=�53         
IsReadOnly$
 True��54         SelectionMode$ Single=�55      $��0��56      $��2��57         Columns 58      0  *System.Windows.Controls.DataGridTextColumn  59      ,  &System.Windows.Controls.DataGridColumn   Header$ Publicsher Name��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *Name+6[     5:      $ Address��6)   $ * 6V    6:   �� *	Address+6V     5;      $ Contact��6)   $ * 6V    6:   �� *	Contact+6V     5<      $ Id��6)   $ * 6U      
Visibility$ 	Collapsed=�6_    65   �� *PublisherId+6_   5>      �� 5A      $��2��6   $��
10,0,10,20q�6)   .+�5C      �� $ 
Horizontal=�6   $	��0,5q�66   .+�5D      �� $��Center=�6    $��80��6;   $
��Name��6F   �� 5E      -   5        $ NameTextBox��5E      $	��Top=�63   $��5q�6K    �� 
IsReadOnly$
 True��6V   $	��200��6~   ��6h   �� *Name+6~   5F      �� 5I      $ 
Horizontal=�6   $	��0,5q�66   .+�5J      �� $��Center=�6    $��80��6;   $��Address��6F   �� 5K      -   5        $ AddressTextBox��5K      $	��Top=�66   $��5q�6N   $
 True��6Y   $	��201��6�   ��6k   �� *	Address+6�   5L      �� 5O      $ 
Horizontal=�6   $	��0,5q�66   .+�5P      �� $��Center=�6    $��80��6;   $��Contact��6F   �� 5Q      -   5        $ ContactTextBox��5Q      $	��Top=�66   $��5q�6N   $
 True��6Y   $	��203��6�   ��6k   �� *	Contact+6�   5R      �� 5U      $ 
Horizontal=�6   $	��164��66   $
��0,10q�6B   .+�5V      �� -   5        $ 	AddButton��5V      $��Add Publisher��60   $	��141��6H   6T   5W      5X      5Y      5Z      5[      