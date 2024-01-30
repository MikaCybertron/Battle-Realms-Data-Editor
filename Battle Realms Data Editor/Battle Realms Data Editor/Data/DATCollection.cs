using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRealmsDataEditor.Data
{
    public class DATCollection
    {
        public enum DatDataType
        {
            Object,
            Boolean = 2,
            Integer = 4,
            Float,
            String = 7
        }

        public DATCollection()
        {
            IsWOTWVersion = false;
        }

        public bool IsWOTWVersion { get; set; }

        public DATDataCollection[] DataCollection { get; set; }

        public DATEnumCollection[] EnumCollection { get; set; }


        // Data Collection
        public class DATDataCollection
        {
            public DATDataCollection(string name, long offset, long bodyOffset, int capacity, List<DATDataColumn> columns)
            {
                Name = name;
                Offset = offset;
                BaseOffset = bodyOffset;
                ColumnCount = capacity;
                Columns = columns;
            }

            public DATDataCollection()
            {
                Name = null;
                Offset = 0;
                BaseOffset = 0;
                ColumnCount = 0;
                Columns = null;
            }

            public string Name { get; set; }

            public long Offset { get; set; }

            public long BaseOffset { get; set; }

            public long BodyOffset { get; set; }

            public int ColumnCount { get; set; } // or Records

            public int RowCount { get; set; }

            public List<DATDataColumn> Columns { get; set; }

            public DATDataCells[][] Cells { get; set; }

            public void CreateColumn()
            {
                Columns.Add(new DATDataColumn());
            }
        }

        public class DATDataColumn
        {
            public DATDataColumn(string name, DatDataType dataType, long offset)
            {
                Name = name;
                DataType = dataType;
                Offset = offset;
            }

            public DATDataColumn()
            {
                Name = null;
                DataType = DatDataType.Object;
                Offset = 0;
            }

            public string Name { get; set; }

            public DatDataType DataType { get; set; }

            public long Offset { get; set; }
        }

        public class DATDataCells
        {
            public DATDataCells(object value, long offset)
            {
                Value = value;
                Offset = offset;
            }

            public DATDataCells()
            {
                Value = null;
                Offset = 0;
            }

            public object Value { get; set; }

            public long Offset { get; set; }
        }


        // Enums Collection
        public class DATEnumCollection
        {
            public string Name { get; set; }

            public long BodyOffset { get; set; }

            public long Offset { get; set; }

            public List<DATEnum> ListEnum { get; set; }

            public void CreateEnum()
            {
                ListEnum.Add(new DATEnum());
            }
        }

        public class DATEnum
        {
            public string Name { get; set; }

            public int Value { get; set; }

            public long Offset { get; set; }
        }
    }
}
