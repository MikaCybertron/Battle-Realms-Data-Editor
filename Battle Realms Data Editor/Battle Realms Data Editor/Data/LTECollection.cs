using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BattleRealmsDataEditor.Data
{
    public class LTECollection
    {

        public static void DoOpen()
        {
            LTEStringCollection = new Dictionary<string, List<StringItem>>();

            DirectoryInfo directoryInfo = new DirectoryInfo("Text");
            if (directoryInfo.Exists)
            {
                FileInfo[] files = directoryInfo.GetFiles("*.lte");

                for (int i = 0; i < files.Length; i++)
                {
                    List<StringItem> stringCollection = new List<StringItem>();

                    MemoryStream input = new MemoryStream(File.ReadAllBytes(files[i].FullName));

                    using (BinaryReader binaryReader = new BinaryReader(input))
                    {
                        if (binaryReader.ReadInt32() == 1)
                        {
                            int capacity = binaryReader.ReadInt32();

                            long[] offset = new long[capacity];

                            for (int j = 0; j < capacity; j++)
                            {
                                int value = binaryReader.ReadInt32();

                                string name = binaryReader.ReadBRString();

                                stringCollection.Add(new StringItem(value, name));
                            }
                        }
                    }

                    LTEStringCollection.Add(files[i].Name, stringCollection);
                }
            }
        }

        public static Dictionary<string, List<StringItem>> LTEStringCollection { get; set; }
    }
}
