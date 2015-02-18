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

namespace MieleraNet.Entidades
{
    public partial class Entidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CSSLink = "~/CSS/style.css";
            if (!Page.IsPostBack)
            {
                if (Page.Request["Pagina"] != null)
                {
                    if (Page.Request["Pagina"] == "1")
                    {
                        pagecontrolEntidades.ActiveTabIndex = 1;
                        pagecontrolEntidades.DataBind();
                    }
                    if (Page.Request["Pagina"] == "2")
                    {
                        mvEntidades.ActiveViewIndex = 1;
                        pagecontrolDir.DataBind();    
                    }
                }
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            MieleraNet.DAL.EntidadesDS ent = new MieleraNet.DAL.EntidadesDS();
            int idenfimo = -1;
            try
            {
                idenfimo = ent.AltaPersonaFisica(edtPaisPF.Text, edtEstadoPF.Text, edtCiudadPF.Text, (char)edtGenero.Value, edtFechaNac.Date, 
                                      edtPrimerAp.Text, edtSegundoAp.Text, edtPrimerNom.Text, edtSegundoNom.Text, "",
                                      (int)edtConPF.Value, (int)edtRelacionesPF.Value, edtTelefono.Text, edtEmail.Text, edtOcup.Text,edtObs.Text);
                if (idenfimo > 0)
                {
                    edtEntidad.Value = idenfimo;
                    mvEntidades.ActiveViewIndex = 1;
                    pagecontrolDir.DataBind();
                }
            }
            catch (Exception ex)
            {
                lbError.Text = "Ocurrio un error en el grabado de la Entidad Fisica" + ex.Message; ;
                popMB.ShowOnPageLoad = true;
            }
            
            /*mvEntidades.ActiveViewIndex = 1;
            pagecontrolDir.DataBind();*/

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            mvEntidades.ActiveViewIndex = 0;
            
            //Se inicializan los controles de la fisica y moral
        }

        protected void btnGrabaPM_Click(object sender, EventArgs e)
        {
            MieleraNet.DAL.EntidadesDS ent = new MieleraNet.DAL.EntidadesDS();
            int idenfimo = -1;
            try
            {
                idenfimo = ent.AltaPersonaMoral( edtPaisReg.Text,edtEstadoReg.Text, edtCiudadReg.Text, edtFechaPM.Date,
                                      edtCorpo.Text, edtTermLeg.Text, edtRFC.Text, edtGiro.Text, edtObservacionPM.Text);
                if (idenfimo > 0)
                {
                    edtEntidad.Value = idenfimo;
                    mvEntidades.ActiveViewIndex = 1;
                }
            }
            catch (Exception ex)
            {
                lbError.Text = "Ocurrio un error en el grabado de la Entidad Moral: " + ex.Message;
                popMB.ShowOnPageLoad = true;
            }
            //mvEntidades.ActiveViewIndex = 1;
        }

        protected void btnGrabaDir_Click(object sender, EventArgs e)
        {
            MieleraNet.DAL.EntidadesDS ent = new MieleraNet.DAL.EntidadesDS();
            try
            {
                ent.AltaDireccion(edtPaisDir.Text, edtEstadoDir.Text, edtMunicipio.Text, edtCiudadDir.Text, edtCodPosDir.Text,edtColonia.Text,edtCalleFront.Text,
                                             edtCalleIzq.Text,edtCalleDer.Text,edtNumExt.Text,edtNumInt.Text,(int)edtClase.Value, edtTipDir.Text, (int)edtEntidad.Value);
                DlgBtnCerrar.Visible = false;
                popMB.HeaderText = "MieleraNet";
                lbError.Text = "La dirección se grabo de manera satisfactoria";
                popMB.ShowOnPageLoad = true;
            }
            catch (Exception ex)
            {
                lbError.Text = "Ocurrio un error en el grabado de la Direccion: " + ex.Message;
                popMB.ShowOnPageLoad = true;
            }
        }

        protected void edtOk_Click(object sender, EventArgs e)
        {
            if (pagecontrolEntidades.ActiveTabIndex == 0)
                Response.Redirect("Entidad.aspx");
            else
                Response.Redirect("Entidad.aspx?pagina=1");
        }

    }
}
