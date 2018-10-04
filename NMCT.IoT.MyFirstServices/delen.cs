
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace NMCT.IoT.MyFirstServices
{
    public static class delen
    {
        
        [FunctionName("deelfunction")]
        public static async Task<IActionResult> deelfunction([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "math/{age1}/{age2}")]HttpRequest req, decimal age1, decimal age2, ILogger log)
        {
            try
            {

                string result = (age1 / age2).ToString();
                return new OkObjectResult(result);
            }
            catch (Exception)
            {

                return new StatusCodeResult(500);
            }

            //log.LogInformation("C# HTTP trigger function processed a request.");

            //string name = req.Query["name"];

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            //return name != null
            //    ? (ActionResult)new OkObjectResult($"Hello, {name}")
            //    : new BadRequestObjectResult("Please pass a name on the query string or in the request body");

        }
    }
    
}
