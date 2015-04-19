using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinc.CarbonCopy.Replication
{
    class KeyValuePairReplicate : Replicate
    {
        public Replicate Key = null;
        new public Replicate Value = null;

        public override string Declaration
        {
            get 
            {
                return String.Concat("{", Key.Declaration, ", ", Value.Declaration, "}");
            }
        }
    }
}
