using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BattleRealmsDataEditor.Data
{
    public class DATEditor
    {
        public DATCollection DAT { get; set; }

        public DATFile DATFile { get; set; }

        public byte[] BufferData { get; set; }

        // Open Data
        public void DoOpen(DATFile datFile)
        {
            this.DAT = new DATCollection();

            this.DATFile = datFile;

            this.BufferData = datFile.DataBuffer;

            MemoryStream input = new MemoryStream(this.BufferData);

            using (BinaryReader binaryReader = new BinaryReader(input))
            {
                int num = binaryReader.ReadInt32();
                long offsetEnum = binaryReader.ReadInt64();
                long offsetData = binaryReader.ReadInt64();

                ReadEnumCollection(binaryReader, offsetEnum);
                ReadDataCollection(binaryReader, offsetData);
            }
        }

        private void ReadEnumCollection(BinaryReader binaryReader, long offset)
        {

            binaryReader.BaseStream.Position = offset;

            int capacity = binaryReader.ReadInt32();

            this.DAT.EnumCollection = new DATCollection.DATEnumCollection[capacity];

            // Body Offset
            for (int i = 0; i < capacity; i++)
            {
                this.DAT.EnumCollection[i] = new DATCollection.DATEnumCollection();
                this.DAT.EnumCollection[i].BodyOffset = binaryReader.ReadInt64();
            }

            // Class Enum
            for (int i = 0; i < capacity; i++)
            {
                this.DAT.EnumCollection[i].Offset = binaryReader.BaseStream.Position;

                this.DAT.EnumCollection[i].Name = binaryReader.ReadBRString();
            }


            // Enum Value
            for (int i = 0; i < capacity; i++)
            {
                binaryReader.BaseStream.Position = this.DAT.EnumCollection[i].BodyOffset;

                int capacity2 = binaryReader.ReadInt32();

                this.DAT.EnumCollection[i].ListEnum = new List<DATCollection.DATEnum>();

                // Enum Value
                for (int j = 0; j < capacity2; j++)
                {
                    this.DAT.EnumCollection[i].CreateEnum();

                    this.DAT.EnumCollection[i].ListEnum[j].Offset = binaryReader.BaseStream.Position;

                    this.DAT.EnumCollection[i].ListEnum[j].Name = binaryReader.ReadBRString();
                }

                // Enum Value
                for (int j = 0; j < capacity2; j++)
                {
                    int value = binaryReader.ReadInt32();

                    this.DAT.EnumCollection[i].ListEnum[j].Value = value;
                }
            }
        }

        private void ReadDataCollection(BinaryReader binaryReader, long offset)
        {
            binaryReader.BaseStream.Position = offset;

            int capacity = binaryReader.ReadInt32();

            this.DAT.DataCollection = new DATCollection.DATDataCollection[capacity];

            // Offset
            for (int i = 0; i < capacity; i++)
            {
                this.DAT.DataCollection[i] = new DATCollection.DATDataCollection();
                this.DAT.DataCollection[i].Offset = binaryReader.ReadInt64();
            }

            // Body Offset
            for (int i = 0; i < capacity; i++)
            {
                this.DAT.DataCollection[i].BaseOffset = binaryReader.ReadInt64();
            }

            // Class Data
            for (int i = 0; i < capacity; i++)
            {
                this.DAT.DataCollection[i].BodyOffset = binaryReader.BaseStream.Position;

                this.DAT.DataCollection[i].Name = binaryReader.ReadBRString();
            }

            // Data Type & Header Name
            for (int i = 0; i < capacity; i++)
            {
                binaryReader.BaseStream.Position = this.DAT.DataCollection[i].Offset;

                int capacity2 = binaryReader.ReadInt32();

                this.DAT.DataCollection[i].ColumnCount = capacity2;

                this.DAT.DataCollection[i].Columns = new List<DATCollection.DATDataColumn>();

                // Data Type
                for (int j = 0; j < capacity2; j++)
                {
                    this.DAT.DataCollection[i].CreateColumn();
                    this.DAT.DataCollection[i].Columns[j].DataType = (DATCollection.DatDataType) binaryReader.ReadInt32();
                }

                // Header Name
                for (int j = 0; j < capacity2; j++)
                {
                    this.DAT.DataCollection[i].Columns[j].Name = binaryReader.ReadBRString();

                    // Check if Batlle Realms.dat is WOTW Version
                    if (this.DAT.DataCollection[i].Columns[j].Name == "WotWTechLevel")
                    {
                        this.DAT.IsWOTWVersion = true;
                    }
                }
            }

            // Value & Offset
            for (int i = 0; i < capacity; i++)
            {
                binaryReader.BaseStream.Position = this.DAT.DataCollection[i].BaseOffset;

                int capacity2 = this.DAT.DataCollection[i].ColumnCount;

                int capacity3 = binaryReader.ReadInt32();

                this.DAT.DataCollection[i].RowCount = capacity3;

                this.DAT.DataCollection[i].Cells = new DATCollection.DATDataCells[capacity3][];

                //for (int k = 0; k < capacity2; k++)
                //{
                //    if (this.DAT.DataCollection[i].Columns[k].Name.ToLower().Contains("cost") || this.DAT.DataCollection[i].Columns[k].Name.ToLower().Contains("clan"))
                //    {
                //        Console.WriteLine("Data: {0}, Column Name: {1} ({2}), Column Index: {3}", this.DAT.DataCollection[i].Name, this.DAT.DataCollection[i].Columns[k].Name, this.DAT.DataCollection[i].Columns[k].DataType.ToString(), k);
                //    }
                //}
                    

                for (int j = 0; j < capacity3; j++)
                {
                    this.DAT.DataCollection[i].Cells[j] = new DATCollection.DATDataCells[capacity2];

                    for (int k = 0; k < capacity2; k++)
                    {
                        this.DAT.DataCollection[i].Cells[j][k] = new DATCollection.DATDataCells();

                        this.DAT.DataCollection[i].Cells[j][k].Offset = (int)binaryReader.BaseStream.Position;

                        if (this.DAT.DataCollection[i].Columns[k].DataType == DATCollection.DatDataType.String)
                        {
                            this.DAT.DataCollection[i].Cells[j][k].Value = binaryReader.ReadBRString();
                        }
                        else
                        {
                            this.DAT.DataCollection[i].Cells[j][k].Value = binaryReader.ReadBRObject(this.DAT.DataCollection[i].Columns[k].DataType);
                        }
                    }
                }
            }
        }



        public object ReadValue(long offset, Type dataType)
        {
            if (offset < 0 || offset + Marshal.SizeOf(dataType) > this.BufferData.Length)
            {
                throw new ArgumentOutOfRangeException("Offset is out of range.");
            }

            byte[] bytes = new byte[Marshal.SizeOf(dataType)];
            Array.Copy(this.BufferData, offset, bytes, 0, bytes.Length);

            if (dataType == typeof(byte))
            {
                return bytes[0];
            }
            else if (dataType == typeof(bool))
            {
                return BitConverter.ToBoolean(bytes, 0);
            }
            else if (dataType == typeof(float))
            {
                return BitConverter.ToSingle(bytes, 0);
            }
            else if (dataType == typeof(int))
            {
                return BitConverter.ToInt32(bytes, 0);
            }
            else if (dataType == typeof(uint))
            {
                return BitConverter.ToUInt32(bytes, 0);
            }
            else if (dataType == typeof(long))
            {
                return BitConverter.ToInt64(bytes, 0);
            }
            else if (dataType == typeof(ulong))
            {
                return BitConverter.ToUInt64(bytes, 0);
            }
            else if (dataType == typeof(short))
            {
                return BitConverter.ToInt16(bytes, 0);
            }
            else if (dataType == typeof(ushort))
            {
                return BitConverter.ToUInt16(bytes, 0);
            }
            else if (dataType == typeof(string))
            {
                int stringLength = BitConverter.ToInt32(bytes, 0);
                byte[] stringBytes = new byte[stringLength - 1];
                Array.Copy(bytes, 4, stringBytes, 0, stringLength - 1);
                return Encoding.Unicode.GetString(stringBytes);
            }
            else
            {
                throw new NotSupportedException("Unsupported data type.");
            }
        }


        public void ChangeValue(long offset, object value)
        {
            if (offset < 0 || offset > this.BufferData.Length)
            {
                throw new ArgumentOutOfRangeException("Offset is out of range.");
            }

            byte[] bytes = null;

            if (value is byte)
            {
                bytes = new byte[]
                {
                    (byte)value
                };
            }
            if (value is bool)
            {
                bytes = BitConverter.GetBytes((bool)value);
            }

            if (value is float)
            {
                bytes = BitConverter.GetBytes((float)value);
            }

            if (value is int)
            {
                bytes = BitConverter.GetBytes((int)value);
            }

            if (value is uint)
            {
                bytes = BitConverter.GetBytes((uint)value);
            }

            if (value is long)
            {
                bytes = BitConverter.GetBytes((long)value);
            }

            if (value is ulong)
            {
                bytes = BitConverter.GetBytes((ulong)value);
            }

            if (value is short)
            {
                bytes = BitConverter.GetBytes((short)value);
            }

            if (value is ushort)
            {
                bytes = BitConverter.GetBytes((ushort)value);
            }

            if (value is string)
            {
                // Convert the string to bytes with the same format as WriteBRString
                string stringValue = (string)value;
                byte[] stringBytes = new byte[stringValue.Length * 2 + 4];
                BitConverter.GetBytes(stringValue.Length + 1).CopyTo(stringBytes, 0);
                for (int i = 0; i < stringValue.Length; i++)
                {
                    BitConverter.GetBytes((short)stringValue[i]).CopyTo(stringBytes, i * 2 + 4);
                }
                BitConverter.GetBytes(0).CopyTo(stringBytes, stringBytes.Length - 4);
                bytes = stringBytes;
            }

            Array.Copy(bytes, 0, this.BufferData, offset, bytes.Length);
        }

        public void SaveFile()
        {
            if (GlobalManagement.SaveALLChangesValue.Count > 0)
            {
                foreach (var pair in GlobalManagement.SaveALLChangesValue)
                {
                    long offset = pair.Key;

                    object value = pair.Value;

                    ChangeValue(offset, value);
                }
            }

            if(!this.DATFile.IsDirectoryExists())
            {
                this.DATFile.CreateDirectory();
            }

            File.WriteAllBytes(Path.Combine(this.DATFile.DirectoryPath, this.DATFile.FileName), this.BufferData);
        }

        public void SaveAsFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Files";
            saveFileDialog.Filter = "DAT Files (*.dat)|*.dat";

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (GlobalManagement.SaveALLChangesValue.Count > 0)
                {
                    foreach (var pair in GlobalManagement.SaveALLChangesValue)
                    {
                        long offset = pair.Key;

                        object value = pair.Value;

                        ChangeValue(offset, value);
                    }
                }

                File.WriteAllBytes(saveFileDialog.FileName, this.BufferData);

                this.DATFile = new DATFile(saveFileDialog.FileName);
            }
        }
    }
}
