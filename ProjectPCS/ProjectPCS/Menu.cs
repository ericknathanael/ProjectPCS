
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPCS
{
    class Menu
    {
        public int ID { get; set; }
        public string kode { get; set; }
        public string namaMenu { get; set; }
        public int harga { get; set; }
        public int diskon { get; set; }
        public int hargaTotal { get; set; }
        public int jumlah { get; set; }

        public Menu(int id, string kode, string namaMenu,int harga, int diskon,int jumlah)
        {
            this.ID = id;
            this.kode = kode;
            this.namaMenu = namaMenu;
            this.harga = harga;
            this.diskon = diskon;
            this.hargaTotal = (harga * jumlah) - (harga * (diskon / 100) * jumlah);
            this.jumlah = jumlah;
        }
        public void tambahMenu()
        {
            jumlah++;
            this.hargaTotal = (harga * jumlah) - (harga * (diskon / 100) * jumlah);
        }
        public string query(string nota)
        {
            string query;
            query = $"insert into d_transaksi values({ID},{nota},{namaMenu},{jumlah},{hargaTotal})";
            return query;
        }
        public int potongan()
        {
            return (harga * (diskon / 100) * jumlah);
        }

    }
}
