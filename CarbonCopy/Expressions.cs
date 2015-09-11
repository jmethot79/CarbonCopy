using System;

namespace Zinc.CarbonCopy
{
    abstract class Expressions
    {
        public string TypeFullName(string variableName)
        {
            return String.Concat(variableName, ".GetType().FullName");
        }

        public string TypeName(string variableName)
        {
            return String.Concat(variableName, ".GetType().Name");
        }

        public string BaseTypeName(string variableName)
        {
            return String.Concat(variableName, ".GetType().BaseType.Name");
        }

        public string ItemsCount(string variableName)
        {
            return String.Concat(variableName, ".Count()");
        }

        public string IsClass(string variableName)
        {
            return String.Concat(variableName, ".GetType().IsClass");
        }

        public string ListMembersType(string variableName)
        {
            return String.Concat(variableName, ".GetType().GenericTypeArguments.First().FullName");
        }

        public abstract string Cast(string variableName, string variableType);

        public abstract string IsInitOnly(string variableName, string propertyName);

        public abstract string CanWrite(string variableName, string propertyName);

        public abstract string Item(string variableName, int itemIndex);

        public abstract string DictionaryKeyType(string variableName);

        public abstract string DictionaryValueType(string variableName);
    }
}
