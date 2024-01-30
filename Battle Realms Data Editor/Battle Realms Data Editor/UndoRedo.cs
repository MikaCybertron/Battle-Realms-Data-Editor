using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRealmsDataEditor
{
    public class UndoRedo
    {
        public List<object> ListUndo { get; set; }

        public List<object> ListRedo { get; set; }

        public UndoRedo()
        {
            ListUndo = new List<object>();
            ListRedo = new List<object>();
        }

        public object Value
        {
            get
            {
                if(ListUndo.Count > 0)
                {
                    return ListUndo[ListUndo.Count - 1];
                }
                return null;
            }
        }

        public void OnUndo()
        {
            if (ListUndo.Count > 0)
            {
                int lastIndex = ListUndo.Count - 1;

                ListRedo.Add(ListUndo[ListUndo.Count - 1]);

                ListUndo.RemoveAt(lastIndex);
            }
        }

        public void OnRedo()
        {
            if (ListRedo.Count > 0)
            {
                int lastIndex = ListRedo.Count - 1;

                ListUndo.Add(ListRedo[ListRedo.Count - 1]);

                ListRedo.RemoveAt(lastIndex);
            }
        }
    }
}
