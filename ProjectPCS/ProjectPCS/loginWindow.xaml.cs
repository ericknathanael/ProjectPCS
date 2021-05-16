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
        public static string user;
        public static string pass;
        public static string source;
        public loginWindow()
        {
            InitializeComponent();
            conn = MainWindow.conn;
        }

        private void btRegis_Click(object sender, RoutedEventArgs e)
        {

            //registerWindow menu = new registerWindow();
            this.Close();
            //menu.ShowDialog();
            this.Hide();
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                user = tbUser.Text;
                pass = tbPass.Text;
                source = tbSource.Text;
                conn = new OracleConnection($"User ID={user};password ={pass};Data Source={source}");
                menuWindow menu = new menuWindow();
                this.Hide();
                menu.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
