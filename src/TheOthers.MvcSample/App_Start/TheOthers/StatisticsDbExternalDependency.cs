using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheOthers.MvcSample.App_Start.Others
{
    public class StatisticsDbExternalDependency : DbExternalDependencyBase
    {
        public StatisticsDbExternalDependency()
            : base("Statistis Database", "StatisticsDb")
        {
        }
    }
}