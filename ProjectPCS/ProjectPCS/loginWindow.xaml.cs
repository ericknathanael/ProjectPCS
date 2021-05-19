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

namespace ProjectPCS
{
    /// <summary>
    /// Interaction logic for loginWindow.xaml
    /// </summary>
    public partial class loginWindow : Window
    {
        public static OracleConnection conn;
        public OracleCommand cmd;
        public static string user;
        public static string name;
        public static string pass;
        public static string source;
        public loginWindow()
        {
            InitializeComponent();
            conn = MainWindow.conn;
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                user = tbUser.Text;
                pass = tbPass.Text;
                string query = $"select id_jabatan from karyawan where username = '{user.ToUpper()}' and pass = '{pass}' and (id_jabatan = 4 or id_jabatan = 1)";
                cmd = new OracleCommand(query, conn);
                OracleDataReader dr = cmd.ExecuteReader();
                int jabatan = -1;
                while (dr.Read())
                {
                    jabatan = int.Parse(dr[0].ToString());
                    MessageBox.Show(jabatan + "");
                }
                
                conn.Close();
                if (jabatan == -1)
                {
                    MessageBox.Show("username atau password salah");
                }
                else if (jabatan == 1)
                {
                    //apabila masuk ke menu manager(Register karyawan,tambah menu, update absensi,laporan)
                }                               
                else if(jabatan == 4)
                {
                    //apabila masuk ke menu kasir(transaksi reservation,print nota);
                }

                //sementara menggunakan ini agar tida   k perlu login menggunakan karyawan dsb

                conn.Open();
                query = $"select nama_karyawan from karyawan where username = '{user.ToUpper()}' and pass = '{pass}' and (id_jabatan = 4 or id_jabatan = 1)";
                cmd = new OracleCommand(query, conn);
                name = cmd.ExecuteScalar().ToString();
                MessageBox.Show(name);
                conn.Close();

                menuWindow menu = new menuWindow();
                this.Hide();
                menu.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
