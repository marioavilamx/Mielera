namespace MieleraNet.Reportes
{
    partial class repRecepcionMiel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(repRecepcionMiel));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.winControlContainer1 = new DevExpress.XtraReports.UI.WinControlContainer();
            this.gridTambores = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.lbAreaTrans = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTranPor = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbDelegadoActivo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbHoraTran = new DevExpress.XtraReports.UI.XRLabel();
            this.lbNumTran = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.lbFechaTran = new DevExpress.XtraReports.UI.XRLabel();
            this.lbFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.lbHora = new DevExpress.XtraReports.UI.XRLabel();
            this.lbTotTran = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbEmpresa = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.paramIDTrans = new DevExpress.XtraReports.Parameters.Parameter();
            this.paramIDEmpresa = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.gridTambores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.winControlContainer1});
            this.Detail.HeightF = 177.5F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // winControlContainer1
            // 
            this.winControlContainer1.LocationFloat = new DevExpress.Utils.PointFloat(15.625F, 10.00001F);
            this.winControlContainer1.Name = "winControlContainer1";
            this.winControlContainer1.SizeF = new System.Drawing.SizeF(593.75F, 110.5F);
            this.winControlContainer1.WinControl = this.gridTambores;
            // 
            // gridTambores
            // 
            this.gridTambores.Location = new System.Drawing.Point(0, 0);
            this.gridTambores.MainView = this.gridView1;
            this.gridTambores.Name = "gridTambores";
            this.gridTambores.Size = new System.Drawing.Size(570, 106);
            this.gridTambores.TabIndex = 0;
            this.gridTambores.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridTambores;
            this.gridView1.Name = "gridView1";
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 45F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbAreaTrans,
            this.xrLabel11,
            this.lbTranPor,
            this.xrLabel5,
            this.lbDelegadoActivo,
            this.xrLabel9,
            this.lbHoraTran,
            this.lbNumTran,
            this.xrPictureBox1,
            this.lbFechaTran,
            this.lbFecha,
            this.lbHora,
            this.lbTotTran,
            this.xrLabel8,
            this.xrLabel2,
            this.xrLabel3,
            this.lbEmpresa,
            this.xrLabel1,
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel4});
            this.PageHeader.HeightF = 241F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.PageHeader_BeforePrint);
            // 
            // lbAreaTrans
            // 
            this.lbAreaTrans.LocationFloat = new DevExpress.Utils.PointFloat(112F, 196F);
            this.lbAreaTrans.Name = "lbAreaTrans";
            this.lbAreaTrans.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbAreaTrans.SizeF = new System.Drawing.SizeF(158.3333F, 15F);
            this.lbAreaTrans.StylePriority.UseTextAlignment = false;
            this.lbAreaTrans.Text = "lbAreaTrans";
            this.lbAreaTrans.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(11.99999F, 196F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Area Trans:";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lbTranPor
            // 
            this.lbTranPor.LocationFloat = new DevExpress.Utils.PointFloat(131F, 181F);
            this.lbTranPor.Name = "lbTranPor";
            this.lbTranPor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTranPor.SizeF = new System.Drawing.SizeF(158.3333F, 15F);
            this.lbTranPor.StylePriority.UseTextAlignment = false;
            this.lbTranPor.Text = "lbTranPor";
            this.lbTranPor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(11.99999F, 181F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(119F, 15.00002F);
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Transferencia por:";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lbDelegadoActivo
            // 
            this.lbDelegadoActivo.LocationFloat = new DevExpress.Utils.PointFloat(112F, 118F);
            this.lbDelegadoActivo.Name = "lbDelegadoActivo";
            this.lbDelegadoActivo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbDelegadoActivo.SizeF = new System.Drawing.SizeF(158.3333F, 15F);
            this.lbDelegadoActivo.StylePriority.UseTextAlignment = false;
            this.lbDelegadoActivo.Text = "lbDelegadoActivo";
            this.lbDelegadoActivo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel9
            // 
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(11.99999F, 118F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Delegado Activo:";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lbHoraTran
            // 
            this.lbHoraTran.LocationFloat = new DevExpress.Utils.PointFloat(114F, 149.5F);
            this.lbHoraTran.Name = "lbHoraTran";
            this.lbHoraTran.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbHoraTran.SizeF = new System.Drawing.SizeF(158.3333F, 15F);
            this.lbHoraTran.StylePriority.UseTextAlignment = false;
            this.lbHoraTran.Text = "lbHoraTran";
            this.lbHoraTran.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lbNumTran
            // 
            this.lbNumTran.LocationFloat = new DevExpress.Utils.PointFloat(114F, 166F);
            this.lbNumTran.Name = "lbNumTran";
            this.lbNumTran.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbNumTran.SizeF = new System.Drawing.SizeF(158.3333F, 15F);
            this.lbNumTran.StylePriority.UseTextAlignment = false;
            this.lbNumTran.Text = "lbNumTran";
            this.lbNumTran.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(9.5F, 6F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(89.58334F, 85.125F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // lbFechaTran
            // 
            this.lbFechaTran.LocationFloat = new DevExpress.Utils.PointFloat(112F, 133F);
            this.lbFechaTran.Name = "lbFechaTran";
            this.lbFechaTran.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbFechaTran.SizeF = new System.Drawing.SizeF(158.3333F, 15F);
            this.lbFechaTran.StylePriority.UseTextAlignment = false;
            this.lbFechaTran.Text = "lbFechaTran";
            this.lbFechaTran.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lbFecha
            // 
            this.lbFecha.LocationFloat = new DevExpress.Utils.PointFloat(521.0833F, 111F);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbFecha.SizeF = new System.Drawing.SizeF(119.7082F, 14.99999F);
            this.lbFecha.StylePriority.UseTextAlignment = false;
            this.lbFecha.Text = "lbFecha";
            this.lbFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lbHora
            // 
            this.lbHora.LocationFloat = new DevExpress.Utils.PointFloat(521.0833F, 126.5F);
            this.lbHora.Name = "lbHora";
            this.lbHora.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbHora.SizeF = new System.Drawing.SizeF(119.7082F, 14.99999F);
            this.lbHora.StylePriority.UseTextAlignment = false;
            this.lbHora.Text = "lbHora";
            this.lbHora.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lbTotTran
            // 
            this.lbTotTran.LocationFloat = new DevExpress.Utils.PointFloat(114F, 212F);
            this.lbTotTran.Name = "lbTotTran";
            this.lbTotTran.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTotTran.SizeF = new System.Drawing.SizeF(158.3333F, 15F);
            this.lbTotTran.StylePriority.UseTextAlignment = false;
            this.lbTotTran.Text = "lbTotTran";
            this.lbTotTran.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel8
            // 
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(12F, 212F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Total Trans:";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel2
            // 
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(12F, 133F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Fecha Trans:";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(14F, 149.5F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Hora Trans:";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lbEmpresa
            // 
            this.lbEmpresa.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbEmpresa.LocationFloat = new DevExpress.Utils.PointFloat(103F, 4F);
            this.lbEmpresa.Name = "lbEmpresa";
            this.lbEmpresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbEmpresa.SizeF = new System.Drawing.SizeF(448.9583F, 23F);
            this.lbEmpresa.StylePriority.UseFont = false;
            this.lbEmpresa.StylePriority.UseTextAlignment = false;
            this.lbEmpresa.Text = "lbEmpresa";
            this.lbEmpresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(150F, 90.99998F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(350F, 19.125F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "DATOS DE LA TRANSFERENCIA DE MIEL";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(471.0833F, 126.5F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(42.70834F, 15F);
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Hora:";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(471.0833F, 111F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(45.8334F, 15F);
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Fecha:";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(12F, 166F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(100F, 15F);
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "N Trans:";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // paramIDTrans
            // 
            this.paramIDTrans.Name = "paramIDTrans";
            this.paramIDTrans.Value = "";
            // 
            // paramIDEmpresa
            // 
            this.paramIDEmpresa.Name = "paramIDEmpresa";
            this.paramIDEmpresa.Value = "";
            // 
            // repRecepcionMiel
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader});
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 45, 100);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.paramIDTrans,
            this.paramIDEmpresa});
            this.Version = "10.1";
            ((System.ComponentModel.ISupportInitialize)(this.gridTambores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel lbHoraTran;
        private DevExpress.XtraReports.UI.XRLabel lbNumTran;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRLabel lbFechaTran;
        private DevExpress.XtraReports.UI.XRLabel lbFecha;
        private DevExpress.XtraReports.UI.XRLabel lbHora;
        private DevExpress.XtraReports.UI.XRLabel lbTotTran;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel lbEmpresa;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.WinControlContainer winControlContainer1;
        private DevExpress.XtraGrid.GridControl gridTambores;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        public DevExpress.XtraReports.Parameters.Parameter paramIDTrans;
        public DevExpress.XtraReports.Parameters.Parameter paramIDEmpresa;
        private DevExpress.XtraReports.UI.XRLabel lbAreaTrans;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel lbTranPor;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel lbDelegadoActivo;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
    }
}
