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
        Karyawan kasir;

        public masterReservasi()
        {
            InitializeComponent();
            conn = MainWindow.conn;
            kasir = loginWindow.karyawan;
            refreshReservasi();
            fillComboBox();
        }

        void refreshReservasi()
        {
            conn.Close();
            conn.Open();
            string qry = "SELECT R.ID AS \"No\", P.NAMA_PELANGGAN AS \"Nama Pelanggan\", " +
                "R.ID_MEJA AS \"Nomor Meja\", TO_CHAR(R.TGL_WAKTU_PEMESANAN,'MM/DD/YYYY') AS \"Tanggal\", " +
                "TO_CHAR(R.WAKTU_PESAN,'HH24:MI') AS \"Jam Reservasi\", " +
                "TO_CHAR(R.PERKIRAAN_KELUAR,'HH24:MI') AS \"Jam Keluar\" " +
                "FROM RESERVATION R, PELANGGAN P " +
                "WHERE R.ID_PELANGGAN = P.ID ORDER BY 4";
            OracleCommand cmd = new OracleCommand(qry, conn);
            cmd.ExecuteReader();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            dgReservasi.ItemsSource = ds.Tables[0].DefaultView;
            conn.Close();
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
        
        void clear()
        {
            labelID.Content = "-";
            comboBoxNamaPelanggan.Text = "";
            comboBoxMeja.Text = "";
            datePickerTanggal.Text = "";
            tbJam.Text = "";
            tbMnt.Text = "";
            buttonInsert.IsEnabled = true;
            buttonUpdate.IsEnabled = false;
            buttonDelete.IsEnabled = false;
        }

        private void picHome_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window window = null;
            if(kasir.id_jabatan == 4)
            {
                window = new KasirWindow();
            }
            else if(kasir.id_jabatan == 1)
            {
                window = new ManagerWindow();
            }
            this.Hide();
            window.ShowDialog();
            this.Close();
        }

        private void TextboxJam_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!validHour(((TextBox)sender).Text + e.Text))
            {
                MessageBox.Show("Input Jam Invalid");
                tbJam.Clear();
            }
        }

        static bool validHour(string str_jam)
        {
            return int.TryParse(str_jam, out int jam) && jam > -1 && jam < 25;
        }

        private void TextBoxMenit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!validMinute(((TextBox)sender).Text + e.Text))
            {
                MessageBox.Show("Input Menit Invalid");
                tbMnt.Clear();
            }
        }

        static bool validMinute(string str_menit)
        {
            return int.TryParse(str_menit, out int menit) && menit > -1 && menit < 60;
        }

        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            conn.Close();
            if (comboBoxNamaPelanggan.Text == "" || comboBoxMeja.Text == "" || datePickerTanggal.Text == "" || tbJam.Text == "" || tbMnt.Text == "")
            {
                MessageBox.Show("Masih ada field yang kosong");
            }
            else
            {
                int input_tahun = datePickerTanggal.SelectedDate.Value.Year,
                input_bulan = datePickerTanggal.SelectedDate.Value.Month,
                input_tanggal = datePickerTanggal.SelectedDate.Value.Day;
                DateTime inputTime = new DateTime(input_tahun, input_bulan, input_tanggal, Convert.ToInt32(tbJam.Text), Convert.ToInt32(tbMnt.Text), 00);

                if (DateTime.Compare(inputTime, DateTime.Now) < 0)
                {
                    MessageBox.Show("Waktu Reservasi tidak valid");
                }
                else if ((DateTime.Now - inputTime).Hours * -1 < 2 && DateTime.Now.Date == datePickerTanggal.SelectedDate)
                {
                    MessageBox.Show("Waktu Reservasi minimal 2 jam dari sekarang");
                }
                else if(Convert.ToInt32(tbJam.Text) < 9)
                {
                    MessageBox.Show("Restoran belum buka");
                }
                else if (Convert.ToInt32(tbJam.Text) > 22)
                {
                    MessageBox.Show("Restoran sudah tutup");
                }
                else
                {
                    conn.Open();
                    string qry = "select to_char(waktu_pesan,'HH24:MI:SS'),to_char(perkiraan_keluar,'HH24:MI:SS'),ID_MEJA,TGL_WAKTU_pemesanan from RESERVATION";
                    OracleCommand cmd = new OracleCommand(qry, conn);
                    OracleDataReader dr = cmd.ExecuteReader();

                    bool flag = true;

                    int jamPesan = Convert.ToInt32(tbJam.Text);
                    int jamKeluar = jamPesan + 2;

                    int menitpesan = Convert.ToInt32(tbMnt.Text);
                    int idMeja = Convert.ToInt32(comboBoxMeja.Text);

                    while (dr.Read())
                    {
                        int jamAkhir = Convert.ToInt32(dr.GetValue(1).ToString().Substring(0, 2));
                        int jamAwal = Convert.ToInt32(dr.GetValue(0).ToString().Substring(0, 2));
                        int menitAwal = Convert.ToInt32(dr.GetValue(0).ToString().Substring(3,2));
                        
                        int menitAkhir = Convert.ToInt32(dr.GetValue(1).ToString().Substring(3,2));
                        string tanggal = dr.GetValue(3).ToString();
                        int idMejaDatabase = Convert.ToInt32(dr.GetValue(2));

                        string[] tanggalInput = datePickerTanggal.SelectedDate.ToString().Split(' ');
                        string[] tanggalDatabase = tanggal.Split(' ');
                        // 21/04/01 24:15:00
                       /* if ((jamAwal <= jamPesan && jamPesan <= jamAkhir && tanggalInput[0] == tanggalDatabase[0] && idMeja == idMejaDatabase) ||  //jam pesan
                            (jamAwal <= jamKeluar && jamKeluar <= jamAkhir && tanggalInput[0] == tanggalDatabase[0] && idMeja == idMejaDatabase))
                        {
                            if (menitAwal <= menitKeluar)
                            {
                                flag = false;
                                break;
                            }
                        }
                        else
                        {
                            flag = true;
                        }*/

                        //if(6 <= 7 & 7 != 8)
                        if(jamAwal == jamPesan && tanggalInput[0] == tanggalDatabase[0] && idMeja == idMejaDatabase) //apabila sama dengan jam awal
                        {
                            MessageBox.Show("1");
                            if(menitAwal <= menitpesan)
                            {
                                flag = false;
                                break;
                            }
                        }
                        else if (jamAwal < jamPesan && jamPesan < jamAkhir && tanggalInput[0] == tanggalDatabase[0] && idMeja == idMejaDatabase) //apabila diantara jam masuk dan keluar
                        {
                            MessageBox.Show(jamPesan + " " + jamAkhir);
                            MessageBox.Show("2");
                            flag = false;
                            break;

                        }else if (jamPesan == jamAkhir && tanggalInput[0] == tanggalDatabase[0] && idMeja == idMejaDatabase) //apabila sama dengan jam akhir
                        {
                            if(menitAkhir > menitpesan)
                            {
                                MessageBox.Show("3");
                                flag = false;
                                break;
                            }
                        }
                        else if (jamAwal == jamKeluar && tanggalInput[0] == tanggalDatabase[0] && idMeja == idMejaDatabase) //apabila sama dengan jam awal
                        {
                            MessageBox.Show("4");
                            if (menitAwal <= menitpesan)
                            {
                                flag = false;
                                break;
                            }
                        }
                        else if (jamAwal < jamKeluar && jamKeluar < jamAkhir && tanggalInput[0] == tanggalDatabase[0] && idMeja == idMejaDatabase) //apabila diantara jam masuk dan keluar
                        {
                            MessageBox.Show("5");
                            flag = false;
                            break;

                        }
                        else if (jamPesan == jamKeluar && tanggalInput[0] == tanggalDatabase[0] && idMeja == idMejaDatabase) //apabila sama dengan jam akhir
                        {
                            if (menitAkhir > menitpesan)
                            {
                                MessageBox.Show("6");
                                flag = false;
                                break;
                            }
                        }

                    }
                    if (flag)
                    {
                        qry = "select max(id) from reservation";
                        cmd = new OracleCommand(qry, conn);
                        int id2 = Convert.ToInt32(cmd.ExecuteScalar().ToString()) + 1;
                        int idPelanggan = comboBoxNamaPelanggan.SelectedIndex + 1;
                        string jam = tbJam.Text + ":" + tbMnt.Text;
                        int kira = Convert.ToInt32(tbJam.Text) + 2;
                        string jam2 = kira.ToString() + ":" + tbMnt.Text;
                        qry = $"insert into reservation values({id2},{idPelanggan},{idMeja},to_date('{datePickerTanggal.Text}','MM:DD:YYYY')," +
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
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            conn.Close();
            if (comboBoxNamaPelanggan.Text == "" || comboBoxMeja.Text == "" || datePickerTanggal.Text == "")
            {
                MessageBox.Show("Masih ada field yang kosong");
            }
            else if (Convert.ToInt32(tbJam.Text) < 9 || Convert.ToInt32(tbJam.Text) > 22)
            {
                MessageBox.Show("Restoran belum buka atau sudah tutup");
            }
            else if (Convert.ToInt32(tbMnt.Text) < 0 || Convert.ToInt32(tbMnt.Text) > 59)
            {
                MessageBox.Show("Menit tidak valid");
            }
            else
            {
                conn.Open();
                string qry = "select TO_CHAR(waktu_pesan,'HH24:MI:SS'),TO_CHAR(PERKIRAAN_KELUAR,'HH24:MI:SS'),id_meja,to_char(tgl_waktu_pemesanan,'MM/DD/YYYY') from RESERVATION";
                OracleCommand cmd = new OracleCommand(qry, conn);
                OracleDataReader dr = cmd.ExecuteReader();
                bool flag = true;

                int jamPesan = Convert.ToInt32(tbJam.Text);
                int jamKeluar = jamPesan + 2;

                int menitpesan = Convert.ToInt32(tbMnt.Text);
                int menitKeluar = menitpesan + 2;
                int idMeja = Convert.ToInt32(comboBoxMeja.Text);

                while (dr.Read())
                {
                    int jamAkhir = Convert.ToInt32(dr.GetValue(1).ToString().Substring(0, 2));
                    int jamAwal = Convert.ToInt32(dr.GetValue(0).ToString().Substring(0, 2));
                    int menitAwal = Convert.ToInt32(dr.GetValue(0).ToString().Substring(3, 2));

                    int menitAkhir = Convert.ToInt32(dr.GetValue(1).ToString().Substring(3, 2));
                    string tanggal = dr.GetValue(3).ToString();
                    int idMejaDatabase = Convert.ToInt32(dr.GetValue(2));

                    string[] tanggalInput = datePickerTanggal.SelectedDate.ToString().Split(' ');
                    string[] tanggalDatabase = tanggal.Split(' ');
                    // 21/04/01 24:15:00
                    if ((jamAwal <= jamPesan && jamPesan <= jamAkhir && tanggalInput[0] == tanggalDatabase[0] && idMeja == idMejaDatabase) ||  //jam pesan
                        (jamAwal <= jamKeluar && jamKeluar <= jamAkhir && tanggalInput[0] == tanggalDatabase[0] && idMeja == idMejaDatabase))
                    {
                        if (menitAwal < menitKeluar)
                        {
                            flag = false;
                            break;
                        }
                    }
                    else
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    int idPelanggan = comboBoxNamaPelanggan.SelectedIndex + 1;
                    int id = Convert.ToInt32(labelID.Content);
                    string jam = tbJam.Text + ":" + tbMnt.Text;
                    int kira = Convert.ToInt32(tbJam.Text) + 2;
                    string jam2 = kira.ToString() + ":" + tbMnt.Text;
                    qry = $"update reservation set id_pelanggan = {idPelanggan}, id_meja = {idMeja}, tgl_waktu_pemesanan = to_date('{datePickerTanggal.Text}','MM/DD/YYYY'), " +
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
            string jam = tbJam.Text + ":" + tbMnt.Text;
            string qry = $"DELETE FROM RESERVATION where id = {labelID.Content}";
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
                comboBoxMeja.SelectedIndex = Convert.ToInt32(dr["Nomor Meja"].ToString()) - 1;
                string tmp = dr["Tanggal"].ToString();
                MessageBox.Show(tmp);
                datePickerTanggal.SelectedDate = Convert.ToDateTime(dr["Tanggal"].ToString());
                tbJam.Text = dr["Jam Reservasi"].ToString().Substring(0, 2);
                tbMnt.Text = dr["Jam Reservasi"].ToString().Substring(3, 2);
                buttonInsert.IsEnabled = false;
                buttonUpdate.IsEnabled = true;
                buttonDelete.IsEnabled = true;
                nomorMeja = Convert.ToInt32(comboBoxMeja.Text);
                tanggal = datePickerTanggal.Text;
                jam = tbJam.Text + ":" + tbMnt.Text;
            }
            conn.Close();
        }
    }
}
