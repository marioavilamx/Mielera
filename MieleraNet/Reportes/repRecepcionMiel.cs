using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using MieleraNet.DAL;
using System.Data;

namespace MieleraNet.Reportes
{
    public partial class repRecepcionMiel : DevExpress.XtraReports.UI.XtraReport
    {
        public repRecepcionMiel()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            RecepTranMielDS recepmiel = new RecepTranMielDS();
            gridTambores.DataSource = recepmiel.ObtenTambTransfMielRep(this.paramIDTrans.Value.ToString());
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

            RecepTranMielDS recepmiel = new RecepTranMielDS();
            DataTable datos = recepmiel.ObtenTransferenciaMielRep(this.paramIDTrans.Value.ToString());
            if (datos.Rows.Count > 0)
            {
                lbNumTran.Text = datos.Rows[0][0].ToString();
                //lbDelegadoActivo
                lbTranPor.Text = datos.Rows[0][2].ToString();
                lbAreaTrans.Text = datos.Rows[0][4].ToString();
                DateTime fecha = (DateTime)datos.Rows[0][5];
                lbFechaTran.Text = fecha.ToShortDateString();
                TimeSpan hora = (TimeSpan)datos.Rows[0][6];
                lbHoraTran.Text = hora.ToString();
                lbTotTran.Text = string.Format("{0:c}", datos.Rows[0][12]);
            }
        }

    }
}
