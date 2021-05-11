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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        OracleConnection conn;
        OracleCommand cmd;
        OracleDataAdapter da;
        OracleDataReader dr;
        DataTable dt;

        public static Karyawan loggedIn { get; set; }

        string query;
        string user;
        string pass;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            if(tbPass.Text == "" || tbUser.Text == "")
            {
                MessageBox.Show("Pastikan Username dan Password sudah terisi");
            }
            else
            {
                try
                {
                    loggedIn = null;
                    conn.Open();
                    user = tbUser.Text;
                    pass = tbPass.Text;
                    query = $"select * from karyawan where username = '{user}' and pass = '{pass}'";
                    cmd = new OracleCommand(query, conn);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        loggedIn = new Karyawan(Convert.ToInt32(dr[1].ToString()), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
                        MessageBox.Show($"{loggedIn.username} - {loggedIn.pass}");
                    }
                    conn.Close();
                    if(loggedIn == null)
                    {
                        MessageBox.Show("Username atau password salah");
                    }
                    else
                    {
                        if(loggedIn.id_jabatan == 1)
                        {
                            ManagerWindow menu = new ManagerWindow();
                            this.Hide();
                            menu.ShowDialog();
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("Username atau Password salah");
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            conn = MainWindow.conn;
        }
    }
}
