using EnvDTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zinc.CarbonCopy.Replication;

namespace Zinc.CarbonCopy
{
    class ReplicationObjetProvider
    {
        private Debugger _debugger;

        public ReplicationObjetProvider(Debugger Debugger)
        {
            _debugger = Debugger;
        }

        public ReplicationObject CreateReplicationObject(string variableName)
        {
            EnvDTE.Expression expression = _debugger.GetExpression(variableName);

            if (!expression.IsValidValue)
            {
                throw new InvalidExpressionException(variableName);
            }

            var s = _debugger.GetExpression(String.Concat(variableName, ".GetType().IsClass")).Value.Replace("\"", String.Empty);

            ReplicationObject replicationObject = new ReplicationObject()
            {
                Name = expression.Name,
                Type = _debugger.GetExpression(String.Concat(variableName, ".GetType().FullName")).Value.Replace("\"", String.Empty),
                Value = expression.Value.Replace("\"", String.Empty),
                IsClass = Boolean.Parse(_debugger.GetExpression(String.Concat(variableName, ".GetType().IsClass")).Value.Replace("\"", String.Empty))
            };

            return replicationObject;
        }
    }
}
