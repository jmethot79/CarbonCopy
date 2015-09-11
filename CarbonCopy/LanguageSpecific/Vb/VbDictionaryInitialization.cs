using System;
using System.Text;

namespace Zinc.CarbonCopy.LanguageSpecific.Vb
{
    class VbDictionaryInitialization : ObjectInitialization
    {
        public VbDictionaryInitialization(string variableName) : base(variableName) { }

        protected override string GenerateInitialization()
        {
            var stringBuilder = new StringBuilder();

            var membersType = DictionaryMembersInitializationHelper.GetMembersType(_variableName);

            stringBuilder.Append(String.Concat("New System.Collections.Generic.Dictionary(Of ", membersType, ")"));

            var membersCount = int.Parse(DebuggerHelper.GetValue(ExpressionsHelper.ItemsCount(_variableName)));

            if (membersCount > 0)
            {
                stringBuilder.AppendLine(" From {");

                var membersInitialization = DictionaryMembersInitializationHelper.GetInitialization(_variableName, membersCount);

                stringBuilder.Append(membersInitialization);
                stringBuilder.Append(String.Concat(Indentation.ToString(), "}"));
            }

            return stringBuilder.ToString();
        }
    }
}
