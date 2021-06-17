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
    /// Interaction logic for masterAbsensi.xaml
    /// </summary>
    public partial class masterAbsensi : Window
    {
        OracleConnection conn;
        OracleCommand cmd;
        OracleDataAdapter da;
        DataTable dt;
        DataSet ds;

        string query;
        string id;
        string kode;
        string masuk;
        string pulang;
        string tanggal;
        string nama;

        string pil;

        public masterAbsensi()
        {
            InitializeComponent();
            conn = MainWindow.conn;
            ResetDataGrid();
            generateID();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            conn.Open();
            dgAbsen.Columns[0].Width = 30;
            dgAbsen.Columns[1].Width = 106;
            dgAbsen.Columns[2].Width = 106;
            dgAbsen.Columns[3].Width = 105;
            dgAbsen.Columns[4].Width = 105;
            dgAbsen.Columns[5].Width = 105;
            query = $"Select id,nama_karyawan from karyawan";
            cmd = new OracleCommand(query, conn);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbNama.Items.Add($"{dr[0].ToString()} - {dr[1].ToString()}");
            }
            conn.Close();
        }

        private void buttonFilter_Click(object sender, RoutedEventArgs e)
        {
            if(tbFilter.Text != "")
            {
                conn.Open();
                query = $"select da.id, k.nama_karyawan,a.kode_absen,da.jam_Masuk,da.jam_pulang,to_char(a.tgl_absen,'DD - MM - YYYY')" +
                $"from d_absensi da left join absensi a on da.id_absen = a.id left join karyawan k on da.id_karyawan = k.id where k.nama_karyawan like '{tbFilter.Text.ToUpper()}%' order by 1";
                cmd = new OracleCommand(query, conn);
                cmd.ExecuteReader();
                da = new OracleDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dgAbsen.ItemsSource = dt.DefaultView;
                conn.Close();
            }
            else
            {
                MessageBox.Show("Textbox tidak boleh kosong!");
            }
        }

        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            ResetDataGrid();
        }


        public void ResetDataGrid()
        {
            /*query = $"select da.id, k.nama_karyawan,a.kode_absen,da.jam_Masuk,da.jam_pulang,to_char(a.tgl_absen,'DD - MM - YYYY')" +
                $"from d_absensi da left join absensi a on da.id_absen = a.id left join karyawan k on da.id_karyawan = k.id order by 1 ";*/
            query = $"select da.id, k.nama_karyawan,a.kode_absen,to_char(da.jam_Masuk,'HH24:MM:SS'),TO_CHAR(da.jam_pulang,'HH24:MM:SS'),to_char(a.tgl_absen,'DD - MM - YYYY')" +
                $"from d_absensi da left join absensi a on da.id_absen = a.id left join karyawan k on da.id_karyawan = k.id order by 1 ";
            cmd = new OracleCommand(query, conn);
            conn.Open();
            cmd.ExecuteReader();
            da = new OracleDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dgAbsen.ItemsSource = dt.DefaultView;
            conn.Close();
        }

        private void dgAbsen_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            tbKode.IsEnabled = false;
            btInsert.IsEnabled = false;
            btDelete.IsEnabled = true;
            btUpdate.IsEnabled = true;
            id = dt.Rows[dgAbsen.SelectedIndex][0].ToString();
            nama = dt.Rows[dgAbsen.SelectedIndex][1].ToString();
            kode = dt.Rows[dgAbsen.SelectedIndex][2].ToString();
            masuk = dt.Rows[dgAbsen.SelectedIndex][3].ToString();
            pulang = dt.Rows[dgAbsen.SelectedIndex][4].ToString();
            tanggal = dt.Rows[dgAbsen.SelectedIndex][5].ToString();

            conn.Open();
            query = $"select id from karyawan where nama_karyawan = '{nama}'";
            cmd = new OracleCommand(query, conn);

            int index = Convert.ToInt32(cmd.ExecuteScalar()) - 1;
            conn.Close();

            lbID.Content = id;
            cbNama.IsEnabled = false;
            cbNama.SelectedIndex = index;
            tbKode.Text = kode;
            tbMasuk.Text = masuk;
            tbKeluar.Text = pulang;
            dtTgl.SelectedDate = DateTime.ParseExact(tanggal,"dd - MM - yyyy", System.Globalization.CultureInfo.InvariantCulture);
            dtTgl.IsEnabled = false;
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if(tbMasuk.Text == "" || tbKeluar.Text == "")
            {
                MessageBox.Show("Pastikan Seluruh Textbox sudah diisi");
            }
            else
            {
                masuk = tbMasuk.Text;
                pulang = tbKeluar.Text;
                query = $"update d_absensi set jam_masuk = to_date('{masuk}','HH24:mi:ss'), jam_pulang = to_date('{pulang}','HH24:mi:ss') where id = {id}";
                conn.Open();
                cmd = new OracleCommand(query, conn);
                using(OracleTransaction trans = conn.BeginTransaction())
                {
                    cmd.Transaction = trans;
                    try
                    {
                        //if(DateTime.ParseExact(masuk,"HH24:mm:ss", System.Globalization.CultureInfo.InvariantCulture) < DateTime.ParseExact(pulang, "HH24:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                        cmd.ExecuteNonQuery();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show(ex.Message);    
                    }
                }
                conn.Close();
            }
            ResetDataGrid();
            clearData();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            masuk = tbMasuk.Text;
            pulang = tbKeluar.Text;
            query = $"delete from d_absensi where id = {id}";
            conn.Open();
            cmd = new OracleCommand(query, conn);
            using (OracleTransaction trans = conn.BeginTransaction())
            {
                cmd.Transaction = trans;
                try
                {
                    cmd.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }
            clearData();
            conn.Close();
        }

        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            if (tbMasuk.Text == "" || tbKode.Text == "")
            {
                MessageBox.Show("pastikan semua sudah terisi");
            }
            else
            {
                conn.Open();

                id = lbID.Content.ToString();
                query = $"Select id from absensi where kode_absen = '{tbKode.Text}'";
                cmd = new OracleCommand(query, conn);

                if (cmd.ExecuteScalar() == null)
                {
                    MessageBox.Show("kode tidak sesuai silahkan coba lagi!");
                }
                else
                {
                    kode = tbKode.Text;
                    string idAbsen = cmd.ExecuteScalar().ToString();
                    masuk = tbMasuk.Text;
                    pulang = tbKeluar.Text;
                    DateTime absenMasuk;
                    string[] tmp = dtTgl.DisplayDate.ToString().Split(' ');
                    string s = $"{tmp[0]} {masuk}";
                    absenMasuk = DateTime.Parse(s);
                    string[] idKaryawan = cbNama.SelectedItem.ToString().Split(' ');

                    if (tbKeluar.Text == "")
                    {
                        query = $"insert into d_absensi values({id},{idAbsen},{idKaryawan[0]},to_date('{masuk}','HH24:mi:ss'),null)";
                    }
                    else
                    {
                        query = $"insert into d_absensi values({id},{idAbsen},{idKaryawan[0]},to_date('{masuk}','HH24:mi:ss'),to_date('{pulang}','HH24:mi:ss'))";
                    }
                    cmd = new OracleCommand(query, conn);
                    using (OracleTransaction tr = conn.BeginTransaction())
                    {
                        cmd.Transaction = tr;
                        try
                        {
                            cmd.ExecuteNonQuery();
                            tr.Commit();
                            MessageBox.Show("Berhasil Insert");
                        }
                        catch (Exception ex)
                        {
                            tr.Rollback();
                            MessageBox.Show(ex.Message);
                        }
                    }
                    clearData();
                }
            }

            conn.Close();
            ResetDataGrid();
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            clearData();
            generateID();
        }

        public void generateID()
        {
            conn.Close();
            query = $"select max(ID) + 1 from D_absensi";
            cmd = new OracleCommand(query, conn);
            conn.Open();
            string id = cmd.ExecuteScalar().ToString();
            lbID.Content = id;
            conn.Close();
        }

        public void clearData()
        {
            lbID.Content = "-";
            cbNama.SelectedIndex = -1;
            tbKode.Text = "";
            tbKeluar.Text = "";
            tbMasuk.Text = "";
            pil = "";
            dtTgl.SelectedDate = DateTime.Now;
            tbKode.IsEnabled = true;
            btUpdate.IsEnabled = false;
            btDelete.IsEnabled = false;
            btClear.IsEnabled = true;
            btInsert.IsEnabled = true;
            dtTgl.SelectedDate = DateTime.Now;
            dtTgl.IsEnabled = true;
            cbNama.IsEnabled = true;

            generateID();
        }

        private void picHome_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ManagerWindow manage = new ManagerWindow();
            this.Hide();
            manage.ShowDialog();
            this.Close();
        }
    }
}
