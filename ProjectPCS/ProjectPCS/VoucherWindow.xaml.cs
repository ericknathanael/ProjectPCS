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
    /// Interaction logic for VoucherWindow.xaml
    /// </summary>
    public partial class VoucherWindow : Window
    {
        OracleConnection conn;
        OracleCommandBuilder builder;
        OracleCommand cmd;
        OracleDataAdapter da;
        DataTable dt;

        string query;

        static int indexDataGrid;
        int status = -1;

        public VoucherWindow()
        {
            InitializeComponent();
            conn = MainWindow.conn;
        }

        public void generateId()
        {
            conn.Open();
            query = $"select max(id) + 1 from voucher";
            cmd = new OracleCommand(query, conn);
            lbId.Content = cmd.ExecuteScalar().ToString();
            conn.Close();
        }
        public void loadData()
        {
            query = "select * from voucher";
            da = new OracleDataAdapter(query, conn);
            builder = new OracleCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dgVoucher.ItemsSource = dt.DefaultView;
            generateId();
        }

        public void loadData(string search)
        {
            query = $"select * from voucher where nama like '%{search.ToUpper()}%'";
            da = new OracleDataAdapter(query, conn);
            builder = new OracleCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dgVoucher.ItemsSource = dt.DefaultView;
        }

        public void resetState()
        {
            indexDataGrid = -1;
            tbNama.Text = "";
            tbDiskon.Text = "";
            status = -1;
            btInsert.IsEnabled = true;
            btDelete.IsEnabled = false;
            btUpdate.IsEnabled = false;
            generateId();
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            loadData(tbSearch.Text);
        }

        private void btInsert_Click(object sender, RoutedEventArgs e)
        {
            if(tbDiskon.Text == "" || tbNama.Text == "" || status == -1)
            {
                MessageBox.Show("Pastikan Seluruh pilihan telah terisi");
            }
            else
            {
                int hasil;
                if (rbAvail.IsChecked == true)
                {
                    status = 1;
                }
                else
                {
                    status = 0;
                }
                try
                {
                    int.TryParse(tbDiskon.Text, out hasil);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                DataRow dr = dt.NewRow();
                dr[0] = lbId.Content;
                dr[1] = tbNama.Text;
                dr[2] = status;
                dr[3] = tbDiskon.Text;
                dt.Rows.Add(dr);
                da.Update(dt);
            }
            resetState();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadData();
            if(lbId.Content == "")
            {
                lbId.Content = "1";
            }
        }

        private void dgVoucher_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            indexDataGrid = dgVoucher.SelectedIndex;

            lbId.Content = dt.Rows[indexDataGrid][0].ToString();
            tbDiskon.Text = dt.Rows[indexDataGrid][3].ToString();
            tbNama.Text = dt.Rows[indexDataGrid][1].ToString();
            status = Convert.ToInt32(dt.Rows[indexDataGrid][2].ToString());
            
            if(status == 1)
            {
                rbAvail.IsChecked = true;
            }
            else
            {
                rbExp.IsChecked = true;
            }
            btInsert.IsEnabled = false;
            btDelete.IsEnabled = true;
            btUpdate.IsEnabled = true;
        }

        private void btClear_Click(object sender, RoutedEventArgs e)
        {
            resetState();
        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            loadData();
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbDiskon.Text == "" || tbNama.Text == "" || status == -1)
                {
                    MessageBox.Show("Pastikan Seluruh pilihan telah terisi");
                }
                else
                {
                    int hasil;
                    if (rbAvail.IsChecked == true)
                    {
                        status = 1;
                    }
                    else
                    {
                        status = 0;
                    }
                    try
                    {
                        int.TryParse(tbDiskon.Text, out hasil);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    DataRow dr = dt.NewRow();
                    dt.Rows[indexDataGrid][0] = lbId.Content;
                    dt.Rows[indexDataGrid][1] = tbNama.Text;
                    dt.Rows[indexDataGrid][2] = status;
                    dt.Rows[indexDataGrid][3] = tbDiskon.Text;
                    da.Update(dt);
                }
                resetState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void rbAvail_Checked(object sender, RoutedEventArgs e)
        {
            status = 1;
        }

        private void rbExp_Checked(object sender, RoutedEventArgs e)
        {
            status = 0;
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            if(indexDataGrid != -1)
            {
                dt.Rows[indexDataGrid].Delete();
                da.Update(dt);
                resetState();
            }
            
        }
    }
}
