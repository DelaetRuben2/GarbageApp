
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
using NMCT.IoT.MyFirstServices.Model;

namespace NMCT.IoT.MyFirstServices
{
    public static class firstpost
    {
        [FunctionName("sum")]
        public static async Task<IActionResult> sum([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "sum/firstpost")]HttpRequest req,ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Som model = JsonConvert.DeserializeObject<Som>(requestBody);

            int result = model.Getal1 + model.Getal2;
            SomResultaat som = new SomResultaat();
            som.Resultaat = result;
            return new OkObjectResult(som);

        }
    }
}
