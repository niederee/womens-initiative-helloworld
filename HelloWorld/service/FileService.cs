using System;
using System.IO;

namespace HelloWorld
{
    public class FileService
    {
        public void MakeFile(FileInfo file)
        {
            makeDirectory(file);
            file.Create();
        }

        private void makeDirectory(FileInfo file)
        {
            if(!file.Directory.Exists)
            {
                file.Directory.Create();
            }
        }
    }
}