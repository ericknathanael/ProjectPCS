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
        
        List<Menu> listPesanan;
        List<Meja> listMeja;
        string query;
        string kode;
        int noMeja = -1;

        public transaksiWindow()
        {
            InitializeComponent();
            listMeja = new List<Meja>();
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
                    if(pesanan.namaMenu == temp[1].ToString())
                    {
                        pesanan.tambahMenu();
                        kembar = true;
                        break;
                    }
                }
                if (!kembar)
                {
                    listPesanan.Add(new Menu(listPesanan.Count + 1,temp[0].ToString(),temp[1].ToString(),Convert.ToInt32(temp[2].ToString()),Convert.ToInt32(temp[3].ToString()),1));
                }
                
                dgTrans.ItemsSource = null;
                dgTrans.ItemsSource = listPesanan;
                MessageBox.Show(listPesanan.Count + "");
            }
        }

        private void cbMeja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if(listPesanan != null)
            {
                ComboBoxItem tmp = (ComboBoxItem)cbMeja.SelectedItem;
                noMeja = Convert.ToInt32(tmp.Name.Substring(1));
                listPesanan = listMeja[noMeja].Pesanan;
            }
            
            //apabila meja dipilih dilihat terlebih dahulu apakah meja tersebut sudah dibooking atau belum, apabila sudah dibooking maka ia akan mengisi ID pelanggan
        }

        private void btCari_Click(object sender, RoutedEventArgs e)
        {
            tableMenu = new DataTable();
            conn.Open();
            string namamenu = tbNama.Text;
            //query = $"select m.kode_menu,m.Nama_Menu,m.harga,m.diskon from menu m where status != 0 and m.namamenu like '{namamenu}%'";
            cmd = new OracleCommand(query, conn);
            //cmd.ExecuteNonQuery();
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
            query = "select m.kode_menu,m.Nama_Menu,m.harga,m.diskon from menu m where status != 0";
            cmd = new OracleCommand(query, conn);
            cmd.ExecuteNonQuery();
            da = new OracleDataAdapter(cmd);
            da.Fill(tableMenu);
            dgMenu.ItemsSource = null;
            dgMenu.Items.Clear();
            dgMenu.ItemsSource = tableMenu.DefaultView;
            conn.Close();
        }

        private void btHapus_Click(object sender, RoutedEventArgs e)
        {
            listPesanan.RemoveAt(dgTrans.SelectedIndex);
            if(noMeja != -1)
            {
                listMeja[noMeja].Pesanan = listPesanan;
            }

        }

        private void btBayar_Click(object sender, RoutedEventArgs e)
        {
            //kurang print bill / nota pembayaran
            conn.Open();
            using(OracleTransaction tr = conn.BeginTransaction())
            {
                cmd.Transaction = tr;
                try
                {
                    ComboBoxItem temp;
                    string nota = lbNota.Content.ToString();
                    string nama;
                    string metode;
                    string idPelanggan = lbPelanggan.Content.ToString();
                    int idMeja;
                    int total;
                    int potongan;
                    int setelahDipotong;

                    temp = (ComboBoxItem)cbMeja.SelectedItem;
                    idMeja = Convert.ToInt32(temp.Name.Substring(1));
                    
                    nama = loginWindow.name;
                    
                    temp = (ComboBoxItem)cbMetode.SelectedItem;
                    metode = temp.Name;

                    setelahDipotong = Convert.ToInt32(lbTotal.Content.ToString());
                    potongan = listMeja[noMeja].totalPotongan();
                    total = listMeja[noMeja].totalKotor();
                    
                    if(idPelanggan == "")
                    {
                        idPelanggan = "null";
                    }


                    query = $"insert into transaksi values('{nota}',{idPelanggan},{idMeja},'{nama}','{metode}',{total},{potongan},{setelahDipotong},sysdate)";
                    cmd = new OracleCommand(query,conn);
                    cmd.ExecuteNonQuery();
                    query = $"select count(id) + 1 from d_transaksi";
                    cmd = new OracleCommand(query, conn);
                    int id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    foreach (Menu item in listMeja[noMeja].Pesanan)
                    {
                        query = $"insert into d_transaksi values({id},{item.ID},'{item.namaMenu}','{item.jumlah}',{item.harga},{item.potongan()},{item.hargaTotal})";
                        id++;
                    }
                }
                catch (Exception ex)
                {
                    tr.Rollback();

                    MessageBox.Show(ex.Message);
                    MessageBox.Show("Transaksi Gagal");
                }
            }
            conn.Close();
        }
    }
}
