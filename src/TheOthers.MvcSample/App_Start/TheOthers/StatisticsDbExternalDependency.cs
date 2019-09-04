namespace TheOthers.MvcSample.App_Start.Others
{
    public class StatisticsDbExternalDependency : DbExternalDependencyBase
    {
        public StatisticsDbExternalDependency()
            : base("Statistics Database", "StatisticsDb")
        {
        }
    }
}