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

                if (Properties.Count > 0)
                {
                    stringBuilder.Append(" {");

                    var propertiesStringBuilder = new StringBuilder();
                    foreach(Replicate arrayMember in Properties)
                    {
                        if (propertiesStringBuilder.Length > 0)
                        {
                            propertiesStringBuilder.AppendLine(",");
                        }
                        propertiesStringBuilder.Append(arrayMember.Declaration);  
                    }

                    stringBuilder.Append(propertiesStringBuilder.ToString());
                    stringBuilder.Append("}");
                }
                
                return stringBuilder.ToString();
            }
        }
    }
}
