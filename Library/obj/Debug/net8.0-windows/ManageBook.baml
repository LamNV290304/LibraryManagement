   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LibraryLibrary  5          Library.ManageBook   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Library     5        N� Title$  
ManageBook��5	       N� 
Background �#F5DEB3.��5      �  � RowDefinitions 5   
   �� 5      $	��22* �6   �� 5      $	��23* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��10,10,30,10q�6,   $��2��6A   .+�5      �� $ 
Horizontal=�6   $��0,0,0,10q�62   .+�5      �� -   5         ��Name$ CategoryComboBox��5      $	��150��65   $��	20,0,10,0q�6A    �� DisplayMemberPath$
 Name��5       �� SelectedValuePath$ 
CategoryId��5      �� 5      -   5        $ AuthorComboBox��5      $	��150��63   $��	20,0,10,0q�6?   $
 Name��5      $ AuthorId��5      �� 5       -   5        $ YearComboBox��5       $	��150��61   $��	20,0,10,0q�6=   5"      �� 5#      -   5         ��Name$ SearchTextBox��5#      $	��200��61   $��	20,5,0,10q�6=   $��Search by Title��5$      
�������5'      5(      �� 5+      -   5        $��Add Book��5+      $	��150��6(   $��40��64   
��� � �
�������$��
20,10,0,10q�5,      $
��Left=�6)   5-      �� 5/      -   5        $��Manage Categories��5/      $	��150��61   $��40��6=   
��� ���
�������$��
20,10,0,10q�50      $
��Left=�6)   51      &   System.Windows.Controls.DataGrid  54      -   5          Name$ BooksDataGrid��54      	   AutoGenerateColumns$	 False��6.   
   
IsReadOnly$

 True��6J      Columns 55      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *BookId+6P     57      $ Title��6)   $ * 6R    68   �� *Title+6R     58      $
 ISBN��6)   $ * 6P    67   �� *Isbn+6P     59      $ 	Publisher��6)   $ * 6Z    6<   �� *	Publisher+6Z     5:      $ Total copies��6)   $ * 6_    6?   �� *TotalCopies+6_     5;      $ Available copies��6)   $ * 6g    6C   �� *AvailableCopies+6g     5<      $ Price��6)   $ * 6R    68   �� *Price+6R     5=      $ Author��6)   $ * 6X    69   �� *
AuthorName+6X     5>      $ Category��6)   $ * 6\    6;   �� *CategoryName+6\     5?      $ Publication Year��6)   $ * 6g    6C   �� *PublicationYear+6g   5A      �� 5D      $ 
Horizontal=�6   $��Center=�62   $��10q�6O   .+�5E      �� -   5         ��Name$ PageInfoText��5E      $��Center=�62   $��Center=�6M   $
��10,0q�6j   5F      5G      5H      5I      