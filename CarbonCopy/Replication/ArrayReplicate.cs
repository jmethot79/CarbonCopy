using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinc.CarbonCopy.Replication
{
    class ArrayReplicate : Replicate
    {
        public override string Declaration
        {
            get
            {
                var stringBuilder = new StringBuilder();

                stringBuilder.Append(String.Concat("New ", Type));

                return stringBuilder.ToString();
            }
        }
    }
}
