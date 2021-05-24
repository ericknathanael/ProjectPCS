using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPCS
{
    class Meja
    {
        public List<Menu> Pesanan { get; set; }
        public int noMeja { get; set; }
        public string waktuMasuk { get; set; }
        public string waktuKeluar { get; set; }

        public Meja(int noMeja)
        {
            Pesanan = new List<Menu>();
            this.noMeja = noMeja;
            this.waktuMasuk = "";
            this.waktuKeluar = "";
        }

        public Meja(int noMeja, string waktuMasuk, string waktuKeluar)
        {
            Pesanan = new List<Menu>();
            this.noMeja = noMeja;
            this.waktuMasuk = waktuMasuk;
            this.waktuKeluar = waktuKeluar;
        }
        public int totalPotongan()
        {
            int total = 0;
            foreach (Menu pesan in Pesanan)
            {
                total += pesan.potongan();
            }
            return total;
        }
        public int totalKotor()
        {
            int total = 0;
            foreach (Menu menu in Pesanan)
            {
                total += menu.harga;
            }
            return total;
        }
    }
}
