   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LibraryLibrary  5          Library.ManageCategory   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Library     5        N� Title$  ManageCategory��5	       N� 
Background �#F5DEB3.��5      � .+�5   
   �� $��Manage Categories��6   $��24(�5      $
��Bold"�5      $��Center=�5      $	��Top=�5      $��10q�5      �� 5   
    �� Orientation$ Vertical=�6   $��10,50,10,10q�6,   .+�5      �� -   5         ��Name$ CategoryNameTextBox��5      $	��300��63   $
��0,10q�6?   ��5      �� *CategoryName+ �� UpdateSourceTrigger$ PropertyChanged=��� 5      -   5        $  CategoryDescriptionTextBox��5      $	��300��6:   $
��0,10q�6F   ��5      �� *CategoryDescription+$ PropertyChanged=��� 5      $ 
Horizontal=�6   $��Center=�62   .+�5      �� -   5        $��Add Category��5      $	��100��60   $��5q�6<   5       �� 5!      -   5        $��Edit Category��5!      $	��100��61   $��5q�6=   5"      �� 5#      -   5        $��Delete Category��5#      $	��100��63   $��5q�6?   5$      5%      5&      &   System.Windows.Controls.DataGrid  5)   
   -   5          Name$ CategoriesDataGrid��5)         AutoGenerateColumns$ False��6/      
IsReadOnly$
 True��5*      $��10,170,10,10q�5+         Columns 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
CategoryId+6P     5.      $	 Category Name��6%   $
 * 6U    6<   �� *Name+6U     5/      $	 Description��6%   $
 * 6Z    6:   �� *Description+6Z   51      52      53      