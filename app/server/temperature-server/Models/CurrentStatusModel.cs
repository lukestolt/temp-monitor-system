namespace temperature_server.Models
{
    public class CurrentStatusModel
    {
        float temperature;
        float humidity;
        string timestamp;
        public CurrentStatusModel(float temp, float hum, string timesp)
        {
            this.temperature = temp;
            this.humidity = hum;
            this.timestamp = timesp;
        }
    }
}