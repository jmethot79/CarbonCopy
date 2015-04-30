using EnvDTE;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zinc.CarbonCopy.Replication
{
    abstract class ReplicateProvider
    {
        protected Debugger Debugger;
        private int _level;

        public ReplicateProvider(Debugger pDebugger)
        {
            Debugger = pDebugger;
            _level = 0;
        }

        public Replicate CreateReplicate(string variableName)
        {
            _level++;

            Replicate replicate = null;

            if (_level > 20) //break infinite loop
            {
                replicate = CreateNullReplicate();
            }
            else
            {
                replicate = GetReplicate(variableName);
            }

            EnvDTE.Expression expression = Debugger.GetExpression(variableName);
          
            replicate.Name = expression.Name.Substring(expression.Name.LastIndexOf(".") + 1);
            replicate.Type = Debugger.GetExpression(String.Concat(variableName, ".GetType().FullName")).Value.Replace("\"", String.Empty).Replace("+", ".").Replace("[]", "()");
            replicate.Value = expression.Value.Replace("\"", String.Empty);

            _level--;

            return replicate;
        }

        private Replicate GetReplicate(string variableName)
        {
            Replicate replicate = null;
            if (IsClass(variableName))
            {
                if (IsString(variableName))
                {
                    replicate = new StringReplicate();
                }
                else if (IsArray(variableName))
                {
                    replicate = CreateArrayReplicate();
                    replicate.Members = GetArrayMembers(variableName);
                }
                else if (IsDictionary(variableName))
                {
                    replicate = CreateDictionaryReplicate();
                    replicate.Members = GetDictionaryMembers(variableName);

                    StringBuilder membersType = new StringBuilder();

                    membersType.Append(Debugger.GetExpression(String.Concat(variableName, ".GetType().GenericTypeArguments(0).FullName")).Value.Replace("\"", String.Empty).Replace("+", "."));
                    membersType.Append(", ");
                    membersType.Append(Debugger.GetExpression(String.Concat(variableName, ".GetType().GenericTypeArguments(1).FullName")).Value.Replace("\"", String.Empty).Replace("+", "."));

                    replicate.MembersType = membersType.ToString();
                }
                else if (IsList(variableName))
                {
                    replicate = CreateListReplicate();
                    replicate.Members = GetListMembers(variableName);
                    replicate.MembersType = Debugger.GetExpression(String.Concat(variableName, ".GetType().GenericTypeArguments.First().FullName")).Value.Replace("\"", String.Empty).Replace("+", ".");
                }
                else
                {
                    replicate = CreateClassReplicate();
                    replicate.Members = GetClassProperties(variableName);
                }
            }
            else
            {
                replicate = new SimpleReplicate();
            }
            return replicate;
        }

 

        protected bool IsClass(string variableName)
        {
            return "true" == Debugger.GetExpression(String.Concat(variableName, ".GetType().IsClass")).Value.ToLower();
        }
        
        protected bool IsString(string variableName)
        {
            return "\"System.String\"" == Debugger.GetExpression(String.Concat(variableName, ".GetType().FullName")).Value;
        }

        protected bool IsArray(string variableName)
        {
            return "\"Array\"" == Debugger.GetExpression(String.Concat(variableName, ".GetType().BaseType.Name")).Value;
        }

        protected bool IsDictionary(string variableName)
        {
            return "\"Dictionary`2\"" == Debugger.GetExpression(String.Concat(variableName, ".GetType().Name")).Value;
        }

        protected bool IsList(string variableName)
        {
            return "\"List`1\"" == Debugger.GetExpression(String.Concat(variableName, ".GetType().Name")).Value;
        }

        protected abstract Replicate CreateNullReplicate();
        protected abstract Replicate CreateClassReplicate();
        protected abstract Replicate CreateListReplicate();
        protected abstract Replicate CreateArrayReplicate();
        protected abstract Replicate CreateDictionaryReplicate();
        protected abstract List<Replicate> GetClassProperties(string variableName);
        protected abstract List<Replicate> GetListMembers(string variableName);
        protected abstract List<Replicate> GetArrayMembers(string variableName);
        protected abstract List<Replicate> GetDictionaryMembers(string variableName);
    }
}
