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
    /// Interaction logic for menuKaryawan.xaml
    /// </summary>
    public partial class menuKaryawan : Window
    {
        OracleConnection conn;
        OracleCommandBuilder builder;
        OracleCommand cmd;
        OracleDataAdapter da;
        DataTable dt;

        string query;
        bool radiobutton;
        public menuKaryawan()
        {
            InitializeComponent();
            conn = loginWindow.conn;
            query = "select id,username,pass,nama_karyawan,tgl_daftar from karyawan";
            da = new OracleDataAdapter(query, conn);

            builder = new OracleCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dgKaryawan.ItemsSource = dt.DefaultView;
        }

        private void menuTrans_Click(object sender, RoutedEventArgs e)
        {
            transaksiWindow trans = new transaksiWindow();
            this.Hide();
            trans.ShowDialog();
            this.Close();
        }

        private void menuLaporan_Click(object sender, RoutedEventArgs e)
        {
            menuLaporan laporan = new menuLaporan();
            this.Hide();
            laporan.ShowDialog();
            this.Close();
        }

        private void masterMenu_Click(object sender, RoutedEventArgs e)
        {
            masterMenu menu = new masterMenu();
            this.Hide();
            menu.ShowDialog();
            this.Close();
        }

        private void btRegis_Click(object sender, RoutedEventArgs e)
        {
            if(tbNama.Text == "" || tbUser.Text == "" ||passBox.Password == ""|| radiobutton != true)
            {
                MessageBox.Show("Pastikan Seluruh Data telah Diisi!");
            }
            else
            {
                int jabatan = 0;
                if (rbManager.IsChecked == true)
                {
                    jabatan = 1;
                }else if(rbKoki.IsChecked == true)
                {
                    jabatan = 2;
                }else if(rbPelayan.IsChecked == true)
                {
                    jabatan = 3;
                }else if(rbKasir.IsChecked == true)
                {
                    jabatan = 4;
                }
                conn.Open();
                query = $"insert into karyawan values(0,{jabatan},'{tbUser.Text}','{passBox.Password}','{tbNama.Text}',sysdate)";
                
                cmd = new OracleCommand(query, conn);
                cmd.ExecuteNonQuery();
                da.Update(dt);
                dgKaryawan.ItemsSource = dt.DefaultView;
                radiobutton = false;
                conn.Close();
            }
        }

        private void dgKaryawan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgKaryawan.Columns[0].Width = 30;
            dgKaryawan.Columns[1].Width = DataGridLength.Auto;
            dgKaryawan.Columns[2].Width = DataGridLength.Auto;
            dgKaryawan.Columns[3].Width = DataGridLength.Auto;
            dgKaryawan.Columns[4].Width = DataGridLength.Auto;
        }

        private void rbManager_Checked(object sender, RoutedEventArgs e)
        {
            radiobutton = true;
        }

        private void rbKoki_Checked(object sender, RoutedEventArgs e)
        {
            radiobutton = true;
        }

        private void rbPelayan_Checked(object sender, RoutedEventArgs e)
        {
            radiobutton = true;
        }

        private void rbKasir_Checked(object sender, RoutedEventArgs e)
        {
            radiobutton = true;
        }
    }
}
