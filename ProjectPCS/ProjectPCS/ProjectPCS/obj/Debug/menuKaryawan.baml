   M S B A M L   `   `   `  ����E  AProjectPCS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ProjectPCS
ProjectPCS  5   	       ProjectPCS.menuKaryawan   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ProjectPCS     5   	   -   5          � Title$  menuKaryawan��5   	   $	��450��6   $	��800��6+   .��5	      � .+�5
   
   o� $��0,0,0.333,391.667q�6   .@�5      m� -   5         m�Name$ 	menuTrans��5      $��Register Karyawan��6*   6E   m� 5      -   5        $ menuKaryawan1��5      $��Tambah Menu��6.   m� 5      -   5        $ menuLaporan��5      $��Absensi��6,   6=   m� 5      -   5        $ 
masterMenu��5      $��Laporan��6+   6<   5      �� 5   
   $��Register Karyawan Baru��6   $
��Left=�61   $��
274,32,0,0q�6L   $	��Top=�6`   $��18(�6x   $
��Bold"�6�   �� 5   
   $��Nama :��6   $
��Left=�6!   $��
38,279,0,0q�6<   $	��Top=�6P   �� 5   
   $��
Username :��6   $
��Left=�6%   $��
16,310,0,0q�6@   $	��Top=�6T   �� 5   
   $��
Password :��6   $
��Left=�6%   $��
20,342,0,0q�6@   $	��Top=�6T   �� 5   
   -   5         ��Name$ tbNama��5      $
��Left=�6"   $��23��6=   $��
90,283,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��308��6�   �� 5   
   -   5        $ tbUser��5      $
��Left=�6"   $��23��6=   $��
90,314,0,0q�6I   $
 Wrap=�6]   $	��Top=�6q   $	��308��6�   G� 5   
   -   5         G�Name$ passBox��5      $
��Left=�6'   $��
90,344,0,0q�6B   $	��Top=�6V   $	��308��6n   $��23��6z   	� 5   
   -	   5         	�Name$ 	rbManager��5      $��Manager��6)   $
��Left=�6;   $��
90,379,0,0q�6V   $	��Top=�6j   6�   	� 5   
   -
   5        $ rbKoki��5      $
��Koki��6&   $
��Left=�65   $��171,379,0,0q�6P   $	��Top=�6e   6}   	� 5   
   -   5        $ 	rbPelayan��5      $��Pelayan��6)   $
��Left=�6;   $��233,379,0,0q�6V   $	��Top=�6k   6�   	� 5   
   -   5        $ rbKasir��5      $��Kasir��6'   $
��Left=�67   $��313,379,0,0q�6R   $	��Top=�6g   6   �� 5   
   $��	Jabatan :��6   $
��Left=�6$   $��
29,373,0,0q�6?   $	��Top=�6S   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgKaryawan��5      $
��Left=�6'   $	��194��6B   $��	10,71,0,0q�6O   $	��Top=�6b   $	��772��6z   6�   �� 5   
   -   5         ��Name$ btRegis��5      $��Register��6"   $
��Left=�65   $��672,371,0,0q�6P   $	��Top=�6e   $	��110��6}   $��35��6�   6�   �� 5   
   -   5        $ btDelete��5      $��Delete��6#   $
��Left=�64   $��557,370,0,0q�6O   $	��Top=�6d   $	��110��6|   $��36��6�   {�.  6�   �� 5   
   -   5        $ btUpdate��5      $��Update��6#   $
��Left=�64   $��442,371,0,0q�6O   $	��Top=�6d   $	��110��6|   $��36��6�   {�.  6�   5!      5"      