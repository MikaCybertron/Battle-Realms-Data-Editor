using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BattleRealmsDataEditor.Data
{
    public class ColumnLink
    {


        public ColumnLink(string enumName, TableLink.TableDataType dataType)
        {
            EnumName = enumName;
            DataType = dataType;
        }

        public ColumnLink(TableLink.TableDataType dataType)
        {
            EnumName = null;
            DataType = dataType;
        }

        public ColumnLink(string lTEOriginal, string lTEWOTW, TableLink.TableDataType dataType)
        {
            EnumName = null;
            LTEOriginal = lTEOriginal;
            LTEWOTW = lTEWOTW;
            DataType = dataType;
        }

        public string EnumName { get; set; }

        public string LTEOriginal { get; set; }

        public string LTEWOTW { get; set; }

        public TableLink.TableDataType DataType { get; set; }
    }
}
