using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Oracle.DataAccess.Client;

namespace ProjectPCS
{
    /// <summary>
    /// Interaction logic for menuWindow.xaml
    /// </summary>
    public partial class menuWindow : Window
    {
        string pilihan = "Transaksi";
        OracleConnection conn;
        DataTable dt; 

        public menuWindow()
        {
            InitializeComponent();
            conn = MainWindow.conn;
        }

        private void menuTrans_Click(object sender, RoutedEventArgs e)
        {
            pilihan = "Transaksi";

        }

        private void menuKaryawan_Click(object sender, RoutedEventArgs e)
        {
            pilihan = "Karyawan";
        }

        private void menuLaporan_Click(object sender, RoutedEventArgs e)
        {            
            pilihan = "Laporan";
        }
    }
}
