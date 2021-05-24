using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPCS
{
    public class Karyawan
    {
        public int id_jabatan { get; set; }
        public string username { get; set; }
        public string pass { get; set; }
        public string nama { get; set; }

        public Karyawan(int id_jabatan, string username, string pass, string nama)
        {
            this.id_jabatan = id_jabatan;
            this.username = username.ToUpper();
            this.pass = pass;
            this.nama = nama;
        }
    }
}
