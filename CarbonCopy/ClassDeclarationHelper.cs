using System;
using System.Collections.Generic;

namespace Zinc.CarbonCopy
{
    public static class ClassDeclarationHelper
    {
        public static List<ObjectDeclaration> GetClassProperties(string _variableName)
        {
            var classProperties = new List<ObjectDeclaration>();

            var type = DebuggerHelper.GetValue(ExpressionsHelper.Type(_variableName)).Replace("\"", String.Empty).Replace("+", ".");

            ////Need to cast it to specific type when list contains abstract types
            foreach (EnvDTE.Expression property in DebuggerHelper.GetMembers(ExpressionsHelper.Cast(_variableName, type)))
            {
                //    if (IsPropertyInitializable(variableName, dataMember.Name))
                //    {
                var propertyDeclaration = ObjectDeclarationFactory.CreateObjectDeclaration(String.Concat(_variableName, ".", property.Name));

                if (propertyDeclaration != null)
                {
                    classProperties.Add(propertyDeclaration);
                }
                //    }
            }

            return classProperties;
        }
    }
}
