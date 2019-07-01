namespace Models
{
    public class TestModel
    {
        public float temperature;
        public float humidity;
        // public string date;
        // public string time;

        public TestModel(float temperature, float humidity)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            // this.date = date;
            // this.time = time;
        }
        
        public TestModel()
        {

        }
    }
}