using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using MieleraNet.DAL;
using MieleraNet.App_Data;

namespace MieleraNet.Reportes
{
    public partial class repMuestras : DevExpress.XtraReports.UI.XtraReport
    {
        public repMuestras()
        {
            InitializeComponent();
        }

        private void repMuestras_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            MuestreoDS dtMuestra = new MuestreoDS();
            ReportesDS.MuestrasDTDataTable muestraDT;
            if ((bool)this.paramEsTambor.Value == true)
            {
                muestraDT = dtMuestra.MuestraAImprimir((string)this.paramIDTrans.Value,(string)this.paramIDTambor.Value);
            }
            else
            {
                muestraDT = dtMuestra.MuestrasAImprimir(this.paramIDTrans.Value.ToString());
            }
            //string idTran = (string)this.idTransferencia.Value;
            /*if (idTran.Length > 0)
            {*/
                //System.Data.DataTable tamboresDT = transf.ObtenTamboresPorIdTransferencia(idTran);
                
                //this.DataSource = transf.ObtenTamboresPorIdTransferencia("102");
                foreach (ReportesDS.MuestrasDTRow row in muestraDT.Rows)
                {
                    this.reportesDS1.MuestrasDT.ImportRow(row);
                }
                
            //}
        }

    }
}
