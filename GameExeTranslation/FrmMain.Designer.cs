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
            this.exeTextLineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.exeTextLineBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.exeTextLineBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvTranslationTable)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exeTextLineBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exeTextLineBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exeTextLineBindingSource2)).BeginInit();
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
            this.DgvTranslationTable.Leave += new System.EventHandler(this.DgvTranslationTable_Leave);
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
            this.ChklReadableSector.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ChklReadableSector_ItemCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Writable Sectors";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Readable Sectors";
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
            this.MnuSave.Name = "MnuSave";
            this.MnuSave.Size = new System.Drawing.Size(193, 22);
            this.MnuSave.Text = "Save Project";
            this.MnuSave.Click += new System.EventHandler(this.MnuSave_Click);
            // 
            // MnuSaveEXE
            // 
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
            // 
            // BtnAddSector
            // 
            this.BtnAddSector.Enabled = false;
            this.BtnAddSector.Location = new System.Drawing.Point(38, 90);
            this.BtnAddSector.Name = "BtnAddSector";
            this.BtnAddSector.Size = new System.Drawing.Size(111, 46);
            this.BtnAddSector.TabIndex = 6;
            this.BtnAddSector.Text = "Add Writable Sector";
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
            this.BtnDeleteSector.UseVisualStyleBackColor = true;
            this.BtnDeleteSector.Click += new System.EventHandler(this.BtnDeleteSector_Click);
            // 
            // exeTextLineBindingSource
            // 
            this.exeTextLineBindingSource.DataSource = typeof(GameExeTranslation.TextFormat.ExeTextLine);
            // 
            // exeTextLineBindingSource1
            // 
            this.exeTextLineBindingSource1.DataSource = typeof(GameExeTranslation.TextFormat.ExeTextLine);
            // 
            // exeTextLineBindingSource2
            // 
            this.exeTextLineBindingSource2.DataSource = typeof(GameExeTranslation.TextFormat.ExeTextLine);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 510);
            this.Controls.Add(this.BtnDeleteSector);
            this.Controls.Add(this.BtnAddSector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChklReadableSector);
            this.Controls.Add(this.DgvTranslationTable);
            this.Controls.Add(this.CmbWriteSector);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameExeTranslator";
            ((System.ComponentModel.ISupportInitialize)(this.DgvTranslationTable)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exeTextLineBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exeTextLineBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exeTextLineBindingSource2)).EndInit();
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
        private BindingSource exeTextLineBindingSource;
        private BindingSource exeTextLineBindingSource1;
        private BindingSource exeTextLineBindingSource2;
        private ToolStripMenuItem MnuSaveEXE;
    }
}