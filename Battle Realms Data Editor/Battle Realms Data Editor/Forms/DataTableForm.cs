using BattleRealmsDataEditor.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BattleRealmsDataEditor.Forms
{
    public partial class DataTableForm : UserControl
    {
        public DataTableForm(MainForm mainForm, DATEditor editor)
        {
            InitializeComponent();

            this.mainForm = mainForm;
            this.Editor = editor;

            ReadListData();
        }

        public MainForm mainForm { get; set; }

        public string FilePath { get; set; }

        public DATEditor Editor { get; set; }

        public Dictionary<string, List<DATCollection.DATEnum>> EnumCollection { get; set; }

        private void DataTableForm_Load(object sender, EventArgs e)
        {
            GlobalManagement.CreateTableLink();
        }

        public void SetLabelText(string labelText)
        {
            this.mainForm.label1.Text = labelText;
        }

        private void ReadListData()
        {
            GlobalManagement.SaveALLChangesValue = new Dictionary<long, object>();

            GlobalManagement.OriginalValue = new Dictionary<long, object>();


            this.listBox1.Items.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            for (int i = 0; i < this.Editor.DAT.DataCollection.Length; i++)
            {
                DATCollection.DATDataCollection dataCollection = this.Editor.DAT.DataCollection[i];
                this.listBox1.Items.Add(dataCollection.Name);

                for (int j = 0; j < dataCollection.RowCount; j++)
                {
                    for (int k = 0; k < dataCollection.ColumnCount; k++)
                    {
                        if (this.Editor.DAT.DataCollection[i].Columns[k].Name == "CanOnlyHaveOne")
                        {
                            this.Editor.DAT.DataCollection[i].Columns[k].DataType = DATCollection.DatDataType.Integer;

                            this.Editor.DAT.DataCollection[i].Cells[j][k].Offset += 5;

                            int exValue = (int)Editor.ReadValue(this.Editor.DAT.DataCollection[i].Cells[j][k].Offset, typeof(int));

                            this.Editor.DAT.DataCollection[i].Cells[j][k].Value = exValue == 49 ? 1 : 0;
                        }

                        long offset = dataCollection.Cells[j][k].Offset;

                        object value = dataCollection.Cells[j][k].Value;

                        GlobalManagement.OriginalValue.Add(offset, value);
                    }

                    
                }
            }

            if (this.listBox1.Items.Count > 0)
            {
                this.listBox1.SelectedIndex = 0;
            }


            EnumCollection = new Dictionary<string, List<DATCollection.DATEnum>>();

            for (int i = 0; i < this.Editor.DAT.EnumCollection.Length; i++)
            {
                DATCollection.DATEnumCollection enumCollection = this.Editor.DAT.EnumCollection[i];

                if(!EnumCollection.IsKeyExists(enumCollection.Name))
                {
                    EnumCollection.Add(enumCollection.Name, enumCollection.ListEnum);
                }
            }

            string version = "Original";
            if(this.Editor.DAT.IsWOTWVersion)
            {
                version = "WOTW";
            }

            this.mainForm.Text = string.Format("Battle Realms Data Editor by Mika Cybertron: {0} ({1} Version)", this.Editor.DATFile.FileName, version);
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
                return;
            }

            try
            {
                SetDefaultDataStartingArmies(selectedIndex);

                DATCollection.DATDataCollection dataCollection = this.Editor.DAT.DataCollection[selectedIndex];

                for (int i = 0; i < dataCollection.Columns.Count; i++)
                {
                    DATCollection.DATDataColumn column = dataCollection.Columns[i];

                    string name = column.Name;

                    string dataType = column.DataType.ToString();

                    string headerName = string.Format("{0} ({1})", name, dataType);

                    //if (name == "BuildingPortrait" || name == "CanOnlyHaveOne")
                    //{
                    //    headerName = string.Format("{0} ({1}) (Not Editable)", name, dataType);
                    //}

                    if (dataType == "String")
                    {
                        NewColumnDataGrid(headerName, true, DataGridViewContentAlignment.MiddleLeft);
                    }
                    else
                    {
                        NewColumnDataGrid(headerName, true, DataGridViewContentAlignment.MiddleRight);
                    }
                    

                    if ((i == 0 || i == 1) && (name.Contains("Type") || name.Contains("ID") || name.Contains("Name") || name.Contains("Actual")))
                    {
                        dataGridView1.Columns[i].Frozen = true;
                    }


                }

                for (int i = 0; i < dataCollection.RowCount; i++)
                {

                    DataGridViewRow dataGridViewRow = new DataGridViewRow();

                    for (int j = 0; j < dataCollection.ColumnCount; j++)
                    {
                        object value = dataCollection.Cells[i][j].Value;

                        //if (dataCollection.Columns[j].Name == "CanOnlyHaveOne")
                        //{
                        //    if(value is int intValue)
                        //    {
                        //        value = intValue == 49 ? 1 : 0;
                        //    }
                        //}

                        dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell
                        {
                            Value = value
                        });
                    }

                    dataGridView1.Rows.Add(dataGridViewRow);
                }

                // Default Width Column
                for (int i = 0; i < dataCollection.ColumnCount; i++)
                {
                    int tempWidth = TextRenderer.MeasureText(dataCollection.Columns[i].Name, dataGridView1.Font).Width + 35;

                    for (int j = 0; j < dataCollection.RowCount; j++)
                    {
                        object value = dataCollection.Cells[j][i].Value;

                        if (value is string)
                        {
                            int headerWidth = TextRenderer.MeasureText((string)value, dataGridView1.Font).Width + 35;

                            if (headerWidth > tempWidth)
                            {
                                tempWidth = headerWidth;

                                dataGridView1.Columns[i].Width = tempWidth;
                            }
                        }
                    }
                }

                SetLabelText(string.Format("Data Table: {0}, Total Column: {1}, Total Row: {2}, Body Offsets: 0x{3:X2}, Offsets: 0x{4:X2}", dataCollection.Name, dataCollection.ColumnCount, dataCollection.RowCount, dataCollection.BodyOffset, dataCollection.Offset));

                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                SetLabelText(string.Format("Error: {0}", ex.Message));
            }
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = this.listBox1.SelectedIndex;

            if (selectedIndex == -1)
            {
                SetLabelText("");
                return;
            }

            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            try
            {
                DATCollection.DATDataCollection dataCollection = this.Editor.DAT.DataCollection[selectedIndex];

                DATCollection.DATDataColumn column = dataCollection.Columns[columnIndex];

                string name = column.Name;

                string dataType = column.DataType.ToString();

                object value = dataCollection.Cells[rowIndex][columnIndex].Value;

                object offset = dataCollection.Cells[rowIndex][columnIndex].Offset;

                SetLabelText(string.Format("Data Table: {0}, Name: {1}, Type: {2}, Value: {3}, Offsets: 0x{4:X2}", dataCollection.Name, name, dataType, value, offset));

            }
            catch (Exception ex)
            {
                SetLabelText(string.Format("Error: {0}", ex.Message));
            }
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = this.listBox1.SelectedIndex;

            if (selectedIndex == -1)
            {
                SetLabelText("");
                return;
            }

            try
            {
                DATCollection.DATDataCollection dataCollection = this.Editor.DAT.DataCollection[selectedIndex];

                SetLabelText(string.Format("Data Table: {0}, Total Column: {1}, Total Row: {2}, Body Offsets: 0x{3:X2}, Offsets: 0x{4:X2}", dataCollection.Name, dataCollection.ColumnCount, dataCollection.RowCount, dataCollection.BodyOffset, dataCollection.Offset));

                if (dataGridView1.SelectedCells.Count == 0)
                {
                    return;
                }

                if (dataGridView1.CurrentCell == null)
                {
                    return;
                }

                if (dataGridView1.CurrentCell.ColumnIndex >= 0)
                {
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;

                    int columnIndex = dataGridView1.CurrentCell.ColumnIndex;

                    DATCollection.DATDataColumn column = dataCollection.Columns[columnIndex];

                    string name = column.Name;

                    string dataType = column.DataType.ToString();

                    object value = dataCollection.Cells[rowIndex][columnIndex].Value;

                    object offset = dataCollection.Cells[rowIndex][columnIndex].Offset;

                    SetLabelText(string.Format("Data Table: {0}, Name: {1}, Type: {2}, Value: {3}, Offsets: 0x{4:X2}", dataCollection.Name, name, dataType, value, offset));
                }

            }
            catch (Exception ex)
            {
                SetLabelText(string.Format("Error: {0}", ex.Message));
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = this.listBox1.SelectedIndex;

            if (selectedIndex == -1)
            {
                SetLabelText("");
                return;
            }

            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            try
            {
                DATCollection.DATDataCollection dataCollection = this.Editor.DAT.DataCollection[selectedIndex];

                DATCollection.DATDataColumn column = dataCollection.Columns[columnIndex];

                string name = column.Name;

                string dataType = column.DataType.ToString();

                object value = dataCollection.Cells[rowIndex][columnIndex].Value;

                long offset = dataCollection.Cells[rowIndex][columnIndex].Offset;

                if (!GlobalManagement.TableLinkCollection[dataCollection.Name].Column.ContainsKey(name))
                {
                    if (column.DataType == DATCollection.DatDataType.Boolean)
                    {
                        GlobalManagement.TableLinkCollection[dataCollection.Name].Column.Add(name, new ColumnLink(TableLink.TableDataType.Boolean));
                    }

                    if (column.DataType == DATCollection.DatDataType.Integer)
                    {
                        GlobalManagement.TableLinkCollection[dataCollection.Name].Column.Add(name, new ColumnLink(TableLink.TableDataType.Integer));
                    }
                    if (column.DataType == DATCollection.DatDataType.Float)
                    {
                        GlobalManagement.TableLinkCollection[dataCollection.Name].Column.Add(name, new ColumnLink(TableLink.TableDataType.Float));
                    }
                    if (column.DataType == DATCollection.DatDataType.String)
                    {
                        GlobalManagement.TableLinkCollection[dataCollection.Name].Column.Add(name, new ColumnLink(TableLink.TableDataType.String));
                    }
                }

                TableLink tableLink = GlobalManagement.TableLinkCollection[dataCollection.Name];

                if (tableLink.Column.IsKeyExists(name))
                {

                    //if(name == "BuildingPortrait" || name == "CanOnlyHaveOne")
                    //{
                    //    // Not Editable
                    //    return;
                    //}

                    EditorForm editorForm = new EditorForm(this, dataCollection.Name, name, tableLink.Column[name].EnumName, value, tableLink.Column[name]);

                    DialogResult result = editorForm.ShowDialog();

                    if(result == DialogResult.OK)
                    {
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[rowIndex][columnIndex].Value = editorForm.Value;

                        this.dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = editorForm.Value;

                        GlobalManagement.SaveALLChangesValue.XAdd(offset, editorForm.Value);
                        if (name == "CanOnlyHaveOne")
                        {
                            if (editorForm.Value is int intValue)
                            {
                                GlobalManagement.SaveALLChangesValue.XAdd(offset, intValue == 1 ? 49 : 48);
                            }
                        }

                        if(GlobalManagement.SaveALLChangesValue.IsKeyExists(offset))
                        {
                            if (GlobalManagement.SaveALLChangesValue.TryGetValue(offset, out object saveAllValue) && GlobalManagement.OriginalValue.TryGetValue(offset, out object originalValue) && object.Equals(saveAllValue, originalValue))
                            {
                                //GlobalManagement.SaveALLChangesValue.Remove(offset);
                            }
                        }

                        if(GlobalManagement.SaveALLChangesValue.Count > 0)
                        {
                            mainForm.saveToolStripMenuItem.Enabled = true;
                            mainForm.saveAsToolStripMenuItem.Enabled = true;
                        }
                        else
                        {
                            mainForm.saveToolStripMenuItem.Enabled = false;
                            mainForm.saveAsToolStripMenuItem.Enabled = false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                SetLabelText(string.Format("Error: {0}", ex.Message));
            }
        }

        private void SetDefaultDataStartingArmies(int selectedIndex)
        {
            DATCollection.DATDataCollection dataCollection = this.Editor.DAT.DataCollection[selectedIndex];

            if (dataCollection.Name == "Data_StartingArmies")
            {
                for (int j = 0; j < dataCollection.RowCount; j++)
                {
                    if (j == 0)
                    {
                        //Console.WriteLine("Row 1");
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][1].Value = 5;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][2].Value = 5;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][3].Value = 5;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][4].Value = 5;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][5].Value = 5;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][6].Value = 5;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][7].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][8].Value = -1;
                    }

                    if (j == 1)
                    {
                        //Console.WriteLine("Row 2");
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][1].Value = 5;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][2].Value = 5;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][3].Value = 5;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][4].Value = 5;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][5].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][6].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][7].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][8].Value = -1;
                    }

                    if (j == 2)
                    {
                        //Console.WriteLine("Row 3");
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][1].Value = 5;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][2].Value = 5;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][3].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][4].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][5].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][6].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][7].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][8].Value = -1;
                    }

                    if (j == 3)
                    {
                        //Console.WriteLine("Row 4");
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][1].Value = 40;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][2].Value = 40;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][3].Value = 40;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][4].Value = 40;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][5].Value = 40;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][6].Value = 40;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][7].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][8].Value = -1;
                    }

                    if (j == 4)
                    {
                        //Console.WriteLine("Row 5");
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][1].Value = 40;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][2].Value = 40;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][3].Value = 40;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][4].Value = 40;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][5].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][6].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][7].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][8].Value = -1;
                    }

                    if (j == 5)
                    {
                        //Console.WriteLine("Row 6");
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][1].Value = 40;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][2].Value = 40;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][3].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][4].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][5].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][6].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][7].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][8].Value = -1;
                    }

                    if (j == 6)
                    {
                        //Console.WriteLine("Row 7");
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][1].Value = 24;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][2].Value = 24;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][3].Value = 24;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][4].Value = 24;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][5].Value = 24;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][6].Value = 24;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][7].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][8].Value = -1;
                    }

                    if (j == 7)
                    {
                        //Console.WriteLine("Row 8");
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][1].Value = 24;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][2].Value = 24;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][3].Value = 24;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][4].Value = 24;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][5].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][6].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][7].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][8].Value = -1;
                    }

                    if (j == 8)
                    {
                        //Console.WriteLine("Row 9");
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][1].Value = 24;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][2].Value = 24;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][3].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][4].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][5].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][6].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][7].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][8].Value = -1;
                    }

                    if (j == 9)
                    {
                        //Console.WriteLine("Row 10");
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][1].Value = 51;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][2].Value = 51;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][3].Value = 51;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][4].Value = 51;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][5].Value = 51;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][6].Value = 51;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][7].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][8].Value = -1;
                    }

                    if (j == 10)
                    {
                        //Console.WriteLine("Row 11");
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][1].Value = 51;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][2].Value = 51;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][3].Value = 51;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][4].Value = 51;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][5].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][6].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][7].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][8].Value = -1;
                    }

                    if (j == 11)
                    {
                        //Console.WriteLine("Row 12");
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][1].Value = 51;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][2].Value = 51;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][3].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][4].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][5].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][6].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][7].Value = -1;
                        this.Editor.DAT.DataCollection[selectedIndex].Cells[j][8].Value = -1;
                    }

                    for (int k = 0; k < dataCollection.ColumnCount; k++)
                    {
                        if (k > 0)
                        {
                            object value = this.Editor.DAT.DataCollection[selectedIndex].Cells[j][k].Value;

                            long offset = this.Editor.DAT.DataCollection[selectedIndex].Cells[j][k].Offset;

                            //Console.WriteLine("Offset: {0} ({0:X2}), Value: {1}", offset, value);

                            GlobalManagement.SaveALLChangesValue.XAdd(offset, value);
                        }
                    }
                }

                //Console.WriteLine("SaveALLChangesValue: {0}", GlobalManagement.SaveALLChangesValue.Count);
            }
        }
    }
}
