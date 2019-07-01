using System.Collections.Generic;
using Models;
using System;

namespace Storage
{
    public sealed class TemperatureData
    {
        private static Object locker = new Object();
        private static TemperatureDataModel instance = null;
        private TemperatureData()
        {

        }
        // private static TemperatureDataModel temperatureData = new TemperatureDataModel();

        public static TemperatureDataModel Instance()
        {
            lock(locker)
            {
                if (instance == null)
                {
                    instance = new TemperatureDataModel();
                }
                return instance;
            }
        }

        public static void UpdateDashboardModel(DashboardModel dm)
        {
            // add the current model to list and then replace it with the param
            instance.dashboardModels.Add(instance.currentDashModel);
            instance.currentDashModel = dm;
        }

    }
}