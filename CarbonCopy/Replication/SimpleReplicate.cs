using System;

namespace Zinc.CarbonCopy.Replication
{
    class SimpleReplicate : Replicate
    {
        public override string Declaration
        {
            get 
            {
                return String.Concat(Type, " = ", Value).Replace(",", ".");
            }
        }
    }
}
