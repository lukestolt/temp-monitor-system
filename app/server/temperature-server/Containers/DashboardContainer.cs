namespace temperature_server.Containers
{
    public sealed class DashboardContainer
    {
        public static DashboardContainer instance = null;
        private static readonly object padlock = new object();
        private CurrentStatusModel curStatusModel;

        DashboardContainer()
        {

        }

        public static DashboardContainer Instance
        {
            get
            {
                lock(padlock)
                {
                    if(instance == null)
                    {
                        instance = new DashboardContainer();
                    }
                    return instance;
                }
            }
        }
    }
}