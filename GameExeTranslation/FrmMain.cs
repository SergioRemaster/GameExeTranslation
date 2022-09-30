using GameExeTranslation.Core;
using GameExeTranslation.TextFormat;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace GameExeTranslation
{
    public partial class FrmMain : Form
    {
        private ExeHandler exeHandler;
        private ExeSectorText exeSectorText;
        private Project project;
        private string projectPath;
        private BindingSource bs = new BindingSource();

        private const string APP_TITLE = "GameExeTranslation";

        public FrmMain()
        {
            InitializeComponent();
        }

        private void EnableControls(bool enable)
        { 
            ChklReadableSector.Enabled = enable;
            DgvTranslationTable.Enabled = enable;
        }

        private void MnuOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "exe; json files (*.exe; *.json)|*.exe; *.json";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    MnuSave.Enabled = true;
                    MnuSaveEXE.Enabled = true;

                    exeHandler = new ExeHandler();
                    CmbWriteSector.Items.Clear();
                    bs.DataSource = null;
                    switch (Path.GetExtension(ofd.FileName).ToLower())
                    {
                        case ".exe":
                            exeHandler.ExePath = ofd.FileName;
                            project = new Project();
                            Text = APP_TITLE + " - New Project";
                            break;
                        case ".json":
                            project = Project.LoadJson(ofd.FileName);
                            exeHandler.ExePath = project.ExePath;
                            projectPath = ofd.FileName;
                            project.ExeSectorTextList.ForEach(p => CmbWriteSector.Items.Add(p));
                            Text = APP_TITLE + " - "+Path.GetFileName(ofd.FileName);
                            break;
                    }

                    //Get Exe info and activate controls
                    exeHandler.GetExeInfo();

                    //Create checked list from already existing sectors of exe
                    ChklReadableSector.Items.Clear();
                    exeHandler.SectorInfoList.ForEach(p => ChklReadableSector.Items.Add(p.Name));
                    if (CmbWriteSector.Items.Count > 0)
                    {
                        CmbWriteSector.Enabled = true;
                        CmbWriteSector.SelectedIndex = 0;
                    }
                    else
                    {
                        CmbWriteSector.Enabled = false;
                        CmbWriteSector.Text = "";
                    }
                    BtnAddSector.Enabled = true;
                    BtnDeleteSector.Enabled = true;
                }
            }
        }

        private void BtnAddSector_Click(object sender, EventArgs e)
        {
            ExeSectorText exe = new ExeSectorText(".newsc"+ (CmbWriteSector.Items.Count+1));
            exe.TextList.Add(new ExeTextLine(0, "New text", ""));
            CmbWriteSector.Items.Add(exe);
            CmbWriteSector.SelectedItem = exe;

            if (CmbWriteSector.Items.Count == 1)
                CmbWriteSector.Enabled = true;
        }

        private void BtnDeleteSector_Click(object sender, EventArgs e)
        {
            CmbWriteSector.Items.Remove(CmbWriteSector.SelectedItem);
            CmbWriteSector.Text = "";

            if (CmbWriteSector.Items.Count == 0)
                CmbWriteSector.Enabled = false;
            else
                CmbWriteSector.SelectedIndex = 0;
        }

        private void CmbWriteSector_EnabledChanged(object sender, EventArgs e)
        {
            EnableControls(CmbWriteSector.Enabled);
        }

        private void CmbWriteSector_TextUpdate(object sender, EventArgs e)
        {
            if (CmbWriteSector.SelectedItem != null &&
                CmbWriteSector.Text != exeSectorText.Name)
            {
                exeSectorText.Name = CmbWriteSector.Text;
                CmbWriteSector.Items[CmbWriteSector.SelectedIndex] = CmbWriteSector.SelectedItem;
            }
        }

        private void CmbWriteSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            exeSectorText = (ExeSectorText)CmbWriteSector.SelectedItem;
            bs.DataSource = exeSectorText.TextList ;
            DgvTranslationTable.DataSource = bs;
            ChklReadableSector.ItemCheck -= ChklReadableSector_ItemCheck;
            for (int x = 0; x < ChklReadableSector.Items.Count; ++x)
                ChklReadableSector.SetItemChecked(x, false);
            exeSectorText.SearchSectorList.ForEach(p => {
                if(ChklReadableSector.Items.Contains(p))
                    ChklReadableSector.SetItemChecked(ChklReadableSector.Items.IndexOf(p), true);
                }
            );
            ChklReadableSector.ItemCheck += ChklReadableSector_ItemCheck;
            DgvTranslationTable.Columns[0].Width = 100;
            DgvTranslationTable.Columns[1].Width = 300;
            DgvTranslationTable.Columns[2].Width = 300;
            DgvTranslationTable.Columns.RemoveAt(4);
            DgvTranslationTable.Columns[1].HeaderText = "Translated Text";
            DgvTranslationTable.Columns[2].HeaderText = "Original Text (Optional)";
            DgvTranslationTable.Columns[3].HeaderText = "Is Full-Width Encode";

            DataGridViewComboBoxColumn combocol = new DataGridViewComboBoxColumn();
            combocol.Name = "Original Sector";
            combocol.DataPropertyName = "OriginalSector";
            exeHandler.SectorInfoList.ForEach(p => combocol.Items.Add(p.Name));
            DgvTranslationTable.Columns.Add(combocol);
        }

        private void ChklReadableSector_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                exeSectorText.SearchSectorList.Add(ChklReadableSector.Items[e.Index].ToString());
            else
                exeSectorText.SearchSectorList.Remove(ChklReadableSector.Items[e.Index].ToString());
        }

        private void MnuSave_Click(object sender, EventArgs e)
        {
            if (!File.Exists(projectPath))
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "json files (*.json)|*.json";
                    sfd.FilterIndex = 1;
                    sfd.RestoreDirectory = true;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        project.ExeSectorTextList.Clear();
                        project.ExePath = exeHandler.ExePath;
                        project.ExeSectorTextList.AddRange(CmbWriteSector.Items.Cast<ExeSectorText>());
                        projectPath = sfd.FileName;
                        project.SaveJson(sfd.FileName);
                        Text = APP_TITLE + " - " + Path.GetFileName(sfd.FileName);
                        MessageBox.Show("Project correctly saved at:\n"+sfd.FileName, "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                project.ExeSectorTextList.Clear();
                project.ExeSectorTextList.AddRange(CmbWriteSector.Items.Cast<ExeSectorText>());
                project.SaveJson(projectPath);
                Text = APP_TITLE + " - " + Path.GetFileName(projectPath);
                MessageBox.Show("Project correctly saved at:\n" + projectPath, "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MnuFile_Click(object sender, EventArgs e)
        {
            DgvTranslationTable.EndEdit();
        }

        private void MnuSaveEXE_Click(object sender, EventArgs e)
        {
            MnuSave_Click(sender, e);
            exeHandler.SaveTranslatedExe(project.ExeSectorTextList);
        }

        private void MnuClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to close the application?\nAll unsaved data will be lost!\n",
                "Information",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (res == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}