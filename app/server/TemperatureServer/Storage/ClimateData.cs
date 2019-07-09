using System.Collections.Generic;
using Models;
using System;

namespace Storage
{
    public sealed class ClimateData
    {
        private static Object locker = new Object();
        private static ClimateDataModel instance = null;
        private ClimateData()
        {

        }
        // private static TemperatureDataModel temperatureData = new TemperatureDataModel();

        public static ClimateDataModel Instance()
        {
            lock(locker)
            {
                if (instance == null)
                {
                    instance = new ClimateDataModel();
                }
                return instance;
            }
        }

        public static void UpdateDashboard(ClimateModel climateMod)
        {
            
            // don't add the first model with empty data to the list
            if(climateMod != null && climateMod.date != null)
            {
                Console.WriteLine("ClimateData updateDashboard: " + climateMod.temperature);
                ClimateModel cData = ClimateData.Instance().currentClimateModel;
                if(cData.humidity != 0)
                {
                    ClimateData.Instance().dashboardModels.Add(instance.currentClimateModel);
                }

                
            }
            instance.currentClimateModel = new ClimateModel(climateMod.temperature, climateMod.humidity);
        }
    }
}