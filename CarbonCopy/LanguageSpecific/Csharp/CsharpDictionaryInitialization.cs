using System;
using System.Text;

namespace Zinc.CarbonCopy.LanguageSpecific.Csharp
{
    class CsharpDictionaryInitialization : ObjectInitialization
    {
        public CsharpDictionaryInitialization(string variableName) : base(variableName) { }

        protected override string GenerateInitialization()
        {
            var stringBuilder = new StringBuilder();

            var membersType = DictionaryMembersInitializationHelper.GetMembersType(_variableName);

            stringBuilder.Append(String.Concat("new System.Collections.Generic.Dictionary<", membersType, ">()"));

            var membersCount = int.Parse(DebuggerHelper.GetValue(ExpressionsHelper.ItemsCount(_variableName)));

            if (membersCount > 0)
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendLine(String.Concat(Indentation.ToString(), "{"));

                var membersInitialization = DictionaryMembersInitializationHelper.GetInitialization(_variableName, membersCount);

                stringBuilder.AppendLine(membersInitialization);
                stringBuilder.Append(String.Concat(Indentation.ToString(), "}"));
            }

            return stringBuilder.ToString();
        }
    }
}
