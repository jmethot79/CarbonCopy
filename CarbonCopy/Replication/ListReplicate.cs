using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinc.CarbonCopy.Replication
{
    class ListReplicate : Replicate
    {
        public override string Declaration
        {
            get 
            {
                var stringBuilder = new StringBuilder();

                stringBuilder.Append(GetReplicateType());

                if (Members.Count > 0)
                {
                    stringBuilder.Append(" From {");

                    var membersStringBuilder = new StringBuilder();
                    foreach (Replicate arrayMember in Members)
                    {
                        if (membersStringBuilder.Length > 0)
                        {
                            membersStringBuilder.AppendLine(",");
                        }
                        membersStringBuilder.Append(arrayMember.Declaration);
                    }

                    stringBuilder.Append(membersStringBuilder.ToString());
                    stringBuilder.Append("}");
                }

                return stringBuilder.ToString();
            }
        }
        public string GetReplicateType()
        {
            return String.Concat("New List(Of ", MembersType,")");
        }
    }
}
