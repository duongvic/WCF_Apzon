namespace Demo
{
    partial class FormOCRD
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControlOCRD = new DevExpress.XtraGrid.GridControl();
            this.gridViewOCRD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CardCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CardName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Fax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.E_Mail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BankName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOCRD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOCRD)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlOCRD
            // 
            this.gridControlOCRD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlOCRD.Location = new System.Drawing.Point(0, 0);
            this.gridControlOCRD.MainView = this.gridViewOCRD;
            this.gridControlOCRD.Name = "gridControlOCRD";
            this.gridControlOCRD.Size = new System.Drawing.Size(648, 400);
            this.gridControlOCRD.TabIndex = 1;
            this.gridControlOCRD.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOCRD});
            this.gridControlOCRD.DoubleClick += new System.EventHandler(this.gridControlOCRD_DoubleClick);
            // 
            // gridViewOCRD
            // 
            this.gridViewOCRD.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CardCode,
            this.CardName,
            this.Fax,
            this.E_Mail,
            this.BankName});
            this.gridViewOCRD.GridControl = this.gridControlOCRD;
            this.gridViewOCRD.Name = "gridViewOCRD";
            // 
            // CardCode
            // 
            this.CardCode.Caption = "Card Code";
            this.CardCode.FieldName = "CardCode";
            this.CardCode.Name = "CardCode";
            this.CardCode.Visible = true;
            this.CardCode.VisibleIndex = 0;
            // 
            // CardName
            // 
            this.CardName.Caption = "Card Name";
            this.CardName.FieldName = "CardName";
            this.CardName.Name = "CardName";
            this.CardName.Visible = true;
            this.CardName.VisibleIndex = 1;
            // 
            // Fax
            // 
            this.Fax.Caption = "Fax";
            this.Fax.FieldName = "Fax";
            this.Fax.Name = "Fax";
            this.Fax.Visible = true;
            this.Fax.VisibleIndex = 2;
            // 
            // E_Mail
            // 
            this.E_Mail.Caption = "EMail";
            this.E_Mail.FieldName = "E_Mail";
            this.E_Mail.Name = "E_Mail";
            this.E_Mail.Visible = true;
            this.E_Mail.VisibleIndex = 3;
            // 
            // BankName
            // 
            this.BankName.Caption = "Bank Name";
            this.BankName.FieldName = "BankName";
            this.BankName.Name = "BankName";
            this.BankName.Visible = true;
            this.BankName.VisibleIndex = 4;
            // 
            // FormOCRD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 400);
            this.Controls.Add(this.gridControlOCRD);
            this.Name = "FormOCRD";
            this.Text = "FormOCRD";
            this.Load += new System.EventHandler(this.FormOCRD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOCRD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOCRD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlOCRD;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOCRD;
        private DevExpress.XtraGrid.Columns.GridColumn CardCode;
        private DevExpress.XtraGrid.Columns.GridColumn CardName;
        private DevExpress.XtraGrid.Columns.GridColumn Fax;
        private DevExpress.XtraGrid.Columns.GridColumn E_Mail;
        private DevExpress.XtraGrid.Columns.GridColumn BankName;

    }
}