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
using System.Data;
using Oracle.DataAccess.Client;

namespace ProjectPCS
{
    /// <summary>
    /// Interaction logic for menuTransaksi.xaml
    /// </summary>
    public partial class menuTransaksi : Window
    {
        OracleConnection conn;
        public menuTransaksi()
        {
            InitializeComponent();
            conn = loginWindow.conn;
        }

        private void menuKaryawan_Click(object sender, RoutedEventArgs e)
        {
            menuKaryawan karyawan = new menuKaryawan();
            this.Hide();
            karyawan.ShowDialog();
            this.Close();
        }

        private void menuLaporan_Click(object sender, RoutedEventArgs e)
        {
            menuLaporan laporan = new menuLaporan();
            this.Hide();
            laporan.ShowDialog();
            this.Close();
        }

        private void masterMenu_Click(object sender, RoutedEventArgs e)
        {
            masterMenu menu = new masterMenu();
            this.Hide();
            menu.ShowDialog();
            this.Close();
        }
    }
}
