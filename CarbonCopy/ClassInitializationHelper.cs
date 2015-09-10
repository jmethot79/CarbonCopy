using System;
using System.Collections.Generic;

namespace Zinc.CarbonCopy
{
    static class ClassInitializationHelper
    {
        public static List<ObjectInitialization> GetClassProperties(string variableName)
        {
            var classProperties = new List<ObjectInitialization>();

            var type = DebuggerHelper.GetValue(ExpressionsHelper.TypeFullName(variableName)).Replace("\"", String.Empty).Replace("+", ".");

            ////Need to cast it to specific type when enumeration contains abstract types
            foreach (string propertyName in DebuggerHelper.GetMembersName(ExpressionsHelper.Cast(variableName, type)))
            {
                if (IsPropertyInitializable(variableName, propertyName))
                {
                    var propertyInitialization = ObjectInitializationFactory.CreateObjectInitialization(String.Concat(variableName, ".", propertyName));

                    if (propertyInitialization != null)
                    {
                        classProperties.Add(propertyInitialization);
                    }
                }
            }

            return classProperties;
        }

        public static bool IsPropertyInitializable(string variableName, string propertyName)
        {
            //TODO: faire interpreter les 2 en 1 seul call au debugger
            return IsPropertyWritable(variableName, propertyName) ||
                IsFieldPublic(variableName, propertyName);
        }

        private static bool IsFieldPublic(string variableName, string propertyName)
        {
            return "false" == DebuggerHelper.GetValue(ExpressionsHelper.IsInitOnly(variableName, propertyName)).ToLower();
        }

        private static bool IsPropertyWritable(string variableName, string propertyName)
        {
            return "true" == DebuggerHelper.GetValue(ExpressionsHelper.CanWrite(variableName, propertyName)).ToLower();
        }
    }
}
