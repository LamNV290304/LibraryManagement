   M S B A M L   `   `   `  ����B  >Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:LibraryLibrary  5   	       Library.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Library     5   	     � WindowState$  	Maximized=�5   	    � Title$ 
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5      � .+�5   
   �� -   5         ��Name$ WelcomeTextBlock��5      $��24(�5      $
��Bold"�5      $��Center=�5      $	��Top=�5      $��0,30,0,0q�5      $��Welcome, Guest!��5      �� 5   
    �� Orientation$ Vertical=�6   $��Center=�6,   $	��Top=�6I   $��0,90,0,0q�6a   .+�5      �� $ 
Horizontal=�6   $��Center=�62   $��0,0,0,20q�6O   .+�5      �� -   5         ��Name$ btnManageBook��5      $��Manage Book��60   $��10q�6F   $
��15,5q�6R   $y�	Collapsed=�6a   �� 5      -   5        $ btnManageLoan��5      $��Manage Loan��60   $��10q�6F   $
��15,5q�6R   $y�	Collapsed=�6a   6x   �� 5      -   5        $ btnManageReservation��5      $��Manage Reservation��67   $��10q�6T   $
��15,5q�6`   $y�	Collapsed=�6o   �� 5      -   5        $ btnManageUser��5      $��Manage User��60   $��10q�6F   $
��15,5q�6R   $y�	Collapsed=�6a   �� 5      -   5        $ btnManageAuthor��5      $��Manage Author��62   $��10q�6J   $
��15,5q�6V   $y�	Collapsed=�6e   6|   �� 5      -   5        $ btnManagePublisher��5      $��Manage Publisher��65   $��10q�6P   $
��15,5q�6\   $y�	Collapsed=�6k   6�   �� 5      -   5        $ btnUserManageLoan��5      $��Manage Loan��64   $��10q�6J   $y�	Collapsed=�6V   6m   �� 5       -	   5        $ btnViewReservation��5       $��View Reservation��65   $��10q�6P   $y�	Collapsed=�6\   $��36��6�   $	��121��6�   �� 5!      -
   5        $ btnHomePage��5!      $
��Home��6.   $��10q�6=   $y�	Collapsed=�6I   $��34��6`   $��70��6l   6w   5#      �� 5&      $ 
Horizontal=�6   $��Center=�62   .+�5'      �� -   5        $ btnLogin��5'      $��Login��6+   $��10q�6;   $
��15,5q�6G   6V   �� 5(      -   5        $ btnRegister��5(      $��Register��6.   $��10q�6A   $
��15,5q�6M   6\   �� 5)      -   5        $ 	btnLogout��5)      $��Logout��6,   $��10q�6=   $
��15,5q�6I   $y�	Collapsed=�6X   6o   �� 5*      -   5        $ 	btnLoaned��5*      $��	Book Loan��6,   $��10q�6@   $
��15,5q�6L   $y�	Collapsed=�6[   6r   5+      5,       � 5/   
   -   5          �Name$ MainContentFrame��5/      $��10,160,10,10q�50        � NavigationUIVisibility$ Hidden=�51      52      53      