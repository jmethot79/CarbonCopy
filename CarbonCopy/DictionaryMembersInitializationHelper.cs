using System;
using System.Text;

namespace Zinc.CarbonCopy
{
    class DictionaryMembersInitializationHelper
    {
        public static string GetInitialization(string variableName, int membersCount)
        {
            var membersStringBuilder = new StringBuilder();

            var keyInitialization = ObjectInitializationFactory.CreateObjectInitialization(String.Concat(variableName, ".Keys.ElementAt(0)"));
            var valueInitialization = ObjectInitializationFactory.CreateObjectInitialization(String.Concat(variableName, ".Values.ElementAt(0)"));

            Indentation.Level++;

            for (int i = 0; i < membersCount; i++)
            {
                keyInitialization.VariableName = String.Concat(variableName, ".Keys.ElementAt(", i.ToString(), ")");
                valueInitialization.VariableName = String.Concat(variableName, ".Values.ElementAt(", i.ToString(), ")");

                if (membersStringBuilder.Length > 0)
                {
                    membersStringBuilder.AppendLine(",");
                }

                membersStringBuilder.Append(String.Concat(Indentation.ToString(), "{", keyInitialization.Initialization, ",", valueInitialization.Initialization, "}"));
            }

            Indentation.Level--;

            return membersStringBuilder.ToString();
        }

        public static string GetMembersType(string variableName)
        {
            var keyType = DebuggerHelper.GetValue(ExpressionsHelper.DictionaryKeyType(variableName)).Replace("\"", String.Empty).Replace("+", ".");
            var valueType = DebuggerHelper.GetValue(ExpressionsHelper.DictionaryValueType(variableName)).Replace("\"", String.Empty).Replace("+", ".");

            return String.Concat(keyType, ", ", valueType);
        }
    }
}
