
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPCS
{
    class Menu
    {
        public int id { get; set; }
        public string jenisMenu { get; set; }
        public string kode { get; set; }
        public string namaMenu { get; set; }
        
        public int status { get; set; }
        public int harga { get; set; }
        public int diskon { get; set; }
        public int hargaTotal { get; set; }
        public int jumlah { get; set; }

        public Menu(int id, string namaJenis, string kode, string namaMenu, int status, int harga, int diskon,int jumlah)
        {
            this.id = id;
            this.jenisMenu = namaJenis;
            this.kode = kode;
            this.namaMenu = namaMenu;
            this.status = status;
            this.harga = harga;
            this.diskon = diskon;
            this.hargaTotal = harga - harga * (diskon / 100);
            this.jumlah = jumlah;
        }
        public void tambahMenu()
        {
            jumlah++;
            hargaTotal = harga - harga * (diskon / 100);
        }
        public string query(string nota)
        {
            string query;
            query = $"insert into d_transaksi values({id},{nota},{namaMenu},{jumlah},{hargaTotal})";
            return query;
        }
    }
}
