   M S B A M L   `   `   `  ����E  AProjectPCS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ProjectPCS
ProjectPCS  5   	       ProjectPCS.registerWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ProjectPCS     5   	   -   5          � Icon$  Image/EPOS-Icon.ico��5   	    � Title$ registerWindow��6$   $	��450��6;   $	��800��6H   .��5	      � .+�5
   
   �� $��Master Karyawan��6   $
��Left=�6*   $��
313,37,0,0q�6E   $	��Top=�6Y   $��18(�6q   $
��Bold"�6   �� 5   
   $��Nama :��6   $
��Left=�6!   $��
38,279,0,0q�6<   $	��Top=�6P   �� 5   
   $��
Username :��6   $
��Left=�6%   $��
16,310,0,0q�6@   $	��Top=�6T   �� 5   
   $��
Password :��6   $
��Left=�6%   $��
20,342,0,0q�6@   $	��Top=�6T   �� 5   
   -   5         ��Name$ tbNama��5      $
��Left=�6"   $��23��6=   $��
90,283,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��308��6�   �� 5   
   -   5        $ tbUser��5      $
��Left=�6"   $��23��6=   $��
90,314,0,0q�6I   $
 Wrap=�6]   $	��Top=�6q   $	��308��6�   	� 5   
   -   5         	�Name$ 	rbManajer��5      $��Manajer��6)   $
��Left=�6;   $��
90,379,0,0q�6V   $	��Top=�6j   6�   	� 5   
   -   5        $ rbKoki��5      $
��Koki��6&   $
��Left=�65   $��171,379,0,0q�6P   $	��Top=�6e   6}   	� 5   
   -   5        $ 	rbPelayan��5      $��Pelayan��6)   $
��Left=�6;   $��233,379,0,0q�6V   $	��Top=�6k   6�   	� 5   
   -   5        $ rbKasir��5      $��Kasir��6'   $
��Left=�67   $��313,379,0,0q�6R   $	��Top=�6g   6   �� 5   
   $��	Jabatan :��6   $
��Left=�6$   $��
29,373,0,0q�6?   $	��Top=�6S   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgKaryawan��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6'   $
��Left=�67   $	��194��6R   $��	10,71,0,0q�6_   $	��Top=�6r   $	��772��6�      
IsReadOnly . 6�   �� 5   
   -	   5         ��Name$ btRegis��5      $��Register��6"   $
��Left=�65   $��672,371,0,0q�6P   $	��Top=�6e   $	��110��6}   $��35��6�   6�   �� 5   
   -
   5        $ btDelete��5      $��Delete��6#   $
��Left=�64   $��557,370,0,0q�6O   $	��Top=�6d   $	��110��6|   $��36��6�   {�.  6�   �� 5   
   -   5        $ btUpdate��5      $��Update��6#   $
��Left=�64   $��442,371,0,0q�6O   $	��Top=�6d   $	��110��6|   $��36��6�   {�.  6�   �� 5   
   -   5        $
��Left=�5      $��34��6+   $��	10,10,0,0q�67   $	��Top=�6J   $��41��6b   $��Image/home.png��6m   6�   �� 5   
   -   5        $ passBox��5      $
��Left=�6#   $��23��6>   $��
93,346,0,0q�6J   $
 Wrap=�6^   $	��Top=�6r   $	��305��6�   5      5      