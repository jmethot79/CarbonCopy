using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinc.CarbonCopy.Replication
{
    class ListMembersProvider : IMembersProvider
    {
        List<Replicate> IMembersProvider.GetMembers(EnvDTE.Debugger debugger, string variableName)
        {
            var members = new List<Replicate>();

            var itemsCount = Int32.Parse(_debugger.GetExpression(String.Concat(variableName, ".Count")).Value);

            for (int i = 0; i < itemsCount; i++)
            {
                members.Add(CreateReplicate(String.Concat(variableName, "(", i.ToString(), ")")));
            }

            return members;
        }
    }
}
