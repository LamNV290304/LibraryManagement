   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LibraryLibrary  5          Library.AddLoan   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Library     5        N� Title$  AddLoan��5       N� 
Background �#F5DEB3$	��435��5	      $	��705��6'   .��5      � $��	0,0,20,40q�6   .+�5   
   �� 
������� �� CornerRadius$ 10��6$    �� Padding$ 20q�66   $��110,121,85,-6q�6C   ._�5      ��  �� 
IsReadOnly$
 True��6   
������  �� TextWrapping$
 Wrap=�6B   $��Create new loan��6V   $��25(�6m   $
��Bold"�6{   $��135,24,45,181q�6�   5      �� 5   
   $��Book ID��6   $
��Left=�6"   $	��Top=�6=   $��131,206,0,0q�6U   �� 5   
   -   5         ��Name$ 	txtBookId��5      $
��Left=�6%   $	��Top=�6@   $	��282��6X   $��248,210,0,0q�6d   �� 5   
   $��UserID��6   $
��Left=�6!   $	��Top=�6<   $��132,248,0,0q�6T    J� RenderTransformOrigin$ 0.337,1.648&�6i   �� 5   
   -   5        $ 	txtUserId��5      $
��Left=�6%   $	��Top=�6@   $	��282��6X   $��248,252,0,0q�6d   �� 5   
   $��Due Date��6   $
��Left=�6#   $	��Top=�6>   $��131,293,0,0q�6V   $ 0.334,0.142&�6k   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpPublicationDate��5      $
��Left=�60   $	��Top=�6K   $	��282��6c   $��248,293,0,0q�6o   �� 5#   
   -   5        $
��Loan��5#      $��Center=�6    $	��Top=�6=   $	��150��6U   $��	1,343,0,0q�6a   6t   5$      5%      