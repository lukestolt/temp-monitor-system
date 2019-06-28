using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;

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
            DashboardModel dm = new DashboardModel(5, 6, "June 28, 2019", "9:54");
            
            var obj = new { name = "hello"};
            // return new JsonResult(obj);
            return Json(dm);
        }
    }
}