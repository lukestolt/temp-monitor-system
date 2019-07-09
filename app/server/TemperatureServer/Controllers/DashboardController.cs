using Microsoft.AspNetCore.Mvc;
using Models;
using Storage;
using System;
using System.Collections.Generic;
using Models.ResponseModels;
using TemperatureServer.HubConfig;
using Microsoft.AspNetCore.SignalR;
using TemperatureServer.Services;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Controllers
{
    public class DashboardController: Controller
    {
        private IHubContext<ClimateHub> _hub;
        private ClimateService _climateService;

        public DashboardController(IHubContext<ClimateHub> hub, ClimateService climateService)
        {
            this._climateService = climateService;
            _hub = hub;
        }

        [HttpGet]
        public ActionResult GetCurrentStatus() 
        {
            // TemperatureData.Instance().currentDashModel = new DashboardModel(5, 6, "June 28, 2019", "9:54");
            ClimateModel dm = ClimateData.Instance().currentClimateModel;

            return Json(dm);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateCurrentStatus([FromBody] ClimateModel dashModel) 
        {
            if(dashModel != null)
            {
                // creates the id
                dashModel.populateFields();

                // insert into the database
                var before = await this._climateService.Create(dashModel);
                Console.WriteLine("\nBefore:" + before.temperature);

                // test that the data is in the database
                var results = _climateService.Get(dashModel.key);
                Console.WriteLine("After " + results.temperature);

                ClimateData.UpdateDashboard(dashModel);
                Console.WriteLine(ClimateData.Instance().currentClimateModel.temperature);
                //_hub.Clients.All.SendAsync("transfertemperaturedata",dashModel);
                return Json(new ResponseModel(ResponseModel.Responses.Success));
            }
            return Json(new ResponseModel(ResponseModel.Responses.Error));
        }
    }
}