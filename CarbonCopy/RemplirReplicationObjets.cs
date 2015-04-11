using EnvDTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zinc.CarbonCopy.Replication;

namespace Zinc.CarbonCopy
{
    class RemplirReplicationObjets
    {
        private Debugger _debugger;

        public RemplirReplicationObjets(Debugger Debugger)
        {
            _debugger = Debugger;
        }

        public ReplicationObject GetReplicationObject(string variableName)
        {
            EnvDTE.Expression expression = _debugger.GetExpression(variableName);

            if (!expression.IsValidValue)
            {
                throw new InvalidExpressionException(variableName);
            }
            
            ReplicationObject replicationObject = new ReplicationObject()
            {
                Name = expression.Name,
                Type = _debugger.GetExpression(String.Concat(variableName, ".GetType().FullName")).Value.Replace("\"",String.Empty),
                Value = expression.Value.Replace("\"", String.Empty)
            };

            return replicationObject;
        }
    }
}
