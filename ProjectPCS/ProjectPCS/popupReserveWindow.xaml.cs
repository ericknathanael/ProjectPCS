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
using System.Data;

namespace ProjectPCS
{
    /// <summary>
    /// Interaction logic for popupReserveWindow.xaml
    /// </summary>
    public partial class popupReserveWindow : Window
    {
        OracleConnection conn;
        OracleCommand cmd;
        OracleDataReader dr;
        OracleDataAdapter da;
        DataTable dt;

        string query;

        public string id { get; set; }
        public string nama { get; set; }
        public string idMeja { get; set; }
        public string tanggal { get; set; }

        public popupReserveWindow()
        {
            InitializeComponent();
            conn = MainWindow.conn;

            query = "select r.id,p.nama_pelanggan,r.id_meja,to_char(r.tgl_waktu_pemesanan,'DD - MM - YYYY') " +
                "from reservation r left join pelanggan p on r.id_pelanggan = p.id";
            loadData(query);    
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgReserve.Columns[1].Width = DataGridLength.Auto;
        }

        private void btFind_Click(object sender, RoutedEventArgs e)
        {
            query = $"select r.id,p.nama_pelanggan,r.id_meja,to_char(r.tgl_waktu_pemesanan,'DD - MM - YYYY') " +
                $"from reservation r left join pelanggan p on r.id_pelanggan = p.id " +
                $"where p.nama_pelanggan like '%{tbNama.Text.ToUpper()}%'";
            loadData(query);
            
        }

        private void loadData(string Query)
        {
            conn.Open();
            
            dt = new DataTable();
            cmd = new OracleCommand(Query, conn);
            cmd.ExecuteReader();
            da = new OracleDataAdapter(cmd);
            da.Fill(dt);
            dgReserve.ItemsSource = dt.DefaultView;

            conn.Close();
        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            query = "select r.id,p.nama_pelanggan,r.id_meja,to_char(r.tgl_waktu_pemesanan,'DD - MM - YYYY') " +
                "from reservation r left join pelanggan p on r.id_pelanggan = p.id";
            loadData(query);
        }

        private void btClear_Click(object sender, RoutedEventArgs e)
        {
            lbID.Content = "";
            lbMeja.Content = "";
            lbNama.Content = "";
            lbTgl.Content = "";
        }

        private void dgReserve_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            DataRow dr = dt.NewRow();
            dr = dt.Rows[dgReserve.SelectedIndex];

            conn.Open();
            id = dr[0].ToString();
            query = $"select id_pelanggan from reservation where id = {id}";
            cmd = new OracleCommand(query, conn);
            id = cmd.ExecuteScalar().ToString();
            conn.Close();
            lbID.Content = dr[0].ToString();

            lbNama.Content = dr[1].ToString();
            nama = lbNama.Content.ToString();
            
            lbMeja.Content = dr[2].ToString();
            idMeja = lbMeja.Content.ToString();
            
            lbTgl.Content = dr[3].ToString();
            tanggal = lbTgl.Content.ToString();
        }

        private void btEnter_Click(object sender, RoutedEventArgs e)
        {
            query = $"select id_pelanggan from reservation where id = {id}";
            cmd = new OracleCommand(query, conn);
            this.Hide();
            this.IsEnabled = false;
        }
    }
}
