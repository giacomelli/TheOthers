using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheOthers.MvcSample.App_Start.Others
{
    public class StatisticsDbOther : DbOtherBase
    {
        public StatisticsDbOther()
            : base("Statistis Database", "StatisticsDb")
        {
        }
    }
}