using System;
using System.Collections.Generic;
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
        OracleCommand cmd;
        //OracleCommandBuilder builder;
        OracleDataAdapter da;
        DataTable dt;

        //OracleDataAdapter daMaster;
        //DataTable masterKaryawan;

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
            conn.Open();
            //query = "select id,username,nama_karyawan,tgl_daftar from karyawan";
            query = "select k.username,k.nama_karyawan,j.nama_jabatan,k.tgl_daftar from karyawan k join jabatan j on k.id_jabatan=j.id";
            da = new OracleDataAdapter(query, conn);
            dt = new DataTable();
            da.Fill(dt);
            dgKaryawan.ItemsSource = dt.DefaultView;

            //query = "select * from karyawan";
            //daMaster = new OracleDataAdapter(query, conn);
            //builder = new OracleCommandBuilder(daMaster);
            //masterKaryawan = new DataTable();
            //daMaster.Fill(masterKaryawan);

            conn.Close();

            index = -1;
            tbNama.Text = "";
            tbUser.Text = "";
            passBox.Text = "";
            rbKasir.IsChecked = false;
            rbKoki.IsChecked = false;
            rbPelayan.IsChecked = false;
            rbManajer.IsChecked = false;
            radiobutton = false;
            btUpdate.IsEnabled = false;
            btDelete.IsEnabled = false;
            btRegis.IsEnabled = true;

            //dgKaryawan.Columns[0].Width = 30;
        }

        private void btRegis_Click(object sender, RoutedEventArgs e)
        {
            if (tbNama.Text == "" || tbUser.Text == "" || passBox.Text == "" || radiobutton != true)
            {
                MessageBox.Show("Pastikan Seluruh Data telah Diisi!");
            }
            else
            {
                int jabatan = 0;
                if (rbManajer.IsChecked == true)
                {
                    jabatan = 1;
                }
                else if (rbKoki.IsChecked == true)
                {
                    jabatan = 2;
                }
                else if (rbPelayan.IsChecked == true)
                {
                    jabatan = 3;
                }
                else if (rbKasir.IsChecked == true)
                {
                    jabatan = 4;
                }
                conn.Open();
                query = $"select username from karyawan where username = '{tbUser.Text.ToUpper()}'";
                cmd = new OracleCommand(query, conn);
                if (cmd.ExecuteScalar() == null)
                {
                    try
                    {
                        query = $"insert into karyawan values({generateID()},{jabatan},'{tbUser.Text}','{passBox.Text}','{tbNama.Text}',sysdate)";
                        cmd = new OracleCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        //DataRow dr = masterKaryawan.NewRow();
                        //dr[0] = generateID();
                        //dr[1] = jabatan;
                        //dr[2] = tbUser.Text.ToUpper();
                        //dr[3] = passBox.Text;
                        //dr[4] = tbNama.Text;
                        //dr[5] = DateTime.Now.ToString();
                        //masterKaryawan.Rows.Add(dr);
                        MessageBox.Show("Berhasil Insert");
                        //daMaster.Update(masterKaryawan);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        conn.Close();
                    }
                    loadData();
                }
                else
                {
                    MessageBox.Show("Username telah dimiliki oleh karyawan lain");
                    conn.Close();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //dgKaryawan.Columns[0].Width = 30;
        }

        private void rbManajer_Checked(object sender, RoutedEventArgs e)
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
            //masterKaryawan.Rows[index][1] = jabatan;
            //masterKaryawan.Rows[index][2] = tbUser.Text;
            //masterKaryawan.Rows[index][3] = passBox.Text;
            //masterKaryawan.Rows[index][4] = tbNama.Text;
            //daMaster.Update(masterKaryawan);

            if (index < 0)
            {
                MessageBox.Show("Silahkan memilih data untuk di Update");
            }
            else
            {
                conn.Open();
                try
                {
                    query = $"update karyawan set nama_karyawan = '{tbNama.Text}', username = '{tbUser.Text}' where username = '{dt.Rows[index][0]}'";
                    cmd = new OracleCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Berhasil Update");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
                loadData();
            }
            //try
            //{
            //    daMaster.Update(masterKaryawan);
            //    MessageBox.Show("Berhasil Update");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            //masterKaryawan.Rows[index].Delete();
            //daMaster.Update(masterKaryawan);
            if (index < 0)
            {
                MessageBox.Show("Silahkan memilih data untuk di Delete");
            }
            else
            {
                try
                {
                    conn.Open();
                    query = $"delete from karyawan where username = '{dt.Rows[index][0]}'";
                    cmd = new OracleCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Berhasil Delete");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
                loadData();
            }
        }

        private void Home_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ManagerWindow home = new ManagerWindow();
            this.Hide();
            home.ShowDialog();
            this.Close();
        }

        private int generateID()
        {
            query = $"select max(ID) + 1 from karyawan";
            OracleCommand cmd = new OracleCommand(query, conn);
            return Convert.ToInt32(cmd.ExecuteScalar().ToString());
        }

        private void dgKaryawan_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgKaryawan.SelectedIndex != -1)
            {
                //DataRow dr = masterKaryawan.Rows[dgKaryawan.SelectedIndex];
                DataRow dr = dt.Rows[dgKaryawan.SelectedIndex];
                tbNama.Text = dr[1].ToString();
                tbUser.Text = dr[0].ToString();
                conn.Open();
                query = $"select pass from karyawan where username = '{dr[0].ToString()}'";
                cmd = new OracleCommand(query, conn);
                passBox.Text = cmd.ExecuteScalar().ToString();
                conn.Close();
                if (dr[2].ToString().Equals(rbManajer.Content.ToString().ToUpper()))
                {
                    rbManajer.IsChecked = true;
                }
                else if (dr[2].ToString().Equals(rbKoki.Content.ToString().ToUpper()))
                {
                    rbKoki.IsChecked = true;
                }
                else if (dr[2].ToString().Equals(rbPelayan.Content.ToString().ToUpper()))
                {
                    rbPelayan.IsChecked = true;
                }
                else if (dr[2].ToString().Equals(rbKasir.Content.ToString().ToUpper()))
                {
                    rbKasir.IsChecked = true;
                }
                //tbNama.Text = dr[4].ToString();
                //tbUser.Text = dr[2].ToString();
                //passBox.Text = dr[3].ToString();

                //if (dr[1].ToString() == "1")
                //{
                //    rbManager.IsChecked = true;
                //}
                //else if (dr[1].ToString() == "2")
                //{
                //    rbKoki.IsChecked = true;
                //}
                //else if (dr[1].ToString() == "3")
                //{
                //    rbPelayan.IsChecked = true;
                //}
                //else if (dr[1].ToString() == "4")
                //{
                //    rbKasir.IsChecked = true;
                //}
                rbManajer.IsEnabled = false;
                rbKoki.IsEnabled = false;
                rbPelayan.IsEnabled = false;
                rbKasir.IsEnabled = false;
                passBox.IsEnabled = false;

                btDelete.IsEnabled = true;
                btUpdate.IsEnabled = true;
                btRegis.IsEnabled = false;
                index = dgKaryawan.SelectedIndex;
            }

        }

        private void DgKaryawan_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            DataGridTextColumn dgColumn = e.Column as DataGridTextColumn;
            if (dgColumn != null && e.PropertyType == typeof(DateTime))
            {
                dgColumn.Binding = new Binding(e.PropertyName)
                {
                    StringFormat = "dd MMMM yyyy",
                    ConverterCulture = CultureInfo.GetCultureInfo("id-ID")
                };
            }
        }

        
    }
}
