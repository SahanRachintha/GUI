   M S B A M L   `   `   `  ����S  OPersonal_Finance_Tracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Personal_Finance_TrackerPersonal_Finance_Tracker  5   	   +    %Personal_Finance_Tracker.IncomeWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Personal_Finance_Tracker     5   	     � Title$  IncomeWindow��5   	   $	��550��6   $	��800��6+   .��5	      � ���#F5F5F5 � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   o� ���#2c3e50
�������$��0��67   .@�5      �� $��0��6    �� Orientation$ 
Horizontal=�6&   .+�5      �� $f��`E:\web development\Dekstop App\Personal_Finance_Tracker\Personal_Finance_Tracker\Images\logo.png��6   $��20��6�   $��20��6�   $��10q�6�   �� 5      $��Personal Finance Tracker��6   
�������$��Center=�6O   m� 5      -   5        $��	Dashboard��5      6.   m� 5      -   5        $��Income��5      6+   m� 5      -   5        $��Expenses��5      6-   m� 5      -   5        $��Profile��5      6,   m� 5      -   5        $��Logout��5      $��28��6@   
���  ��$	��120��6]   5      5      �� 5   
   $��1��6   $	��796��6"   $��	2,10,2,-1q�6.   .+�5      �� $��Income��6   $��24(�6&   $
��Bold"�64   
���   �$	��294��6Y   $��10q�6e   �� 5      -   5        $��IncomeSourcePlaceholder��5      $��Enter source��6;   
�������$
��Left=�6a   $��	250,0,0,0q�6|    J� IsHitTestVisible$ False��6�   $��78��6�   �� 5       -   5        $��IncomeSourceTextBox��5       $	��300��65   $��30��6A   $��10q�6M   �� 5$      -   5        $��IncomeAmountPlaceholder��5$      $��Enter amount��6;   
�������$
��Left=�6a   $��	250,0,0,0q�6|   $ False��6�   �� 5%      -	   5        $��IncomeAmountTextBox��5%      $	��300��61   $��30��6=   $��10q�6I   (  "System.Windows.Controls.DatePicker  5(      -
   5        $��IncomeDatePicker��5(      $	��300��61   $��30��6=   $��10q�6I   �� 5*      -   5        $��
Add Income��5*      
��� ���
�������$	��100��6i   $��30��6u   $��10q�6�   �� 5,      -   5        $��
IncomeList��5,      $	��400��6)   $	��103��65   $��20q�6B    �� View 5-      �� 5.      .P�5/      �� $
��Date��6)    �� Width$	 100��67    �� DisplayMemberBinding 6C   �� *Date+�� 50      $��Source��6)   $	 150��69    6E   �� *Source+�� 51      $��Amount��6)   $	 100��69    6E   �� *Amount+52      54      �� 55      -   5        $��Delete Income��55      $
��10,5q�6H   
���  ��
�������$��24��6z   $	��100��6�   56      57      5:      