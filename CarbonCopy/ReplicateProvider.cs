using EnvDTE;
using System;
using System.Collections.Generic;
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
 
                if (expression.Value != "Nothing")
                {
                    replicate = GetReplicate(variableName);

                    replicate.Name = expression.Name.Substring(expression.Name.LastIndexOf(".") + 1);
                    replicate.Type = _debugger.GetExpression(String.Concat(variableName, ".GetType().FullName")).Value.Replace("\"", String.Empty).Replace("+", ".").Replace("[]", "()");
                    replicate.Value = expression.Value.Replace("\"", String.Empty);

                    return replicate;
                }

                return null;
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
                }
                else if (IsList(variableName))
                {
                    replicate = new ListReplicate();
                    replicate.Members = GetListMembers(variableName);
                    replicate.MembersType = _debugger.GetExpression(String.Concat(variableName, ".GetType().GenericTypeArguments.First().FullName")).Value.Replace("\"", String.Empty);
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

        //private bool IsCollection(string variableName)
        //{
        // //            Dim typeCollection = GetType(ICollection)
        // //If (typeObjet.IsGenericType AndAlso typeCollection.IsAssignableFrom(typeObjet.GetGenericTypeDefinition())) OrElse
        // //   typeObjet.GetInterfaces().Any(Function(uneInterface) uneInterface.IsGenericType AndAlso uneInterface.GetGenericTypeDefinition() = typeCollection) Then

        //    //var expression = String.Concat("(",variableName,".GetType().IsGenericType AndAlso GetType(ICollection).IsAssignableFrom(",
        //    //    variableName,".GetType().GetGenericTypeDefinition)) OrElse ", variableName,".GetType().GetInterfaces().Any(Function(anInterface) ",
        //    //    "anInterface.IsGenericType AndAlso anInterface.GetGenericTypeDefinition() = GetType(ICollection))");
        //    var expression = String.Concat("(", variableName, ".GetType().IsGenericType AndAlso GetType(ICollection).IsAssignableFrom(",
        //        variableName, ".GetType().GetGenericTypeDefinition))");

        //    var value = _debugger.GetExpression(expression).Value;
        //    System.Windows.Forms.MessageBox.Show(expression);
        //    System.Windows.Forms.MessageBox.Show(value);
        //    return "True" == _debugger.GetExpression(String.Concat(variableName, ".GetType().FullName")).Value;
        //}

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
            throw new NotImplementedException();
        }

        private List<Replicate> GetArrayMembers(string variableName)
        {
            throw new NotImplementedException();
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
