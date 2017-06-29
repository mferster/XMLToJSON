using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToJSON.Models
{
    public interface IFileModels
    {
        string filePath { get; set; }

        bool isXMLFormat();
        bool isJSONFormat();
        string ReadFile();
        bool SaveAs(string content, string extension);
    }
}
