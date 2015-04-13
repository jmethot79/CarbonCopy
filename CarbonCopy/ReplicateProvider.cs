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

            //TODO: gérer si propriete volontairement settée à nothing, mais constructeur initialise, il faut garder nothing.
            if (expression.Value != "Nothing")
            { 
            //var IsArray = _debugger.GetExpression(String.Concat(variableName, ".GetType().BaseType.Name")).Value.Replace("\"", String.Empty);
            //    var IsClass = Boolean.Parse(_debugger.GetExpression(String.Concat(variableName, ".GetType().IsClass")).Value.Replace("\"", String.Empty));
            //    var IsCollection = false;
            //    var IsString = _debugger.GetExpression(String.Concat(variableName, ".GetType().FullName")).Value.Replace("\"", String.Empty).Equals("System.String");
                var IsArray = _debugger.GetExpression(String.Concat(variableName, ".GetType().BaseType.Name")).Value.Replace("\"", String.Empty).Equals("Array").ToString().ToLower();
                var IsClass = _debugger.GetExpression(String.Concat(variableName, ".GetType().IsClass")).Value.Replace("\"", String.Empty);
                var IsCollection = false;
                var IsString = _debugger.GetExpression(String.Concat(variableName, ".GetType().FullName")).Value.Replace("\"", String.Empty).Equals("System.String");
 
             var properties = new ObjectProperties() 
            {
                IsArray = Boolean.Parse(_debugger.GetExpression(String.Concat(variableName, ".GetType().BaseType.Name")).Value.Replace("\"", String.Empty).Equals("Array").ToString().ToLower()),
                IsClass = Boolean.Parse(_debugger.GetExpression(String.Concat(variableName, ".GetType().IsClass")).Value.Replace("\"", String.Empty)),
                IsCollection = false,
                IsString = _debugger.GetExpression(String.Concat(variableName, ".GetType().FullName")).Value.Replace("\"", String.Empty).Equals("System.String")
            };

            Replicate replicate = ReplicateFactory.CreateReplicate(properties);
            
            replicate.Name = expression.Name.Substring(expression.Name.LastIndexOf(".") + 1);
            replicate.Type = _debugger.GetExpression(String.Concat(variableName, ".GetType().FullName")).Value.Replace("\"", String.Empty).Replace("+", ".").Replace("[]","()");
            replicate.Value = expression.Value.Replace("\"", String.Empty);
           
            if (properties.IsClass)
            {
                if (properties.IsArray) 
                {
                    replicate.Properties = GetElements(variableName);
                }
                else
                {
                    replicate.Properties = GetProperties(variableName);
                }
                
            }


            return replicate;
            }
            return null;

        }

        private List<Replicate> GetElements(string expression)
        {
            var members = new List<Replicate>();

            EnvDTE.Expression expression2 = _debugger.GetExpression(expression);

            foreach (EnvDTE.Expression dataMember in expression2.DataMembers)
            {
                var value = _debugger.GetExpression(String.Concat(expression, dataMember.Name)).Value;

                //todo: FIND Better
                if (value != "Nothing")
                {
                    var name = _debugger.GetExpression(String.Concat(expression, dataMember.Name)).Name;
                    var property = CreateReplicate(name);

                    members.Add(property);
                }
            }

            if (members.Count == 0)
            {
                members = null;
            }

            return members;
        }

        private List<Replicate> GetProperties(string expression)
        {
            var properties = new List<Replicate>();

            EnvDTE.Expression expression2 = _debugger.GetExpression(expression);

            foreach (EnvDTE.Expression dataMember in expression2.DataMembers)
            {
                var property = CreateReplicate(String.Concat(expression, ".", dataMember.Name));

                if (property != null)
                {
                    properties.Add(property);
                } 
            }

            if (properties.Count == 0)
            {
                properties = null;
            }
            
            return properties;
        }
    }
}
