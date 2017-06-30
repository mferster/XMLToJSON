using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XMLToJSON.Models;

namespace XMLToJSON.Controllers
{
    public class ConvertController : ApiController
    {
        // POST: api/Convert
        public HttpResponseMessage Post(FileModels file)
        {
            var response = new HttpResponseMessage();
            try
            {
                if (file != null && file.Exists)
                {
                    var conversion = new ConversionModels();

                    //Do the conversion
                    conversion.Convert(file as IFileModels);

                    //Prepare the response
                    response.Content = new StringContent(conversion.Result);
                    response.StatusCode = conversion.Status;

                    return response;
                }
                else
                {
                    response.Content = new StringContent("Error: file does not exist");
                    response.StatusCode = HttpStatusCode.ExpectationFailed;
                    return response;
                }
            }
            catch(Exception ex)
            {
                response.Content = new StringContent(ex.Message);
                response.StatusCode = HttpStatusCode.InternalServerError;
                return response;
            }
        }
    }
}
