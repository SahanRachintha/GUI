   M S B A M L   `   `   `  ����S  OPersonal_Finance_Tracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Personal_Finance_TrackerPersonal_Finance_Tracker  5   	   -    'Personal_Finance_Tracker.ExpensesWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Personal_Finance_Tracker     5   	     � Title$  ExpensesWindow��5   	   $	��580��6    $	��800��6-   .��5	      � ���#F5F5F5 � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   o� ���#2c3e50
�������$��0��67   .@�5      �� $��0��6    �� Orientation$ 
Horizontal=�6&   .+�5      �� $f��`E:\web development\Dekstop App\Personal_Finance_Tracker\Personal_Finance_Tracker\Images\logo.png��6   $��20��6�   $��20��6�   $��10q�6�   �� 5      $��Personal Finance Tracker��6   
�������$��Center=�6O   m� 5      -   5        $��	Dashboard��5      6.   m� 5      -   5        $��Income��5      6+   m� 5      -   5        $��Expenses��5      6-   m� 5      -   5        $��Profile��5      6,   m� 5      -   5        $��Logout��5      $��28��6@   
���  ��$	��120��6]   5      5      �� 5   
   $��1��6   $��20q�6"   .+�5      �� $��Expenses��6   $��20(�6(   $
��Bold"�66   $��	0,20,0,10q�6H   $��86��6[   $��28��6f   �� 5!      $��Enter Description��6   
�������$
��Left=�6G   $��	230,0,0,0q�6b    J� IsHitTestVisible$ False��6u   $��78��6�   �� 5"      -   5         ��Name$ DescriptionTextBox��5"      $��10q�66   $	��300��6B   $��30��6N   6Z   �� 5&      $��Enter Amount��6   
�������$
��Left=�6B   $��	230,0,0,0q�6]   $ False��6p   $��78��6�   �� 5'      -   5        $ AmountTextBox��5'      $��10q�61   $	��300��6=   $��30��6I   (  "System.Windows.Controls.DatePicker  5*      -   5          Name$ 
DatePicker��5*      $��10q�6-   $	��300��69   $��30��6E   �� 5,      $��Enter Category��6   
�������$
��Left=�6D   $��	230,0,0,0q�6_   $ False��6r   $��78��6�   �� 5-      -	   5        $ CategoryTextBox��5-      $��10q�63   $	��300��6?   $��30��6K   �� 50      -
   5        $��Add Expense��50      $
��0,10q�6D   
��� ���
�������$	��100��6y   $��30��6�   �� 52      -   5         ��Name$ ExpensesListView��52       �� SelectionMode$ Single=�61   $	��457��6H    �� View 53      �� 54      .P�55      �� $
��Date��6)   	 �� Width$		 100��6]   
 �� DisplayMemberBinding
 67   �� *Date+6]   �� 56      $��Description��6)   $		 150��6k   
 6>   �� *Description+6k   �� 57      $��Amount��6)   $		 100��6a   
 69   �� *Amount+6a   �� 58      $��Category��6)   $		 100��6e   
 6;   �� *
Category+6e   59      5;      �� 5=      -   5        $��Delete Expense��5=      $��10,20q�6J   
���  ��
�������$	��100��6}   $��24��6�   5>      5?      5A      