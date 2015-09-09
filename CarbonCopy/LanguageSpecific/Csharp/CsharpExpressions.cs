using System;

namespace Zinc.CarbonCopy.LanguageSpecific.Csharp
{
    class CsharpExpressions : Expressions
    {
        public override string Cast(string variableName, string variableType)
        {
            return String.Concat("(", variableType, ")", variableName);
        }
    }
}
