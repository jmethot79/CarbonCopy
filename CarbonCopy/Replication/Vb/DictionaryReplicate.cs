using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinc.CarbonCopy.Replication.Vb
{
    class DictionaryReplicate : Replicate
    {
        public override string Declaration
        {
            get 
            {
                var stringBuilder = new StringBuilder();

                if (Members.Count > 0)
                {
                    Indentation.Level++;

                    stringBuilder.Append(String.Concat("New Dictionary(Of ", MembersType, ") From {"));

                    var membersStringBuilder = new StringBuilder();
                    foreach (Replicate member in Members)
                    {
                        if (membersStringBuilder.Length > 0)
                        {
                            membersStringBuilder.AppendLine(",");
                        }
                        membersStringBuilder.Append(String.Concat(Indentation.ToString(), member.Declaration));
                    }

                    Indentation.Level--;

                    stringBuilder.Append(membersStringBuilder.ToString());
                    stringBuilder.Append("}");
                }

                return stringBuilder.ToString();
            }
        }
    }
}
