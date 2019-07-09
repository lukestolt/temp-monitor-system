using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class ClimateModel
    {

        public double temperature { get; set; }

        public double humidity { get; set; }

        public string date { get; set; }

        public string time { get; set; }

        [BsonId]
        public string key { get; set; }

        public ClimateModel(double temperature, double humidity)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            populateFields();

        }

        public ClimateModel()
        {

        }

        public void populateFields()
        {
            DateTime localDate = DateTime.Now;

            string hour = localDate.Hour + "";
            if (localDate.Hour < 10)
                hour = "0" + localDate.Minute;

            string minute = localDate.Minute + "";
            if (localDate.Minute < 10)
                minute = "0" + localDate.Minute;

            string second = localDate.Second + "";
            if (localDate.Second < 10)
                minute = "0" + localDate.Second;

            string month = localDate.Month + "";
            if (localDate.Month < 10)
                month = "0" + localDate.Month;

            string day = localDate.Day + "";
            if (localDate.Day < 10)
                day = "0" + localDate.Day;

            this.time = hour + ":" + minute;
            this.date = month + "/" + day + "/" + localDate.Year;
            this.key = localDate.Year + month + day + hour + minute + second;
        }
    }
}