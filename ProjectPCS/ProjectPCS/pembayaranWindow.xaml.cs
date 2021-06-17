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

namespace ProjectPCS
{
    /// <summary>
    /// Interaction logic for pembayaranWindow.xaml
    /// </summary>
    public partial class pembayaranWindow : Window
    {
        public int hasil { get; set; }
        public int harga { get; set; }
        public pembayaranWindow(int bayar)
        {
            InitializeComponent();
            harga = bayar;
        }

        private void btSubmit_Click(object sender, RoutedEventArgs e)
        {
            hasil = 0;
            int test;
            if(int.TryParse(tbBayaran.Text,out test))
            {
                if(harga > test)
                {
                    MessageBox.Show("Nominal tidak mencukupi silahkan masukkan ulang");
                }
                else
                {
                    hasil = test;
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Isi dengan angka");
            }
        }
    }
}
