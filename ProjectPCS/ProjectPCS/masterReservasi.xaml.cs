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
                "R.ID_MEJA AS \"ID Meja\", TO_CHAR(R.TGL_WAKTU_PEMESANAN,'DD - MM - YYYY') AS \"Tanggal\" FROM RESERVATION R, PELANGGAN P " +
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
            if (comboBoxNamaPelanggan.Text == "" || comboBoxMeja.Text == "" || datePickerTanggal.Text == "")
            {
                MessageBox.Show("Masih ada field yang kosong");
            }
            else
            {
                conn.Open();
                string qry = "select ID_MEJA from MEJA";
                OracleCommand cmd = new OracleCommand(qry, conn);
                OracleDataReader dr = cmd.ExecuteReader();
                bool flag = true;
                while (dr.Read())
                {
                    if (dr[0].ToString() == comboBoxMeja.Text)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    qry = "select max(id) from meja";
                    cmd = new OracleCommand(qry, conn);
                    int id = Convert.ToInt32(cmd.ExecuteScalar().ToString()) + 1;
                    qry = "insert into meja values(:ID,:ID_MEJA,:WAKTU,:PERKIRAAN)";
                    try
                    {
                        DateTime date = DateTime.ParseExact(datePickerTanggal.Text, "dd/MM/yyyy", null);
                        cmd = new OracleCommand(qry, conn);
                        cmd.Parameters.Add("ID", OracleDbType.Int32).Value = id;
                        cmd.Parameters.Add("ID_MEJA", OracleDbType.Int32).Value = comboBoxMeja.Text;
                        cmd.Parameters.Add("WAKTU", OracleDbType.Date).Value = date;
                        cmd.Parameters.Add("PERKIRAAN", OracleDbType.Date).Value = date;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        conn.Close();
                    }
                    conn.Open();
                    qry = "select max(id) from reservation";
                    cmd = new OracleCommand(qry, conn);
                    int id2 = Convert.ToInt32(cmd.ExecuteScalar().ToString()) + 1;
                    qry = "insert into reservation values(:ID2,:ID_PELANGGAN,:ID_MEJA2,:TGL)";
                    int idPelanggan = comboBoxNamaPelanggan.SelectedIndex + 1;
                    int idMeja = Convert.ToInt32(comboBoxMeja.Text);
                    qry = $"insert into reservation values({id2},{idPelanggan},{idMeja},to_date('{datePickerTanggal.Text}','dd:MM:YYYY'))";
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
            else
            {
                conn.Open();
                string qry = "select ID_MEJA from MEJA";
                OracleCommand cmd = new OracleCommand(qry, conn);
                OracleDataReader dr = cmd.ExecuteReader();
                bool flag = true;
                while (dr.Read())
                {
                    if (dr[0].ToString() == comboBoxMeja.Text)
                    {
                        flag = false;
                    }
                    if(nomorMeja == Convert.ToInt32(comboBoxMeja.Text))
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    qry = "UPDATE MEJA SET ID_MEJA = :ID_MEJA, WAKTU_PESAN = :WAKTU, " +
                        "PERKIRAAN_KELUAR = :PERKIRAAN WHERE ID_MEJA = '" + nomorMeja + "'";
                    try
                    {
                        DateTime date = DateTime.ParseExact(datePickerTanggal.Text, "dd/MM/yyyy", null);
                        cmd = new OracleCommand(qry, conn);
                        cmd.Parameters.Add("ID_MEJA", OracleDbType.Int32).Value = comboBoxMeja.Text;
                        cmd.Parameters.Add("WAKTU", OracleDbType.Date).Value = date;
                        cmd.Parameters.Add("PERKIRAAN", OracleDbType.Date).Value = date;
                        qry = "UPDATE RESERVATION SET ID_PELANGGAN = :ID_PELANGAN, ID_MEJA = :ID_MEJA, " +
                            "TGL_WAKTU_PEMESANAN = :TGL WHERE ID = '" + labelID.Content + "'";
                        cmd = new OracleCommand(qry, conn);
                        cmd.Parameters.Add("ID_PELANGGAN", OracleDbType.Int32).Value = comboBoxNamaPelanggan.SelectedIndex + 1;
                        cmd.Parameters.Add("ID_MEJA", OracleDbType.Int32).Value = comboBoxMeja.Text;
                        cmd.Parameters.Add("TGL", OracleDbType.Date).Value = date;
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
            string qry = "DELETE FROM RESERVATION where ID_MEJA ='" + comboBoxMeja.Text + "'";
            string qry2 = "DELETE FROM MEJA where ID_MEJA ='" + comboBoxMeja.Text + "'";
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(qry, conn);
                cmd.ExecuteNonQuery();
                cmd = new OracleCommand(qry2, conn);
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
                buttonInsert.IsEnabled = false;
                buttonUpdate.IsEnabled = true;
                buttonDelete.IsEnabled = true;
                nomorMeja = Convert.ToInt32(comboBoxMeja.Text);
            }
            conn.Close();
        }
    }
}
