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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Oracle.DataAccess.Client;

namespace ProjectPCS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static OracleConnection conn;
        public static string source, userId, pass;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                source = tbSource.Text;
                userId = tbUser.Text;
                pass = tbPass.Text;
                conn = new OracleConnection("Data Source = " + source + "; User ID = " + userId + "; password = " + pass);
                LoginWindow menu = new LoginWindow();
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
