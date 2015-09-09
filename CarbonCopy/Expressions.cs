using System;

namespace Zinc.CarbonCopy
{
    abstract class Expressions
    {
        public string Type(string variableName)
        {
            return String.Concat(variableName, ".GetType().FullName");
        }

        public string ItemsCount(string variableName)
        {
            return String.Concat(variableName, ".Count()");
        }

        public string IsClass(string variableName)
        {
            return String.Concat(variableName, ".GetType().IsClass");
        }

        public abstract string Cast(string variableName, string variableType);

        public abstract string IsInitOnly(string variableName, string propertyName);

        public abstract string CanWrite(string variableName, string propertyName);
    }
}
