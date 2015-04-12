using EnvDTE;
using System;
using System.Collections.Generic;
using Zinc.CarbonCopy.Replication;

namespace Zinc.CarbonCopy
{
    class ReplicateProvider
    {
        private Debugger _debugger;

        public ReplicateProvider(Debugger Debugger)
        {
            _debugger = Debugger;
        }

        public Replicate CreateReplicate(string variableName)
        {
            EnvDTE.Expression expression = _debugger.GetExpression(variableName);

            var properties = new ObjectProperties() 
            {
                IsArray = false,
                IsClass = Boolean.Parse(_debugger.GetExpression(String.Concat(variableName, ".GetType().IsClass")).Value.Replace("\"", String.Empty)),
                IsCollection = false,
                IsString = _debugger.GetExpression(String.Concat(variableName, ".GetType().FullName")).Value.Replace("\"", String.Empty).Equals("System.String")
            };

            Replicate replicate = ReplicateFactory.CreateReplicate(properties);
            
            replicate.Name = expression.Name.Substring(expression.Name.LastIndexOf(".") + 1);
            replicate.Type = _debugger.GetExpression(String.Concat(variableName, ".GetType().FullName")).Value.Replace("\"", String.Empty).Replace("+",".");
            replicate.Value = expression.Value.Replace("\"", String.Empty);
            replicate.IsClass = Boolean.Parse(_debugger.GetExpression(String.Concat(variableName, ".GetType().IsClass")).Value.Replace("\"", String.Empty));
            
            if (replicate.IsClass)
            {
                replicate.Properties = GetProperties(variableName);
            }

            return replicate;
        }

        private List<Replicate> GetProperties(string expression)
        {
            var properties = new List<Replicate>();

            EnvDTE.Expression expression2 = _debugger.GetExpression(expression);

            foreach (EnvDTE.Expression dataMember in expression2.DataMembers)
            {
                var property = CreateReplicate(String.Concat(expression, ".", dataMember.Name));

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
