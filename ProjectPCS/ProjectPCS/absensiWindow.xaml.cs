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
using System.Windows.Threading;
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
        OracleCommand cmd;
        OracleDataAdapter da;
        DataTable dt;
        Karyawan karyawan;

        string query;

        public absensiWindow()
        {
            InitializeComponent();
            conn = loginWindow.conn;
            karyawan = loginWindow.karyawan;
            displayPage();
            query = $"select count(*) from karyawan k left join d_absensi da on k.id = da.id_karyawan left join absensi a on da.id_absen = a.id " +
                $"where to_char(tgl_absen,'mm') = to_char(sysdate,'mm') and k.id = {karyawan.id_karyawan}";
            conn.Open();
            cmd = new OracleCommand(query, conn);
            //lbAbsen.Content += cmd.ExecuteScalar().ToString() + " kali";
            lbNama.Content = karyawan.nama;
            conn.Close();
        }

        public absensiWindow(string kode)
        {
            InitializeComponent();
            conn = MainWindow.conn;
            karyawan = loginWindow.karyawan;
            displayPage();
            query = $"select count(*) from karyawan k left join d_absensi da on k.id = da.id_karyawan left join absensi a on da.id_absen = a.id " +
                $"where to_char(tgl_absen,'mm') = to_char(sysdate,'mm') and k.id = {karyawan.id_karyawan}";
            conn.Open();
            cmd = new OracleCommand(query, conn);
            //lbAbsen.Content += cmd.ExecuteScalar().ToString() + " kali";
            lbNama.Content = karyawan.nama;
            tbKode.Text = kode;
            conn.Close();
        }

        private void displayPage()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            labelDateTime.Content = DateTime.Now.ToString("D", new CultureInfo("id-ID")) + "\t" + DateTime.Now.ToString("T");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            query = $"select Kode_absen from absensi where to_char(tgl_absen,'DD-MM-YYYY') = to_char(SYSDATE,'DD-MM-YYYY') ";
            cmd = new OracleCommand(query, conn);
            conn.Open();
            string kode = cmd.ExecuteScalar().ToString();
            if (kode == tbKode.Text)
            {
                try
                {
                    query = $"select id from absensi where kode_absen = '{kode}'";
                    cmd = new OracleCommand(query, conn);
                    string idAbsen = cmd.ExecuteScalar().ToString();
                    query = $"select * from d_absensi where id_absen = {idAbsen} and id_karyawan = {karyawan.id_karyawan}";
                    cmd = new OracleCommand(query, conn);
                    if (cmd.ExecuteScalar() != null)
                    {
                        tbKode.Text = ManagerWindow.kode;
                        tbKode.IsEnabled = false;
                        btAbsen.Content = "Absen Pulang";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            conn.Close();
        }

        public void resetLabel(string idAbsen)
        {
            conn.Close();
            conn.Open();
            query = $"select count(*) from d_absensi where id_absen = {idAbsen} and id_karyawan = {karyawan.id_karyawan}";
            cmd.CommandText = query;
            int total = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            //lbAbsen.Content = $"Jumlah Absen Bulan ini sudah {total} kali";
            MessageBox.Show("Absen Berhasil");
            conn.Close();
        }

        private void BtAbsen_Click(object sender, RoutedEventArgs e)
        {
            string idAbsen;
            conn.Open();
            if(tbKode.Text == "")
            {
                MessageBox.Show("Masukkan Kode Terlebih Dahulu");
            }else
            {
                query = $"select kode_absen from absensi where to_char(sysdate,'DD-MM-YYYY') =TO_CHAR(tgl_absen,'DD-MM-YYYY')";
                cmd = new OracleCommand(query, conn);
                string kode = "";
                if(cmd.ExecuteScalar() != null)
                {
                    kode = cmd.ExecuteScalar().ToString();
                    query = $"select id from absensi where kode_absen = '{kode}'";
                    cmd.CommandText = query;
                    idAbsen = cmd.ExecuteScalar().ToString();
                    if (kode == tbKode.Text)
                    {
                        query = $"select jam_masuk from d_absensi where id_absen = {idAbsen} and id_karyawan = {karyawan.id_karyawan}";
                        cmd = new OracleCommand(query, conn);
                        if (cmd.ExecuteScalar() == null)
                        {
                            try
                            {
                                query = $"select MAX(ID) + 1 from d_absensi";
                                cmd = new OracleCommand(query, conn);
                                string id = cmd.ExecuteScalar().ToString();
                                query = $"insert into d_absensi values({id},{idAbsen},{karyawan.id_karyawan},sysdate,null)";
                                cmd = new OracleCommand(query, conn);
                                cmd.ExecuteNonQuery();
                                btAbsen.Content = "Absen Pulang";
                                tbKode.IsEnabled = false;
                                resetLabel(idAbsen);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            
                        }
                        else
                        {
                            query = $"update d_absensi set jam_pulang = sysdate " +
                                $"where id_absen = {idAbsen} and id_karyawan = {karyawan.id_karyawan}";
                            cmd = new OracleCommand(query, conn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Selamat beristirahat");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Kode belum ada, silahkan hubungi Manager");
                }
                this.Close();
            }
            conn.Close();
        }
    }
}
