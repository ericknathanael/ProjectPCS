using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectPCS
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ManagerWindow()
        {
            InitializeComponent();
        }

        private void mnRegister_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbJabatan.Items.Add(new ComboBoxItem()
            {
                Name = "1",
                Content = "Manager"
            });
            cbJabatan.Items.Add(new ComboBoxItem()
            {
                Name = "2",
                Content = "Koki"
            });
            cbJabatan.Items.Add(new ComboBoxItem()
            {
                Name = "3",
                Content = "Pelayan"
            });
            cbJabatan.Items.Add(new ComboBoxItem()
            {
                Name = "4",
                Content = "Kasir"
            });
            cbJabatan.Items.Add(new ComboBoxItem()
            {
                Name = "5",
                Content = "Resepsionis"
            });
            cbJabatan.SelectedIndex = 0;
        }

        private void btRegis_Click(object sender, RoutedEventArgs e)
        {
            string nama = tbNama.Text;
            string user = tbUsername.Text;
            string pass = tbPass.Text;
            int id_jabatan = 0;
            ComboBoxItem temp = (ComboBoxItem)cbJabatan.SelectedItem;
            id_jabatan = Convert.ToInt32(temp.Name.ToString());

            if(nama == "" || user == "" || id_jabatan == 0)
            {
                MessageBox.Show("Isi isian dengan benar");
            }
            
        }
    }
}
