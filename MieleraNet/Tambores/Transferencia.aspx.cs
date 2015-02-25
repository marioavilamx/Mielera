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

namespace MieleraNet.Tambores
{
    public partial class Transferencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Page.Request["Pagina"] != null)
                {
                    if (Page.Request["Pagina"] == "1")
                    {
                        pagecontrolTrans.ActiveTabIndex = 1;
                        pagecontrolTrans.DataBind();
                    }
                    if (Page.Request["Pagina"] == "2")
                    {
                        
                    }
                }
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            int idarea = (int)Session["idarea"];
            int idusr = (int)Session["idusr"];
            TransferenciasDS trans = new TransferenciasDS();
            trans.EnviaTransferencia((int)edtDestino.Value, idarea, DateTime.Now, idusr);
            gridTransferencias.DataBind();
        }

        protected void CallbackPanel_Callback(object sender, CallbackEventArgsBase e)
        {
            TransferenciasDS trans = new TransferenciasDS();
            int idarea = (int)Session["idarea"];
            int idusr = (int)Session["idusr"];
            switch (e.Parameter)
            {
                case "GrabaTambor":
                    int result = -100;
                    result = trans.AgregaTamborPendiente(idusr, int.Parse(edtTambor.Text), idarea);
                    switch (result)
                    {
                        case -1: lbError.Text = "No se puede agregar el barril porque no pertence al área o la tara es igual a cero";
                            break;
                        case -2: lbError.Text = "No se puede volver a agregar los tambores ya agregados";
                            break;
                        case -3: lbError.Text = "El tambor esta en proceso de envío";
                            break;
                        case 0: 
                            break;
                    }
                    if (result != 0)
                    {
                        popMB.ShowOnPageLoad = true;
                    }
                    break;
                case "EliminaListaTambores":
                   listboxTambores.DataBind();
                    if (listboxTambores.Items.Count > 0)
                    {
                        int idTran = (int)listboxTambores.Items[0].Value;
                        trans.EliminaListaTambores(0, idTran);
                        
                    }
                    break;
                case "GrabaTamborRango":
                    int TamIni = int.Parse(hfLista["TamIni"].ToString());
                    int TamFin = int.Parse(hfLista["TamFin"].ToString());
                    lbError.Text = "";
                    int result2 = -100;
                    bool bHuboErrores = false;
                    for (int i = TamIni; i <= TamFin; i++)
                    {
                        result2 = -100;
                        result2 = trans.AgregaTamborPendiente(idusr, i, idarea);
                        switch (result2)
                        {
                            case -1: lbError.Text += i + ",";
                                bHuboErrores = true;
                                break;
                            case -2: lbError.Text += i + ",";
                                bHuboErrores = true;
                                break;
                            case -3: lbError.Text += i + ",";
                                bHuboErrores = true;
                                break;
                            case 0: 
                                break;
                        }
                    }

                    if (bHuboErrores)
                    {
                        lbError.Text = "No se pudieron agregar los siguientes Tambores[ " + lbError.Text + "]";
                        popMB.ShowOnPageLoad = true;
                        DlgBtnCerrar.Focus();
                    }
                    break;
            }
            listboxTambores.DataBind();            
        }


        protected void listboxTambores_Callback(object sender, CallbackEventArgsBase e)
        {

            int idtambor = int.Parse(e.Parameter);
            double idarea = (double)hfLista["idarea"];

            TransferenciasDS trans = new TransferenciasDS();
            trans.EliminaListaTambores(idtambor, (int)idarea);
            listboxTambores.DataBind();
        }

        protected void gridTambores_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["idHistTran"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        protected void btnRecep_Click(object sender, EventArgs e)
        {
            TransferenciasDS tranDS = new TransferenciasDS();
            System.Collections.Generic.List<object> lista = gridRecepcion.GetSelectedFieldValues("NUM_TAMBOR");
            System.Collections.Generic.List<object> listadest = gridRecepcion.GetSelectedFieldValues("IDDESTINO");
            System.Collections.Generic.List<object> listaEnvio = gridRecepcion.GetSelectedFieldValues("IDENVIO");

            for (int i = 0; i < lista.Count; i++)
            {
                int numTambor = (int)lista[i];
                int idenvio = (int)listaEnvio[i];
                short iddest = (short)listadest[i];
                tranDS.RecepcionaTambores(numTambor, idenvio, iddest);
            }
            gridRecepcion.DataBind();

        }




    }
}
