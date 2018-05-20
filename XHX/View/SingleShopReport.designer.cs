namespace XHX.View
{
    partial class SingleShopReport
    {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdShop = new DevExpress.XtraEditors.PanelControl();
            this.btnAreaSubject = new DevExpress.XtraEditors.SimpleButton();
            this.btnShopSubject = new DevExpress.XtraEditors.SimpleButton();
            this.btnShopCharter = new DevExpress.XtraEditors.SimpleButton();
            this.btnAreaCharter = new DevExpress.XtraEditors.SimpleButton();
            this.btnAllCharter = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboProjects = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnModule = new DevExpress.XtraEditors.ButtonEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.tbnFilePath = new DevExpress.XtraEditors.ButtonEdit();
            this.pbrProgress = new System.Windows.Forms.ProgressBar();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnGenerate = new DevExpress.XtraEditors.SimpleButton();
            this.grcShop = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcShopCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcShopName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboAreaCode = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.chkUseChk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnShopOrder = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).BeginInit();
            this.grdShop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjects.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnModule.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbnFilePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseChk)).BeginInit();
            this.SuspendLayout();
            // 
            // grdShop
            // 
            this.grdShop.Controls.Add(this.btnShopOrder);
            this.grdShop.Controls.Add(this.btnAreaSubject);
            this.grdShop.Controls.Add(this.btnShopSubject);
            this.grdShop.Controls.Add(this.btnShopCharter);
            this.grdShop.Controls.Add(this.btnAreaCharter);
            this.grdShop.Controls.Add(this.btnAllCharter);
            this.grdShop.Controls.Add(this.labelControl1);
            this.grdShop.Controls.Add(this.cboProjects);
            this.grdShop.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdShop.Location = new System.Drawing.Point(5, 5);
            this.grdShop.Margin = new System.Windows.Forms.Padding(0);
            this.grdShop.Name = "grdShop";
            this.grdShop.Size = new System.Drawing.Size(982, 42);
            this.grdShop.TabIndex = 11;
            // 
            // btnAreaSubject
            // 
            this.btnAreaSubject.Location = new System.Drawing.Point(703, -2);
            this.btnAreaSubject.Name = "btnAreaSubject";
            this.btnAreaSubject.Size = new System.Drawing.Size(109, 44);
            this.btnAreaSubject.TabIndex = 100;
            this.btnAreaSubject.Text = "区域体系得分";
            this.btnAreaSubject.Click += new System.EventHandler(this.btnAreaSubject_Click);
            // 
            // btnShopSubject
            // 
            this.btnShopSubject.Location = new System.Drawing.Point(568, -2);
            this.btnShopSubject.Name = "btnShopSubject";
            this.btnShopSubject.Size = new System.Drawing.Size(129, 44);
            this.btnShopSubject.TabIndex = 99;
            this.btnShopSubject.Text = "经销商体系得分";
            this.btnShopSubject.Click += new System.EventHandler(this.btnShopSubject_Click);
            // 
            // btnShopCharter
            // 
            this.btnShopCharter.Location = new System.Drawing.Point(432, -2);
            this.btnShopCharter.Name = "btnShopCharter";
            this.btnShopCharter.Size = new System.Drawing.Size(129, 44);
            this.btnShopCharter.TabIndex = 98;
            this.btnShopCharter.Text = "经销商环节得分";
            this.btnShopCharter.Click += new System.EventHandler(this.btnShopCharter_Click);
            // 
            // btnAreaCharter
            // 
            this.btnAreaCharter.Location = new System.Drawing.Point(317, -2);
            this.btnAreaCharter.Name = "btnAreaCharter";
            this.btnAreaCharter.Size = new System.Drawing.Size(109, 44);
            this.btnAreaCharter.TabIndex = 97;
            this.btnAreaCharter.Text = "区域环节得分";
            this.btnAreaCharter.Click += new System.EventHandler(this.btnAreaCharter_Click);
            // 
            // btnAllCharter
            // 
            this.btnAllCharter.Location = new System.Drawing.Point(196, -2);
            this.btnAllCharter.Name = "btnAllCharter";
            this.btnAllCharter.Size = new System.Drawing.Size(115, 45);
            this.btnAllCharter.TabIndex = 96;
            this.btnAllCharter.Text = "全国环节得分";
            this.btnAllCharter.Click += new System.EventHandler(this.btnAllCharter_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.Location = new System.Drawing.Point(24, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "项目名";
            // 
            // cboProjects
            // 
            this.cboProjects.Location = new System.Drawing.Point(71, 12);
            this.cboProjects.Name = "cboProjects";
            this.cboProjects.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProjects.Size = new System.Drawing.Size(100, 21);
            this.cboProjects.TabIndex = 12;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.btnModule);
            this.groupControl2.Controls.Add(this.simpleButton2);
            this.groupControl2.Controls.Add(this.simpleButton1);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.tbnFilePath);
            this.groupControl2.Controls.Add(this.pbrProgress);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.btnGenerate);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(5, 47);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(982, 98);
            this.groupControl2.TabIndex = 92;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.Location = new System.Drawing.Point(589, 25);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 14);
            this.labelControl2.TabIndex = 93;
            this.labelControl2.Text = "上传数据路径";
            // 
            // btnModule
            // 
            this.btnModule.EditValue = "";
            this.btnModule.Location = new System.Drawing.Point(667, 22);
            this.btnModule.Name = "btnModule";
            this.btnModule.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnModule.Size = new System.Drawing.Size(268, 21);
            this.btnModule.TabIndex = 92;
            this.btnModule.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnModule_ButtonClick);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(648, 49);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(129, 44);
            this.simpleButton2.TabIndex = 91;
            this.simpleButton2.Text = "不计分经销商设置";
            this.simpleButton2.Visible = false;
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(582, 49);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(60, 44);
            this.simpleButton1.TabIndex = 90;
            this.simpleButton1.Text = "查询";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl4.Location = new System.Drawing.Point(5, 24);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(84, 14);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "模板所在文件夹";
            // 
            // tbnFilePath
            // 
            this.tbnFilePath.EditValue = "";
            this.tbnFilePath.Location = new System.Drawing.Point(95, 21);
            this.tbnFilePath.Name = "tbnFilePath";
            this.tbnFilePath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tbnFilePath.Size = new System.Drawing.Size(481, 21);
            this.tbnFilePath.TabIndex = 1;
            this.tbnFilePath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.tbnFilePath_ButtonClick);
            // 
            // pbrProgress
            // 
            this.pbrProgress.Location = new System.Drawing.Point(64, 54);
            this.pbrProgress.Name = "pbrProgress";
            this.pbrProgress.Size = new System.Drawing.Size(391, 23);
            this.pbrProgress.TabIndex = 89;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Options.UseTextOptions = true;
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl5.Location = new System.Drawing.Point(5, 58);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "生成进度";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(461, 48);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(115, 45);
            this.btnGenerate.TabIndex = 88;
            this.btnGenerate.Text = "生成报告";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // grcShop
            // 
            this.grcShop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcShop.Location = new System.Drawing.Point(5, 145);
            this.grcShop.MainView = this.gridView1;
            this.grcShop.Name = "grcShop";
            this.grcShop.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboAreaCode,
            this.chkUseChk});
            this.grcShop.Size = new System.Drawing.Size(982, 405);
            this.grcShop.TabIndex = 93;
            this.grcShop.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcShopCode,
            this.gcShopName});
            this.gridView1.GridControl = this.grcShop;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gcShopCode
            // 
            this.gcShopCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcShopCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcShopCode.Caption = "经销商代码";
            this.gcShopCode.FieldName = "ShopCode";
            this.gcShopCode.Name = "gcShopCode";
            this.gcShopCode.OptionsColumn.AllowEdit = false;
            this.gcShopCode.OptionsColumn.AllowSize = false;
            this.gcShopCode.OptionsColumn.ReadOnly = true;
            this.gcShopCode.Visible = true;
            this.gcShopCode.VisibleIndex = 0;
            this.gcShopCode.Width = 207;
            // 
            // gcShopName
            // 
            this.gcShopName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcShopName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcShopName.Caption = "经销商名称";
            this.gcShopName.FieldName = "ShopName";
            this.gcShopName.Name = "gcShopName";
            this.gcShopName.OptionsColumn.AllowEdit = false;
            this.gcShopName.OptionsColumn.AllowSize = false;
            this.gcShopName.Visible = true;
            this.gcShopName.VisibleIndex = 1;
            this.gcShopName.Width = 347;
            // 
            // cboAreaCode
            // 
            this.cboAreaCode.AutoHeight = false;
            this.cboAreaCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAreaCode.Name = "cboAreaCode";
            // 
            // chkUseChk
            // 
            this.chkUseChk.AutoHeight = false;
            this.chkUseChk.Name = "chkUseChk";
            // 
            // btnShopOrder
            // 
            this.btnShopOrder.Location = new System.Drawing.Point(820, 0);
            this.btnShopOrder.Name = "btnShopOrder";
            this.btnShopOrder.Size = new System.Drawing.Size(115, 45);
            this.btnShopOrder.TabIndex = 101;
            this.btnShopOrder.Text = "经销商排名";
            this.btnShopOrder.Click += new System.EventHandler(this.btnShopOrder_Click);
            // 
            // SingleShopReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grcShop);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.grdShop);
            this.Name = "SingleShopReport";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(992, 555);
            ((System.ComponentModel.ISupportInitialize)(this.grdShop)).EndInit();
            this.grdShop.ResumeLayout(false);
            this.grdShop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjects.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnModule.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbnFilePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseChk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl grdShop;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboProjects;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ButtonEdit tbnFilePath;
        private System.Windows.Forms.ProgressBar pbrProgress;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnGenerate;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl grcShop;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcShopCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcShopName;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkUseChk;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboAreaCode;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ButtonEdit btnModule;
        private DevExpress.XtraEditors.SimpleButton btnAreaSubject;
        private DevExpress.XtraEditors.SimpleButton btnShopSubject;
        private DevExpress.XtraEditors.SimpleButton btnShopCharter;
        private DevExpress.XtraEditors.SimpleButton btnAreaCharter;
        private DevExpress.XtraEditors.SimpleButton btnAllCharter;
        private DevExpress.XtraEditors.SimpleButton btnShopOrder;
    }
}
