using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using MieleraNet.DAL;
using System.Data;

namespace MieleraNet.Reportes
{
    public partial class repCompraMiel : DevExpress.XtraReports.UI.XtraReport
    {
        public repCompraMiel()
        {
            InitializeComponent();
        }

        private void repCompraMiel_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            CompraMielDS periferica = new CompraMielDS();
            DataTable dtCompra = periferica.ObtenCompraMielPorIdCompra(int.Parse(this.paramIdCompra.Value.ToString()));
            gridCompraTambores.DataSource = dtCompra;
            if (dtCompra.Rows.Count > 0)
            {
                lbApicultor.Text = dtCompra.Rows[0][1].ToString();
                lbNotaEntrada.Text = this.paramIdCompra.Value + "-" + dtCompra.Rows[0][0].ToString();
                lbArea.Text = dtCompra.Rows[0][2].ToString();
                DateTime fCompra = (DateTime)dtCompra.Rows[0][3];
                lbFecha.Text = fCompra.ToString("dd/MM/yy");
                barcodeNota.Text = lbNotaEntrada.Text;
            }


        }

    }
}
