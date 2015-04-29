using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinc.CarbonCopy.Replication.Vb
{
    class NullReplicate : Replicate
    {
        public override string Declaration
        {
            get { return "Nothing"; }
        }
    }
}
