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
    public partial class registerWindow : Window
    {
        OracleConnection conn;
        OracleCommandBuilder builder;
        OracleDataAdapter da;
        DataTable dt;

        string query;
        int index;
        bool radiobutton;
        public registerWindow()
        {
            InitializeComponent();
            conn = loginWindow.conn;
            loadData();
        }

        private void loadData()
        {
            query = "select id,username,nama_karyawan,tgl_daftar from karyawan";
            da = new OracleDataAdapter(query, conn);
            builder = new OracleCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dgKaryawan.ItemsSource = dt.DefaultView;
        }

        private void btLogout_Click(object sender, RoutedEventArgs e)
        {
            loginWindow login = new loginWindow();
            this.Hide();
            login.ShowDialog();
            this.Close();
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
                //query = $"insert into karyawan values(0,{jabatan},'{tbUser.Text}','{passBox.Password}','{tbNama.Text}',sysdate)";
                DataRow dr = dt.NewRow();
                dr[0] = 0;
                dr[1] = jabatan;
                dr[2] = tbUser.Text.ToUpper();
                dr[3] = passBox.Password;
                dr[4] = tbNama.Text.ToUpper();
                dr[5] = DateTime.Now.ToString();
                dt.Rows.Add(dr);
                da.Update(dt);
                dgKaryawan.ItemsSource = dt.DefaultView;
                radiobutton = false;
                conn.Close();
                loadData();
            }
        }

        private void dgKaryawan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgKaryawan.SelectedIndex != -1)
            {
                
                DataRow dr = dt.Rows[dgKaryawan.SelectedIndex];
                tbNama.Text = dr[4].ToString();
                tbUser.Text = dr[2].ToString();
                passBox.Password = dr[3].ToString();

                if (dr[1].ToString() == "1")
                {
                    rbManager.IsChecked = true;
                }
                else if (dr[1].ToString() == "2")
                {
                    rbKoki.IsChecked = true;
                }
                else if (dr[1].ToString() == "3")
                {
                    rbPelayan.IsChecked = true;
                }
                else if (dr[1].ToString() == "4")
                {
                    rbKasir.IsChecked = true;
                }
                rbManager.IsEnabled = false;
                rbKoki.IsEnabled = false;
                rbPelayan.IsEnabled = false;
                rbKasir.IsEnabled = false;

                btDelete.IsEnabled = true;
                btUpdate.IsEnabled = true;
                btRegis.IsEnabled = false;
                index = dgKaryawan.SelectedIndex;
            }
           
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

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataRow dr = dt.NewRow();
            dr[0] = dt.Rows[index][0].ToString();
            dr[1] = dt.Rows[index][1].ToString();
            dr[2] = tbUser.Text;
            dr[3] = passBox.Password;
            dr[4] = tbNama.Text;
            dr[5] = dt.Rows[index][5].ToString();
            dt.Rows[index].Delete();
            dt.Rows.Add(dr);

            da.Update(dt);

            tbNama.Text = "";
            tbUser.Text = "";
            passBox.Password = "";
            rbKasir.IsChecked = false;
            rbManager.IsChecked = false;
            rbKoki.IsChecked = false;
            rbPelayan.IsChecked = false;

            btUpdate.IsEnabled = false;
            btDelete.IsEnabled = false;
            btRegis.IsEnabled = true;
            loadData();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            dt.Rows[index].Delete();
            da.Update(dt);

            tbNama.Text = "";
            tbUser.Text = "";
            passBox.Password = "";
            rbKasir.IsChecked = false;
            rbManager.IsChecked = false;
            rbKoki.IsChecked = false;
            rbPelayan.IsChecked = false;

            btUpdate.IsEnabled = false;
            btDelete.IsEnabled = false;
            btRegis.IsEnabled = true;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ManagerWindow home = new ManagerWindow();
            this.Hide();
            home.ShowDialog();
            this.Close();
        }
    }
}
