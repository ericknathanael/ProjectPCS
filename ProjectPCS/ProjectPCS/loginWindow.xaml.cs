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
using Oracle.DataAccess.Client;

namespace ProjectPCS
{
    /// <summary>
    /// Interaction logic for loginWindow.xaml
    /// </summary>
    public partial class loginWindow : Window
    {
        public static OracleConnection conn;
        public static Karyawan karyawan;
        public OracleCommand cmd;
        public OracleDataReader dr;        
        //public static string user;
        //public static string name;
        //public static string pass;
        //public static string source;

        public loginWindow()
        {
            InitializeComponent();
            conn = MainWindow.conn;
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            if (tbUser.Text.Length <= 0 && tbPass.Text.Length <= 0)
            {
                MessageBox.Show("username dan password karyawan tidak boleh kosong");
            }
            else if (tbUser.Text.Length <= 0)
            {
                MessageBox.Show("username karyawan tidak boleh kosong");
            }
            else if (tbPass.Text.Length <= 0)
            {
                MessageBox.Show("password karyawan tidak boleh kosong");
            }
            else
            {
                try
                {
                    conn.Open();
                    //user = tbUser.Text;
                    //pass = tbPass.Text;
                    string query = $"select id from karyawan where username = '{tbUser.Text.ToUpper()}'";
                    cmd = new OracleCommand(query, conn);
                    dr = cmd.ExecuteReader();                    
                    if (!dr.HasRows)
                    {
                        MessageBox.Show("username karyawan tidak terdaftar");
                        dr.Close();
                        conn.Close();
                    }
                    else
                    {
                        dr.Close();
                        query = $"select * from karyawan where username = '{tbUser.Text.ToUpper()}' and pass = '{tbPass.Text}'";
                        cmd = new OracleCommand(query, conn);
                        dr = cmd.ExecuteReader();
                        if (!dr.HasRows)
                        {
                            MessageBox.Show("password karyawan salah");
                        }
                        else
                        {
                            while (dr.Read())
                            {
                                karyawan = new Karyawan(int.Parse(dr[0].ToString()), int.Parse(dr[1].ToString()), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
                            }
                            dr.Close();
                            conn.Close();
                            Window window = null;
                            if (karyawan.id_jabatan == 1)
                            {
                                // apabila masuk ke menu manager(Register karyawan, tambah menu, update absensi)
                                window = new ManagerWindow();
                            }
                            else if (karyawan.id_jabatan == 4)
                            {
                                // apabila masuk ke menu kasir(transaksi reservation, print nota)                                
                                window = new KasirWindow();
                            }
                            else
                            {
                                window = new absensiWindow();
                            }
                            this.Hide();
                            window.ShowDialog();
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    dr.Close();
                    conn.Close();
                }
            }
            
        }

        //private string namaUser()
        //{
        //    string nama = "";
        //    conn.Open();
        //    string query = $"select nama_karyawan from karyawan where username = '{user.ToUpper()}' and pass = '{pass}'";
        //    cmd = new OracleCommand(query, conn);
        //    name = cmd.ExecuteScalar().ToString();
        //    MessageBox.Show(name);
        //    conn.Close();
     
        //    menuWindow menu = new menuWindow();
        //    this.Hide();
        //    menu.ShowDialog();
        //    this.Close();
        //    return nama;
        //}
    }
}
