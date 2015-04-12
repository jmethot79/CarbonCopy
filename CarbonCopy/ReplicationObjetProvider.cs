using EnvDTE;
using System;
using System.Collections.Generic;
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
            //var Name = expression.Name;
            //var Type = _debugger.GetExpression(String.Concat(variableName, ".GetType().FullName")).Value.Replace("\"", String.Empty);
            //var Value = expression.Value.Replace("\"", String.Empty);
            //var IsClass = _debugger.GetExpression(String.Concat(variableName, ".GetType().IsClass")).Value.Replace("\"", String.Empty);

            EnvDTE.Expression expression = _debugger.GetExpression(variableName);

            ReplicationObject replicationObject = new ReplicationObject()
            {
                Name = expression.Name.Substring(expression.Name.LastIndexOf(".") + 1),
                Type = _debugger.GetExpression(String.Concat(variableName, ".GetType().FullName")).Value.Replace("\"", String.Empty).Replace("+","."),
                Value = expression.Value.Replace("\"", String.Empty),
                IsClass = Boolean.Parse(_debugger.GetExpression(String.Concat(variableName, ".GetType().IsClass")).Value.Replace("\"", String.Empty))
            };

            if (replicationObject.IsClass)
            {
                replicationObject.Properties = GetProperties(variableName);
            }

            return replicationObject;
        }

        private List<ReplicationObject> GetProperties(string expression)
        {
            var properties = new List<ReplicationObject>();

            EnvDTE.Expression expression2 = _debugger.GetExpression(expression);

            foreach (EnvDTE.Expression dataMember in expression2.DataMembers)
            {
                var property = CreateReplicationObject(String.Concat(expression, ".", dataMember.Name));

                properties.Add(property);
            }

            if (properties.Count == 0)
            {
                properties = null;
            }
            
            return properties;
        }
    }
}
