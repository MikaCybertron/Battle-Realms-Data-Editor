using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRealmsDataEditor.Data
{
    public class TableLink
    {
        public enum TableDataType
        {
            Object,
            Boolean = 2,
            Integer = 4,
            Float,
            String = 7,
            Enum,
            LTE
        }

        public TableLink()
        {
            Column = new Dictionary<string, ColumnLink>();
        }

        public Dictionary<string, ColumnLink> Column { get; set; }
    }


}
