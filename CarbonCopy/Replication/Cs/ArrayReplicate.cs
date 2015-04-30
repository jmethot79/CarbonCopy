using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinc.CarbonCopy.Replication.Cs
{
    class ArrayReplicate : Replicate
    {
        public override string Declaration
        {
            get
            {
                //            MyClass mc = new MyClass() { S1 = "tes", I1 = 2, A1 = new string[] { "test2", "test2" } };

                var stringBuilder = new StringBuilder();

                if (Members.Count > 0)
                {
                    stringBuilder.Append("new string[] {");

                    var membersStringBuilder = new StringBuilder();
                    foreach(Replicate arrayMember in Members)
                    {
                        if (membersStringBuilder.Length > 0)
                        {
                            membersStringBuilder.AppendLine(",");
                        }
                        membersStringBuilder.Append(String.Concat(Indentation.ToString(), arrayMember.Declaration));  
                    }

                    stringBuilder.Append(membersStringBuilder.ToString());
                    stringBuilder.Append("}");
                }
                
                return stringBuilder.ToString();
            }
        }
    }
}
