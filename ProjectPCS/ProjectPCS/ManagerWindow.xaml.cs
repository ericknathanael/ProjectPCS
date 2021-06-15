using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        OracleConnection conn;
        OracleCommand cmd;
        Karyawan manager;
        
        //string nama;
        string query;

        public static string kode;
        
        public ManagerWindow()
        {
            InitializeComponent();
            conn = MainWindow.conn;
            manager = loginWindow.karyawan;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbWelcome.Content = $"Welcome, {manager.nama}";
            conn.Open();

            query = $"select kode_absen from absensi where to_char(tgl_absen,'dd-mm-yyyy') = to_char(sysdate,'dd-mm-yyyy')";
            cmd = new OracleCommand(query, conn);
            if(cmd.ExecuteScalar() != null)
            {
                lbKode.Content = cmd.ExecuteScalar().ToString();
                kode = lbKode.Content + "";
            }
            if(lbKode.Content != "")
            {
                btGenerate.IsEnabled = false;
            }

            conn.Close();
        }

        private void btLogout_Click(object sender, RoutedEventArgs e)
        {
            loginWindow login = new loginWindow();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }

        private void btRegis_Click(object sender, RoutedEventArgs e)
        {
            registerWindow regis = new registerWindow();
            this.Hide();
            regis.ShowDialog();
            this.Close();
        }

        private void btLaporan_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("belom");
        }

        private void btMenu_Click(object sender, RoutedEventArgs e)
        {
            masterMenu menu = new masterMenu();
            this.Hide();
            menu.ShowDialog();
            this.Close();
        }

        private void btAbsensi_Click(object sender, RoutedEventArgs e)
        {
            Window window = null;
            if (manager.id_jabatan != 1)
            {
                window = new absensiWindow();
            }
            else
            {
                window = new masterAbsensi();
            }
            this.Hide();
            window.ShowDialog();
            this.Close();
        }

        private void btGenerate_Click(object sender, RoutedEventArgs e)
        {
            string ketemu = "";
            int id = 0;

            query = $"select kode_absen from absensi where to_char(tgl_absen,'dd-mm-yyyy') = to_char(sysdate,'dd-mm-yyyy')";
            conn.Open();
            cmd = new OracleCommand(query, conn);
            if(cmd.ExecuteScalar() != null)
            {
                ketemu = cmd.ExecuteScalar().ToString();
                
            }
            else
            {
                using (OracleTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    cmd.Transaction = trans;
                    try
                    {
                        kode = randomHuruf().ToUpper();
                        lbKode.Content = kode;

                        query = $"select count(*) + 1 from absensi";
                        cmd = new OracleCommand(query, conn);
                        id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                        query = $"insert into absensi values({id},'{kode}',sysdate)";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        trans.Rollback();
                    }
                }
                
            }
            conn.Close();
            btGenerate.IsEnabled = false;
        }

        public string randomHuruf()
        {
            Random r = new Random();
            string huruf = "";
            string[] az = new string[] {"b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", 
                "p", "q", "r", "s", "t", "v", "w", "x", "y", "z", "a", 
                "e", "i", "o", "u", "1", "2", "3", "4", "5", "6", "7",
                "8", "9", "0"};
            for (int i = 0; i < 3; i++)
            {
                huruf += az[r.Next(0,25)];
            }
            return huruf + DateTime.UtcNow.ToString("dd");
        }

        private void btVoucher_Click(object sender, RoutedEventArgs e)
        {
            VoucherWindow voucher = new VoucherWindow();
            this.Hide();
            voucher.ShowDialog();
            this.Close();
        }

        private void btCustomer_Click(object sender, RoutedEventArgs e)
        {
            regisCustWindow cust = new regisCustWindow();
            this.Hide();
            cust.ShowDialog();
            this.Close();
        }

        private void btReserve_Click(object sender, RoutedEventArgs e)
        {
            masterReservasi reserve = new masterReservasi();
            this.Hide();
            reserve.ShowDialog();
            this.Close();
        }
    }
}
