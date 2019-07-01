using System.Collections.Generic;

namespace Models
{
    public class TemperatureDataModel
    {
        public List<DashboardModel> dashboardModels = new List<DashboardModel>();
        public DashboardModel currentDashModel = new DashboardModel();
        public TemperatureDataModel()
        {

        }
    }
}