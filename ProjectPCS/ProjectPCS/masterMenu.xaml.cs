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
    /// Interaction logic for masterMenu.xaml
    /// </summary>
    public partial class masterMenu : Window
    {
        int barisKeKlik;
        string kode;
        OracleConnection conn;
        DataSet ds, ds2;
        public masterMenu()
        {
            InitializeComponent();
            conn = loginWindow.conn;
            refreshMenu();
            refreshJenis();
            fillJenis();
        }
        void refreshMenu()
        {
            conn.Close();
            conn.Open();
            string qry = "SELECT M.ID AS \"No\", M.KODE_MENU AS \"Kode Menu\", M.NAMA_MENU AS \"Nama Makanan\", " +
                   "J.NAMA_JENIS AS \"Jenis Makanan\", CASE WHEN M.STATUS = 1 THEN 'AVAILABLE' ELSE 'NOT AVAILABLE' END AS \"Status\"," +
                   " M.HARGA AS \"Harga\", M.DISKON AS \"Diskon\", M.HARGA_AKHIR AS \"Harga Akhir\" " +
                   "FROM MENU M, JENIS_MENU J WHERE M.ID_JENIS_MENU = J.ID ORDER BY M.ID";
            OracleCommand cmd = new OracleCommand(qry, conn);
            cmd.ExecuteReader();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            dgMenu.ItemsSource = ds.Tables[0].DefaultView;
            conn.Close();
        }
        void refreshJenis()
        {
            conn.Close();
            conn.Open();
            string qry = "SELECT ID AS \"No\", KODE_JENIS AS \"Kode Jenis Makanan\", NAMA_JENIS AS \"Jenis Makanan\" FROM JENIS_MENU ORDER BY ID";
            OracleCommand cmd = new OracleCommand(qry, conn);
            cmd.ExecuteReader();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            ds2 = new DataSet();
            da.Fill(ds2);
            dgJenis.ItemsSource = ds2.Tables[0].DefaultView;
            conn.Close();
        }
        void fillJenis()
        {
            conn.Close();
            conn.Open();
            comboBoxJenis.Items.Clear();
            string qry = "select * from jenis_menu order by id";
            OracleCommand cmd = new OracleCommand(qry, conn);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBoxJenis.Items.Add(dr.GetString(2));
            }
            conn.Close();
        }
        void clear()
        {
            labelKode.Content = "-";
            textBoxNama.Text = "";
            textBoxHarga.Text = "";
            textBoxDiskon.Text = "";
            comboBoxJenis.Text = "";
            buttonInsert.IsEnabled = true;
            buttonUpdate.IsEnabled = false;
            buttonDelete.IsEnabled = false;
            radioButton1.IsChecked = true;
            radioButton2.IsChecked = false;
        }
        void clear2()
        {
            labelKode2.Content = "-";
            textBoxJenis.Text = "";
            buttonInsert2.IsEnabled = true;
            buttonUpdate2.IsEnabled = false;
            buttonDelete2.IsEnabled = false;
        }
        void generateKodeMenu()
        {
            string[] kata = textBoxNama.Text.Split(' ');
            string qry = "select kode_menu from menu";
            OracleCommand cmd = new OracleCommand(qry, conn);
            OracleDataReader dr = cmd.ExecuteReader();
            int ctr = 1;
            while (dr.Read())
            {
                if (dr.GetString(0).Substring(0, 2) == kata[0].Substring(0, 1) + kata[1].Substring(0, 1))
                {
                    ctr++;
                }
            }
            kode = kata[0].Substring(0, 1) + kata[1].Substring(0, 1);
            for (int i = 0; i < 3 - Convert.ToInt32(ctr.ToString().Length); i++)
            {
                kode += "0";
            }
            kode += ctr.ToString();
        }
        void generateKodeJenis()
        {
            string qry = "select kode_jenis from jenis_menu";
            OracleCommand cmd = new OracleCommand(qry, conn);
            OracleDataReader dr = cmd.ExecuteReader();
            int ctr = 1;
            while (dr.Read())
            {
                if (dr.GetString(0).Substring(0, 2) == textBoxJenis.Text.Substring(0, 2))
                {
                    ctr++;
                }
            }
            kode = textBoxJenis.Text.Substring(0, 2);
            for (int i = 0; i < 3 - Convert.ToInt32(ctr.ToString().Length); i++)
            {
                kode += "0";
            }
            kode += ctr.ToString();
        }

        private void menuTrans_Click(object sender, RoutedEventArgs e)
        {
            transaksiWindow trans = new transaksiWindow();
            this.Hide();
            trans.ShowDialog();
            this.Close();
        }

        private void menuKaryawan_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow manager = new ManagerWindow();
            this.Hide();
            manager.ShowDialog();
            this.Close();
        }

        private void menuLaporan_Click(object sender, RoutedEventArgs e)
        {
            //menuLaporan laporan = new menuLaporan();
            this.Hide();
            //laporan.ShowDialog();
            this.Close();
        }

        private void buttonInsert2_Click(object sender, RoutedEventArgs e)
        {
            conn.Close();
            if(textBoxJenis.Text == "")
            {
                MessageBox.Show("Masih ada field yang kosong");
            }
            else
            {
                conn.Open();
                string qry = "select NAMA_JENIS from jenis_menu";
                OracleCommand cmd = new OracleCommand(qry, conn);
                OracleDataReader dr = cmd.ExecuteReader();
                bool flag = true;
                while (dr.Read())
                {
                    if(dr.GetString(0) == textBoxJenis.Text)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    qry = "select max(id) from jenis_menu";
                    cmd = new OracleCommand(qry, conn);
                    int id = Convert.ToInt32(cmd.ExecuteScalar().ToString()) + 1;
                    generateKodeJenis();
                    qry = "insert into jenis_menu values(:ID,:KODE_JENIS,:NAMA_JENIS)";
                    try
                    {
                        cmd = new OracleCommand(qry, conn);
                        cmd.Parameters.Add("ID", OracleDbType.Int32).Value = id;
                        cmd.Parameters.Add("KODE_JENIS", OracleDbType.Varchar2).Value = kode;
                        cmd.Parameters.Add("NAMA_JENIS", OracleDbType.Varchar2).Value = textBoxJenis.Text;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Insert Jenis Makanan Berhasil");
                        refreshJenis();
                        fillJenis();
                        clear2();
                        conn.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Jenis Makanan sudah ada");
                }
            }
        }

        private void buttonUpdate2_Click(object sender, RoutedEventArgs e)
        {
            conn.Close();
            if (textBoxJenis.Text == "")
            {
                MessageBox.Show("Masih ada field yang kosong");
            }
            else
            {
                string qry = "UPDATE JENIS_MENU SET NAMA_JENIS='" + textBoxJenis.Text + 
                    "' WHERE KODE_JENIS ='" + labelKode2.Content + "'";
                try
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand(qry, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Menu Makanan Berhasil");
                    refreshMenu();
                    refreshJenis();
                    fillJenis();
                    clear2();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
            }
        }

        private void buttonDelete2_Click(object sender, RoutedEventArgs e)
        {
            conn.Close();
            conn.Open();
            string qry = "select id from jenis_menu where nama_jenis = '" + textBoxJenis.Text + "'";
            OracleCommand cmd = new OracleCommand(qry, conn);
            int id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            qry = "DELETE FROM MENU where ID_JENIS_MENU ='" + id + "'";
            string qry2 = "DELETE FROM JENIS_MENU where ID ='" + id + "'";
            try
            {
                cmd = new OracleCommand(qry, conn);
                cmd.ExecuteNonQuery();
                cmd = new OracleCommand(qry2, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Jenis Makanan Berhasil");
                refreshMenu();
                refreshJenis();
                fillJenis();
                clear2();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            conn.Close();
            if(textBoxNama.Text == "" || textBoxHarga.Text == "" || textBoxDiskon.Text == "" || comboBoxJenis.Text == "")
            {
                MessageBox.Show("Masih ada field yang kosong");
            }
            else
            {
                conn.Open();
                string qry = "select NAMA_MENU from menu";
                OracleCommand cmd = new OracleCommand(qry, conn);
                OracleDataReader dr = cmd.ExecuteReader();
                bool flag = true;
                while (dr.Read())
                {
                    if (dr.GetString(0) == textBoxNama.Text)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    qry = "select max(id) from menu";
                    cmd = new OracleCommand(qry, conn);
                    int id = Convert.ToInt32(cmd.ExecuteScalar().ToString()) + 1;
                    generateKodeMenu();
                    qry = "insert into menu values(:ID,:ID_JENIS,:KODE_MENU,:NAMA_MENU,:STATUS,:HARGA,:DISKON,:HARGA_AKHIR)";
                    try
                    {
                        cmd = new OracleCommand(qry, conn);
                        cmd.Parameters.Add("ID", OracleDbType.Int32).Value = id;
                        cmd.Parameters.Add("ID_JENIS", OracleDbType.Int32).Value = comboBoxJenis.SelectedIndex + 1;
                        cmd.Parameters.Add("KODE_MENU", OracleDbType.Varchar2).Value = kode;
                        cmd.Parameters.Add("NAMA_MENU", OracleDbType.Varchar2).Value = textBoxNama.Text;
                        if (radioButton1.IsChecked == true)
                        {
                            cmd.Parameters.Add("STATUS", OracleDbType.Int32).Value = 1;
                        }
                        else
                        {
                            cmd.Parameters.Add("STATUS", OracleDbType.Int32).Value = 0;
                        }
                        cmd.Parameters.Add("HARGA", OracleDbType.Int32).Value = textBoxHarga.Text;
                        cmd.Parameters.Add("DISKON", OracleDbType.Int32).Value = textBoxDiskon.Text;
                        int hargaAkhir = Convert.ToInt32(textBoxHarga.Text) - (Convert.ToInt32(textBoxHarga.Text) * Convert.ToInt32(textBoxDiskon.Text) / 100);
                        cmd.Parameters.Add("HARGA_AKHIR", OracleDbType.Int32).Value = hargaAkhir;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Insert Menu Makanan Berhasil");
                        refreshMenu();
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
                    MessageBox.Show("Menu Makanan sudah ada");
                }
            }
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            conn.Close();
            if (textBoxNama.Text == "" || comboBoxJenis.Text == "" || textBoxHarga.Text == "" || textBoxDiskon.Text == "")
            {
                MessageBox.Show("Masih ada field yang kosong");
            }
            else
            {
                string qry = "UPDATE MENU SET NAMA_MENU= :NAMA_MENU , ID_JENIS_MENU= :ID_JENIS, " +
                        "STATUS = :STATUS, HARGA = :HARGA, DISKON = :DISKON WHERE KODE_MENU = :KODE";
                try
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand(qry, conn);
                    cmd.Parameters.Add("NAMA_MENU", OracleDbType.Varchar2).Value = textBoxNama.Text;
                    cmd.Parameters.Add("ID_JENIS", OracleDbType.Int32).Value = comboBoxJenis.SelectedIndex + 1;
                    if (radioButton1.IsChecked == true)
                    {
                        cmd.Parameters.Add("STATUS", OracleDbType.Int32).Value = 1;
                    }
                    else
                    {
                        cmd.Parameters.Add("STATUS", OracleDbType.Int32).Value = 0;
                    }
                    cmd.Parameters.Add("HARGA", OracleDbType.Int32).Value = textBoxHarga.Text;
                    cmd.Parameters.Add("DISKON", OracleDbType.Int32).Value = textBoxDiskon.Text;
                    cmd.Parameters.Add("KODE", OracleDbType.Varchar2).Value = labelKode.Content;
                    cmd.ExecuteNonQuery();
                    int harga = Convert.ToInt32(textBoxHarga.Text);
                    int diskon = (Convert.ToInt32(textBoxHarga.Text) * Convert.ToInt32(textBoxDiskon.Text) / 100);
                    int hargaAkhir = harga - diskon;
                    qry = "UPDATE MENU SET HARGA_AKHIR = '" + hargaAkhir + "' WHERE KODE_MENU = '" + labelKode.Content + "'";
                    cmd = new OracleCommand(qry, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Menu Makanan Berhasil");
                    refreshMenu();
                    clear();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            conn.Close();
            string qry = "DELETE FROM MENU where NAMA_MENU ='" + textBoxNama.Text + "'";
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(qry, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Menu Makanan Berhasil");
                refreshMenu();
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

        private void buttonClear2_Click(object sender, RoutedEventArgs e)
        {
            clear2();
        }
        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            textBoxFilter.Text = "";
            refreshMenu();
        }
        private void buttonReset2_Click(object sender, RoutedEventArgs e)
        {
            textBoxFilter2.Text = "";
            refreshJenis();
        }

        private void buttonFilter_Click(object sender, RoutedEventArgs e)
        {
            conn.Close();
            conn.Open();
            string qry = "SELECT M.ID AS \"No\", M.KODE_MENU AS \"Kode Menu\", M.NAMA_MENU AS \"Nama Makanan\", " +
                    "J.NAMA_JENIS AS \"Jenis Makanan\", CASE WHEN M.STATUS = 1 THEN 'AVAILABLE' ELSE 'NOT AVAILABLE' END AS \"Status\"," +
                    " M.HARGA AS \"Harga\", M.DISKON AS \"Diskon\", M.HARGA_AKHIR AS \"Harga Akhir\" " +
                    "FROM MENU M, JENIS_MENU J WHERE M.ID_JENIS_MENU = J.ID AND M.NAMA_MENU LIKE '%" + textBoxFilter.Text + "%' ORDER BY M.ID";
            OracleCommand cmd = new OracleCommand(qry, conn);
            cmd.ExecuteReader();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            dgMenu.ItemsSource = ds.Tables[0].DefaultView;
            conn.Close();
        }
        private void buttonFilter2_Click(object sender, RoutedEventArgs e)
        {
            conn.Close();
            conn.Open();
            string qry = "SELECT ID AS \"No\", KODE_JENIS AS \"Kode Jenis Makanan\", NAMA_JENIS AS \"Jenis Makanan\" " +
                "FROM JENIS_MENU WHERE NAMA_JENIS LIKE '%" + textBoxFilter2.Text + "%' ORDER BY ID";
            OracleCommand cmd = new OracleCommand(qry, conn);
            cmd.ExecuteReader();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            ds2 = new DataSet();
            da.Fill(ds2);
            dgJenis.ItemsSource = ds2.Tables[0].DefaultView;
            conn.Close();
        }
        private void dgMenu_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            conn.Close();
            conn.Open();
            barisKeKlik = dgMenu.Items.IndexOf(dgMenu.CurrentItem);
            string qry = "SELECT COUNT(*) FROM MENU";
            OracleCommand cmd = new OracleCommand(qry, conn);
            int jumlah = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (barisKeKlik >= 0 && barisKeKlik < jumlah)
            {
                DataRow dr = ds.Tables[0].Rows[barisKeKlik];
                qry = "select kode_menu from menu where nama_menu = '" + dr["Nama Makanan"].ToString() + "'";
                cmd = new OracleCommand(qry, conn);
                string kode = cmd.ExecuteScalar().ToString();
                labelKode.Content = kode;
                textBoxNama.Text = dr["Nama Makanan"].ToString();
                qry = "select id from jenis_menu where nama_jenis ='" + dr["Jenis Makanan"] + "'";
                cmd = new OracleCommand(qry, conn);
                int id = Convert.ToInt32(cmd.ExecuteScalar().ToString()) - 1;
                comboBoxJenis.SelectedIndex = id;
                textBoxHarga.Text = dr["Harga"].ToString();
                textBoxDiskon.Text = dr["Diskon"].ToString();
                if(dr["Status"].ToString() == "AVAILABLE")
                {
                    radioButton1.IsChecked = true;
                    radioButton2.IsChecked = false;
                }
                else
                {
                    radioButton1.IsChecked = false;
                    radioButton2.IsChecked = true;
                }
                buttonInsert.IsEnabled = false;
                buttonUpdate.IsEnabled = true;
                buttonDelete.IsEnabled = true;
            }
            conn.Close();
        }

        private void dgJenis_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            conn.Close();
            conn.Open();
            barisKeKlik = dgJenis.Items.IndexOf(dgJenis.CurrentItem);
            string qry = "SELECT COUNT(*) FROM JENIS_MENU";
            OracleCommand cmd = new OracleCommand(qry, conn);
            int jumlah = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (barisKeKlik >= 0 && barisKeKlik < jumlah)
            {
                DataRow dr = ds2.Tables[0].Rows[barisKeKlik];
                labelKode2.Content = dr["Kode Jenis Makanan"].ToString();
                textBoxJenis.Text = dr["Jenis Makanan"].ToString();
                buttonInsert2.IsEnabled = false;
                buttonUpdate2.IsEnabled = true;
                buttonDelete2.IsEnabled = true;
            }
            conn.Close();
        }
    }
}
