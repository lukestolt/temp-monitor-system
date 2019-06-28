using Microsoft.AspNetCore.Mvc;
using temperature_server.Models;
//using System;

namespace temperature_server.Controllers
{
    public class DashboardController : Controller
    {
        private CurrentStatusModel csm;
        public DashboardController()
        {
            //FIXME: temp mock data
            //CurrentStatusModel(5, 10, "2:26 , 6/2/19");
            CurrentStatusModel csm = DasboardContainer.Instance;
        }
        //dashboard/getCurrentStatus
        [HttpGet]
        public IActionResult getCurrentStatus()
        {
            Console.WriteLine("\n\nInside of the getCurrentStatus()\n\n");
            Console.WriteLine("\n\n " + csm);
            this.csm = new CurrentStatusModel(5, 10, "2:26 , 6/2/19");
            return Json(this.csm);

        }

        //TODO: login component otherwise they don't see anyting

    }
}
