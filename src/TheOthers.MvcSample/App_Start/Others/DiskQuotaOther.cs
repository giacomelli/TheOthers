using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheOthers.MvcSample.App_Start.Others
{
    public class DiskQuotaOther : OtherBase
    {
        public DiskQuotaOther()
            : base("Disk quota")
        {
        }

        protected override OtherStatus PerformCheckStatus()
        {
			throw new NotImplementedException ();
        }
    }
}