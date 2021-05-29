using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

namespace ProjectPCS
{
    /// <summary>
    /// Interaction logic for absensiWindow.xaml
    /// </summary>
    public partial class absensiWindow : Window
    {
        OracleConnection conn;
        OracleCommandBuilder builder;
        OracleCommand cmd;
        OracleDataAdapter da;
        DataTable dt;

        public absensiWindow()
        {
            InitializeComponent();
            conn = loginWindow.conn;
            displayPage();
        }

        private void displayPage()
        {
            CultureInfo ci = new CultureInfo("id-ID");
            labelDate.Content = DateTime.Now.ToString("D", ci);
            labelTime.Content = DateTime.Now.ToString("T");
        }

        private void menuTrans_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuLaporan_Click(object sender, RoutedEventArgs e)
        {

        }

        private void masterMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgAbsenKaryawan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnAbsen_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
