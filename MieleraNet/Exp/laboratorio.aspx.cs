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

namespace MieleraNet.Exp
{
    public partial class laboratorio : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmbLotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExportDS labDS = new ExportDS();
            
            if (cmbLotes.Text.Length > 0)
            {
                btnGrabaCert.Enabled = true;
                //Se lee el lota para ver si ya tiene guardado el reporte fisico
                DataTable dtFQ = labDS.ObtenFisicoQuimicoByIdNumProd(cmbLotes.Value.ToString());
                if (dtFQ.Rows.Count > 0)
                {
                    edtNumRep.Text = dtFQ.Rows[0][2].ToString();
                    edtFecha.Date = (DateTime)dtFQ.Rows[0][3];
                    edtFactura.Text = dtFQ.Rows[0][4].ToString();
                    edtProducto.Text = dtFQ.Rows[0][5].ToString();
                    edtDesc.Text = dtFQ.Rows[0][6].ToString();
                    edtTemperatura.Text = dtFQ.Rows[0][7].ToString();
                    edtEmpaquetado.Text = dtFQ.Rows[0][8].ToString();
                    edtFechaIni.Date = (DateTime)dtFQ.Rows[0][9];
                    edtFechaFin.Date = (DateTime)dtFQ.Rows[0][10];
                    edtEmpresa.Value = (int)dtFQ.Rows[0][11];
                    btnRepFisico.Enabled = true;
                    edtDesc.Enabled = false;

                    //Se selecciona el datatable para el grid del detalle
                    int idReporte = (int)dtFQ.Rows[0][0];
                    //gridFQDet.DataSource = labDS.ObtenFisicoQuimicoByIdReporte(idReporte);
                    //gridFQDet.DataBind();

                    objDSFQDet.SelectParameters.Clear();
                    objDSFQDet.SelectParameters.Add("idReporte", idReporte.ToString());
                    //gridFQDet.DataSource = objDSFQDet;
                    gridFQDet.DataBind();
                }
                else
                {
                    int inumrep = labDS.ObtenNumeroSiguienteReporteFisico();
                    inumrep = inumrep + 1;
                    string numrep = "PM" + (DateTime.Now.Year - 2000) + DateTime.Now.DayOfYear.ToString("000") + inumrep.ToString("00");
                    edtNumRep.Text = numrep;
                    edtEmpresa.Value = 1;
                    edtFecha.Date = DateTime.Now;

                    edtProducto.Text = "MIEL DE ABEJA PURA";
                    edtDesc.Text = cmbLotes.Text;
                    edtTemperatura.Text = "AMBIENTE";
                    edtEmpaquetado.Text = "PET / 150gr";
                    edtFactura.Text = "";
                    edtFechaIni.Text = "";
                    edtFechaFin.Text = "";
                    edtFactura.Focus();
                    btnRepFisico.Enabled = false;
                    edtDesc.Enabled = true;

                    //Limpiamos el grid del detalle
                    objDSFQDet.SelectParameters.Clear();
                    objDSFQDet.SelectParameters.Add("idReporte", "0");
                    gridFQDet.DataBind();
                }

                //Analisis Report
                btnAddRep.Enabled = true;
                btnRepLab.Enabled = true;

                objDSAnalisis.SelectParameters.Clear();
                objDSAnalisis.SelectParameters.Add("numprod", cmbLotes.Value.ToString());
                objDSAnalisis.DataBind();

                //Certificado de Analisis
                DataTable dtCertificado = labDS.ObtenCertificadoIdNumProd(cmbLotes.Value.ToString());
                if (dtCertificado.Rows.Count > 0)
                {
                    edtCFecha.Date = (DateTime)dtCertificado.Rows[0]["FECHA"];
                    edtCReportNo.Text = dtCertificado.Rows[0]["FOLIO"].ToString();
                    edtCRef.Text = dtCertificado.Rows[0]["INVOICE"].ToString();
                    edtCContract.Text = dtCertificado.Rows[0]["CONTRAC"].ToString();
                    edtConteiner.Text = dtCertificado.Rows[0]["CONTAINER"].ToString();
                    edtCOurRef.Text = dtCertificado.Rows[0]["OURREFERENCE"].ToString();
                    edtCProducto.Text = dtCertificado.Rows[0]["PRODUCT"].ToString();
                    edtCLote.Text = dtCertificado.Rows[0]["DESCRIPTION"].ToString();
                    edtCTemp.Text = dtCertificado.Rows[0]["TEMPERATURA"].ToString();
                    edtCCalidad.Text = dtCertificado.Rows[0]["PACKING"].ToString();
                    edtCFechaInicio.Date = (DateTime)dtCertificado.Rows[0]["FECHAINICERTI"];
                    edtCFechaFin.Date = (DateTime)dtCertificado.Rows[0]["FECHAFINCERTI"];
                    edtCliente.Value = (int)dtCertificado.Rows[0]["IDCLIENTE"];

                    btnRepCertificado.Enabled = true;
                    edtCOurRef.Enabled = false;

                    //Se selecciona el datatable para el grid del detalle
                    int IdCertificado = (int)dtCertificado.Rows[0][0];
                    objDSCertDet.SelectParameters.Clear();
                    objDSCertDet.SelectParameters.Add("IDCERTIFICADO", IdCertificado.ToString());
                    objDSCertDet.DataBind();
                }
                else
                {
                    int inumrep = labDS.ObtenNumeroSiguienteCertificado();
                    inumrep = inumrep + 1;
                    string numrep = "MI" + (DateTime.Now.Year - 2000) + DateTime.Now.DayOfYear.ToString("000") + inumrep.ToString("00");
                    edtCReportNo.Text = numrep;
                    //edtEmpresa.Value = 1;
                    edtCFecha.Date = DateTime.Now;

                    edtCProducto.Text = "YUCATAN HONEY";
                    edtCTemp.Text = "Room temperate";
                    edtCCalidad.Text = "PET / 150gr";
                    edtCLote.Focus();
                    btnRepCertificado.Enabled = false;
                    edtCOurRef.Enabled = true;

                    edtCFecha.Text = "";
                    edtCOurRef.Text = cmbLotes.Text;
                    edtCContract.Text = "";
                    edtConteiner.Text = "";
                    edtCOurRef.Text = cmbLotes.Text;
                    edtCLote.Text = "";

                    //Limpiamos el grid del detalle
                    objDSCertDet.SelectParameters.Clear();
                    objDSCertDet.SelectParameters.Add("IDCERTIFICADO", "0");
                    objDSCertDet.DataBind();
                }
            }
            else
            {
                //Analisis Report
                edtNorepana.Text="";
                edtFechaExt.Text = "";
                edtEmpresaExt.Text = "";
                btnAddRep.Enabled = false;
                btnRepLab.Enabled = false;
                btnGrabaCert.Enabled = false;
               
 
            }
        }

        protected void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbLotes.Text = "";
            //btnGenEntrada.Enabled = false;
            //btnGenEntradaIntegradora.Enabled = false;
        }

        protected void btnGrabaFis_Click(object sender, EventArgs e)
        {
            ExportDS labDS = new ExportDS();
            if (Session["idusr"] != null)
            {
                if (cmbLotes.Value != null)
                {
                    //Checamos si existe el reporte fisico del lote seleccionado
                    DataTable dtFQ = labDS.ObtenFisicoQuimicoByIdNumProd(cmbLotes.Value.ToString());
                    if (dtFQ.Rows.Count > 0)
                    {
                        int idReporte = (int)dtFQ.Rows[0][0];

                        //Actualizamos el encabezado del Fisico - Quimico
                        labDS.AcutalizaFisicoQuimico(idReporte, edtNumRep.Text, edtFecha.Date, edtFactura.Text, edtProducto.Text, edtDesc.Text, edtTemperatura.Text, edtEmpaquetado.Text, edtFechaIni.Date, edtFechaFin.Date, (int)edtEmpresa.Value, (int)Session["idusr"]);
                    }
                    else// Si No existe lo insertamos
                    {
                        labDS.InsertaFisicoQuimico(cmbLotes.Value.ToString(), edtNumRep.Text, edtFecha.Date, edtFactura.Text, edtProducto.Text, edtDesc.Text, edtTemperatura.Text, edtEmpaquetado.Text, edtFechaIni.Date, edtFechaFin.Date, (int)edtEmpresa.Value, (int)Session["idusr"]);
                        int idReporte = labDS.ObtenIdReporteByNumProd(cmbLotes.Value.ToString());
                        if (idReporte != 0)
                        {
                            labDS.InsertaFisicoQuimicoDet(idReporte, "FISICO", "COLOR", "", "mm", "-------------", "PPUND");
                            labDS.InsertaFisicoQuimicoDet(idReporte, "FISICO", "OLOR/SABOR", "", "", "-------------", "ORGANOLEPTICO");
                            labDS.InsertaFisicoQuimicoDet(idReporte, "QUIMICO", "H.M.F", "", "PPM", "-------------", "ESPECTROFOTOMETRICO");
                            labDS.InsertaFisicoQuimicoDet(idReporte, "QUIMICO", "MOISTIURE", "", "%", "-------------", "REFRACTOMETRICO");
                        }
                        btnRepFisico.Enabled = true;

                        //Actualizamos el grid del detalle del Fisico-Quimico
                        objDSFQDet.SelectParameters.Clear();
                        objDSFQDet.SelectParameters.Add("idReporte", idReporte.ToString());
                        gridFQDet.DataBind();
                    }
                }
            }
        }

        protected void btnAddRep_Click(object sender, EventArgs e)
        {
            ExportDS labDS = new ExportDS();
            labDS.InsertaAnalisisReport(edtNorepana.Text, edtFechaExt.Date, (int)edtEmpresaExt.Value, cmbLotes.Value.ToString());
         
            objDSAnalisis.SelectParameters.Clear();
            objDSAnalisis.SelectParameters.Add("numprod", cmbLotes.Value.ToString());
            objDSAnalisis.DataBind();

        }

        protected void btnGrabaCert_Click(object sender, EventArgs e)
        {
            ExportDS labDS = new ExportDS();
            if (Session["idusr"] != null)
            {
                if (cmbLotes.Value != null)
                {
                    //Checamos si existe el reporte fisico del lote seleccionado
                    DataTable dtCertificado = labDS.ObtenCertificadoIdNumProd(cmbLotes.Value.ToString());
                    if (dtCertificado.Rows.Count > 0)
                    {
                        int IDCERTIFICADO = (int)dtCertificado.Rows[0][0];

                        //Actualizamos el encabezado Certificado
                        labDS.ActualizaCertificado(IDCERTIFICADO, edtCReportNo.Text, edtCFecha.Date, edtCRef.Text, edtCContract.Text, edtConteiner.Text, edtCProducto.Text, edtCLote.Text, edtCTemp.Text, edtCCalidad.Text, edtCFechaInicio.Date, edtCFechaFin.Date, (int)edtCliente.Value);
                    }
                    else// Si No existe lo insertamos
                    {
                        labDS.InsertaCertificado(edtCReportNo.Text, edtCFecha.Date, cmbLotes.Value.ToString(), edtCRef.Text, edtCContract.Text, edtConteiner.Text, edtCProducto.Text, edtCLote.Text, edtCTemp.Text, edtCCalidad.Text, edtCFechaInicio.Date, edtCFechaFin.Date, (int)Session["idusr"], edtCOurRef.Text, (int)edtCliente.Value);
                        int idCert = labDS.ObtenIdCertificadoByNumProd(cmbLotes.Value.ToString());
                        if (idCert != 0)
                        {
                            labDS.InsertaCertificadoDet(idCert, "Streptomycin", "n.d", "Ppb", "10 ppb", "CHARM");
                            labDS.InsertaCertificadoDet(idCert, "Sulfonamides", "n.d", "Ppb", "10 ppb", "CHARM");
                            labDS.InsertaCertificadoDet(idCert, "Tetracyclines", "n.d", "Ppb", "15 ppb", "ELISA");
                            labDS.InsertaCertificadoDet(idCert, "Chloramphenicol", "n.d", "Ppb", "0.15 ppb", "ELISA");
                            labDS.InsertaCertificadoDet(idCert, "Glycerol", "-", "Ppm", "-", "UV/FOTOMETRIC");
                            labDS.InsertaCertificadoDet(idCert, "F/G", "-", "-", "-", "UV/FOTOMETRIC");
                            //Obtenemos los valores capturados en el Fisico-Quimico
                            DataTable dtDetFQ = labDS.ObtenDetalleFisicoQuimicoByNumProd(cmbLotes.Value.ToString());

                            for (int i = 0; i < dtDetFQ.Rows.Count; i++)
                            {
                                switch (dtDetFQ.Rows[i][0].ToString())
                                {
                                    case "COLOR":
                                        labDS.InsertaCertificadoDet(idCert, "Color", dtDetFQ.Rows[i][1].ToString(), "Mm", "-", "PFUND");
                                        break;
                                    case "OLOR/SABOR":
                                        break;
                                    case "H.M.F":
                                        labDS.InsertaCertificadoDet(idCert, "H.M.F", dtDetFQ.Rows[i][1].ToString(), "Ppm", "-", "ESPECTOFOTOMETRIC");
                                        break;
                                    case "MOISTIURE":
                                        labDS.InsertaCertificadoDet(idCert, "Moisture", dtDetFQ.Rows[i][1].ToString(), "%", "-", "REFRACTOMETRIC");
                                        break;
                                }  
                            }
                            
                            
                        }
                        btnRepCertificado.Enabled = true;

                        //Actualizamos el grid del detalle del certificado
                        objDSCertDet.SelectParameters.Clear();
                        objDSCertDet.SelectParameters.Add("IDCERTIFICADO", idCert.ToString());
                        objDSCertDet.DataBind();
                    }
                }
            }
        }

       



    }
}
