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
using Oracle.DataAccess.Client;
using System.Data;

namespace ProjectPCS
{
    /// <summary>
    /// Interaction logic for transaksiWindow.xaml
    /// </summary>
    public partial class transaksiWindow : Window
    {
        OracleConnection conn;
        OracleCommand cmd; //menu 
        OracleCommandBuilder builder;
        OracleDataAdapter da;
        DataTable dt; 
        
        List<Menu> listPesanan;
        string query;

        public transaksiWindow()
        {
            InitializeComponent();
            conn = MainWindow.conn;
            dt = new DataTable();
            da = new OracleDataAdapter();
            
            
            cbMetode.Items.Add(new ComboBoxItem() { 
                Name= "CASH",
                Content = "Cash"
            });
            cbMetode.Items.Add(new ComboBoxItem()
            {
                Name = "OVO",
                Content = "Ovo"
            });
            cbMetode.Items.Add(new ComboBoxItem()
            {
                Name = "GOPAY",
                Content = "GoPay"
            });
            cbMetode.Items.Add(new ComboBoxItem()
            {
                Name = "SHOPEEPAY",
                Content = "ShopeePay"
            });
            cbMetode.SelectedIndex = 0;
            listPesanan = new List<Menu>();

            conn.Open();
            query = "select kode_menu,Nama_Menu,harga from menu";
            cmd = new OracleCommand(query, conn);
            cmd.ExecuteNonQuery();
            da = new OracleDataAdapter(cmd);
            da.Fill(dt);
            dgMenu.ItemsSource = dt.DefaultView;
            conn.Close();
        }

        private void btTambah_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void tbKode_TextChanged(object sender, TextChangedEventArgs e)
        {
            conn.Open();
            query = $"select * from menu where status != 0 and kode like '{tbKode.Text}%'";
            cmd = new OracleCommand(query, conn);
            cmd.ExecuteNonQuery();
            da = new OracleDataAdapter(cmd);
            da.Fill(dt);
            dgMenu.ItemsSource = dt.DefaultView;
            conn.Close();
        }
    }
}
