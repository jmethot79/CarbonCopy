using System.Text;

namespace Zinc.CarbonCopy.LanguageSpecific.Csharp
{
    class CsharpListInitialization : ObjectDeclaration
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

                Indentation.Level++;

                var membersStringBuilder = new StringBuilder();

                for (int i = 0; i < membersCount; i++)
                {
                    if (membersStringBuilder.Length > 0)
                    {
                        membersStringBuilder.AppendLine(",");
                    }
                    
                    var memberInitialization = ObjectDeclarationFactory.CreateObjectDeclaration(string.Concat(_variableName, "[", i.ToString(), "]"));

                    membersStringBuilder.Append(string.Concat(Indentation.ToString(), memberInitialization.Initialization));
                }

                Indentation.Level--;

                stringBuilder.AppendLine(membersStringBuilder.ToString());
                stringBuilder.Append(string.Concat(Indentation.ToString(), "}"));
            }

            return stringBuilder.ToString();
        }
    }
}
