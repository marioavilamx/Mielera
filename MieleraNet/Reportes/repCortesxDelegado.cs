using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using MieleraNet.DAL;

namespace MieleraNet.Reportes
{
    public partial class repCortesxDelegado : DevExpress.XtraReports.UI.XtraReport
    {
        public repCortesxDelegado()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            CompraMielDS compra = new CompraMielDS();

            gridCorteDelegado.DataSource = compra.ObtenCortesPorDelegado((DateTime)this.paramFechaIni.Value, (DateTime)this.paramFechaFin.Value,(int)this.paramDelegado.Value);
        }

        private void repCortesxDelegado_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lbFechas.Text = "DEL " + ((DateTime)paramFechaIni.Value).ToShortDateString() + " AL " + ((DateTime)paramFechaFin.Value).ToShortDateString();
        }

    }
}
