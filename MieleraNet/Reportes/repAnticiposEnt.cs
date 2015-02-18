using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using MieleraNet.DAL;

namespace MieleraNet.Reportes
{
    public partial class repAnticiposEnt : DevExpress.XtraReports.UI.XtraReport
    {
        public repAnticiposEnt()
        {
            InitializeComponent();
            
        }

        private void repAnticiposEnt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lbTitulo.Text = "REPORTE DE ANTICIPOS ENTREGADOS A DELEGADOS DEL " + ((DateTime)paramFechaIni.Value).ToShortDateString() 
             + " AL " + ((DateTime)paramFechaFin.Value).ToShortDateString();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            CompraMielDS compra = new CompraMielDS();
            gridAnticipos.DataSource = compra.ObtenAnticiposDelegadoPorFecha((DateTime)this.paramFechaIni.Value, (DateTime)this.paramFechaFin.Value, (int)this.paramDelegado.Value);
        }

    }
}
