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
        Karyawan karyawan;

        List<Menu> listPesanan;
        List<Meja> listMeja;
        string query;
        string kode;

        string tanggal;
        string nama;

        int jumlah = 0;
        int noMeja = -1;
        int index = -1;

        public transaksiWindow()
        {
            InitializeComponent();
            listPesanan = new List<Menu>();
            listMeja = new List<Meja>();
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.dateText.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            }, this.Dispatcher);
            conn = MainWindow.conn;
            karyawan = loginWindow.karyawan;
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
                if(tbNama.Text == "" || tbJumlah.Text == "")
                {
                    MessageBox.Show("Pastikan Seluruh Isian Telah terisi dengan benar");
                }
                else
                {
                    int result;
                    try
                    {
                        if (Int32.TryParse(tbJumlah.Text, out result)) 
                        {
                            DataRow temp = tableMenu.Rows[dgMenu.SelectedIndex];
                            bool kembar = false;
                            foreach (Menu pesanan in listPesanan)
                            {
                                if (pesanan.kode == tbNama.Text)
                                {
                                    pesanan.tambahMenu(result);
                                    kembar = true;
                                    break;
                                }
                            }
                            if (!kembar)
                            {
                                listPesanan.Add(new Menu(listPesanan.Count + 1, temp[0].ToString(), temp[1].ToString(), Convert.ToInt32(temp[2].ToString()), Convert.ToInt32(temp[3].ToString()), Convert.ToInt32(tbJumlah.Text)));
                            }
                            lbTotal.Content = countTotal();
                            dgTrans.ItemsSource = null;
                            dgTrans.ItemsSource = listPesanan;
                        }
                        else
                        {
                            MessageBox.Show("Jumlah harus diisi dengan angka");
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            tbJumlah.Text = "";
            tbNama.Text = "";
        }

       

        private void btCari_Click(object sender, RoutedEventArgs e)
        {
            tableMenu = new DataTable();
            conn.Open();
            string kodeMenu = tbNama.Text;
            query = $"select m.kode_menu,m.Nama_Menu,m.harga,m.diskon from menu m where status != 0 and m.kode_menu like '{kodeMenu.ToUpper()}%'";
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

        public string countTotal()
        {
            int total = 0;
            foreach (Menu item in listPesanan)
            {
                total += item.hargaTotal;
            }
            return total.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgMenu.Columns[1].Width = DataGridLength.Auto;


        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            isiMenu();
            tbNama.Text = "";
            tbJumlah.Text = "";
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
            dgTrans.ItemsSource = null;
            listPesanan.Clear();
            listPesanan = new List<Menu>();
            dgTrans.ItemsSource = listPesanan;
            lbTotal.Content = "0";
        }

        private void btBayar_Click(object sender, RoutedEventArgs e)
        {
            //kurang print bill / nota pembayaran + pengecekan tidak ada dsb
            conn.Open();
            using(OracleTransaction tr = conn.BeginTransaction())
            {
                cmd.Transaction = tr;
                if(cbMetode.SelectedIndex == -1 || listPesanan.Count < 1 || tbMeja.Text == "")
                {
                    MessageBox.Show("Error silahkan coba lagi");
                }
                else
                {
                    try
                    {
                        bool flag = true;
                        ComboBoxItem temp;
                        string nota = lbNota.Content.ToString();
                        //string nama;
                        string metode;
                        string idPelanggan = lbPelanggan.Content.ToString();
                        int idMeja;
                        int total;
                        int potongan;
                        int setelahDipotong;

                        flag = int.TryParse(tbMeja.Text.ToString(), out idMeja);

                        temp = (ComboBoxItem)cbMetode.SelectedItem;
                        metode = temp.Name;

                        setelahDipotong = Convert.ToInt32(lbTotal.Content.ToString());
                        potongan = totalPotongan();
                        total = totalKotor();

                        if (idPelanggan == "")
                        {
                            idPelanggan = "null";
                        }

                        query = $"insert into transaksi values(0,'{nota}',{idPelanggan},{idMeja},'{karyawan.nama}'," +
                            $"'{metode}',{total},{potongan},{setelahDipotong},sysdate)";
                        cmd = new OracleCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        query = $"select max(id) from transaksi";
                        cmd = new OracleCommand(query, conn);
                        int id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                        foreach (Menu item in listPesanan)
                        {
                            query = $"insert into d_transaksi values({id},{item.ID},{item.jumlah})";
                            cmd.CommandText = query;
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Transaksi Berhasil");
                        tr.Commit();

                        notaWindow notaPembayaran = new notaWindow(nota);
                        notaPembayaran.ShowDialog();


                    }
                    catch (Exception ex)
                    {
                        tr.Rollback();
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("Transaksi Gagal");
                    }
                }
                
            }
            conn.Close();
        }

        public int totalPotongan()
        {
            int total = 0;
            foreach (Menu pesan in listPesanan)
            {
                total += pesan.potongan();
            }
            return total;
        }

        public int totalKotor()
        {
            int total = 0;
            foreach (Menu menu in listPesanan)
            {
                total += menu.harga;
            }
            return total;
        }

        private void picHome_MouseDown(object sender, MouseButtonEventArgs e)
        {
            KasirWindow kasir = new KasirWindow();
            this.Hide();
            kasir.ShowDialog();
            this.Close();
        }

        private void dgMenu_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgMenu.SelectedIndex != -1)
            {
                tbNama.Text = tableMenu.Rows[dgMenu.SelectedIndex][0].ToString();
                tbJumlah.Text = 1 + "";
            }
        }

        private void btReservasi_Click(object sender, RoutedEventArgs e)
        {
            popupReserveWindow popup = new popupReserveWindow();
            popup.ShowDialog();
            lbPelanggan.Content = popup.nama;
            tbMeja.Text = popup.idMeja;
            nama = popup.nama;
            tanggal = popup.tanggal;
            MessageBox.Show(tanggal);
        }

        private void btHpsData_Click(object sender, RoutedEventArgs e)
        {
            lbNota.Content = "";
            lbPelanggan.Content = "";
            tbMeja.Text = "";
            cbMetode.SelectedIndex = -1;
        }

        private void dgTrans_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int index = dgTrans.SelectedIndex;
            dgTrans.ItemsSource = null;
            listPesanan.RemoveAt(index);
            dgTrans.ItemsSource = listPesanan;
            lbTotal.Content = countTotal();
        }
    }
}
