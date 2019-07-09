using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class ClimateDataModel
    {
        public List<ClimateModel> dashboardModels;
        public ClimateModel currentClimateModel;
        public ClimateDataModel()
        {
            dashboardModels = new List<ClimateModel>();
            currentClimateModel = new ClimateModel();
        }
    }
}