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

        OracleDataAdapter daMaster;
        DataTable masterKaryawan;

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
            dt = new DataTable();
            da.Fill(dt);
            dgKaryawan.ItemsSource = dt.DefaultView;

            query = "select * from karyawan";
            daMaster = new OracleDataAdapter(query, conn);
            builder = new OracleCommandBuilder(daMaster);
            masterKaryawan = new DataTable();
            daMaster.Fill(masterKaryawan);

            tbNama.Text = "";
            tbUser.Text = "";
            passBox.Text = "";
            rbKasir.IsChecked = false;
            rbKoki.IsChecked = false;
            rbPelayan.IsChecked = false;
            rbManager.IsChecked = false;
            radiobutton = false;

            //dgKaryawan.Columns[0].Width = 30;
        }

        private void btRegis_Click(object sender, RoutedEventArgs e)
        {
            if(tbNama.Text == "" || tbUser.Text == "" ||passBox.Text == ""|| radiobutton != true)
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

                try
                {
                    DataRow dr = masterKaryawan.NewRow();
                    dr[0] = generateID();
                    dr[1] = jabatan;
                    dr[2] = tbUser.Text.ToUpper();
                    dr[3] = passBox.Text;
                    dr[4] = tbNama.Text;
                    dr[5] = DateTime.Now.ToString();
                    masterKaryawan.Rows.Add(dr);
                    MessageBox.Show("Berhasil Insert");
                    daMaster.Update(masterKaryawan);
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
                loadData();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgKaryawan.Columns[0].Width = 30;
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
            masterKaryawan.Rows[index][2] = tbUser.Text;
            masterKaryawan.Rows[index][4] = tbNama.Text;
            try
            {
                daMaster.Update(masterKaryawan);
                MessageBox.Show("update berhasil");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            tbNama.Text = "";
            tbUser.Text = "";
            passBox.Text = "";
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
            masterKaryawan.Rows[index].Delete();
            daMaster.Update(masterKaryawan);

            tbNama.Text = "";
            tbUser.Text = "";
            passBox.Text = "";
            rbKasir.IsChecked = false;
            rbManager.IsChecked = false;
            rbKoki.IsChecked = false;
            rbPelayan.IsChecked = false;

            btUpdate.IsEnabled = false;
            btDelete.IsEnabled = false;
            btRegis.IsEnabled = true;
            loadData();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ManagerWindow home = new ManagerWindow();
            this.Hide();
            home.ShowDialog();
            this.Close();
        }

        private int generateID()
        {
            int id = 0;
            query = $"select count(ID) + 1 from karyawan";
            OracleCommand cmd = new OracleCommand(query, conn);
            id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            return id;
        }

        private void dgKaryawan_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgKaryawan.SelectedIndex != -1)
            {

                DataRow dr = masterKaryawan.Rows[dgKaryawan.SelectedIndex];
                tbNama.Text = dr[4].ToString();
                tbUser.Text = dr[2].ToString();
                passBox.Text = dr[3].ToString();

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
    }
}
