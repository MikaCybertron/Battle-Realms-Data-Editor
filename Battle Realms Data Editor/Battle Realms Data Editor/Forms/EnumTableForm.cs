using BattleRealmsDataEditor.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleRealmsDataEditor.Forms
{
    public partial class EnumTableForm : UserControl
    {
        public EnumTableForm(MainForm mainForm, DATEditor editor)
        {
            InitializeComponent();

            this.mainForm = mainForm;
            this.Editor = editor;

            ReadListData();
        }

        public MainForm mainForm { get; set; }

        public string FilePath { get; set; }

        public DATEditor Editor { get; set; }

        private void EnumTableForm_Load(object sender, EventArgs e)
        {

        }

        private void ReadListData()
        {
            this.listBox1.Items.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            for (int i = 0; i < this.Editor.DAT.EnumCollection.Length; i++)
            {
                DATCollection.DATEnumCollection dataCollection = this.Editor.DAT.EnumCollection[i];
                this.listBox1.Items.Add(dataCollection.Name);
            }

            if (this.listBox1.Items.Count > 0)
            {
                this.listBox1.SelectedIndex = -1;
            }
        }

        private int NewColumnDataGrid(string headerText, bool readOnly, DataGridViewContentAlignment aligment = DataGridViewContentAlignment.MiddleRight)
        {
            // Create a new column
            DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
            newColumn.HeaderText = headerText;
            newColumn.Name = headerText;


            int headerWidth = TextRenderer.MeasureText(headerText, dataGridView1.Font).Width + 35;

            newColumn.Width = headerWidth;

            newColumn.ReadOnly = readOnly;

            newColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

            // Set the alignment of the text within the column
            newColumn.DefaultCellStyle.Alignment = aligment;

            // Add the new column to the DataGridView
            return dataGridView1.Columns.Add(newColumn);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            int selectedIndex = this.listBox1.SelectedIndex;

            if (selectedIndex == -1)
            {
                mainForm.label1.Text = "";
                return;
            }

            try
            {
                NewColumnDataGrid("ID (Integer)", true, DataGridViewContentAlignment.MiddleRight);

                NewColumnDataGrid("Name (String)", true, DataGridViewContentAlignment.MiddleLeft);

                DATCollection.DATEnumCollection enumCollection = this.Editor.DAT.EnumCollection[selectedIndex];

                int tempWidth = 0;
                for (int i = 0; i < enumCollection.ListEnum.Count; i++)
                {
                    DATCollection.DATEnum enums = enumCollection.ListEnum[i];

                    DataGridViewRow dataGridViewRow = new DataGridViewRow();

                    dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell
                    {
                        Value = enums.Value
                    });

                    dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell
                    {
                        Value = enums.Name
                    });

                    int headerWidth = TextRenderer.MeasureText(enums.Name, dataGridView1.Font).Width + 35;

                    if(headerWidth > tempWidth)
                    {
                        tempWidth = headerWidth;
                    }

                    dataGridView1.Columns[1].Width = tempWidth;

                    dataGridView1.Rows.Add(dataGridViewRow);
                }
                dataGridView1.Columns[0].Frozen = true;

                mainForm.label1.Text = string.Format("Enum Table: {0}, Total Enum: {1}, Offsets: 0x{2:X2}", enumCollection.Name, enumCollection.ListEnum.Count, enumCollection.Offset);

                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error:" + ex);
                mainForm.label1.Text = string.Format("Error: {0}", ex.Message);
            }
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = this.listBox1.SelectedIndex;

            if (selectedIndex == -1)
            {
                mainForm.label1.Text = "";
                return;
            }

            int rowIndex = e.RowIndex;

            try
            {
                DATCollection.DATEnumCollection enumCollection = this.Editor.DAT.EnumCollection[selectedIndex];

                DATCollection.DATEnum enums = enumCollection.ListEnum[rowIndex];

                mainForm.label1.Text = string.Format("Enum Table: {0}, Name: {1}, Value: {2}, Offsets: 0x{3:X2}", enumCollection.Name, enums.Name, enums.Value, enums.Offset);
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error:" + ex);
                mainForm.label1.Text = string.Format("Error: {0}", ex.Message);
            }
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = this.listBox1.SelectedIndex;

            if (selectedIndex == -1)
            {
                mainForm.label1.Text = "";
                return;
            }

            try
            {
                DATCollection.DATEnumCollection enumCollection = this.Editor.DAT.EnumCollection[selectedIndex];

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int rowIndex = dataGridView1.SelectedRows[0].Index;

                    DATCollection.DATEnum enums = enumCollection.ListEnum[rowIndex];

                    mainForm.label1.Text = string.Format("Enum Table: {0}, Name: {1}, Value: {2}, Offsets: 0x{3:X2}", enumCollection.Name, enums.Name, enums.Value, enums.Offset);
                }
                else
                {
                    mainForm.label1.Text = string.Format("Enum Table: {0}, Total Enum: {1}, Offsets: 0x{2:X2}", enumCollection.Name, enumCollection.ListEnum.Count, enumCollection.Offset);
                }
                
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error:" + ex);
                mainForm.label1.Text = string.Format("Error: {0}", ex.Message);
            }
        }
    }
}
