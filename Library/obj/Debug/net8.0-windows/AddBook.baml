   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LibraryLibrary  5   	       Library.AddBook   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Library     5   	     � Title$  Add New Book��5   	   $	��526��6   $	��800��6+   ���#40E0D0.��5
      � $��
0,10,20,20q�6   .+�5   
   �� $��Add New Book��6   $��24(�5      $
��Bold"�5      $��Center=�5      $	��Top=�5      $��	0,30,0,20q�5      
���OO/�5      �� 5   
   
������� �� CornerRadius$ 10��6$    �� Padding$ 20q�66   $��90,66,65,10q�6C   ._�5      �� -   5         ��Name$ cbAuthor��5      $
��Left=�6)   $	��Top=�6D   $	��400��6\   $��140,113,0,0q�6h    �� DisplayMemberPath$
 Name��5       �� SelectedValuePath$ AuthorId��60   5      �� 5   
   $��ISBN:��6   $
��Left=�6    $	��Top=�6;   $��148,120,0,0q�6S   �� 5   
   -   5         ��Name$ txtISBN��5      $
��Left=�6#   $	��Top=�6>   $	��400��6V   $��248,120,0,0q�6b   �� 5   
   $��Book Title:��6   $
��Left=�6&   $	��Top=�6A   $��148,157,0,0q�6Y   �� 5   
   -   5        $ txtTitle��5      $
��Left=�6$   $	��Top=�6?   $	��400��6W   $��248,157,0,0q�6c   �� 5"   
   $��Author:��6   $
��Left=�6"   $	��Top=�6=   $��148,197,0,0q�6U   �� 5%   
   $��	Category:��6   $
��Left=�6$   $	��Top=�6?   $��148,237,0,0q�6W   �� 5&   
   -   5        $ 
cbCategory��5&      $
��Left=�6'   $	��Top=�6B   $	��400��6Z   $��248,237,0,0q�6f   $
 Name��5'      $ 
CategoryId��6,   �� 5*   
   $��
Publisher:��6   $
��Left=�6%   $	��Top=�6@   $��148,277,0,0q�6X   �� 5+   
   -   5        $ cbPublisher��5+      $
��Left=�6(   $	��Top=�6C   $	��400��6[   $��248,277,0,0q�6g   $
 Name��5,      $ PublisherId��6,   �� 5/   
   $��Publication Year��6   $
��Left=�6+   $	��Top=�6F   $��148,317,0,0q�6^   �� 50   
   -   5        $ txtPublicationYear��50      $
��Left=�6.   $	��Top=�6I   $	��400��6a   $��248,321,0,0q�6m   �� 53   
   $��Total copies:��6   $
��Left=�6(   $	��Top=�6C   $��148,353,0,0q�6[   �� 54   
   -   5        $ txtTotalCopy��54      $
��Left=�6(   $	��Top=�6C   $	��400��6[   $��248,357,0,0q�6g   �� 56   
   $��Price:��6   $
��Left=�6!   $	��Top=�6<   $��153,389,0,0q�6T    J� RenderTransformOrigin$ 	0.3,0.014&�6i   �� 57   
   -   5        $ txtPrice��57      $
��Left=�6$   $	��Top=�6?   $	��400��6W   $��248,393,0,0q�6c   �� 5:   
   -	   5        $��Add Book��5:      $
��Left=�6$   $	��Top=�6?   $	��150��6W   $��345,434,0,0q�6c   5;      5<      5=      