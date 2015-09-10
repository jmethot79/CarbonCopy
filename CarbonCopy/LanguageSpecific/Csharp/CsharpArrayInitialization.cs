using System;
using System.Text;

namespace Zinc.CarbonCopy.LanguageSpecific.Csharp
{
    class CsharpArrayInitialization : ObjectDeclaration
    {
        public CsharpArrayInitialization(string variableName) : base(variableName) { }

        protected override string GenerateInitialization()
        {
            var stringBuilder = new StringBuilder();

            var membersCount = int.Parse(DebuggerHelper.GetValue(ExpressionsHelper.ItemsCount(_variableName)));

            var type = DebuggerHelper.GetValue(ExpressionsHelper.TypeFullName(_variableName)).Replace("\"", String.Empty).Replace("+", ".");

            stringBuilder.AppendLine(String.Concat("new ", type));
            
            stringBuilder.AppendLine(String.Concat(Indentation.ToString(), "{"));

            var membersInitialization = MembersInitializationHelper.GetMembersInitialization(_variableName, membersCount);

            stringBuilder.AppendLine(membersInitialization);
            stringBuilder.Append(String.Concat(Indentation.ToString(), "}"));
           
            return stringBuilder.ToString();            
        }
    }
}
