using System;
using System.Text;

namespace Zinc.CarbonCopy.LanguageSpecific.Vb
{
    class VbArrayInitialization : ObjectDeclaration
    {
        public VbArrayInitialization(string variableName) : base(variableName) { }

        protected override string GenerateInitialization()
        {
            var stringBuilder = new StringBuilder();

            var membersCount = int.Parse(DebuggerHelper.GetValue(ExpressionsHelper.ItemsCount(_variableName)));

            stringBuilder.AppendLine(String.Concat(Indentation.ToString(), "{"));

            var membersInitialization = MembersInitializationHelper.GetMembersInitialization(_variableName, membersCount);

            stringBuilder.Append(membersInitialization);
            stringBuilder.Append(String.Concat(Indentation.ToString(), "}"));

            return stringBuilder.ToString();   
        }
    }
}
