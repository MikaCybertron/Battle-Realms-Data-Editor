using BattleRealmsDataEditor.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRealmsDataEditor
{
    public static class BinaryReaderExtensions
    {
        public static object ReadBRObject(this BinaryReader binaryReader, DATCollection.DatDataType dataType)
        {
            if (dataType == DATCollection.DatDataType.Boolean)
            {
                return binaryReader.ReadBoolean();
            }
            if (dataType == DATCollection.DatDataType.Integer)
            {
                return binaryReader.ReadInt32();
            }
            if (dataType == DATCollection.DatDataType.Float)
            {
                return binaryReader.ReadSingle();
            }
            if (dataType == DATCollection.DatDataType.String)
            {
                return binaryReader.ReadBRString();
            }
            return null;
        }

        public static string ReadBRString(this BinaryReader binaryReader)
        {
            StringBuilder stringBuilder = new StringBuilder();
            binaryReader.ReadByte();
            int num = binaryReader.ReadInt32() - 1;
            for (int i = 0; i < num; i++)
            {
                stringBuilder.Append((char)binaryReader.ReadInt16());
            }
            binaryReader.ReadInt16();
            return stringBuilder.ToString();
        }

        public static string ReadBRString2(this BinaryReader binaryReader)
        {
            int num = binaryReader.ReadInt32();
            byte[] bytes = binaryReader.ReadBytes(num * 2 - 2);
            binaryReader.BaseStream.Position += 2L;
            return Encoding.Unicode.GetString(bytes);
        }
    }
}
