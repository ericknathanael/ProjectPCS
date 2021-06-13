using System;
using System.Data;
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
    /// Interaction logic for regisCustWindow.xaml
    /// </summary>
    public partial class regisCustWindow : Window
    {
        OracleConnection conn;
        OracleCommandBuilder builder; 
        OracleCommand cmd;
        DataTable dt;
        OracleDataAdapter da;
        Karyawan karyawan;

        string query;
        string id;
        string nama;
        string alamat;
        string notelp;

        static int indexDataGrid = -1;
        
        public regisCustWindow()
        {
            InitializeComponent();
            conn = MainWindow.conn;
            karyawan = loginWindow.karyawan;
            if (karyawan.id_jabatan == 4)
            {
                this.formCustomer.Visibility = Visibility.Hidden;
            }
            else if (karyawan.id_jabatan == 1)
            {
                this.formCustomer.Visibility = Visibility.Visible;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadData();
        }

        private void dgCust_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            indexDataGrid = dgCust.SelectedIndex;
            id = dt.Rows[indexDataGrid][0].ToString();
            nama = dt.Rows[indexDataGrid][1].ToString();
            alamat = dt.Rows[indexDataGrid][2].ToString();
            notelp = dt.Rows[indexDataGrid][3].ToString();

            lbId.Content = id;
            tbNama.Text = nama;
            tbAlamat.Text = alamat;
            tbTelp.Text = notelp;

            btInsert.IsEnabled = false;
            btDelete.IsEnabled = true;
            btUpdate.IsEnabled = true;
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            if(tbSearch.Text != "")
            {
                loadData(tbSearch.Text);
            }
            else
            {
                MessageBox.Show("Masukkan nama terlebih dahulu!");
            }
        }


        private void btInsert_Click(object sender, RoutedEventArgs e)
        {
            if(tbAlamat.Text == "" || tbNama.Text == "" || tbTelp.Text == "")
            {
                MessageBox.Show("field masih ada yang belum terisi");
            }
            else
            {
                try
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = lbId.Content.ToString();
                    dr[1] = tbNama.Text.ToString().ToUpper();
                    dr[2] = tbAlamat.Text.ToUpper();
                    dr[3] = tbTelp.Text.ToUpper();
                    dt.Rows.Add(dr);
                    da.Update(dt);
                    MessageBox.Show("berhasil Insert");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            resetState();
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (tbAlamat.Text == "" || tbNama.Text == "" || tbTelp.Text == "")
            {
                MessageBox.Show("field masih ada yang belum terisi");
            }
            else
            {
                try
                {
                    DataRow dr = dt.NewRow();
                    dt.Rows[indexDataGrid][0] = lbId.Content.ToString();
                    dt.Rows[indexDataGrid][1] = tbNama.Text.ToString().ToUpper();
                    dt.Rows[indexDataGrid][2] = tbAlamat.Text.ToUpper();
                    dt.Rows[indexDataGrid][3] = tbTelp.Text.ToUpper();
                    da.Update(dt);
                    MessageBox.Show("berhasil Update");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            resetState();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dt.Rows[indexDataGrid].Delete();
                da.Update(dt);
                MessageBox.Show("Berhasil Delete");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            resetState();
        }

        private void btClear_Click(object sender, RoutedEventArgs e)
        {
            resetState();
        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            loadData();
            tbSearch.Text = "";
        }

        public void generateId()
        {
            conn.Open();
            query = $"select max(id) + 1 from pelanggan";
            cmd = new OracleCommand(query, conn);
            lbId.Content = cmd.ExecuteScalar().ToString();
            conn.Close();
        }
        public void loadData()
        {
            query = "select * from pelanggan";
            da = new OracleDataAdapter(query, conn);
            builder = new OracleCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dgCust.ItemsSource = dt.DefaultView;
            generateId();
        }

        public void loadData(string search)
        {
            query = $"select * from pelanggan where nama_pelanggan like '%{search.ToUpper()}%'";
            da = new OracleDataAdapter(query, conn);
            builder = new OracleCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dgCust.ItemsSource = dt.DefaultView;
        }

        public void resetState()
        {
            indexDataGrid = -1;
            tbAlamat.Text = "";
            tbNama.Text = "";
            tbTelp.Text = "";

            btInsert.IsEnabled = true;
            btDelete.IsEnabled = false;
            btUpdate.IsEnabled = false;
            generateId();
        }
    }
}
