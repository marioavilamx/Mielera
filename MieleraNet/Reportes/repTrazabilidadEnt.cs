using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using MieleraNet.DAL;
using System.Data;

namespace MieleraNet.Reportes
{
    public partial class repTrazabilidadEnt : DevExpress.XtraReports.UI.XtraReport
    {
        public repTrazabilidadEnt()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            RecepTranMielDS recepmiel = new RecepTranMielDS();
            DataTable dtTraz = recepmiel.ObtenTrazabilidadEntrada(this.paramIDTrans.Value.ToString());
            gridTambores.DataSource = dtTraz;
            //double TotalImporte=0;
            //for (int i = 0; i < dtTraz.Rows.Count; i++)
            //{
            //    TotalImporte += (double)dtTraz.Rows[i][8];
            //}
            //lbTotImporte.Text = string.Format("{0:c}",TotalImporte);
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            

        }

        private void ReportFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            RecepTranMielDS recepmiel = new RecepTranMielDS();
            double tot = recepmiel.ObtenTotalPagadoRep(this.paramIDTrans.Value.ToString());
            lbTotTran.Text = string.Format("{0:c}",tot);
            lbTotImporte.Text = string.Format("{0:c}", tot);
        }

    }
}
