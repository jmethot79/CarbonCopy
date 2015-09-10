using System.Text;

namespace Zinc.CarbonCopy.LanguageSpecific.Csharp
{
    class CsharpListInitialization : ObjectInitialization
    {
        public CsharpListInitialization(string variableName) : base(variableName) {}

        protected override string GenerateInitialization()
        {
            var stringBuilder = new StringBuilder();

            var membersType = ListInitializationHelper.GetListMembersType(_variableName);

            var membersCount = int.Parse(DebuggerHelper.GetValue(ExpressionsHelper.ItemsCount(_variableName)));

            stringBuilder.AppendLine(string.Concat("new List<", membersType, ">()"));

            if (membersCount > 0)
            {
                stringBuilder.AppendLine(string.Concat(Indentation.ToString(), "{"));

                var membersInitialization = MembersInitializationHelper.GetMembersInitialization(_variableName, membersCount);

                stringBuilder.AppendLine(membersInitialization);
                stringBuilder.Append(string.Concat(Indentation.ToString(), "}"));
            }

            return stringBuilder.ToString();
        }
    }
}
