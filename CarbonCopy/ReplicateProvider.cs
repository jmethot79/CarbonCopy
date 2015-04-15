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
                //System.Windows.Forms.MessageBox.Show(_debugger.GetExpression(String.Concat(variableName, ".GetType().BaseType.Name")).Value);
                Replicate replicate = null;
                if (IsClass(variableName))
                {
                    if (IsString(variableName))
                    {
                        replicate = new StringReplicate();
                    }
                    else if (IsCollection(variableName))
                    {
                        replicate = new CollectionReplicate();

                        if (IsArray(variableName))
                        {
                            replicate.Members = GetArrayMembers(variableName);
                        }                    
                        else if (IsDictionary(variableName))
                        {
                            replicate.Members = GetDictionaryMembers(variableName);
                        }
                        else
                        {
                            replicate.Members = GetCollectionMembers(variableName);
                        }
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
            
                replicate.Name = expression.Name.Substring(expression.Name.LastIndexOf(".") + 1);
                replicate.Type = _debugger.GetExpression(String.Concat(variableName, ".GetType().FullName")).Value.Replace("\"", String.Empty).Replace("+", ".").Replace("[]","()");
                replicate.Value = expression.Value.Replace("\"", String.Empty);

                return replicate;
            }

            return null;
        }

        private bool IsClass(string variableName)
        {
            return "True" == _debugger.GetExpression(String.Concat(variableName, ".GetType().IsClass")).Value;
        }
        
        private bool IsString(string variableName)
        {
            return "System.String" == _debugger.GetExpression(String.Concat(variableName, ".GetType().FullName")).Value;
        }

        private bool IsCollection(string variableName)
        {
            return true;// "System.String" == _debugger.GetExpression(String.Concat(variableName, ".GetType().FullName")).Value;
        }

        private bool IsArray(string variableName)
        {
            return "\"Array\"" == _debugger.GetExpression(String.Concat(variableName, ".GetType().BaseType.Name")).Value;
        }

        private bool IsDictionary(string variableName)
        {
            return _debugger.GetExpression(String.Concat(variableName, ".GetType().Name")).Value.Contains("Dictionary");
        }

        private List<Replicate> GetReplicateMembers(string variableName)
        {
            throw new NotImplementedException();
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

            //            If Not ObjetsDansCollection.GetEnumerator().MoveNext() Then
            //   Return String.Empty
            //End If

            // Dim typeObjetCollection As Type = ObjetsDansCollection(0).GetType()
            string expression1 = _debugger.GetExpression(String.Concat(variableName, ".First()")).Value;
            string expression2 = _debugger.GetExpression(String.Concat(variableName, ".First()")).Name;
            string expression3 = _debugger.GetExpression(String.Concat(variableName, ".First()")).Type;

            //System.IO.File.AppendAllText("c:\test.txt", expression1);
            //System.IO.File.AppendAllText("c:\test.txt", expression2);
            //System.IO.File.AppendAllText("c:\test.txt", expression3);


            EnvDTE.Expression expression = _debugger.GetExpression(variableName);

            foreach (EnvDTE.Expression dataMember in expression.DataMembers)
            {
                var value = _debugger.GetExpression(String.Concat(variableName, dataMember.Name)).Value;

                //todo: FIND Better
                if (value != "Nothing")
                {
                    var name = _debugger.GetExpression(String.Concat(variableName, dataMember.Name)).Name;
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

        private List<Replicate> GetArrayMembers(string variableName)
        {
            var members = new List<Replicate>();

            //            If Not ObjetsDansCollection.GetEnumerator().MoveNext() Then
            //   Return String.Empty
            //End If

            // Dim typeObjetCollection As Type = ObjetsDansCollection(0).GetType()
            string expression1 = _debugger.GetExpression(String.Concat(variableName, ".First()")).Value;
            string expression2 = _debugger.GetExpression(String.Concat(variableName, ".First()")).Name;
            string expression3 = _debugger.GetExpression(String.Concat(variableName, ".First()")).Type;

            //System.IO.File.AppendAllText("c:\test.txt", expression1);
            //System.IO.File.AppendAllText("c:\test.txt", expression2);
            //System.IO.File.AppendAllText("c:\test.txt", expression3);


            EnvDTE.Expression expression = _debugger.GetExpression(variableName);

            foreach (EnvDTE.Expression dataMember in expression.DataMembers)
            {
                var value = _debugger.GetExpression(String.Concat(variableName, dataMember.Name)).Value;

                //todo: FIND Better
                if (value != "Nothing")
                {
                    var name = _debugger.GetExpression(String.Concat(variableName, dataMember.Name)).Name;
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

        private List<Replicate> GetCollectionMembers(string variableName)
        {
            var members = new List<Replicate>();

      //            If Not ObjetsDansCollection.GetEnumerator().MoveNext() Then
      //   Return String.Empty
      //End If

     // Dim typeObjetCollection As Type = ObjetsDansCollection(0).GetType()
            string expression1 = _debugger.GetExpression(String.Concat(variableName,".First()")).Value;
            string expression2 = _debugger.GetExpression(String.Concat(variableName, ".First()")).Name;
            string expression3 = _debugger.GetExpression(String.Concat(variableName, ".First()")).Type;




            EnvDTE.Expression expression = _debugger.GetExpression(variableName);

            foreach (EnvDTE.Expression dataMember in expression.DataMembers)
            {
                var value = _debugger.GetExpression(String.Concat(variableName, dataMember.Name)).Value;

                //todo: FIND Better
                if (value != "Nothing")
                {
                    var name = _debugger.GetExpression(String.Concat(variableName, dataMember.Name)).Name;
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
    }
}
