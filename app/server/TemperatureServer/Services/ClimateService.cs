using Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperatureServer.Models;

namespace TemperatureServer.Services
{
    public class ClimateService
    {
        private readonly IMongoCollection<ClimateModel> _climates;

        public ClimateService()
        {
            var client = new MongoClient(ClimateDatabaseSettings.ConnectionString);
            var database = client.GetDatabase(ClimateDatabaseSettings.DatabaseName);
            bool isMongoLive = database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000);
            if(isMongoLive)
            {
                Console.WriteLine("\nMongo Database is Live!\n");
            }
            else
            {
                Console.WriteLine("\nERROR: Could Not Connect to Mongo Database\n");
            }
            

            _climates = database.GetCollection<ClimateModel>(ClimateDatabaseSettings.ClimateCollectionName);
        }

        public List<ClimateModel> GetAll()
        {
            try
            {
                var filter = new FilterDefinitionBuilder<ClimateModel>().Empty;
                var results = _climates.Find<ClimateModel>(c => true).ToList();
                Console.WriteLine("results  = " + results);
                Console.WriteLine("\n");
                foreach (ClimateModel climate in results)
                {
                    Console.WriteLine("temperature = " + climate.temperature);
                }
                return results;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }
        public ClimateModel Get(string key)
        {
            try
            {
                return _climates.Find(dashboard => dashboard.key.Equals(key)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        public async Task<ClimateModel> Create(ClimateModel climate)
        {
            try
            {
                await _climates.InsertOneAsync(climate);
                return climate;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        public void Update(string key, ClimateModel climateIn) =>
            _climates.ReplaceOne(climate => climate.key.Equals(key), climateIn);

        public void Remove(ClimateModel climateIn) =>
            _climates.DeleteOne(climate => climate.key.Equals(climateIn.key));

        public void Remove(string key) =>
            _climates.DeleteOne(climate => climate.key.Equals(key));
    }
}
