using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRealmsDataEditor.Data
{
    public class StringItem
    {
        public StringItem(int iD, string text)
        {
            ID = iD;
            Text = text;
        }

        public int ID { get; set; }

        public string Text { get; set; }

        public override string ToString()
        {
            return string.Format("{0,-4} - {1}", this.ID, this.Text);
        }
    }
}
