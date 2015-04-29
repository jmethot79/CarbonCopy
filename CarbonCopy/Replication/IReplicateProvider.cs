using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinc.CarbonCopy.Replication
{
    interface IReplicateProvider
    {
        Replicate CreateReplicate(string variableName);
    }
}
