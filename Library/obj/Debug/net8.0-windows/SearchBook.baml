   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LibraryLibrary  5   	       Library.SearchBook   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Library     5   	     N� Title$  SearchBookGuest��5   	   $	��450��6!   $	��800��6.    N� 
Background �#F5DEB3.��5
      � .+�5   
   �� 
������� �� CornerRadius$ 10��6$    �� Padding$ 20q�66   $��50,50,50,50q�6C   ._�5      �� .+�5      �  � ColumnDefinitions 5      �� 5      $
��191* �6+   �� 5      $
��138* �6+   �� 5      $
��237* �6+   �� 5      $	��94* �6+   .+�5      �� $��
Category :��6    $��20(�62   $��	10,0,72,0q�6@   $��Center=�6S   $��0��6n   $��26��6~   �� 5      -   5         ��Name$ 
cbCategory��5      $��14(�63   $��5q�5      $��
114,0,10,0q�6#   $��Center=�5      $��2��5       �� DisplayMemberPath$
 Name��5       �� SelectedValuePath$ 
CategoryId��5       5!      �� 5$      -   5         ��Name$ 	txtSearch��5$      $��2��61   $��14(�6A   $��5q�5%      $��9,0,0,0q�6'   68   �� 5(      -   5        $��Tìm kiếm��5(      $��3��60   $��84��6@   ���#4CAF50
�������$��14(�5)   B   $
��Bold"�5*      $
��Left=�6,   $��10,0,0,0q�6G   6Y   5+      &   System.Windows.Controls.DataGrid  5.      -   5        	  Name$	 	dgResults��5.      $	��200��6.   $��0,20,0,0q�6;   
   AutoGenerateColumns$
 False��6M      HeadersVisibility$ Column=�6i      
IsReadOnly$
 True��6�      CanUserAddRows$ False��6�      Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$ Title��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *Title+6V     51      $ Author��6-   $ * 6\    6=   �� *
AuthorName+6\     52      $ Category��6-   $ * 6`    6?   �� *CategoryName+6`   54      55      56      57      58      