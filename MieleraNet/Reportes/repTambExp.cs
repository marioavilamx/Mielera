using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using MieleraNet.DAL;
using System.Data;

namespace MieleraNet.Reportes
{
    public partial class repTambExp : DevExpress.XtraReports.UI.XtraReport
    {
        public repTambExp()
        {
            InitializeComponent();
        }

        private void repTambExp_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ExportDS exportDS = new ExportDS();
            string idContrato = "2";//= (string)this.idTransferencia.Value;
            if (idContrato.Length > 0)
            {
                System.Data.DataTable tamboresDT = exportDS.ObtenTamboresExportadosPorContrato(idContrato);
                //this.DataSource = transf.ObtenTamboresPorIdTransferencia("102");
                foreach (DataRow row in tamboresDT.Rows)
                {
                    this.reportesDS1.TamboresExp.ImportRow(row);
                }
                
            }
        }

    }
}
