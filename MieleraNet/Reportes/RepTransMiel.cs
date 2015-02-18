using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using MieleraNet.DAL;
using System.Data;

namespace MieleraNet.Reportes
{
    public partial class RepTransMiel : DevExpress.XtraReports.UI.XtraReport
    {
        public RepTransMiel()
        {
            InitializeComponent();
        }

        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //this.paramIDEmpresa
            CentralDS central = new CentralDS();
            DataTable centralDT = central.ObtenEmpresasPorID(this.paramIDEmpresa.Value.ToString());
            if (centralDT.Rows.Count > 0)
            {
                lbEmpresa.Text = centralDT.Rows[0][1].ToString();
            }
            lbHora.Text = DateTime.Now.ToShortTimeString();
            lbFecha.Text = DateTime.Now.ToShortDateString();

            CompraMielDS compramiel = new CompraMielDS();
            DataTable datos = compramiel.ObtenTransferenciaMielRep(this.paramIDTrans.Value.ToString());
            if (datos.Rows.Count > 0)
            {
               lbNumTran.Text = datos.Rows[0][0].ToString();
               lbDelegado.Text = datos.Rows[0][2].ToString();
               DateTime fecha = (DateTime)datos.Rows[0][5];
               lbFechaTran.Text = fecha.ToShortDateString();
               TimeSpan hora = (TimeSpan)datos.Rows[0][6];
               DateTime dtHora = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hora.Hours, hora.Minutes, hora.Seconds);

               lbHoraTran.Text = dtHora.ToShortTimeString();
               lbTotTran.Text = string.Format("{0:c}",datos.Rows[0][12]);
            }
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            CompraMielDS compramiel = new CompraMielDS();
            gridTambores.DataSource = compramiel.ObtenTambTransfMielRep(this.paramIDTrans.Value.ToString());
            //gridTambores.DataSource
        }

    }
}
