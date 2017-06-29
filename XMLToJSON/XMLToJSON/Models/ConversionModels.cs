using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XMLToJSON.Models
{
    public class ConversionModels
    {
        public string Result { get; set; }
        public HttpStatusCode Status { get; set; }

        public ConversionModels() {}

        //Convert the file from one format to the other
        public void Convert(IFileModels file)
        {
            if (file == null)
            {
                Result = "Error: Cannot find file";
                Status = HttpStatusCode.ExpectationFailed;
                return;
            }

            string newFileContents, extension;

            if (file.isXMLFormat())
            {
                newFileContents = ConvertToJSON(file);
                extension = ".json";
            }
            else if (file.isJSONFormat())
            {
                newFileContents = ConvertToXML(file);
                extension = ".xml";
            }
            else
            {
                Result = String.Format(
                    "Error: {0} is neither a xml nor a json file", file.filePath);
                Status = HttpStatusCode.ExpectationFailed;
                return;
            }

            file.SaveAs(newFileContents, extension);

            Result = String.Format("C:\\temp\\file{0} created successfully!", extension);
            Status = HttpStatusCode.Created;
        }

        private string ConvertToJSON(IFileModels file)
        {
            string xml = file.ReadFile();
            var xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);
            return JsonConvert.SerializeXmlNode(xmldoc);
        }

        private string ConvertToXML(IFileModels file)
        {
            string json = file.ReadFile();

            var xml = JsonConvert.DeserializeXmlNode(json);
            return xml.OuterXml;
        }
    }
}