using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLToJSON.Models;

namespace ConsoleXMLToJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = "Error Occured";
            try
            {
                string filePath = PromptUserForFilepath();
                var file = new FileModels(filePath);

                if (filePath != null && filePath != "" && file.Exists)
                {
                    var conversion = new ConversionModels();

                    //Do the Conversion
                    conversion.Convert(file as IFileModels);

                    //Prepare the results
                    result = conversion.Result;
                }
                else
                {
                    result = "Error: file does not exist";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
                Console.WriteLine(result);
                Console.Read();
            }
        }

        static string PromptUserForFilepath()
        {
            Console.WriteLine("Enter filepath including filename of file to convert:");
            Console.WriteLine(@"ex. C:\temp\original.xml");
            return Console.ReadLine();
        }
    }
}
