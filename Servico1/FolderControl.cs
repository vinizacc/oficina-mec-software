using System;
using System.IO;

namespace Servico1
{
    public class FolderControl
    {
        public string mainFolder { get; set; }
        public FolderControl()
        {

            mainFolder = @"./Pdf";
        }

        public string getMainFolder() { return mainFolder; }
        public void createDir()
        {
            if (!Directory.Exists(mainFolder))
            {
                Directory.CreateDirectory(mainFolder);
            }
        }

        //public string fileNameFromPath(string fileNameAndPath)
        //{

        //}


        //O index será o nome do arquivo = data que foi criada.
        public string createPdf()
        {
            string fileNameWithExtention = mainFolder + "/" + dataHoje() + ".pdf";

            return fileNameWithExtention;
        }

        public string pathForCurrentFile()
        {

            string fileNameWithExtention = mainFolder + "/" + dataHoje() + ".pdf";
            return fileNameWithExtention;
        }

        private string dataHoje()
        {
            string hoje = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
            return hoje;
        }
        //
        public string absolutePathOfPdf(string relativePath)
        {
            string absolutePath = System.IO.Path.GetFullPath(relativePath);
            return absolutePath;
        }

        public string fileName(string path)
        {
            string fileName = System.IO.Path.GetFileNameWithoutExtension(path);
            return fileName;
        }

        public string filePath(string pathWithFile)
        {
            string filePath = System.IO.Path.GetDirectoryName(pathWithFile);
            return filePath;
        }
    }
}
