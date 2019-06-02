using Microsoft.AspNetCore.Mvc;
using temperature_server.Models;
using System;

namespace temperature_server.Controllers
{
    public class DashboardController : Controller
    {
        public CurrentStatusModel csm;
        public DashboardController()
        {
            //FIXME: temp mock data
            csm = new CurrentStatusModel(5, 10, "2:26 , 6/2/19");
        }

        [HttpGet]
        public IActionResult getCurrentStatus()
        {
            Console.WriteLine("\n\nInside of the getCurrentStatus()\n\n");
            this.csm = new CurrentStatusModel(5, 10, "2:26 , 6/2/19");
            Console.WriteLine(Json(this.csm));
            return Json(this.csm);
        }

        //TODO: login component otherwise they don't see anyting

    }
}
