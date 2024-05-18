using BattleRealmsDataEditor.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BattleRealmsDataEditor.Forms
{
    public partial class EditorForm : Form
    {
        public EditorForm(DataTableForm dataTableForm, string tableName, string columnName, string labelName, object value, ColumnLink columnLink)
        {
            InitializeComponent();

            Reset();

            this.EnabledTitleBarDarkMode();

            this.DataTableForm = dataTableForm;

            this.Text = string.Format("{0} - {1}", tableName, columnName);

            this.TableName = tableName;

            this.ColumnName = columnName;

            this.label1.Text = labelName;

            this.DataType = columnLink.DataType;

            this.Value = value;

            this.IsEditAble = true;

            if (columnLink.DataType == TableLink.TableDataType.LTE)
            {
                this.comboBoxList.Visible = true;

                string LTEName = null;
                if (this.DataTableForm.Editor.DAT.IsWOTWVersion)
                {
                    LTEName = columnLink.LTEWOTW;
                }
                else
                {
                    LTEName = columnLink.LTEOriginal;
                }

                this.label1.Text = LTEName;

                this.ListStringItem = LTECollection.LTEStringCollection[LTEName];

                for (int i = 0; i < this.ListStringItem.Count; i++)
                {
                    StringItem stringItem = this.ListStringItem[i];

                    this.comboBoxList.Items.Add(stringItem.ToString());
                }

                for (int i = 0; i < this.ListStringItem.Count; i++)
                {
                    StringItem stringItem = this.ListStringItem[i];
                    if (stringItem.ID == (int)value)
                    {
                        this.comboBoxList.SelectedIndex = i;
                        break;
                    }
                }
            }

            if (columnLink.DataType == TableLink.TableDataType.Enum)
            {
                this.comboBoxList.Visible = true;

                List<DATCollection.DATEnum> ListEnum = this.DataTableForm.EnumCollection[labelName];

                for (int i = 0; i < this.DataTableForm.EnumCollection[labelName].Count; i++)
                {
                    DATCollection.DATEnum enums = ListEnum[i];

                    this.ListStringItem.Add(new StringItem(enums.Value, enums.Name));

                    this.comboBoxList.Items.Add(string.Format("{0} - {1}", enums.Value, enums.Name));
                }

                for (int i = 0; i < this.ListStringItem.Count; i++)
                {
                    StringItem stringItem = this.ListStringItem[i];
                    if (stringItem.ID == (int)value)
                    {
                        this.comboBoxList.SelectedIndex = i;
                        break;
                    }
                }
            }

            if (columnLink.DataType == TableLink.TableDataType.LTE || columnLink.DataType == TableLink.TableDataType.Enum)
            {
                int minValue = 0, maxValue = 0;
                for (int i = 0; i < this.ListStringItem.Count; i++)
                {
                    StringItem stringItem = this.ListStringItem[i];

                    if (stringItem.ID < minValue)
                    {
                        minValue = stringItem.ID;
                    }

                    if (stringItem.ID > maxValue)
                    {
                        maxValue = stringItem.ID;
                    }
                }

                this.numNumber.Minimum = minValue;
                this.numNumber.Maximum = maxValue;
                this.numNumber.DecimalPlaces = 0;

                if (value is int intValue)
                {
                    this.numNumber.Value = (decimal)intValue;
                }
                this.numNumber.Visible = true;
                this.comboBoxList.Location = new Point(15, 65);
                this.Size = new Size(454, 210);

                this.numNumber.Select(0, this.numNumber.Text.Length);
            }

            if (columnLink.DataType == TableLink.TableDataType.Boolean)
            {
                this.checkBoxBoolean.Visible = true;

                if (value is int intValue)
                {
                    this.checkBoxBoolean.Checked = intValue == 1 ? true : false;
                }

                if (value is bool boolValue)
                {
                    this.checkBoxBoolean.Checked = boolValue;
                }

                this.checkBoxBoolean.Select();

                this.label1.Text = "Boolean";
            }

            if (columnLink.DataType == TableLink.TableDataType.Integer)
            {
                this.numNumber.Visible = true;
                this.numNumber.DecimalPlaces = 0;
                this.numNumber.Minimum = int.MinValue;
                this.numNumber.Maximum = int.MaxValue;

                if (value is int intValue)
                {
                    this.numNumber.Value = (decimal)intValue;
                }

                this.numNumber.Select(0, this.numNumber.Text.Length);

                this.label1.Text = "Integer";
            }

            if (columnLink.DataType == TableLink.TableDataType.Float)
            {
                this.numNumber.Visible = true;
                this.numNumber.DecimalPlaces = 2;
                this.numNumber.Minimum = decimal.MinValue;
                this.numNumber.Maximum = decimal.MaxValue;

                if (value is float floatValue)
                {
                    this.numNumber.Value = (decimal)floatValue;
                }

                this.numNumber.Select(0, this.numNumber.Text.Length);

                this.label1.Text = "Float";
            }

            if (columnLink.DataType == TableLink.TableDataType.String)
            {
                this.textBoxString.Visible = true;
                this.textBoxString.Text = (string)value;

                this.textBoxString.Select();

                this.label1.Text = "String";
            }

            this.label2.Visible = true;
        }

        public bool IsEditAble { get; set; }

        public string TableName { get; set; }

        public string ColumnName { get; set; }

        private DataTableForm DataTableForm { get; set; }

        private List<StringItem> ListStringItem { get; set; }

        private TableLink.TableDataType DataType { get; set; }

        public object Value { get; set; }

        private void EditValue_Load(object sender, EventArgs e)
        {
        }

        private void EditValue_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void Reset()
        {
            this.ListStringItem = new List<StringItem>();

            this.label2.Visible = false;
            this.numNumber.Visible = false;
            this.comboBoxList.Visible = false;
            this.textBoxString.Visible = false;
            this.checkBoxBoolean.Visible = false;

            Point location = new Point(15, 36);

            this.numNumber.Location = location;
            this.comboBoxList.Location = location;
            this.textBoxString.Location = location;

            this.numNumber.Size = new Size(409, 23);
            this.comboBoxList.Size = new Size(407, 23);
            this.textBoxString.Size = new Size(410, 23);
        }

        private void checkBoxBoolean_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxBoolean.Checked)
            {
                this.checkBoxBoolean.Text = "True";
            }
            else
            {
                this.checkBoxBoolean.Text = "False";
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SaveAndSendValue();
        }

        private void SaveAndSendValue()
        {
            if (this.DataType == TableLink.TableDataType.LTE)
            {
                StringItem stringItem = this.ListStringItem[this.comboBoxList.SelectedIndex];

                this.Value = stringItem.ID;
            }

            if (this.DataType == TableLink.TableDataType.Enum)
            {
                StringItem stringItem = this.ListStringItem[this.comboBoxList.SelectedIndex];

                this.Value = stringItem.ID;
            }

            if (this.DataType == TableLink.TableDataType.Boolean)
            {
                if (this.Value is int)
                {
                    this.Value = this.checkBoxBoolean.Checked ? 1 : 0;
                }

                if (this.Value is bool)
                {
                    this.Value = this.checkBoxBoolean.Checked ? true : false;
                }
            }

            if (this.DataType == TableLink.TableDataType.Integer)
            {
                this.Value = Convert.ToInt32(this.numNumber.Value);
            }

            if (this.DataType == TableLink.TableDataType.Float)
            {
                this.Value = Convert.ToSingle(this.numNumber.Value);
            }

            if (this.DataType == TableLink.TableDataType.String)
            {
                this.Value = this.textBoxString.Text;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Event_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SaveAndSendValue();
            }
        }

        private void numNumber_KeyUp(object sender, KeyEventArgs e)
        {
            this.numNumber_ValueChanged(sender, e);
        }

        private void numNumber_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.DataType == TableLink.TableDataType.LTE || this.DataType == TableLink.TableDataType.Enum)
                {
                    int selectIndex = this.comboBoxList.SelectedIndex;

                    int valueID = (int)this.numNumber.Value;

                    if (this.ListStringItem.Count > 0)
                    {
                        for (int i = 0; i < this.ListStringItem.Count; i++)
                        {
                            StringItem stringItem = this.ListStringItem[i];

                            if (stringItem.ID == valueID)
                            {
                                if (selectIndex != i)
                                {
                                    this.comboBoxList.SelectedIndex = i;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.DataTableForm.SetLabelText(string.Format("Error: {0}", ex.Message));
            }
        }

        private void comboBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.DataType == TableLink.TableDataType.LTE || this.DataType == TableLink.TableDataType.Enum)
                {
                    int selectIndex = this.comboBoxList.SelectedIndex;

                    int valueID = (int)this.numNumber.Value;

                    if (this.ListStringItem.Count > 0)
                    {
                        StringItem stringItem = this.ListStringItem[selectIndex];

                        if (valueID != stringItem.ID)
                        {
                            if (stringItem.ID is int intValue)
                            {
                                this.numNumber.Value = (decimal)intValue;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.DataTableForm.SetLabelText(string.Format("Error: {0}", ex.Message));
            }
        }
    }
}