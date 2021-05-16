
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
        public int jenis_menu { get; set; }
        public string kode { get; set; }
        public string namaMenu { get; set; }
        public int status { get; set; }
        public int harga { get; set; }
        public int diskon { get; set; }
        public int hargaTotal { get; set; }

        public Menu(int id, int jenis_menu, string kode, string namaMenu, int status, int harga, int diskon)
        {
            this.id = id;
            this.jenis_menu = jenis_menu;
            this.kode = kode;
            this.namaMenu = namaMenu;
            this.status = status;
            this.harga = harga;
            this.diskon = diskon;
            this.hargaTotal = harga - harga * (diskon / 100);
        }
    }
}
