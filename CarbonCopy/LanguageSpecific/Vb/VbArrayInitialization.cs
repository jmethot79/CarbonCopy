using System;
using System.Text;

namespace Zinc.CarbonCopy.LanguageSpecific.Vb
{
    class VbArrayInitialization : ObjectInitialization
    {
        public VbArrayInitialization(string variableName) : base(variableName) { }

        protected override string GenerateInitialization()
        {
            var stringBuilder = new StringBuilder();

            var membersCount = int.Parse(DebuggerHelper.GetValue(ExpressionsHelper.ItemsCount(_variableName)));

            var type = DebuggerHelper.GetValue(ExpressionsHelper.TypeFullName(_variableName)).Replace("\"", String.Empty).Replace("+", ".").Replace("[]","()");

            stringBuilder.AppendLine(String.Concat(Indentation.ToString(), "New ", type, " {"));

            var membersInitialization = MembersInitializationHelper.GetMembersInitialization(_variableName, membersCount);

            stringBuilder.Append(membersInitialization);
            stringBuilder.Append(String.Concat(Indentation.ToString(), "}"));

            return stringBuilder.ToString();   
        }
    }
}
