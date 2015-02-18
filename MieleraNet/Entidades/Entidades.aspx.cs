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

namespace MieleraNet.Entidades
{
    public partial class Entidades : System.Web.UI.Page
    {
        enum ViewType { entidad, fisicas, preview };
        /*static string[] seasons = new string[4] { 
         "Winter", "Spring", "Summer", "Autumn" 
         };*/

        
        static string[][] months = new string[4][] { 
         new string[]{ "December", "January", "February" },
         new string[]{ "March", "April", "May" }, 
         new string[]{ "June", "July", "August" }, 
         new string[]{ "September", "October", "November" } 
        };

        static string[] entidades = new string[2] { "Persona Fisica", "Persona Moral" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ResetAnswers();
            LoadView();
        }
        private void LoadView()
        {
            mvVoting.ActiveViewIndex = (int)hfAnswers["questionIndex"];
            switch ((ViewType)mvVoting.ActiveViewIndex)
            {
                case ViewType.entidad:
                    LoadEntidad();
                    break;
                case ViewType.fisicas:
                    LoadFisicas();
                    break;
                case ViewType.preview:
                    LoadPreview();
                    break;
            }
        }
        private void LoadEntidad()
        {
            rblEntidades.Items.Clear();
            rblEntidades.Items.AddRange(entidades);
            rblEntidades.SelectedIndex = (int)hfAnswers["entidades"];
            
            
        }
        private void LoadFisicas()
        {
            edtPrimerNom.Text = (string)hfAnswers["PrimerNombre"];
            edtSegundoNom.Text = (string)hfAnswers["SegundoNombre"];
            edtPrimerAp.Text = (string)hfAnswers["PrimerApellido"];
            edtSegundoAp.Text = (string)hfAnswers["SegundoApellido"];
        }
        private void LoadPreview()
        {
            int entidadesIndex = (int)hfAnswers["entidades"];
            lblSelectedSeason.Text = entidades[entidadesIndex];
            
        }
        private void ResetAnswers()
        {
            hfAnswers["questionIndex"] = 0;
            hfAnswers["entidades"] = 0;
            hfAnswers["PrimerNombre"] = "";
            hfAnswers["SegundoNombre"] = "";
            hfAnswers["PrimerApellido"] = "";
            hfAnswers["SegundoApellido"] = "";
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.PathAndQuery, true);
        }

        protected void ASPxComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
