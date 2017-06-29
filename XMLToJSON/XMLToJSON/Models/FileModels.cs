using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace XMLToJSON.Models
{
    public class FileModels: IFileModels
    {
        public FileModels() { }

        public FileModels(string filePath)
        {
            this.filePath = filePath;
        }

        public string filePath { get; set; }

        //Check if file exists
        public bool Exists
        {
            get { return File.Exists(filePath); }
        }

        //Check file extension
        public bool isXMLFormat()
        {
            return filePath.Substring(filePath.Length - 4, 4).ToUpper() == ".XML";
        }

        //Check file extension
        public bool isJSONFormat()
        {
            return filePath.Substring(filePath.Length - 5, 5).ToUpper() == ".JSON";
        }

        public string ReadFile()
        {
            return File.ReadAllText(filePath);
        }

        public bool SaveAs(string content, string extension)
        {
            if (!Directory.Exists(@"C:\temp\"))
                Directory.CreateDirectory(@"C:\temp\");

            using (var writer = new StreamWriter(@"C:\temp\file" + extension, false))
            {
                writer.Write(content);
            }

            return true;
        }
    }
}