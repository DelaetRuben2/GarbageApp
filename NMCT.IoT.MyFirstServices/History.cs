
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
        public static class History
        {
            [FunctionName("historyfunction")]
            public static async Task<IActionResult> historyfunction([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequest req, ILogger log)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
                //logged informatie in de azure cloud, handig voor te debuggen bij productie.
                string from = string.Empty;
                string to = string.Empty;

                try
                {
                    foreach (var key in req.Query.Keys)
                    {
                        if (key == "from")
                        {
                            from = req.Query["from"];
                        }
                        if (key == "to")
                        {
                            to = req.Query["to"];
                        }
                    }
                    string result = ("Van " + from + " tot " + to);
                    return new OkObjectResult(result);
                }
                catch (Exception)
                {

                    return new StatusCodeResult(500);
                }









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
