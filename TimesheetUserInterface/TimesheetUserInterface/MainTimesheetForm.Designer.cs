namespace TimesheetUserInterface
{
    partial class MainTimesheetForm
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
            BaseForm.ColorPalette colorPalette1 = new BaseForm.ColorPalette();
            BaseForm.ColorPalette colorPalette2 = new BaseForm.ColorPalette();
            BaseForm.ColorPalette colorPalette3 = new BaseForm.ColorPalette();
            this.btnDelete = new BaseForm.TSButton();
            this.lstTimeSheets = new BaseForm.TSListBox();
            this.btnAddProject = new BaseForm.TSButton();
            this.gListFunctions = new BaseForm.GListBox();
            this.gListActivities = new BaseForm.GListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tsCalendar = new BaseForm.TSCalendar();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.gListProjects = new BaseForm.GListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gListRole = new BaseForm.GListBox();
            this.gListAdditional = new BaseForm.GListBox();
            this.btnAddEntry = new BaseForm.TSButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gListDomains = new BaseForm.GListBox();
            this.btnUpdate = new BaseForm.TSButton();
            this.baseControl1 = new BaseForm.BaseControl();
            this.label9 = new System.Windows.Forms.Label();
            this.baseControl2 = new BaseForm.BaseControl();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnSuggestion = new BaseForm.TSButton();
            this.tsButton1 = new BaseForm.TSButton();
            this.tsButton2 = new BaseForm.TSButton();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.btnDelete.BackColorSwatch = BaseForm.Swatch.Shade1;
            this.btnDelete.BorderPaint = true;
            this.btnDelete.BorderSwatch = BaseForm.Swatch.Shade2;
            this.btnDelete.BorderWidth = 1;
            this.btnDelete.ClickSwatch = BaseForm.Swatch.Tint1;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.HoverSwatch = BaseForm.Swatch.Primary;
            this.btnDelete.Location = new System.Drawing.Point(1082, 311);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PaintOnlyTop = false;
            this.btnDelete.Size = new System.Drawing.Size(155, 30);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete Entry";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lstTimeSheets
            // 
            this.lstTimeSheets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTimeSheets.BackColor = System.Drawing.Color.White;
            this.lstTimeSheets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTimeSheets.BorderSwatch = BaseForm.Swatch.Shade1;
            this.lstTimeSheets.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstTimeSheets.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTimeSheets.IntegralHeight = false;
            this.lstTimeSheets.ItemHeight = 17;
            this.lstTimeSheets.Location = new System.Drawing.Point(15, 347);
            this.lstTimeSheets.Name = "lstTimeSheets";
            this.lstTimeSheets.Size = new System.Drawing.Size(1222, 391);
            this.lstTimeSheets.Sorted = true;
            this.lstTimeSheets.TabIndex = 2;
            this.lstTimeSheets.SelectedIndexChanged += new System.EventHandler(this.lstTimeSheets_SelectedIndexChanged);
            this.lstTimeSheets.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstTimeSheets_MouseDown);
            this.lstTimeSheets.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstTimeSheets_MouseUp);
            // 
            // btnAddProject
            // 
            this.btnAddProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.btnAddProject.BackColorSwatch = BaseForm.Swatch.Shade1;
            this.btnAddProject.BorderPaint = true;
            this.btnAddProject.BorderSwatch = BaseForm.Swatch.Shade1;
            this.btnAddProject.BorderWidth = 1;
            this.btnAddProject.ClickSwatch = BaseForm.Swatch.Tint1;
            this.btnAddProject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProject.ForeColor = System.Drawing.Color.White;
            this.btnAddProject.HoverSwatch = BaseForm.Swatch.Primary;
            this.btnAddProject.Location = new System.Drawing.Point(423, 311);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.PaintOnlyTop = false;
            this.btnAddProject.Size = new System.Drawing.Size(188, 30);
            this.btnAddProject.TabIndex = 5;
            this.btnAddProject.Text = "Edit Poject List";
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // gListFunctions
            // 
            this.gListFunctions.BackColor = System.Drawing.Color.White;
            this.gListFunctions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListFunctions.BorderSwatch = BaseForm.Swatch.Shade1;
            this.gListFunctions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.gListFunctions.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gListFunctions.FormattingEnabled = true;
            this.gListFunctions.ItemHeight = 16;
            this.gListFunctions.Location = new System.Drawing.Point(249, 165);
            this.gListFunctions.Margin = new System.Windows.Forms.Padding(3, 3, 7, 7);
            this.gListFunctions.Name = "gListFunctions";
            this.gListFunctions.Size = new System.Drawing.Size(161, 176);
            this.gListFunctions.TabIndex = 7;
            this.gListFunctions.Click += new System.EventHandler(this.gListFunctions_Click);
            this.gListFunctions.SelectedIndexChanged += new System.EventHandler(this.gListFunctions_SelectedIndexChanged);
            // 
            // gListActivities
            // 
            this.gListActivities.BackColor = System.Drawing.Color.White;
            this.gListActivities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListActivities.BorderSwatch = BaseForm.Swatch.Shade1;
            this.gListActivities.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gListActivities.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gListActivities.FormattingEnabled = true;
            this.gListActivities.ItemHeight = 16;
            this.gListActivities.Location = new System.Drawing.Point(749, 53);
            this.gListActivities.Margin = new System.Windows.Forms.Padding(3, 3, 7, 7);
            this.gListActivities.Name = "gListActivities";
            this.gListActivities.Size = new System.Drawing.Size(170, 288);
            this.gListActivities.Sorted = true;
            this.gListActivities.TabIndex = 8;
            this.gListActivities.Click += new System.EventHandler(this.gListActivities_Click);
            this.gListActivities.SelectedIndexChanged += new System.EventHandler(this.gListActivities_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label2.Location = new System.Drawing.Point(249, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Domain:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label3.Location = new System.Drawing.Point(746, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Activity:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tsCalendar
            // 
            this.tsCalendar.BorderPaint = true;
            this.tsCalendar.BorderSwatch = BaseForm.Swatch.Shade1;
            this.tsCalendar.BorderWidth = 1;
            this.tsCalendar.CurrentDate = new System.DateTime(2016, 6, 14, 0, 0, 0, 0);
            this.tsCalendar.DisplayDate = new System.DateTime(2016, 6, 1, 0, 0, 0, 0);
            this.tsCalendar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsCalendar.Location = new System.Drawing.Point(12, 69);
            this.tsCalendar.Name = "tsCalendar";
            this.tsCalendar.PaintOnlyTop = false;
            this.tsCalendar.Size = new System.Drawing.Size(224, 157);
            this.tsCalendar.TabIndex = 9;
            this.tsCalendar.Text = "tsCalendar";
            this.tsCalendar.Click += new System.EventHandler(this.tsCalendar_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.White;
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(116, 40);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown1.TabIndex = 10;
            this.numericUpDown1.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label4.Location = new System.Drawing.Point(12, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date and Hours:";
            // 
            // gListProjects
            // 
            this.gListProjects.BackColor = System.Drawing.Color.White;
            this.gListProjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListProjects.BorderSwatch = BaseForm.Swatch.Shade1;
            this.gListProjects.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gListProjects.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gListProjects.FormattingEnabled = true;
            this.gListProjects.ItemHeight = 16;
            this.gListProjects.Location = new System.Drawing.Point(420, 53);
            this.gListProjects.Margin = new System.Windows.Forms.Padding(3, 3, 7, 7);
            this.gListProjects.Name = "gListProjects";
            this.gListProjects.Size = new System.Drawing.Size(191, 256);
            this.gListProjects.Sorted = true;
            this.gListProjects.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label5.Location = new System.Drawing.Point(420, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Project:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gListRole
            // 
            this.gListRole.BackColor = System.Drawing.Color.White;
            this.gListRole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListRole.BorderSwatch = BaseForm.Swatch.Shade1;
            this.gListRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gListRole.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gListRole.FormattingEnabled = true;
            this.gListRole.ItemHeight = 16;
            this.gListRole.Location = new System.Drawing.Point(621, 53);
            this.gListRole.Margin = new System.Windows.Forms.Padding(3, 3, 7, 7);
            this.gListRole.Name = "gListRole";
            this.gListRole.Size = new System.Drawing.Size(118, 96);
            this.gListRole.TabIndex = 12;
            this.gListRole.Click += new System.EventHandler(this.gListRole_Click);
            this.gListRole.SelectedIndexChanged += new System.EventHandler(this.gListRole_SelectedIndexChanged);
            // 
            // gListAdditional
            // 
            this.gListAdditional.BackColor = System.Drawing.Color.White;
            this.gListAdditional.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListAdditional.BorderSwatch = BaseForm.Swatch.Shade1;
            this.gListAdditional.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gListAdditional.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gListAdditional.FormattingEnabled = true;
            this.gListAdditional.ItemHeight = 16;
            this.gListAdditional.Location = new System.Drawing.Point(929, 53);
            this.gListAdditional.Margin = new System.Windows.Forms.Padding(3, 3, 7, 7);
            this.gListAdditional.Name = "gListAdditional";
            this.gListAdditional.Size = new System.Drawing.Size(141, 288);
            this.gListAdditional.Sorted = true;
            this.gListAdditional.TabIndex = 13;
            this.gListAdditional.Click += new System.EventHandler(this.gListAdditional_Click);
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.btnAddEntry.BackColorSwatch = BaseForm.Swatch.Shade1;
            this.btnAddEntry.BorderPaint = true;
            this.btnAddEntry.BorderSwatch = BaseForm.Swatch.Shade1;
            this.btnAddEntry.BorderWidth = 1;
            this.btnAddEntry.ClickSwatch = BaseForm.Swatch.Tint1;
            this.btnAddEntry.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEntry.ForeColor = System.Drawing.Color.White;
            this.btnAddEntry.HoverSwatch = BaseForm.Swatch.Primary;
            this.btnAddEntry.Location = new System.Drawing.Point(1080, 168);
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.PaintOnlyTop = false;
            this.btnAddEntry.Size = new System.Drawing.Size(155, 30);
            this.btnAddEntry.TabIndex = 15;
            this.btnAddEntry.Text = "Add Entry";
            this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label1.Location = new System.Drawing.Point(618, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Role/Function:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label6.Location = new System.Drawing.Point(246, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Specify:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtComments
            // 
            this.txtComments.BackColor = System.Drawing.Color.White;
            this.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtComments.Location = new System.Drawing.Point(1081, 54);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(153, 107);
            this.txtComments.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label7.Location = new System.Drawing.Point(1078, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Comments:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label8.Location = new System.Drawing.Point(926, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Specify:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gListDomains
            // 
            this.gListDomains.BackColor = System.Drawing.Color.White;
            this.gListDomains.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gListDomains.BorderSwatch = BaseForm.Swatch.Shade1;
            this.gListDomains.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.gListDomains.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gListDomains.FormattingEnabled = true;
            this.gListDomains.ItemHeight = 16;
            this.gListDomains.Location = new System.Drawing.Point(249, 53);
            this.gListDomains.Margin = new System.Windows.Forms.Padding(3, 3, 7, 7);
            this.gListDomains.Name = "gListDomains";
            colorPalette1.Palette = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(42)))), ((int)(((byte)(103))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(107)))), ((int)(((byte)(204))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(193)))), ((int)(((byte)(230))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(246)))))};
            colorPalette1.Primary = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(107)))), ((int)(((byte)(204)))));
            colorPalette1.Shade1 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            colorPalette1.Shade2 = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(42)))), ((int)(((byte)(103)))));
            colorPalette1.Tint1 = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(193)))), ((int)(((byte)(230)))));
            colorPalette1.Tint2 = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(246)))));
            this.gListDomains.Palette = colorPalette1;
            this.gListDomains.Size = new System.Drawing.Size(161, 96);
            this.gListDomains.TabIndex = 4;
            this.gListDomains.Click += new System.EventHandler(this.gListDomains_Click);
            this.gListDomains.SelectedIndexChanged += new System.EventHandler(this.gListDomains_SelectedIndexChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.btnUpdate.BackColorSwatch = BaseForm.Swatch.Shade1;
            this.btnUpdate.BorderPaint = true;
            this.btnUpdate.BorderSwatch = BaseForm.Swatch.Shade1;
            this.btnUpdate.BorderWidth = 1;
            this.btnUpdate.ClickSwatch = BaseForm.Swatch.Tint1;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.HoverSwatch = BaseForm.Swatch.Primary;
            this.btnUpdate.Location = new System.Drawing.Point(1080, 204);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.PaintOnlyTop = false;
            this.btnUpdate.Size = new System.Drawing.Size(155, 30);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "Update Entry";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // baseControl1
            // 
            this.baseControl1.BorderPaint = true;
            this.baseControl1.BorderSwatch = BaseForm.Swatch.Primary;
            this.baseControl1.BorderWidth = 1;
            this.baseControl1.Location = new System.Drawing.Point(1080, 53);
            this.baseControl1.Name = "baseControl1";
            this.baseControl1.PaintOnlyTop = false;
            this.baseControl1.Size = new System.Drawing.Size(155, 109);
            this.baseControl1.TabIndex = 19;
            this.baseControl1.Text = "baseControl1";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.label9.Location = new System.Drawing.Point(12, 229);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(224, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Description:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // baseControl2
            // 
            this.baseControl2.BorderPaint = true;
            this.baseControl2.BorderSwatch = BaseForm.Swatch.Shade1;
            this.baseControl2.BorderWidth = 1;
            this.baseControl2.Location = new System.Drawing.Point(12, 245);
            this.baseControl2.Name = "baseControl2";
            this.baseControl2.PaintOnlyTop = true;
            this.baseControl2.Size = new System.Drawing.Size(224, 2);
            this.baseControl2.TabIndex = 21;
            this.baseControl2.Text = "baseControl2";
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.lblDescription.Location = new System.Drawing.Point(12, 250);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(224, 91);
            this.lblDescription.TabIndex = 22;
            // 
            // btnSuggestion
            // 
            this.btnSuggestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSuggestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.btnSuggestion.BackColorSwatch = BaseForm.Swatch.Shade1;
            this.btnSuggestion.BorderPaint = true;
            this.btnSuggestion.BorderSwatch = BaseForm.Swatch.Shade1;
            this.btnSuggestion.BorderWidth = 1;
            this.btnSuggestion.ClickSwatch = BaseForm.Swatch.Tint1;
            this.btnSuggestion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuggestion.ForeColor = System.Drawing.Color.White;
            this.btnSuggestion.HoverSwatch = BaseForm.Swatch.Primary;
            this.btnSuggestion.Location = new System.Drawing.Point(1140, 744);
            this.btnSuggestion.Name = "btnSuggestion";
            this.btnSuggestion.PaintOnlyTop = false;
            this.btnSuggestion.Size = new System.Drawing.Size(97, 23);
            this.btnSuggestion.TabIndex = 23;
            this.btnSuggestion.Text = "Suggestion Box";
            this.btnSuggestion.Click += new System.EventHandler(this.btnSuggestion_Click);
            // 
            // tsButton1
            // 
            this.tsButton1.AccentColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.tsButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tsButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.tsButton1.BackColorSwatch = BaseForm.Swatch.Shade1;
            this.tsButton1.BorderPaint = true;
            this.tsButton1.BorderSwatch = BaseForm.Swatch.Shade1;
            this.tsButton1.BorderWidth = 1;
            this.tsButton1.ClickSwatch = BaseForm.Swatch.Tint1;
            this.tsButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsButton1.ForeColor = System.Drawing.Color.White;
            this.tsButton1.HoverSwatch = BaseForm.Swatch.Primary;
            this.tsButton1.Location = new System.Drawing.Point(1037, 744);
            this.tsButton1.MainColor = System.Drawing.Color.DarkBlue;
            this.tsButton1.Name = "tsButton1";
            this.tsButton1.PaintOnlyTop = false;
            colorPalette2.Palette = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(42)))), ((int)(((byte)(103))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(107)))), ((int)(((byte)(204))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(193)))), ((int)(((byte)(230))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(246)))))};
            colorPalette2.Primary = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(107)))), ((int)(((byte)(204)))));
            colorPalette2.Shade1 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            colorPalette2.Shade2 = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(42)))), ((int)(((byte)(103)))));
            colorPalette2.Tint1 = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(193)))), ((int)(((byte)(230)))));
            colorPalette2.Tint2 = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(246)))));
            this.tsButton1.Palette = colorPalette2;
            this.tsButton1.SecondaryColor = System.Drawing.Color.AliceBlue;
            this.tsButton1.Size = new System.Drawing.Size(97, 23);
            this.tsButton1.TabIndex = 24;
            this.tsButton1.Text = "Coming Soon";
            this.tsButton1.Click += new System.EventHandler(this.tsButton1_Click);
            // 
            // tsButton2
            // 
            this.tsButton2.AccentColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.tsButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tsButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.tsButton2.BackColorSwatch = BaseForm.Swatch.Shade1;
            this.tsButton2.BorderPaint = true;
            this.tsButton2.BorderSwatch = BaseForm.Swatch.Shade1;
            this.tsButton2.BorderWidth = 1;
            this.tsButton2.ClickSwatch = BaseForm.Swatch.Tint1;
            this.tsButton2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsButton2.ForeColor = System.Drawing.Color.White;
            this.tsButton2.HoverSwatch = BaseForm.Swatch.Primary;
            this.tsButton2.Location = new System.Drawing.Point(934, 744);
            this.tsButton2.MainColor = System.Drawing.Color.DarkBlue;
            this.tsButton2.Name = "tsButton2";
            this.tsButton2.PaintOnlyTop = false;
            colorPalette3.Palette = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(42)))), ((int)(((byte)(103))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(107)))), ((int)(((byte)(204))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(193)))), ((int)(((byte)(230))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(246)))))};
            colorPalette3.Primary = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(107)))), ((int)(((byte)(204)))));
            colorPalette3.Shade1 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            colorPalette3.Shade2 = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(42)))), ((int)(((byte)(103)))));
            colorPalette3.Tint1 = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(193)))), ((int)(((byte)(230)))));
            colorPalette3.Tint2 = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(246)))));
            this.tsButton2.Palette = colorPalette3;
            this.tsButton2.SecondaryColor = System.Drawing.Color.AliceBlue;
            this.tsButton2.Size = new System.Drawing.Size(97, 23);
            this.tsButton2.TabIndex = 24;
            this.tsButton2.Text = "Coming Soon";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(66)))), ((int)(((byte)(160)))));
            this.lblStatus.Location = new System.Drawing.Point(12, 746);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(76, 13);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Hours Today:";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainTimesheetForm
            // 
            this.AccentColor = System.Drawing.Color.DodgerBlue;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BorderWidth = 2;
            this.ClientSize = new System.Drawing.Size(1247, 768);
            this.Controls.Add(this.tsButton2);
            this.Controls.Add(this.tsButton1);
            this.Controls.Add(this.btnSuggestion);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.baseControl2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddEntry);
            this.Controls.Add(this.gListProjects);
            this.Controls.Add(this.gListAdditional);
            this.Controls.Add(this.gListRole);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.tsCalendar);
            this.Controls.Add(this.gListActivities);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddProject);
            this.Controls.Add(this.gListDomains);
            this.Controls.Add(this.lstTimeSheets);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.gListFunctions);
            this.Controls.Add(this.baseControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(89)))), ((int)(((byte)(158)))));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainTimesheetForm";
            this.SecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(255)))));
            this.Text = "G5 Engineering Timesheets";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseForm.TSButton btnDelete;
        private BaseForm.TSListBox lstTimeSheets;
        private BaseForm.TSButton btnAddProject;
        private BaseForm.GListBox gListFunctions;
        private BaseForm.GListBox gListActivities;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private BaseForm.TSCalendar tsCalendar;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private BaseForm.GListBox gListProjects;
        private System.Windows.Forms.Label label5;
        private BaseForm.GListBox gListRole;
        private BaseForm.GListBox gListAdditional;
        private BaseForm.TSButton btnAddEntry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private BaseForm.GListBox gListDomains;
        private BaseForm.TSButton btnUpdate;
        private BaseForm.BaseControl baseControl1;
        private System.Windows.Forms.Label label9;
        private BaseForm.BaseControl baseControl2;
        private System.Windows.Forms.Label lblDescription;
        private BaseForm.TSButton btnSuggestion;
        private BaseForm.TSButton tsButton1;
        private BaseForm.TSButton tsButton2;
        private System.Windows.Forms.Label lblStatus;

    }
}