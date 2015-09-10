using System.Text;

namespace Zinc.CarbonCopy.LanguageSpecific.Vb
{
    class VbListInitialization : ObjectInitialization
    {
        public VbListInitialization(string variableName) : base(variableName) { }

        protected override string GenerateInitialization()
        {
            var stringBuilder = new StringBuilder();

            var membersType = ListInitializationHelper.GetListMembersType(_variableName);

            var membersCount = int.Parse(DebuggerHelper.GetValue(ExpressionsHelper.ItemsCount(_variableName)));

            stringBuilder.Append(string.Concat("New List(Of ", membersType, ")"));

            if (membersCount > 0)
            {
                stringBuilder.AppendLine(" From {");

                var membersInitialization = MembersInitializationHelper.GetMembersInitialization(_variableName, membersCount);

                stringBuilder.Append(membersInitialization);
                stringBuilder.Append("}");
            }

            return stringBuilder.ToString();
        }
    }
}
