using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using MieleraNet.DAL;

namespace MieleraNet.Reportes
{
    public partial class repCortesxFecha : DevExpress.XtraReports.UI.XtraReport
    {
        public repCortesxFecha()
        {
            InitializeComponent();
        }

        private void repCortesxFecha_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //lbDelegado.Text = "FRANCISCO ROCHA BAAS AL 31 DE ENERO DE 2012";
            lbDelegado.Text = this.paramNombre.Value.ToString();
            //lbFechas.Text = "DEL " + ((DateTime)paramFechaIni.Value).ToString("t") + " AL " + ((DateTime)paramFechaFin.Value).ToShortDateString();
            lbFechas.Text = "DEL " + ((DateTime)paramFechaIni.Value).ToShortDateString() + " AL " + ((DateTime)paramFechaFin.Value).ToShortDateString();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            CompraMielDS compra = new CompraMielDS();
            gridCortexFecha.DataSource = compra.ObtenCortesPorFecha((DateTime)this.paramFechaIni.Value,(DateTime)this.paramFechaFin.Value,(int)this.paramDelegado.Value);
        }

    }
}
