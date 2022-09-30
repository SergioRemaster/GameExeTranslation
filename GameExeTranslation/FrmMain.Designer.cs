namespace GameExeTranslation
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.CmbWriteSector = new System.Windows.Forms.ComboBox();
            this.DgvTranslationTable = new System.Windows.Forms.DataGridView();
            this.ChklReadableSector = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSaveEXE = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnAddSector = new System.Windows.Forms.Button();
            this.BtnDeleteSector = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.LabHelp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTranslationTable)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmbWriteSector
            // 
            this.CmbWriteSector.Enabled = false;
            this.CmbWriteSector.FormattingEnabled = true;
            this.CmbWriteSector.Location = new System.Drawing.Point(38, 45);
            this.CmbWriteSector.MaxLength = 8;
            this.CmbWriteSector.Name = "CmbWriteSector";
            this.CmbWriteSector.Size = new System.Drawing.Size(228, 23);
            this.CmbWriteSector.TabIndex = 0;
            this.toolTip1.SetToolTip(this.CmbWriteSector, "Sectors you use for translated text.\r\nWrite in the box to rename the current sele" +
        "cted box.");
            this.CmbWriteSector.SelectedIndexChanged += new System.EventHandler(this.CmbWriteSector_SelectedIndexChanged);
            this.CmbWriteSector.TextUpdate += new System.EventHandler(this.CmbWriteSector_TextUpdate);
            this.CmbWriteSector.EnabledChanged += new System.EventHandler(this.CmbWriteSector_EnabledChanged);
            // 
            // DgvTranslationTable
            // 
            this.DgvTranslationTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTranslationTable.Enabled = false;
            this.DgvTranslationTable.Location = new System.Drawing.Point(12, 181);
            this.DgvTranslationTable.MultiSelect = false;
            this.DgvTranslationTable.Name = "DgvTranslationTable";
            this.DgvTranslationTable.RowTemplate.Height = 25;
            this.DgvTranslationTable.Size = new System.Drawing.Size(984, 319);
            this.DgvTranslationTable.TabIndex = 1;
            // 
            // ChklReadableSector
            // 
            this.ChklReadableSector.CheckOnClick = true;
            this.ChklReadableSector.Enabled = false;
            this.ChklReadableSector.FormattingEnabled = true;
            this.ChklReadableSector.Location = new System.Drawing.Point(288, 45);
            this.ChklReadableSector.Name = "ChklReadableSector";
            this.ChklReadableSector.Size = new System.Drawing.Size(180, 130);
            this.ChklReadableSector.TabIndex = 2;
            this.toolTip1.SetToolTip(this.ChklReadableSector, "Select the sectors you want to replace the text on new exe.\r\n.rdatasector  for ex" +
        "ample, commonly use .data sector for use text in-game,\r\nso you should check that" +
        " sector in the list.");
            this.ChklReadableSector.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ChklReadableSector_ItemCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Writable Sectors";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Readable Sectors For Pointers";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MnuFile
            // 
            this.MnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuOpen,
            this.MnuSave,
            this.MnuSaveEXE,
            this.toolStripSeparator1,
            this.MnuClose});
            this.MnuFile.Name = "MnuFile";
            this.MnuFile.Size = new System.Drawing.Size(37, 20);
            this.MnuFile.Text = "File";
            this.MnuFile.Click += new System.EventHandler(this.MnuFile_Click);
            // 
            // MnuOpen
            // 
            this.MnuOpen.Name = "MnuOpen";
            this.MnuOpen.Size = new System.Drawing.Size(193, 22);
            this.MnuOpen.Text = "Open EXE or Project...";
            this.MnuOpen.Click += new System.EventHandler(this.MnuOpen_Click);
            // 
            // MnuSave
            // 
            this.MnuSave.Enabled = false;
            this.MnuSave.Name = "MnuSave";
            this.MnuSave.Size = new System.Drawing.Size(193, 22);
            this.MnuSave.Text = "Save Project";
            this.MnuSave.Click += new System.EventHandler(this.MnuSave_Click);
            // 
            // MnuSaveEXE
            // 
            this.MnuSaveEXE.Enabled = false;
            this.MnuSaveEXE.Name = "MnuSaveEXE";
            this.MnuSaveEXE.Size = new System.Drawing.Size(193, 22);
            this.MnuSaveEXE.Text = "Save and Generate EXE";
            this.MnuSaveEXE.Click += new System.EventHandler(this.MnuSaveEXE_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // MnuClose
            // 
            this.MnuClose.Name = "MnuClose";
            this.MnuClose.Size = new System.Drawing.Size(193, 22);
            this.MnuClose.Text = "Close";
            this.MnuClose.Click += new System.EventHandler(this.MnuClose_Click);
            // 
            // BtnAddSector
            // 
            this.BtnAddSector.Enabled = false;
            this.BtnAddSector.Location = new System.Drawing.Point(38, 90);
            this.BtnAddSector.Name = "BtnAddSector";
            this.BtnAddSector.Size = new System.Drawing.Size(111, 46);
            this.BtnAddSector.TabIndex = 6;
            this.BtnAddSector.Text = "Add Writable Sector";
            this.toolTip1.SetToolTip(this.BtnAddSector, "Create a new sector.\r\nEach one can use different configuration on readable sector" +
        "s.");
            this.BtnAddSector.UseVisualStyleBackColor = true;
            this.BtnAddSector.Click += new System.EventHandler(this.BtnAddSector_Click);
            // 
            // BtnDeleteSector
            // 
            this.BtnDeleteSector.Enabled = false;
            this.BtnDeleteSector.Location = new System.Drawing.Point(155, 90);
            this.BtnDeleteSector.Name = "BtnDeleteSector";
            this.BtnDeleteSector.Size = new System.Drawing.Size(111, 46);
            this.BtnDeleteSector.TabIndex = 7;
            this.BtnDeleteSector.Text = "Delete Writable Sector";
            this.toolTip1.SetToolTip(this.BtnDeleteSector, "Permanently erase current selected sector.");
            this.BtnDeleteSector.UseVisualStyleBackColor = true;
            this.BtnDeleteSector.Click += new System.EventHandler(this.BtnDeleteSector_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // LabHelp
            // 
            this.LabHelp.AutoSize = true;
            this.LabHelp.Font = new System.Drawing.Font("Segoe UI", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabHelp.Location = new System.Drawing.Point(959, 147);
            this.LabHelp.Name = "LabHelp";
            this.LabHelp.Size = new System.Drawing.Size(24, 31);
            this.LabHelp.TabIndex = 8;
            this.LabHelp.Text = "?";
            this.toolTip1.SetToolTip(this.LabHelp, resources.GetString("LabHelp.ToolTip"));
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 510);
            this.Controls.Add(this.LabHelp);
            this.Controls.Add(this.BtnDeleteSector);
            this.Controls.Add(this.BtnAddSector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChklReadableSector);
            this.Controls.Add(this.DgvTranslationTable);
            this.Controls.Add(this.CmbWriteSector);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameExeTranslator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DgvTranslationTable)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox CmbWriteSector;
        private DataGridView DgvTranslationTable;
        private CheckedListBox ChklReadableSector;
        private Label label1;
        private Label label2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem MnuFile;
        private ToolStripMenuItem MnuOpen;
        private ToolStripMenuItem MnuSave;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem MnuClose;
        private Button BtnAddSector;
        private Button BtnDeleteSector;
        private ToolStripMenuItem MnuSaveEXE;
        private ContextMenuStrip contextMenuStrip1;
        private ToolTip toolTip1;
        private Label LabHelp;
    }
}