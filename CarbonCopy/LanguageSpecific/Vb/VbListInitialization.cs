using System.Text;

namespace Zinc.CarbonCopy.LanguageSpecific.Vb
{
    class VbListInitialization : ObjectDeclaration
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

                Indentation.Level++;

                var membersStringBuilder = new StringBuilder();

                for (int i = 0; i < membersCount; i++)
                {
                    if (membersStringBuilder.Length > 0)
                    {
                        membersStringBuilder.AppendLine(",");
                    }
                    
                    var memberInitialization = ObjectDeclarationFactory.CreateObjectDeclaration(string.Concat(_variableName, "(", i.ToString(), ")"));

                    membersStringBuilder.Append(string.Concat(Indentation.ToString(), memberInitialization.Initialization));
                }

                Indentation.Level--;

                stringBuilder.Append(membersStringBuilder.ToString());
                stringBuilder.Append("}");
            }

            return stringBuilder.ToString();
        }
    }
}
