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
    /// Interaction logic for KasirWindow.xaml
    /// </summary>
    public partial class KasirWindow : Window
    {
        OracleConnection conn;
        Karyawan kasir;

        public KasirWindow()
        {
            InitializeComponent();
            conn = MainWindow.conn;
            kasir = loginWindow.karyawan;
        }


        private void btLogout_Click(object sender, RoutedEventArgs e)
        {
            loginWindow login = new loginWindow();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            transaksiWindow trans = new transaksiWindow();
            this.Hide();
            trans.ShowDialog();
            this.Close();
        }

        private void picPesan_MouseDown(object sender, MouseButtonEventArgs e)
        {
            masterReservasi reserve = new masterReservasi();
            this.Hide();
            reserve.ShowDialog();
            this.Close();
        }

        private void picAbsen_MouseDown(object sender, MouseButtonEventArgs e)
        {
            absensiWindow absen = new absensiWindow();
            absen.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbNama.Content += kasir.nama;
        }
    }
}
