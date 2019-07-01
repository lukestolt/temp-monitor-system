using Microsoft.AspNetCore.Mvc;
using Models;
using Storage;
using System;
using System.Collections.Generic;
using Models.ResponseModels;

namespace Controllers
{
    public class DashboardController: Controller
    {
        public DashboardController()
        {

        }

        [HttpGet]
        public ActionResult GetCurrentStatus() 
        {
            // TemperatureData.Instance().currentDashModel = new DashboardModel(5, 6, "June 28, 2019", "9:54");
            DashboardModel dm = TemperatureData.Instance().currentDashModel;
            return Json(dm);
        }

        [HttpPost]
        public ActionResult UpdateCurrentStatus([FromBody] DashboardModel dashModel) 
        {
            Console.WriteLine(dashModel);
            if(dashModel != null)
            {
                TemperatureData.UpdateDashboardModel(dashModel);
                Console.WriteLine(TemperatureData.Instance().currentDashModel.date);
                return Json(new ResponseModel(ResponseModel.Responses.Success));
            }
            return Json(new ResponseModel(ResponseModel.Responses.Error));
        }

        [HttpPost]
        public void UpdateTest([FromBody] string num) 
        {
            Console.WriteLine("num = " + num);
        }

    }
}