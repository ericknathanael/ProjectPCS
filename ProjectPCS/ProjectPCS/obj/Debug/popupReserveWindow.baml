   M S B A M L   `   `   `  ����E  AProjectPCS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ProjectPCS
ProjectPCS  5   	   #    ProjectPCS.popupReserveWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ProjectPCS     5   	   -   5          � Icon$  Image/EPOS-Icon.ico��5   	    � Title$ popupReserveWindow��6$   $	��450��6?   $	��800��6L   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	dgReserve��5
         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6&   $
��Left=�66   $	��390��6Q   $��	10,15,0,0q�6^   $	��Top=�6q   $	��559��6�   6�   �� 5   
   $
��ID :��6   $
��Left=�6   $��
618,25,0,0q�6:   $	��Top=�6N   �� 5   
   $��Nama :��6   $
��Left=�6!   $��
603,65,0,0q�6<   $	��Top=�6P   �� 5   
   $��Meja :��6   $
��Left=�6!   $��608,105,0,0q�6<   $	��Top=�6Q   �� 5   
   $��Tanggal 
Pemesanan :��6   $
��Left=�68   $��574,145,0,0q�6S   $	��Top=�6h   �� 5   
   -   5         ��Name$
 lbID��5      $��-��6   $
��Left=�6*   $��
655,25,0,0q�6E   $	��Top=�6Y   �� 5   
   -   5        $ lbNama��5      $��-��6    $
��Left=�6,   $��
655,65,0,0q�6G   $	��Top=�6[   �� 5   
   -   5        $ lbMeja��5      $��-��6    $
��Left=�6,   $��655,105,0,0q�6G   $	��Top=�6\   �� 5   
   -   5        $ lbTgl��5      $��-��6   $
��Left=�6+   $��655,155,0,0q�6F   $	��Top=�6[   $��83��6s   �� 5   
   -   5         ��Name$ btFind��5      $
��Cari��6!   $
��Left=�60   $��575,272,0,0q�6K   $	��Top=�6`   $��95��6x   6�   �� 5   
   -   5        $ btReset��5      $��Reset��6"   $
��Left=�62   $��680,272,0,0q�6M   $	��Top=�6b   $��95��6z   6�   �� 5   
   -	   5         ��Name$ tbNama��5      $
��Left=�6"   $��23��6=   $��575,230,0,0q�6I    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��200��6�   �� 5   
   $��Cari Nama :��6   $
��Left=�6&   $��575,199,0,0q�6A   $	��Top=�6V   �� 5   
   -
   5        $ btEnter��5      $��Enter��6"   $
��Left=�62   $��575,378,0,0q�6M   $	��Top=�6b   $��95��6z   $��27��6�   6�   �� 5   
   -   5        $ btClear��5      $��Clear��6"   $
��Left=�62   $��680,378,0,0q�6M   $	��Top=�6b   $��95��6z   $��27��6�   6�   5      5      