using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRealmsDataEditor.Data
{
    public class DATFile
    {
        public DATFile(string fullPath)
        {
            FileInfo fileInfo = new FileInfo(fullPath);

            DataBuffer = File.ReadAllBytes(fullPath);

            FullPath = fileInfo.FullName;

            DirectoryPath = fileInfo.Directory.FullName;

            FileName = fileInfo.Name;

            DirectoryName = fileInfo.DirectoryName;

            Extension = fileInfo.Extension;
        }

        public byte[] DataBuffer { get; private set; }

        public string FullPath { get; private set; }

        public string DirectoryPath { get; private set; }

        public string FileName { get; private set; }

        public string DirectoryName { get; private set; }

        public string Extension { get; private set; }

        public bool IsFileExists()
        {
            return File.Exists(this.FullPath);
        }

        public bool IsDirectoryExists()
        {
            return Directory.Exists(this.DirectoryPath);
        }

        public void CreateDirectory()
        {
            Directory.CreateDirectory(this.DirectoryPath);
        }

        public override string ToString()
        {
            return string.Format("Full Path: {0},\nDirectory Path: {1},\nFile Name: {2},\nDirectory Name: {3},\nExtension: {4}", FullPath, DirectoryPath, FileName, DirectoryName, Extension);
        }
    }
}
