using EnvDTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinc.CarbonCopy.Replication
{
    class ObjectExpressionFactory
    {
        private Debugger _debugger;

        public ObjectExpressionFactory(Debugger debugger)
        {
            _debugger = debugger;
        }

        public ReplicationObject MakeExpressionObject(string variableName)
        {
            EnvDTE.Expression expression = _debugger.GetExpression(variableName);

            return new ReplicationObject
            {
                Name = variableName,
                Type = expression.Type,
                Value = expression.Value
            };
        }
    }
}
