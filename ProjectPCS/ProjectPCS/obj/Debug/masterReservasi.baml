   M S B A M L   `   `   `  ����E  AProjectPCS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ProjectPCS
ProjectPCS  5   	        ProjectPCS.masterReservasi   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ProjectPCS     5   	     � Icon$  Image/EPOS-Icon.ico��5   	    � Title$ masterReservasi��6$   $	��359��6<   $	��855��6I   .��5	      � $	��329��6   $	��Top=�6   .+�5
   
   �� -   5         ��Name$ picHome��5
      $
��Left=�6!   $��40��6<   $��9,9,0,0q�6H   $	��Top=�6Y   $��40��6q   $
��Fill=�6|   $��Image/Home.png��6�   6�   �� 5   
   $��Master Reservasi��6   $
��Left=�6+   $��	55,12,0,0q�6F   $	��Top=�6Y   $��20(�6q   $
��Bold"�6   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dgReservasi��5      $
��Left=�6&   $	��259��6A   $��	55,54,0,0q�6N   $	��Top=�6a   $	��474��6y      
IsReadOnly . 6�   �� 5   
   $��Nama Pelanggan : ��6   $
��Left=�6,   $��
543,92,0,0q�6G   $	��Top=�6[   �� 5   
   $��Nomor Meja : ��6   $
��Left=�6(   $��567,133,0,0q�6C   $	��Top=�6X   �� 5   
   -   5        $��comboBoxNamaPelanggan��5      $
��Left=�60   $��
670,96,0,0q�6K   $	��Top=�6_   $	��149��6w   �� 5   
   $��ID : ��6   $
��Left=�6    $��
622,54,0,0q�6;   $	��Top=�6O   �� 5   
   -   5        $��comboBoxMeja��5      $
��Left=�6'   $��670,136,0,0q�6B   $	��Top=�6W   $	��149��6o   �� 5   
   $��
Tanggal : ��6   $
��Left=�6%   $��593,177,0,0q�6@   $	��Top=�6U   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��datePickerTanggal��5      $
��Left=�6.   $��670,178,0,0q�6I   $	��Top=�6^   $	��149��6v      SelectedDateFormat$ Short=�6�   �� 5   
   -   5         ��Name$ buttonInsert��5      $��Insert��6'   $
��Left=�68   $��549,261,0,0q�6S   $	��Top=�6h   $��75��6�   6�   �� 5   
   -   5        $ buttonUpdate��5      $��Update��6'   $
��Left=�68   $��650,261,0,0q�6S   $	��Top=�6h   $��75��6�   {�.  6�   �� 5   
   -   5        $ buttonDelete��5      $��Delete��6'   $
��Left=�68   $��744,261,0,0q�6S   $	��Top=�6h   $��75��6�   {�.  6�   �� 5   
   -	   5        $ buttonClear��5      $��Clear��6&   $
��Left=�66   $��650,292,0,0q�6Q   $	��Top=�6f   $��75��6~   6�   �� 5   
   -
   5        $��labelID��5      $��-��6   $
��Left=�6+   $��
670,54,0,0q�6F   $	��Top=�6Z   �� 5   
   $��Waktu : ��6   $
��Left=�6#   $��599,219,0,0q�6>   $	��Top=�6S   �� 5   
   -   5         ��Name$ tbJam��5      $
��Left=�6!   $��23��6<   $��670,219,0,0q�6H    �� TextWrapping$
 Wrap=�6]   $��12��6q   $	��Top=�6{   $��59��6�   6�   �� 5   
   -   5        $ tbMnt��5      $
��Left=�6!   $��23��6<   $��760,219,0,0q�6H   $
 Wrap=�6]   $��00��6q   $	��Top=�6{   $��59��6�   6�   �� 5   
   $��:��6   $
��Left=�6   $��738,216,0,0q�67   $	��Top=�6L   5      5      