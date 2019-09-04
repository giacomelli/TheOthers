using System;

namespace TheOthers.MvcSample
{
    public class LegacySystemExternalDependecy : ExternalDependencyBase
    {
        public LegacySystemExternalDependecy() : base("Legacy system")
        {
        }

        protected override ExternalDependencyStatus PerformCheckStatus()
        {
            // TODO: perform the check against the legacy system api.
            throw new NotImplementedException();
        }
    }
}

