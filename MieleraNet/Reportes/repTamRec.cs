using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using MieleraNet.DAL;
using System.Data;

namespace MieleraNet
{
    public partial class repTamRec : DevExpress.XtraReports.UI.XtraReport
    {
        public repTamRec()
        {
            InitializeComponent();
        }

        private void repTamRec_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            TransferenciasDS transf = new TransferenciasDS();
            string idTran = (string)this.idTransferencia.Value;
            if (idTran.Length > 0)
            {
                System.Data.DataTable tamboresDT = transf.ObtenTamboresPorIdTransferencia(idTran);
                //this.DataSource = transf.ObtenTamboresPorIdTransferencia("102");
                foreach (DataRow row in tamboresDT.Rows)
                {
                    this.reportesDS1.TamboresDT.ImportRow(row);
                }
                DataTable transfDT = transf.ObtenTransferenciaPorIdTran(idTran);
                if (transfDT.Rows.Count > 0)
                {
                    this.pDelegado.Value = transfDT.Rows[0][7].ToString();
                    lbArea.Text = transfDT.Rows[0][8].ToString();
                    lbPara.Text = transfDT.Rows[0][9].ToString();
                    lbAreaDestino.Text = transfDT.Rows[0][10].ToString();
                    lbFechaEnv.Text = ((DateTime)transfDT.Rows[0][3]).ToShortDateString();
                }
            }
        }
    }
}
