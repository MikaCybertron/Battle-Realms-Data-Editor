using BattleRealmsDataEditor.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BattleRealmsDataEditor.Forms
{
    public partial class LTETableForm : UserControl
    {
        public LTETableForm(MainForm mainForm)
        {
            InitializeComponent();

            this.mainForm = mainForm;

            InitializeDataGrid();
            ReadListData();
            CreateEventListener();
        }

        private void CreateEventListener()
        {
            DataGridLTETable.CellFormatting += (s, e) =>
            {
                e.CellStyle.BackColor = Color.FromArgb(64, 64, 64);
                e.CellStyle.ForeColor = Color.White;
            };
        }

        private void InitializeDataGrid()
        {
            DataGridLTETable.EnableDoubleBuffered();
            DataGridLTETable.EnableDoubleBuffered();
            DataGridLTETable.EnableHeadersVisualStyles = false;
            DataGridLTETable.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(38, 38, 38);
            DataGridLTETable.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridLTETable.DefaultCellStyle.SelectionBackColor = Color.FromArgb(38, 79, 120);
            DataGridLTETable.DefaultCellStyle.SelectionForeColor = Color.White;
            DataGridLTETable.ColumnHeadersHeight = 30;
            DataGridLTETable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        public MainForm mainForm { get; set; }

        private void LTETableForm_Load(object sender, EventArgs e)
        {
        }

        private void ReadListData()
        {
            this.listBox1.Items.Clear();
            DataGridLTETable.Columns.Clear();
            DataGridLTETable.Rows.Clear();

            foreach (var pair in LTECollection.LTEStringCollection)
            {
                string name = pair.Key;

                this.listBox1.Items.Add(name);
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

            int headerWidth = TextRenderer.MeasureText(headerText, DataGridLTETable.Font).Width + 35;

            newColumn.Width = headerWidth;

            newColumn.ReadOnly = readOnly;

            newColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

            // Set the alignment of the text within the column
            newColumn.DefaultCellStyle.Alignment = aligment;

            // Add the new column to the DataGridView
            return DataGridLTETable.Columns.Add(newColumn);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridLTETable.Columns.Clear();
            DataGridLTETable.Rows.Clear();

            int selectedIndex = this.listBox1.SelectedIndex;

            if (selectedIndex == -1)
            {
                mainForm.label1.Text = "";
                return;
            }

            try
            {
                NewColumnDataGrid("ID (Integer)", true, DataGridViewContentAlignment.MiddleRight);

                NewColumnDataGrid("Text (String)", true, DataGridViewContentAlignment.MiddleLeft);

                List<StringItem> stringItems = LTECollection.LTEStringCollection[this.listBox1.SelectedItem.ToString()];

                int tempWidth = 0;
                for (int i = 0; i < stringItems.Count; i++)
                {
                    StringItem item = stringItems[i];

                    DataGridViewRow dataGridViewRow = new DataGridViewRow();

                    dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell
                    {
                        Value = item.ID
                    });

                    dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell
                    {
                        Value = item.Text
                    });

                    int headerWidth = TextRenderer.MeasureText(item.Text, DataGridLTETable.Font).Width + 35;

                    if (headerWidth > tempWidth)
                    {
                        tempWidth = headerWidth;
                    }
                    DataGridLTETable.Columns[1].Width = tempWidth;

                    DataGridLTETable.Rows.Add(dataGridViewRow);
                }
                DataGridLTETable.Columns[0].Frozen = true;

                mainForm.label1.Text = string.Format("LTE Table: {0}, Total String Item: {1}", this.listBox1.SelectedItem.ToString(), stringItems.Count);

                DataGridLTETable.ClearSelection();
            }
            catch (Exception ex)
            {
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
                List<StringItem> stringItems = LTECollection.LTEStringCollection[this.listBox1.SelectedItem.ToString()];

                StringItem item = stringItems[rowIndex];

                mainForm.label1.Text = string.Format("LTE Table: {0}, ID: {1}, Text: {2}", this.listBox1.SelectedItem.ToString(), item.ID, item.Text);
            }
            catch (Exception ex)
            {
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
                List<StringItem> stringItems = LTECollection.LTEStringCollection[this.listBox1.SelectedItem.ToString()];

                if (DataGridLTETable.SelectedRows.Count > 0)
                {
                    int rowIndex = DataGridLTETable.SelectedRows[0].Index;

                    StringItem item = stringItems[rowIndex];

                    mainForm.label1.Text = string.Format("LTE Table: {0}, ID: {1}, Text: {2}", this.listBox1.SelectedItem.ToString(), item.ID, item.Text);
                }
                else
                {
                    mainForm.label1.Text = string.Format("LTE Table: {0}, Total String Item: {1}", this.listBox1.SelectedItem.ToString(), stringItems.Count);
                }
            }
            catch (Exception ex)
            {
                mainForm.label1.Text = string.Format("Error: {0}", ex.Message);
            }
        }
    }
}