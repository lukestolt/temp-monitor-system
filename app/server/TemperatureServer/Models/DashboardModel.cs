namespace Models
{
    public class DashboardModel
    {
        public float temperature;
        public float humidity;
        public string date;
        public string time;

        public DashboardModel(float temperature, float humidity, string date, string time)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.date = date;
            this.time = time;
        }
        
        public DashboardModel()
        {

        }
    }
}