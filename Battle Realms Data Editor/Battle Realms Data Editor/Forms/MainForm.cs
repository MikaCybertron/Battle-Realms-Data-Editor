using BattleRealmsDataEditor.Data;
using System;
using System.IO;
using System.Windows.Forms;

namespace BattleRealmsDataEditor.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeDragDropFile();

            this.EnabledTitleBarDarkMode();

            FormClosing += (s, e) =>
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    GC.Collect();
                }
            };
        }

        public DATEditor Editor { get; set; }

        private DataTableForm MainDataTable { get; set; }

        private EnumTableForm MainEnumTable { get; set; }

        private LTETableForm MainLTETable { get; set; }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LTECollection.DoOpen();

            this.label1.Text = "";

            this.MainLTETable = new LTETableForm(this);

            ShowMainControl(this.MainPanel3, this.MainLTETable);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Open File Battle Realms.dat";
            openFileDialog.Filter = "Battle Realms.dat|*.dat";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                OpenSingleDATFile(filePath);
            }
        }

        private void ShowMainControl(Panel mainPanel, Control control)
        {
            this.ClearMainControl(mainPanel);

            if (control != null)
            {
                control.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(control);
            }
        }

        private void ClearMainControl(Panel mainPanel)
        {
            foreach (Control control in mainPanel.Controls)
            {
                mainPanel.Controls.Remove(control);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Editor.SaveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Editor.SaveAsFile();

            string version = "Original";
            if (this.Editor.DAT.IsWOTWVersion)
            {
                version = "WOTW";
            }

            this.Text = string.Format("Battle Realms Data Editor by Mika Cybertron: {0} ({1} Version)", this.Editor.DATFile.FileName, version);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var AboutBox = new AboutForm();

            if (AboutBox.ShowDialog(this) == DialogResult.OK)
            {
            }
        }

        private void InitializeDragDropFile()
        {
            this.AllowDrop = true;

            this.DragDrop += (s, e) =>
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (files.Length > 1)
                {
                    MessageBox.Show("Not allowed multiple drag drop files.", "Error Opening file",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (files.Length == 1)
                {
                    var ext = Path.GetExtension(files[0]).ToLower();

                    if (ext == ".dat")
                    {
                        OpenSingleDATFile(files[0]);
                    }
                }
            };

            this.DragEnter += (s, e) =>
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy | DragDropEffects.Move;
                }
            };
        }

        private void OpenSingleDATFile(string filePath)
        {
            try
            {
                DATFile datFile = new DATFile(filePath);

                Editor = new DATEditor();

                Editor.DoOpen(datFile);

                this.MainDataTable = null;

                this.MainDataTable = new DataTableForm(this, this.Editor);

                this.MainEnumTable = null;

                this.MainEnumTable = new EnumTableForm(this, this.Editor);

                ShowMainControl(this.MainPanel1, this.MainDataTable);

                ShowMainControl(this.MainPanel2, this.MainEnumTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while reading the stream: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}