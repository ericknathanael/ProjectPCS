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
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
        }

        private void rbAbsensi_Checked(object sender, RoutedEventArgs e)
        {
            CrystalReport1 rpt = new CrystalReport1();
            rpt.SetDatabaseLogon(MainWindow.userId, MainWindow.pass, MainWindow.source, "");
            //rpt.SetParameterValue();
            cReport.ViewerCore.ReportSource = rpt;
        }

        private void rbTransaksi_Checked(object sender, RoutedEventArgs e)
        {
            CrystalReport2 rpt = new CrystalReport2();
            rpt.SetDatabaseLogon(MainWindow.userId, MainWindow.pass, MainWindow.source, "");
            cReport.ViewerCore.ReportSource = rpt;
        }
    }
}
