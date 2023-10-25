using System.Windows.Forms;

namespace DataRestorationTool
{
    partial class MyPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyPluginControl));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_LoadAudit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_RestoreData = new System.Windows.Forms.ToolStripButton();
            this.combo_Tables = new System.Windows.Forms.ComboBox();
            this.label_Table = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_RetrieveAll = new System.Windows.Forms.CheckBox();
            this.lbl_RetrieveAll = new System.Windows.Forms.Label();
            this.btn_DeselectAll = new System.Windows.Forms.Button();
            this.btn_SelectAll = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_DateTo = new System.Windows.Forms.Label();
            this.dateTime_To = new System.Windows.Forms.DateTimePicker();
            this.label_DateFrom = new System.Windows.Forms.Label();
            this.dateTime_From = new System.Windows.Forms.DateTimePicker();
            this.label_DateRange = new System.Windows.Forms.Label();
            this.dataGrid_DeletedRecords = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pb_Tooltip = new System.Windows.Forms.PictureBox();
            this.cb_ContinueOnError = new System.Windows.Forms.CheckBox();
            this.lbl_ContinueOnError = new System.Windows.Forms.Label();
            this.cb_ReuseGUID = new System.Windows.Forms.CheckBox();
            this.lbl_ReuseRecordID = new System.Windows.Forms.Label();
            this.cb_PAFlow = new System.Windows.Forms.CheckBox();
            this.cb_PlgnExec = new System.Windows.Forms.CheckBox();
            this.lbl_ByPassPA = new System.Windows.Forms.Label();
            this.lbl_ByPassPlgn = new System.Windows.Forms.Label();
            this.lbl_AdvSettings = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGrid_Details = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deletionDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deletedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.auditItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fieldNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deletedFieldBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_DeletedRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Tooltip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Details)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.auditItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deletedFieldBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.tsb_LoadAudit,
            this.toolStripSeparator1,
            this.tsb_RestoreData});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(1212, 31);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(40, 28);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsb_LoadAudit
            // 
            this.tsb_LoadAudit.Enabled = false;
            this.tsb_LoadAudit.Image = global::DataRestorationTool.Properties.Resources.Load;
            this.tsb_LoadAudit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_LoadAudit.Name = "tsb_LoadAudit";
            this.tsb_LoadAudit.Size = new System.Drawing.Size(149, 28);
            this.tsb_LoadAudit.Text = "Load Deleted Records";
            this.tsb_LoadAudit.Click += new System.EventHandler(this.tsb_LoadAudit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsb_RestoreData
            // 
            this.tsb_RestoreData.Enabled = false;
            this.tsb_RestoreData.Image = global::DataRestorationTool.Properties.Resources.Restore;
            this.tsb_RestoreData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_RestoreData.Name = "tsb_RestoreData";
            this.tsb_RestoreData.Size = new System.Drawing.Size(148, 28);
            this.tsb_RestoreData.Text = "Restore Selected Data";
            this.tsb_RestoreData.Click += new System.EventHandler(this.tsb_RestoreData_Click);
            // 
            // combo_Tables
            // 
            this.combo_Tables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Tables.Enabled = false;
            this.combo_Tables.FormattingEnabled = true;
            this.combo_Tables.Location = new System.Drawing.Point(80, 10);
            this.combo_Tables.Name = "combo_Tables";
            this.combo_Tables.Size = new System.Drawing.Size(200, 21);
            this.combo_Tables.TabIndex = 5;
            // 
            // label_Table
            // 
            this.label_Table.AutoSize = true;
            this.label_Table.Location = new System.Drawing.Point(5, 15);
            this.label_Table.Name = "label_Table";
            this.label_Table.Size = new System.Drawing.Size(67, 13);
            this.label_Table.TabIndex = 6;
            this.label_Table.Text = "Select Table";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_RetrieveAll);
            this.groupBox1.Controls.Add(this.lbl_RetrieveAll);
            this.groupBox1.Controls.Add(this.btn_DeselectAll);
            this.groupBox1.Controls.Add(this.btn_SelectAll);
            this.groupBox1.Controls.Add(this.label_Table);
            this.groupBox1.Controls.Add(this.combo_Tables);
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(283, 98);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // cb_RetrieveAll
            // 
            this.cb_RetrieveAll.AutoSize = true;
            this.cb_RetrieveAll.Enabled = false;
            this.cb_RetrieveAll.Location = new System.Drawing.Point(110, 40);
            this.cb_RetrieveAll.Name = "cb_RetrieveAll";
            this.cb_RetrieveAll.Size = new System.Drawing.Size(15, 14);
            this.cb_RetrieveAll.TabIndex = 10;
            this.cb_RetrieveAll.UseVisualStyleBackColor = true;
            this.cb_RetrieveAll.CheckedChanged += new System.EventHandler(this.cb_RetrieveAll_CheckedChanged);
            // 
            // lbl_RetrieveAll
            // 
            this.lbl_RetrieveAll.AutoSize = true;
            this.lbl_RetrieveAll.Location = new System.Drawing.Point(5, 40);
            this.lbl_RetrieveAll.Name = "lbl_RetrieveAll";
            this.lbl_RetrieveAll.Size = new System.Drawing.Size(104, 13);
            this.lbl_RetrieveAll.TabIndex = 9;
            this.lbl_RetrieveAll.Text = "Retrieve All Records";
            // 
            // btn_DeselectAll
            // 
            this.btn_DeselectAll.Enabled = false;
            this.btn_DeselectAll.Location = new System.Drawing.Point(90, 70);
            this.btn_DeselectAll.Name = "btn_DeselectAll";
            this.btn_DeselectAll.Size = new System.Drawing.Size(75, 25);
            this.btn_DeselectAll.TabIndex = 8;
            this.btn_DeselectAll.Text = "Deselect All";
            this.btn_DeselectAll.UseVisualStyleBackColor = true;
            this.btn_DeselectAll.Click += new System.EventHandler(this.btn_DeselectAll_Click);
            // 
            // btn_SelectAll
            // 
            this.btn_SelectAll.Enabled = false;
            this.btn_SelectAll.Location = new System.Drawing.Point(10, 70);
            this.btn_SelectAll.Name = "btn_SelectAll";
            this.btn_SelectAll.Size = new System.Drawing.Size(75, 25);
            this.btn_SelectAll.TabIndex = 7;
            this.btn_SelectAll.Text = "Select All";
            this.btn_SelectAll.UseVisualStyleBackColor = true;
            this.btn_SelectAll.Click += new System.EventHandler(this.btn_SelectAll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label_DateTo);
            this.groupBox2.Controls.Add(this.dateTime_To);
            this.groupBox2.Controls.Add(this.label_DateFrom);
            this.groupBox2.Controls.Add(this.dateTime_From);
            this.groupBox2.Controls.Add(this.label_DateRange);
            this.groupBox2.Location = new System.Drawing.Point(286, 1);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox2.Size = new System.Drawing.Size(169, 98);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // label_DateTo
            // 
            this.label_DateTo.AutoSize = true;
            this.label_DateTo.Location = new System.Drawing.Point(15, 65);
            this.label_DateTo.Name = "label_DateTo";
            this.label_DateTo.Size = new System.Drawing.Size(20, 13);
            this.label_DateTo.TabIndex = 10;
            this.label_DateTo.Text = "To";
            // 
            // dateTime_To
            // 
            this.dateTime_To.Enabled = false;
            this.dateTime_To.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTime_To.Location = new System.Drawing.Point(50, 62);
            this.dateTime_To.Name = "dateTime_To";
            this.dateTime_To.Size = new System.Drawing.Size(100, 20);
            this.dateTime_To.TabIndex = 2;
            // 
            // label_DateFrom
            // 
            this.label_DateFrom.AutoSize = true;
            this.label_DateFrom.Location = new System.Drawing.Point(15, 40);
            this.label_DateFrom.Name = "label_DateFrom";
            this.label_DateFrom.Size = new System.Drawing.Size(30, 13);
            this.label_DateFrom.TabIndex = 9;
            this.label_DateFrom.Text = "From";
            // 
            // dateTime_From
            // 
            this.dateTime_From.Enabled = false;
            this.dateTime_From.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTime_From.Location = new System.Drawing.Point(50, 37);
            this.dateTime_From.Name = "dateTime_From";
            this.dateTime_From.Size = new System.Drawing.Size(100, 20);
            this.dateTime_From.TabIndex = 1;
            // 
            // label_DateRange
            // 
            this.label_DateRange.AutoSize = true;
            this.label_DateRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DateRange.Location = new System.Drawing.Point(10, 15);
            this.label_DateRange.Name = "label_DateRange";
            this.label_DateRange.Size = new System.Drawing.Size(94, 17);
            this.label_DateRange.TabIndex = 0;
            this.label_DateRange.Text = "Date Range";
            // 
            // dataGrid_DeletedRecords
            // 
            this.dataGrid_DeletedRecords.AllowUserToAddRows = false;
            this.dataGrid_DeletedRecords.AllowUserToDeleteRows = false;
            this.dataGrid_DeletedRecords.AutoGenerateColumns = false;
            this.dataGrid_DeletedRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid_DeletedRecords.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGrid_DeletedRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_DeletedRecords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.nameDataGridViewTextBoxColumn,
            this.tableDataGridViewTextBoxColumn,
            this.deletionDateDataGridViewTextBoxColumn,
            this.deletedByDataGridViewTextBoxColumn});
            this.dataGrid_DeletedRecords.DataSource = this.auditItemBindingSource;
            this.dataGrid_DeletedRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_DeletedRecords.Location = new System.Drawing.Point(0, 0);
            this.dataGrid_DeletedRecords.Name = "dataGrid_DeletedRecords";
            this.dataGrid_DeletedRecords.ReadOnly = true;
            this.dataGrid_DeletedRecords.RowHeadersVisible = false;
            this.dataGrid_DeletedRecords.RowHeadersWidth = 102;
            this.dataGrid_DeletedRecords.Size = new System.Drawing.Size(610, 510);
            this.dataGrid_DeletedRecords.TabIndex = 9;
            this.dataGrid_DeletedRecords.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_DeletedRecords_CellContentClick);
            // 
            // Select
            // 
            this.Select.FillWeight = 20F;
            this.Select.HeaderText = "";
            this.Select.MinimumWidth = 12;
            this.Select.Name = "Select";
            this.Select.ReadOnly = true;
            this.Select.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.FillWeight = 200F;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Record";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1212, 612);
            this.splitContainer1.SplitterDistance = 100;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pb_Tooltip);
            this.groupBox3.Controls.Add(this.cb_ContinueOnError);
            this.groupBox3.Controls.Add(this.lbl_ContinueOnError);
            this.groupBox3.Controls.Add(this.cb_ReuseGUID);
            this.groupBox3.Controls.Add(this.lbl_ReuseRecordID);
            this.groupBox3.Controls.Add(this.cb_PAFlow);
            this.groupBox3.Controls.Add(this.cb_PlgnExec);
            this.groupBox3.Controls.Add(this.lbl_ByPassPA);
            this.groupBox3.Controls.Add(this.lbl_ByPassPlgn);
            this.groupBox3.Controls.Add(this.lbl_AdvSettings);
            this.groupBox3.Location = new System.Drawing.Point(460, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox3.Size = new System.Drawing.Size(350, 98);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // pb_Tooltip
            // 
            this.pb_Tooltip.Image = global::DataRestorationTool.Properties.Resources.info;
            this.pb_Tooltip.InitialImage = global::DataRestorationTool.Properties.Resources.info;
            this.pb_Tooltip.Location = new System.Drawing.Point(153, 14);
            this.pb_Tooltip.Name = "pb_Tooltip";
            this.pb_Tooltip.Size = new System.Drawing.Size(17, 17);
            this.pb_Tooltip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Tooltip.TabIndex = 9;
            this.pb_Tooltip.TabStop = false;
            this.toolTip1.SetToolTip(this.pb_Tooltip, resources.GetString("pb_Tooltip.ToolTip"));
            // 
            // cb_ContinueOnError
            // 
            this.cb_ContinueOnError.AutoSize = true;
            this.cb_ContinueOnError.Location = new System.Drawing.Point(315, 65);
            this.cb_ContinueOnError.Name = "cb_ContinueOnError";
            this.cb_ContinueOnError.Size = new System.Drawing.Size(15, 14);
            this.cb_ContinueOnError.TabIndex = 8;
            this.cb_ContinueOnError.UseVisualStyleBackColor = true;
            // 
            // lbl_ContinueOnError
            // 
            this.lbl_ContinueOnError.AutoSize = true;
            this.lbl_ContinueOnError.Location = new System.Drawing.Point(205, 65);
            this.lbl_ContinueOnError.Name = "lbl_ContinueOnError";
            this.lbl_ContinueOnError.Size = new System.Drawing.Size(89, 13);
            this.lbl_ContinueOnError.TabIndex = 7;
            this.lbl_ContinueOnError.Text = "Continue on Error";
            // 
            // cb_ReuseGUID
            // 
            this.cb_ReuseGUID.AutoSize = true;
            this.cb_ReuseGUID.Location = new System.Drawing.Point(315, 40);
            this.cb_ReuseGUID.Name = "cb_ReuseGUID";
            this.cb_ReuseGUID.Size = new System.Drawing.Size(15, 14);
            this.cb_ReuseGUID.TabIndex = 6;
            this.cb_ReuseGUID.UseVisualStyleBackColor = true;
            // 
            // lbl_ReuseRecordID
            // 
            this.lbl_ReuseRecordID.AutoSize = true;
            this.lbl_ReuseRecordID.Location = new System.Drawing.Point(205, 40);
            this.lbl_ReuseRecordID.Name = "lbl_ReuseRecordID";
            this.lbl_ReuseRecordID.Size = new System.Drawing.Size(106, 13);
            this.lbl_ReuseRecordID.TabIndex = 5;
            this.lbl_ReuseRecordID.Text = "Reuse deleted GUID";
            // 
            // cb_PAFlow
            // 
            this.cb_PAFlow.AutoSize = true;
            this.cb_PAFlow.Checked = true;
            this.cb_PAFlow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_PAFlow.Location = new System.Drawing.Point(175, 65);
            this.cb_PAFlow.Name = "cb_PAFlow";
            this.cb_PAFlow.Size = new System.Drawing.Size(15, 14);
            this.cb_PAFlow.TabIndex = 4;
            this.cb_PAFlow.UseVisualStyleBackColor = true;
            // 
            // cb_PlgnExec
            // 
            this.cb_PlgnExec.AutoSize = true;
            this.cb_PlgnExec.Checked = true;
            this.cb_PlgnExec.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_PlgnExec.Location = new System.Drawing.Point(175, 40);
            this.cb_PlgnExec.Name = "cb_PlgnExec";
            this.cb_PlgnExec.Size = new System.Drawing.Size(15, 14);
            this.cb_PlgnExec.TabIndex = 3;
            this.cb_PlgnExec.UseVisualStyleBackColor = true;
            // 
            // lbl_ByPassPA
            // 
            this.lbl_ByPassPA.AutoSize = true;
            this.lbl_ByPassPA.Location = new System.Drawing.Point(8, 65);
            this.lbl_ByPassPA.Name = "lbl_ByPassPA";
            this.lbl_ByPassPA.Size = new System.Drawing.Size(148, 13);
            this.lbl_ByPassPA.TabIndex = 2;
            this.lbl_ByPassPA.Text = "ByPass Power Automate Flow";
            // 
            // lbl_ByPassPlgn
            // 
            this.lbl_ByPassPlgn.AutoSize = true;
            this.lbl_ByPassPlgn.Location = new System.Drawing.Point(8, 40);
            this.lbl_ByPassPlgn.Name = "lbl_ByPassPlgn";
            this.lbl_ByPassPlgn.Size = new System.Drawing.Size(162, 13);
            this.lbl_ByPassPlgn.TabIndex = 1;
            this.lbl_ByPassPlgn.Text = "ByPass Custom Plugin Execution";
            // 
            // lbl_AdvSettings
            // 
            this.lbl_AdvSettings.AutoSize = true;
            this.lbl_AdvSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AdvSettings.Location = new System.Drawing.Point(10, 15);
            this.lbl_AdvSettings.Name = "lbl_AdvSettings";
            this.lbl_AdvSettings.Size = new System.Drawing.Size(143, 17);
            this.lbl_AdvSettings.TabIndex = 0;
            this.lbl_AdvSettings.Text = "Advanced Settings";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(1);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGrid_DeletedRecords);
            this.splitContainer2.Panel1MinSize = 601;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGrid_Details);
            this.splitContainer2.Size = new System.Drawing.Size(1212, 510);
            this.splitContainer2.SplitterDistance = 610;
            this.splitContainer2.TabIndex = 11;
            // 
            // dataGrid_Details
            // 
            this.dataGrid_Details.AllowUserToAddRows = false;
            this.dataGrid_Details.AllowUserToDeleteRows = false;
            this.dataGrid_Details.AutoGenerateColumns = false;
            this.dataGrid_Details.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid_Details.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGrid_Details.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Details.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fieldNameDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.dataGrid_Details.DataSource = this.deletedFieldBindingSource;
            this.dataGrid_Details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_Details.Location = new System.Drawing.Point(0, 0);
            this.dataGrid_Details.Name = "dataGrid_Details";
            this.dataGrid_Details.ReadOnly = true;
            this.dataGrid_Details.RowHeadersVisible = false;
            this.dataGrid_Details.RowHeadersWidth = 102;
            this.dataGrid_Details.Size = new System.Drawing.Size(598, 510);
            this.dataGrid_Details.TabIndex = 10;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.Tag = "";
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Advanced Settings Information";
            // 
            // tableDataGridViewTextBoxColumn
            // 
            this.tableDataGridViewTextBoxColumn.DataPropertyName = "Table";
            this.tableDataGridViewTextBoxColumn.FillWeight = 90F;
            this.tableDataGridViewTextBoxColumn.HeaderText = "Table";
            this.tableDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.tableDataGridViewTextBoxColumn.Name = "tableDataGridViewTextBoxColumn";
            this.tableDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deletionDateDataGridViewTextBoxColumn
            // 
            this.deletionDateDataGridViewTextBoxColumn.DataPropertyName = "DeletionDate";
            this.deletionDateDataGridViewTextBoxColumn.FillWeight = 90F;
            this.deletionDateDataGridViewTextBoxColumn.HeaderText = "Deleted On";
            this.deletionDateDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.deletionDateDataGridViewTextBoxColumn.Name = "deletionDateDataGridViewTextBoxColumn";
            this.deletionDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deletedByDataGridViewTextBoxColumn
            // 
            this.deletedByDataGridViewTextBoxColumn.DataPropertyName = "DeletedBy";
            this.deletedByDataGridViewTextBoxColumn.FillWeight = 90F;
            this.deletedByDataGridViewTextBoxColumn.HeaderText = "Deleted By";
            this.deletedByDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.deletedByDataGridViewTextBoxColumn.Name = "deletedByDataGridViewTextBoxColumn";
            this.deletedByDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // auditItemBindingSource
            // 
            this.auditItemBindingSource.DataSource = typeof(DataRestorationTool.Model.AuditItem);
            // 
            // fieldNameDataGridViewTextBoxColumn
            // 
            this.fieldNameDataGridViewTextBoxColumn.DataPropertyName = "FieldName";
            this.fieldNameDataGridViewTextBoxColumn.FillWeight = 30F;
            this.fieldNameDataGridViewTextBoxColumn.HeaderText = "Field";
            this.fieldNameDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.fieldNameDataGridViewTextBoxColumn.Name = "fieldNameDataGridViewTextBoxColumn";
            this.fieldNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deletedFieldBindingSource
            // 
            this.deletedFieldBindingSource.DataSource = typeof(DataRestorationTool.Model.DeletedField);
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "MyPluginControl";
            this.PluginIcon = ((System.Drawing.Icon)(resources.GetObject("$this.PluginIcon")));
            this.Size = new System.Drawing.Size(1212, 643);
            this.TabIcon = global::DataRestorationTool.Properties.Resources.C3K32x321;
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_DeletedRecords)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Tooltip)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Details)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.auditItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deletedFieldBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.ComboBox combo_Tables;
        private System.Windows.Forms.Label label_Table;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_DateRange;
        private System.Windows.Forms.DateTimePicker dateTime_From;
        private System.Windows.Forms.DateTimePicker dateTime_To;
        private System.Windows.Forms.Label label_DateFrom;
        private System.Windows.Forms.Label label_DateTo;
        private System.Windows.Forms.ToolStripButton tsb_LoadAudit;
        private System.Windows.Forms.DataGridView dataGrid_DeletedRecords;
        private System.Windows.Forms.BindingSource auditItemBindingSource;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.BindingSource deletedFieldBindingSource;
        private System.Windows.Forms.DataGridView dataGrid_Details;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewLinkColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deletionDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deletedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsb_RestoreData;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_AdvSettings;
        private System.Windows.Forms.Label lbl_ByPassPlgn;
        private System.Windows.Forms.Label lbl_ByPassPA;
        private System.Windows.Forms.CheckBox cb_PlgnExec;
        private System.Windows.Forms.CheckBox cb_PAFlow;
        private System.Windows.Forms.Button btn_SelectAll;
        private System.Windows.Forms.Button btn_DeselectAll;
        private System.Windows.Forms.Label lbl_ReuseRecordID;
        private System.Windows.Forms.CheckBox cb_ReuseGUID;
        private System.Windows.Forms.Label lbl_ContinueOnError;
        private System.Windows.Forms.CheckBox cb_ContinueOnError;
        private ToolTip toolTip1;
        private PictureBox pb_Tooltip;
        private Label lbl_RetrieveAll;
        private CheckBox cb_RetrieveAll;
    }
}
