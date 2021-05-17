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
using System.Windows.Threading;

namespace ProjectPCS
{
    /// <summary>
    /// Interaction logic for transaksiWindow.xaml
    /// </summary>
    public partial class transaksiWindow : Window
    {
        OracleConnection conn;
        OracleCommand cmd; //menu 
        OracleCommandBuilder builder;
        OracleDataAdapter da;
        OracleDataReader dr;
        DataTable tableMenu;
        DataTable tableTrans;
        
        List<Menu> listPesanan;
        string query;
        string kode;

        public transaksiWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.dateText.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            }, this.Dispatcher);
            conn = MainWindow.conn;
            tableMenu = new DataTable();
            da = new OracleDataAdapter();
            
            lbNota.Content = create_nota();

            cbMetode.Items.Add(new ComboBoxItem() { 
                Name= "CASH",
                Content = "Cash"
            });
            cbMetode.Items.Add(new ComboBoxItem()
            {
                Name = "OVO",
                Content = "Ovo"
            });
            cbMetode.Items.Add(new ComboBoxItem()
            {
                Name = "GOPAY",
                Content = "GoPay"
            });
            cbMetode.Items.Add(new ComboBoxItem()
            {
                Name = "SHOPEEPAY",
                Content = "ShopeePay"
            });

            cbMeja.Items.Add(new ComboBoxItem()
            {
                Name = "M1",
                Content = "Meja 1"
            });
            cbMeja.Items.Add(new ComboBoxItem()
            {
                Name = "M2",
                Content = "Meja 2"
            });
            cbMeja.Items.Add(new ComboBoxItem()
            {
                Name = "M3",
                Content = "Meja 3"
            });
            cbMeja.Items.Add(new ComboBoxItem()
            {
                Name = "M4",
                Content = "Meja 4"
            });
            cbMeja.Items.Add(new ComboBoxItem()
            {
                Name = "M5",
                Content = "Meja 5"
            });
            cbMeja.Items.Add(new ComboBoxItem()
            {
                Name = "M6",
                Content = "Meja 6"
            });
            cbMeja.Items.Add(new ComboBoxItem()
            {
                Name = "M7",
                Content = "Meja 7"
            });
            cbMeja.Items.Add(new ComboBoxItem()
            {
                Name = "M8",
                Content = "Meja 8"
            });
            cbMeja.Items.Add(new ComboBoxItem()
            {
                Name = "M9",
                Content = "Meja 9"
            });
            cbMeja.Items.Add(new ComboBoxItem()
            {
                Name = "M10",
                Content = "Meja 10"
            });

            cbMeja.SelectedIndex = 0;
            cbMetode.SelectedIndex = 0;
            listPesanan = new List<Menu>();

            isiMenu();

            tableTrans = new DataTable();
            dgTrans.ItemsSource = listPesanan;
        }

        private void btTambah_Click(object sender, RoutedEventArgs e)
        {
            if(dgMenu.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih Barang yang ingin ditambahkan");
            }
            else
            {
                DataRow temp = tableMenu.Rows[dgMenu.SelectedIndex];
                bool kembar = false;
                foreach(Menu pesanan in listPesanan)
                {
                    if(pesanan.namaMenu == temp[2].ToString())
                    {
                        pesanan.tambahMenu();
                        kembar = true;
                        break;
                    }
                }
                if (!kembar)
                {
                    listPesanan.Add(new Menu(listPesanan.Count + 1,temp[1].ToString(),temp[0].ToString(),temp[2].ToString(),1,Convert.ToInt32(temp[3].ToString()),
                        Convert.ToInt32(temp[4].ToString()),1));
                }
                
                dgTrans.ItemsSource = null;
                dgTrans.ItemsSource = listPesanan;
                MessageBox.Show(listPesanan.Count + "");
            }
        }

        private void cbMeja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //apabila meja dipilih dilihat terlebih dahulu apakah meja tersebut sudah dibooking atau belum, apabila sudah dibooking maka ia akan mengisi ID pelanggan
        }

        private void btCari_Click(object sender, RoutedEventArgs e)
        {
            tableMenu = new DataTable();
            conn.Open();
            query = "select m.kode_menu,jm.nama_jenis,m.Nama_Menu,m.harga,m.diskon from menu m left join jenis_menu jm on jm.id = m.id_jenis_menu where status != 0";
            cmd = new OracleCommand(query, conn);
            cmd.ExecuteNonQuery();
            da = new OracleDataAdapter(cmd);
            da.Fill(tableMenu);
            dgMenu.ItemsSource = tableMenu.DefaultView;
            conn.Close();
        }
        private string create_nota()
        {
            conn.Open();
            string nota;
            cmd = new OracleCommand()
            {
                CommandType = CommandType.StoredProcedure,
                Connection = conn,
                CommandText = "CREATE_NOTA"
            };
            cmd.Parameters.Add(new OracleParameter()
            {
                Direction = ParameterDirection.ReturnValue,
                ParameterName = "nota",
                OracleDbType = OracleDbType.Varchar2,
                Size = 15
            });
            cmd.ExecuteNonQuery();
            nota = Convert.ToString(cmd.Parameters["nota"].Value.ToString());
            conn.Close();

            return nota;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgMenu.Columns[0].Width = DataGridLength.Auto;
            dgMenu.Columns[1].Width = DataGridLength.Auto;
            dgMenu.Columns[2].Width = DataGridLength.Auto;
            dgMenu.Columns[3].Width = DataGridLength.Auto;
            dgMenu.Columns[4].Width = DataGridLength.Auto;
            dgTrans.Columns[0].Width = 30;
            dgTrans.Columns[1].Width = DataGridLength.Auto;
            dgTrans.Columns[2].Width = DataGridLength.Auto;
            dgTrans.Columns[3].Width = DataGridLength.Auto;
            dgTrans.Columns[4].Width = DataGridLength.Auto;
            dgTrans.Columns[5].Width = DataGridLength.Auto;
        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            isiMenu();
        }

        private void isiMenu()
        {
            conn.Open();
            query = "select m.kode_menu,jm.nama_jenis,m.Nama_Menu,m.harga,m.diskon from menu m left join jenis_menu jm on jm.id = m.id_jenis_menu where status != 0";
            
            cmd = new OracleCommand(query, conn);
            cmd.ExecuteNonQuery();
            da = new OracleDataAdapter(cmd);
            da.Fill(tableMenu);
            dgMenu.ItemsSource = null;
            dgMenu.Items.Clear();
            dgMenu.ItemsSource = tableMenu.DefaultView;
            conn.Close();
        }
    }
}
