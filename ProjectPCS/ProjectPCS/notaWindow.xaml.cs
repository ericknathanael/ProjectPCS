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
    /// Interaction logic for notaWindow.xaml
    /// </summary>
    public partial class notaWindow : Window
    {
        Karyawan kasir; 
        public notaWindow(string nota,int nominalYgDibayar)
        {
            InitializeComponent();
            kasir = loginWindow.karyawan;
            CrystalReport3 rpt = new CrystalReport3();
            rpt.SetDatabaseLogon(MainWindow.userId, MainWindow.pass, MainWindow.source, "");
            rpt.SetParameterValue("nomorNota", nota);
            rpt.SetParameterValue("Pembayaran", nominalYgDibayar);
            report.ViewerCore.ReportSource = rpt;
        }
    }
}
