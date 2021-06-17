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
    /// Interaction logic for masterReservasi.xaml
    /// </summary>
    public partial class masterReservasi : Window
    {
        int barisKeKlik, nomorMeja;
        string tanggal, jam;
        OracleConnection conn;
        DataSet ds;
        public masterReservasi()
        {
            InitializeComponent();
            conn = loginWindow.conn;
            refreshReservasi();
            fillComboBox();
        }
        void fillComboBox()
        {
            conn.Close();
            conn.Open();
            comboBoxNamaPelanggan.Items.Clear();
            string qry = "select * from pelanggan order by id";
            OracleCommand cmd = new OracleCommand(qry, conn);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBoxNamaPelanggan.Items.Add(dr.GetString(1));
            }
            comboBoxMeja.Items.Clear();
            for (int i = 1; i < 11; i++)
            {
                comboBoxMeja.Items.Add(i);
            }
            conn.Close();
        }
        void refreshReservasi()
        {
            conn.Close();
            conn.Open();
            string qry = "SELECT R.ID AS \"No\", P.NAMA_PELANGGAN AS \"Nama Pelanggan\", " +
                "R.ID_MEJA AS \"ID Meja\", TO_CHAR(R.TGL_WAKTU_PEMESANAN,'DD - MM - YYYY') AS \"Tanggal\", " +
                "TO_CHAR(R.WAKTU_PESAN,'HH24:MI') AS \"Jam Reservasi\", " +
                "TO_CHAR(R.PERKIRAAN_KELUAR,'HH24:MI') AS \"Jam Keluar\" " +
                "FROM RESERVATION R, PELANGGAN P " +
                "WHERE R.ID_PELANGGAN = P.ID ORDER BY R.ID";
            OracleCommand cmd = new OracleCommand(qry, conn);
            cmd.ExecuteReader();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            dgReservasi.ItemsSource = ds.Tables[0].DefaultView;
            conn.Close();
        }
        void clear()
        {
            labelID.Content = "-";
            comboBoxNamaPelanggan.Text = "";
            comboBoxMeja.Text = "";
            datePickerTanggal.Text = "";
            textboxJam.Text = "";
            textBoxMenit.Text = "";
            buttonInsert.IsEnabled = true;
            buttonUpdate.IsEnabled = false;
            buttonDelete.IsEnabled = false;
        }
        private void picHome_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ManagerWindow home = new ManagerWindow();
            this.Hide();
            home.ShowDialog();
            this.Close();
        }

        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            conn.Close();
            if (comboBoxNamaPelanggan.Text == "" || comboBoxMeja.Text == "" || datePickerTanggal.Text == "" || textboxJam.Text == "" || textBoxMenit.Text == "")
            {
                MessageBox.Show("Masih ada field yang kosong");
            }
            else if(Convert.ToInt32(textboxJam.Text) < 9 || Convert.ToInt32(textboxJam.Text) > 22)
            {
                MessageBox.Show("Restoran belum buka atau sudah tutup");
            }
            else if(Convert.ToInt32(textBoxMenit.Text) < 0 || Convert.ToInt32(textBoxMenit.Text) > 59)
            {
                MessageBox.Show("Menit tidak valid");
            } 
            else
            {
                conn.Open();
                string qry = "select * from RESERVATION";
                OracleCommand cmd = new OracleCommand(qry, conn);
                OracleDataReader dr = cmd.ExecuteReader();
                bool flag = true;
                while (dr.Read())
                {
                    MessageBox.Show(dr[4].ToString());
                    int jam3 = Convert.ToInt32(dr[4].ToString().Substring(11, 2)) + 1;
                    if (dr[2].ToString() == comboBoxMeja.Text && dr[3].ToString().Substring(0, 10) == datePickerTanggal.Text && dr[4].ToString().Substring(11, 2) == textboxJam.Text ||
                        dr[2].ToString() == comboBoxMeja.Text && dr[3].ToString().Substring(0, 10) == datePickerTanggal.Text && jam3.ToString() == textboxJam.Text)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    qry = "select max(id) from reservation";
                    cmd = new OracleCommand(qry, conn);
                    int id2 = Convert.ToInt32(cmd.ExecuteScalar().ToString()) + 1;
                    int idPelanggan = comboBoxNamaPelanggan.SelectedIndex + 1;
                    int idMeja = Convert.ToInt32(comboBoxMeja.Text);
                    string jam = textboxJam.Text + ":" + textBoxMenit.Text;
                    int kira = Convert.ToInt32(textboxJam.Text) + 2;
                    string jam2 = kira.ToString() + ":" + textBoxMenit.Text;
                    qry = $"insert into reservation values({id2},{idPelanggan},{idMeja},to_date('{datePickerTanggal.Text}','dd:MM:YYYY')," +
                        $"to_date('{jam}', 'HH24:mi:ss'),to_date('{jam2}','HH24:mi:ss'))";
                    try
                    {
                        cmd = new OracleCommand(qry, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Insert Reservasi Berhasil");
                        refreshReservasi();
                        clear();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Meja sudah direservasi");
                }
            }
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            conn.Close();
            if (comboBoxNamaPelanggan.Text == "" || comboBoxMeja.Text == "" || datePickerTanggal.Text == "")
            {
                MessageBox.Show("Masih ada field yang kosong");
            }
            else if (Convert.ToInt32(textboxJam.Text) < 9 || Convert.ToInt32(textboxJam.Text) > 22)
            {
                MessageBox.Show("Restoran belum buka atau sudah tutup");
            }
            else if (Convert.ToInt32(textBoxMenit.Text) < 0 || Convert.ToInt32(textBoxMenit.Text) > 59)
            {
                MessageBox.Show("Menit tidak valid");
            }
            else
            {
                conn.Open();
                string qry = "select * from RESERVATION";
                OracleCommand cmd = new OracleCommand(qry, conn);
                OracleDataReader dr = cmd.ExecuteReader();
                bool flag = true;
                while (dr.Read())
                {
                    int jam3 = Convert.ToInt32(dr[4].ToString().Substring(11, 2)) + 1;
                    if (dr[2].ToString() == comboBoxMeja.Text && dr[3].ToString().Substring(0, 10) == datePickerTanggal.Text && dr[4].ToString().Substring(11, 2) == textboxJam.Text ||
                        dr[2].ToString() == comboBoxMeja.Text && dr[3].ToString().Substring(0, 10) == datePickerTanggal.Text && jam3.ToString() == textboxJam.Text)
                    {
                        flag = false;
                    }
                    if(nomorMeja == Convert.ToInt32(comboBoxMeja.Text) && tanggal == datePickerTanggal.Text && jam == textboxJam.Text + ":" + textBoxMenit.Text)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    int idPelanggan = comboBoxNamaPelanggan.SelectedIndex + 1;
                    int idMeja = Convert.ToInt32(comboBoxMeja.Text);
                    int id = Convert.ToInt32(labelID.Content);
                    string jam = textboxJam.Text + ":" + textBoxMenit.Text;
                    int kira = Convert.ToInt32(textboxJam.Text) + 2;
                    string jam2 = kira.ToString() + ":" + textBoxMenit.Text;
                    qry = $"update reservation set id_pelanggan = {idPelanggan}, id_meja = {idMeja}, tgl_waktu_pemesanan = to_date('{datePickerTanggal.Text}','dd:MM:YYYY'), " +
                        $"waktu_pesan = to_date('{jam}', 'HH24:mi:ss'), perkiraan_keluar = to_date('{jam2}','HH24:mi:ss') where id = {id}";
                    try
                    {
                        cmd = new OracleCommand(qry, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Update Reservasi Berhasil");
                        refreshReservasi();
                        clear();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Meja sudah direservasi");
                }
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            conn.Close();
            string jam = textboxJam.Text + ":" + textBoxMenit.Text;
            string qry = "DELETE FROM RESERVATION where ID_MEJA ='" + comboBoxMeja.Text + "' " +
                "AND TGL_WAKTU_PEMESANAN = to_date('" + datePickerTanggal.Text + "','dd:MM:YYYY')" +
                "AND WAKTU_PESAN = to_date('" + jam + "', 'HH24:mi:ss')";
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(qry, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Reservasi Berhasil");
                refreshReservasi();
                clear();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void dgReservasi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            conn.Close();
            conn.Open();
            barisKeKlik = dgReservasi.Items.IndexOf(dgReservasi.CurrentItem);
            string qry = "SELECT COUNT(*) FROM RESERVATION";
            OracleCommand cmd = new OracleCommand(qry, conn);
            int jumlah = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (barisKeKlik >= 0 && barisKeKlik < jumlah)
            {
                DataRow dr = ds.Tables[0].Rows[barisKeKlik];
                labelID.Content = dr["No"].ToString();
                qry = "select id from pelanggan where nama_pelanggan ='" + dr["Nama Pelanggan"] + "'";
                cmd = new OracleCommand(qry, conn);
                int id = Convert.ToInt32(cmd.ExecuteScalar().ToString()) - 1;
                comboBoxNamaPelanggan.SelectedIndex = id;
                comboBoxMeja.SelectedIndex = Convert.ToInt32(dr["ID Meja"].ToString()) - 1;
                datePickerTanggal.SelectedDate = Convert.ToDateTime(dr["Tanggal"].ToString());
                textboxJam.Text = dr["Jam Reservasi"].ToString().Substring(0, 2);
                textBoxMenit.Text = dr["Jam Reservasi"].ToString().Substring(3, 2);
                buttonInsert.IsEnabled = false;
                buttonUpdate.IsEnabled = true;
                buttonDelete.IsEnabled = true;
                nomorMeja = Convert.ToInt32(comboBoxMeja.Text);
                tanggal = datePickerTanggal.Text;
                jam = textboxJam.Text + ":" + textBoxMenit.Text;
            }
            conn.Close();
        }
    }
}
