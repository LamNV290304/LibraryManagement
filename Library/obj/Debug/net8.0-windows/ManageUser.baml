   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LibraryLibrary  5          Library.ManageUser   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Library     5        N� Title$  
ManageUser��5	      .��5      � ���#F0F8FF$��10q�6     � ColumnDefinitions 5   
   �� 5      $��8* �6   �� 5      $��5* �6   .+�5   
   �� $��0��6   $��
10,10,5,10q�6%   .+�5      �� $��Manage Users��6   $��24(�5      $
��Bold"�5      
���OO/�$��Center=�5      $��0,0,0,10q�5      �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��0,0,0,10q�6O   .+�5      �� $��Search by Username:��6   $��0,0,5,0q�67   $��Center=�6H   �� 5      -   5         ��Name$ txtSearchUsername��5      $	��200��65   6A   5      &   System.Windows.Controls.DataGrid  5!      -   5          Name$ dataGridUsers��5!         AutoGenerateColumns$ False��5"         CanUserAddRows$ False��5#         CanUserDeleteRows$ False��5$         
IsReadOnly$
 True��5%      	   ColumnHeaderHeight$	 40Q�5&      
   	RowHeight$
 35Q�5'         AlternatingRowBackground
 �����   Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$ Username��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *
Username+6X     5-      $ 
First Name��6)   $ * 6[    6=   �� *	FirstName+6[     5.      $ 	Last Name��6)   $ * 6Y    6<   �� *
LastName+6Y     5/      $ Email��6)   $ * 6R    68   �� *Email+6R     50      $ Phone��6)   $ * 6R    68   �� *Phone+6R     51      $ Address��6)   $ * 6V    6:   �� *	Address+6V     52      $ 
Created At��6)   $ * 6z    6=   �� *	CreatedAt+ �� StringFormat$ {0:yyyy-MM-dd}��6z   54      55      �� 58   
   $��1��6   $��
5,10,10,10q�6%   .+�59      �� $%��Books Borrowed by Selected User��6   $��24(�5:      $
��Bold"�5;      
���OO/�$��Center=�5=      $��0,0,0,10q�5>        5@      -   5        $ dataGridBorrowedBooks��5@      $ False��5A      $ False��5B      $ False��5C      $
 True��5D      $	 40Q�5E      $
 35Q�5F      
 ����� 5I        5J      $ 
Book Title��6)   $ * 6W    6=   �� *Title+6W     5K      $ Borrow Date��6)   $ * 6|    6>   �� *
BorrowDate+$ {0:yyyy-MM-dd}��6|     5L      $ Due Date��6)   $ * 6v    6;   �� *	DueDate+$ {0:yyyy-MM-dd}��6v     5M      $ Return Date��6)   $ * 6|    6>   �� *
ReturnDate+$ {0:yyyy-MM-dd}��6|   5O      5P      5Q      5R      