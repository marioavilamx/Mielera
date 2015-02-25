using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MieleraNet.DAL;
using DevExpress.Web;

namespace MieleraNet.Solicitudes
{
    public partial class solicitud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbFechaHoy.Text = DateTime.Now.ToString("dd/MM/yy");
            edtFechaMax.MinDate = DateTime.Now;
        }

        protected void rbAnticipo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAnticipo.Checked)
            {
                mvSolic.ActiveViewIndex = 0;
                InicializaCaptura();
                edtMonto.Focus();
            }
            
        }

        protected void rbSum_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSum.Checked)
            {
                mvSolic.ActiveViewIndex = 1;
                InicializaCaptura();
                edtApicultor.Focus();
            }
            
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            AnticipoDS solicitud = new AnticipoDS();
            try
            {
                if (rbAnticipo.Checked)
                {
                    solicitud.InsertaSolicitud(int.Parse(Session["idusr"].ToString()), edtAntObsr.Text, Double.Parse(edtMonto.Value.ToString()));
                }
                else
                {
                    solicitud.InsertaSolicitudSuministro(int.Parse(Session["idusr"].ToString()), edtObser.Text, edtApicultor.Value.ToString(), Double.Parse(edtKilos.Value.ToString()), double.Parse(edtPrecio.Text), int.Parse(edtTambores.Value.ToString()), int.Parse(edtFrascos.Value.ToString()), edtFechaMax.Date);

                }
                lbError.Text = "La solicitud se ha guardado con exito";
                popMB.ShowOnPageLoad = true;
                InicializaCaptura();
                gridSolicitud.DataBind();
                pagecontrolSolicitud.ActiveTabIndex = 0;
                
            }
            catch (Exception ex)
            {
                lbError.Text = "Lo sentimos el sistema ha tenido el siguiente error: " + ex.Message;
                popMB.ShowOnPageLoad = true;
                
            }
            
            
        }

        private void InicializaCaptura()
        {
            edtApicultor.Text = "";
            edtAntObsr.Text = "";
            edtMonto.Text = "";

            edtKilos.Text = "";
            edtPrecio.Text = "";
            edtFrascos.Text = "";
            edtTambores.Text = "";
            edtObser.Text = "";
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            lbError.Text = "No se pudo conectar al servidor, Disculpe las molestias\n Detalle del Error:\n" ;
            popMB.ShowOnPageLoad = true;
        }

        protected void gridSolicitud_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            if (e.ButtonID == "Enviar") 
            {
                AnticipoDS solicitud = new AnticipoDS();
                solicitud.InsertaEnvioSolicitud(83, 1, "solicitud", "Merida", gridSolicitud.GetRowValues(e.VisibleIndex, "IDSOLREC").ToString());
                gridSolicitud.DataBind();
                gridHistorial.DataBind();
            }
        }

        protected void gridSolicitud_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "IDSOLREC")
            {
                /*string strMuestreado = (string)gridTambEnv.GetRowValues(e.VisibleRowIndex, "STATUS");
                int idTambor = (int)gridTambEnv.GetRowValues(e.VisibleRowIndex, "IDTAMBOR");
                int idTrans = (int)gridTambEnv.GetRowValues(e.VisibleRowIndex, "IDTRANS");
                int valor = (int)e.Value;
                if (strMuestreado == "SI")
                {
                    e.DisplayText = "<a Target=\"_blank\" href=\"../Reportes/ImpMuestras.aspx?idtrans=" + idTrans.ToString() + "&idtambor=" + idTambor.ToString() + "\">" + valor.ToString() + "</a>";
                    btnReimprimir.Visible = true;
                }*/
            }
        }

        protected void ASPxGridView1_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["idDetalleSolRec"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }



    }
}
