using System;

namespace Zinc.CarbonCopy.LanguageSpecific.Csharp
{
    class CsharpExpressions : Expressions
    {
        public override string Cast(string variableName, string variableType)
        {
            return String.Concat("(", variableType, ")", variableName);
        }

        public override string IsInitOnly(string variableName, string propertyName)
        {
            return String.Concat(variableName, ".GetType().GetField(\"", propertyName, "\", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).IsInitOnly");
        }

        public override string CanWrite(string variableName, string propertyName)
        {
            return String.Concat(variableName, ".GetType().GetProperty(\"", propertyName, "\", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).CanWrite");
        }
    }
}
