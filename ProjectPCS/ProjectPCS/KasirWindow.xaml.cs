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

        public KasirWindow()
        {
            InitializeComponent();
            conn = MainWindow.conn;
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
            //pemesananWindow reserve = new pemesananWindow();
            this.Hide();
            //reserve.ShowDialog();
            this.Close();
        }
    }
}
