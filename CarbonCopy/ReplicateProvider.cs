using EnvDTE;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
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
            Replicate replicate = null;
            try
            {
                EnvDTE.Expression expression = _debugger.GetExpression(variableName);

                replicate = GetReplicate(variableName);
                replicate.Name = expression.Name.Substring(expression.Name.LastIndexOf(".") + 1);
                replicate.Type = _debugger.GetExpression(String.Concat(variableName, ".GetType().FullName")).Value.Replace("\"", String.Empty).Replace("+", ".").Replace("[]", "()");
                replicate.Value = expression.Value.Replace("\"", String.Empty);

                return replicate;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Concat("In CreateReplicate, variableName: ", variableName));
                if (replicate != null)
                {
                    MessageBox.Show(String.Format("Name {0} - Type {1} - Value {2} ", replicate.Name, replicate.Type, replicate.Value));
                }
                throw ex;
            }
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
                    replicate = new ArrayReplicate();
                    replicate.Members = GetArrayMembers(variableName);
                }
                else if (IsDictionary(variableName))
                {
                    replicate = new DictionaryReplicate();
                    replicate.Members = GetDictionaryMembers(variableName);

                    StringBuilder membersType = new StringBuilder();

                    membersType.Append(_debugger.GetExpression(String.Concat(variableName, ".GetType().GenericTypeArguments(0).FullName")).Value.Replace("\"", String.Empty).Replace("+", "."));
                    membersType.Append(", ");
                    membersType.Append(_debugger.GetExpression(String.Concat(variableName, ".GetType().GenericTypeArguments(1).FullName")).Value.Replace("\"", String.Empty).Replace("+", "."));

                    replicate.MembersType = membersType.ToString();
                }
                else if (IsList(variableName))
                {
                    replicate = new ListReplicate();
                    replicate.Members = GetListMembers(variableName);
                    replicate.MembersType = _debugger.GetExpression(String.Concat(variableName, ".GetType().GenericTypeArguments.First().FullName")).Value.Replace("\"", String.Empty).Replace("+",".");
                }
                else
                {
                    replicate = new ClassReplicate();
                    replicate.Members = GetProperties(variableName);
                }
            }
            else
            {
                replicate = new SimpleReplicate();
            }
            return replicate;
        }

        private bool IsClass(string variableName)
        {
            return "True" == _debugger.GetExpression(String.Concat(variableName, ".GetType().IsClass")).Value;
        }
        
        private bool IsString(string variableName)
        {
            return "\"System.String\"" == _debugger.GetExpression(String.Concat(variableName, ".GetType().FullName")).Value;
        }

         private bool IsArray(string variableName)
        {
            return "\"Array\"" == _debugger.GetExpression(String.Concat(variableName, ".GetType().BaseType.Name")).Value;
        }

        private bool IsDictionary(string variableName)
        {
            return "\"Dictionary`2\"" == _debugger.GetExpression(String.Concat(variableName, ".GetType().Name")).Value;
        }

        private bool IsList(string variableName)
        {
            return "\"List`1\"" == _debugger.GetExpression(String.Concat(variableName, ".GetType().Name")).Value;
        }

        private List<Replicate> GetProperties(string variableName)
        {
            var properties = new List<Replicate>();

            EnvDTE.Expression expression = _debugger.GetExpression(variableName);

            foreach (EnvDTE.Expression dataMember in expression.DataMembers)
            {
                var property = CreateReplicate(String.Concat(variableName, ".", dataMember.Name));

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

        private List<Replicate> GetDictionaryMembers(string variableName)
        {
            var members = new List<Replicate>();

            var itemsCount = Int32.Parse(_debugger.GetExpression(String.Concat(variableName, ".Count")).Value);

            for (int i = 0; i < itemsCount; i++)
            {
                KeyValuePairReplicate member = new KeyValuePairReplicate();

                member.Key = CreateReplicate(String.Concat(variableName, ".Keys(", i.ToString(), ")"));
                member.Value = CreateReplicate(String.Concat(variableName, ".Values(", i.ToString(), ")"));
                members.Add(member);
            }
            return members;
        }

        private List<Replicate> GetArrayMembers(string variableName)
        {
            var members = new List<Replicate>();

            var itemsCount = Int32.Parse(_debugger.GetExpression(String.Concat(variableName, ".Count")).Value);

            for (int i = 0; i < itemsCount; i++)
            {
                members.Add(CreateReplicate(String.Concat(variableName, "(", i.ToString(), ")")));
            }

            return members;
        }

        private List<Replicate> GetListMembers(string variableName)
        {
            var members = new List<Replicate>();

            var itemsCount = Int32.Parse(_debugger.GetExpression(String.Concat(variableName, ".Count")).Value);

            for (int i=0; i < itemsCount; i++)
            {
                members.Add(CreateReplicate(String.Concat(variableName, "(", i.ToString(), ")")));
            }

            return members;
        }
    }
}
