using Microsoft.AspNetCore.Mvc;
using Models.ResponseModels;
using MongoDB.Driver;
using Newtonsoft.Json;
using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TemperatureServer.Services;

namespace TemperatureServer.Controllers
{
    public class HistoricalController: Controller
    {
        private readonly ClimateService _climateService;
        public HistoricalController(ClimateService climateService)
        {
            this._climateService = climateService;
        }

        [HttpGet]
        public IActionResult GetHistoricalData()
        {
            foreach(string key in RouteData.Values.Keys)
            {
                Console.WriteLine("\nKey = " + key);
            }
            string startKey = RouteData.Values["startKey"] + "";
            string finishKey = RouteData.Values["finishKey"] + "";
            Console.WriteLine(startKey);
            Console.WriteLine(finishKey);
            // example for query to get all the values in a range
            // var filter = builder.And(builder.Eq("status", "A"), builder.Lt("qty", 30));


            string tempJson = JsonConvert.SerializeObject(ClimateData.Instance().dashboardModels);
            System.IO.File.WriteAllText(@"C:\Git\RemoteTemperature\app\server\TemperatureServer\Data\data.txt", tempJson);
            return Json(ClimateData.Instance().dashboardModels);
        }
    }
}
