   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LibraryLibrary  5          Library.ManageLoan   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Library     5        N� Title$  
ManageLoan��5	       N� 
Background �#F5DEB3.��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   $��109.96��6*   �� 5       � ColumnDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $��1* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��2��6;   $��40,40,40,40q�6O   .+�5      �� -   5         ��Name$ SearchTextBox��5      $	��200��6-   $��5q�69   $��Search by Username��6D   
�������6^   �� 5      -   5         ��Name$ SearchButton��5      $��Search��6+   $��5q�6W   5      � 5"   
   $��1��6   $��2��6   $��0,10,0,0q�60   $	��390��6B   $	��Top=�6O    5#      �� 5$      $	��49* �6#   �� 5%      $	��47* �6#   �� 5'      $	��64* �6#   .+�5,      &   System.Windows.Controls.DataGrid  -   5          Name$ LoansDataGrid��5,         AutoGenerateColumns$ False��5-      	   CanUserAddRows$	 False��5.      
   CanUserDeleteRows$
 False��5/         CanUserSortColumns$
 True��50      $��10,-10,10,35q�51         GridLinesVisibility$	 All=�52         
IsReadOnly$
 True��53         SelectionMode$ Single=�54      $��0��55      $��2��56   I      Columns 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn   Header$ Loan ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *LoanId+6U     59      $ 
Book Title��6)   $ * 6[    6=   �� *	BookTitle+6[     5:      $ 	User Name��6)   $ 70 6Y    6<   �� *
UserName+6Y     5;      $ 	Loan Date��6)   $ 70 6Y    6<   �� *
LoanDate+6Y     5<      $ Due Date��6)   $ 70 6W    6;   �� *	DueDate+6W     5=      $ Return Date��6)   $ 80 6]    6>   �� *
ReturnDate+6]     5>      $
 Fine��6)   $ 60 6P    67   �� *Fine+6P     5?      $ Overdue Days��6)   $ 90 6_    6?   �� *OverdueDays+6_     5@      $ 
Staff Name��6)   $ * 6[    6=   �� *	StaffName+   
Visibility 6e   �� *StaffVisibility+5B      �� 5E      $��2��6   $��
10,0,10,20q�6)   .+�5F      �� -   5         ��Name$ LoanDetailsTextBlock��5F      $��		Loan Details��6:   $
��0,15q�6X   $��21��6f   �� 5H      -   5        $ LoanIdTextBox��5H      $	��Top=�61   $
��50,5q�6I    �� 
IsReadOnly$
 True��6W   ��6i   �� *LoanId+�� 5I      -   5        $ BookTitleTextBox��5I      $	��Top=�64   $
��50,5q�6L   $
 True��6Z   ��6l   �� *	BookTitle+�� 5J      -   5        $ UserNameTextBox��5J      $	��Top=�63   $
��50,5q�6K   $
 True��6Y   ��6k   �� *
UserName+�� 5K      -   5        $ LoanDateTextBox��5K      $	��Top=�63   $
��50,5q�6K   $
 True��6Y   ��6k   �� *
LoanDate+�� 5L      -	   5        $ DueDateTextBox��5L      $	��Top=�62   $
��50,5q�6J   $
 True��6X   ��6j   �� *	DueDate+�� 5M      -
   5        $ ReturnDateTextBox��5M      $	��Top=�65   $
��50,5q�6M   $
 True��6[   ��6m   �� *
ReturnDate+�� 5N      -   5        $ FineTextBox��5N      $	��Top=�6/   $
��50,5q�6G   $
 True��6U   ��6g   �� *Fine+�� 5O      -   5        $ OverdueDaysTextBox��5O      $	��Top=�66   $
��50,5q�6N   $
 True��6\   ��6n   �� *OverdueDays+�� 5Q      $ 
Horizontal=�6   $	��164��66   $
��0,10q�6B   .+�5R      �� -   5        $ ReturnButton��5R      $��Return��63   $��5q�6_   $��Center=�6j   �� 5S      -   5        $ 	AddButton��5S      $��Add New Loan��60   $��5q�6_   $��Center=�6j   5T      5U      5V      5W      5X      