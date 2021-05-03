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
        OracleConnection conn; 
        public loginWindow()
        {
            InitializeComponent();
            conn = MainWindow.conn;
        }

        private void btRegis_Click(object sender, RoutedEventArgs e)
        {

            registerWindow menu = new registerWindow();
            this.Close();
            menu.ShowDialog();
            this.Hide();
        }
    }
}
