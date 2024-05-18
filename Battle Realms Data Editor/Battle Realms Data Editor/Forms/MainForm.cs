using BattleRealmsDataEditor.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleRealmsDataEditor.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            DarkTitleBar.EnabledDarkTheme(Handle, true);
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

                DATFile datFile = new DATFile(filePath);

                Console.WriteLine(datFile.ToString());

                Editor = new DATEditor();

                Editor.DoOpen(datFile);

                this.MainDataTable = null;

                this.MainDataTable = new DataTableForm(this, this.Editor);

                this.MainEnumTable = null;

                this.MainEnumTable = new EnumTableForm(this, this.Editor);

                ShowMainControl(this.MainPanel1, this.MainDataTable);

                ShowMainControl(this.MainPanel2, this.MainEnumTable);

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
    }
}
