using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinc.CarbonCopy.Replication.Cs
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
                    stringBuilder.AppendLine(String.Concat("new Dictionary<", MembersType, ">"));
                    stringBuilder.AppendLine(String.Concat(Indentation.ToString(), "{"));

                    Indentation.Level++;

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

                    stringBuilder.AppendLine(membersStringBuilder.ToString());
                    stringBuilder.Append(String.Concat(Indentation.ToString(), "}"));
                }

                return stringBuilder.ToString();
            }
        }
    }
}
