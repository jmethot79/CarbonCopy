using System.Text;

namespace Zinc.CarbonCopy
{
    class MembersInitializationHelper
    {
        public static string GetMembersInitialization(string variableName, int membersCount)
        {
            var membersStringBuilder = new StringBuilder();

            Indentation.Level++;

            for (int i = 0; i < membersCount; i++)
            {
                if (membersStringBuilder.Length > 0)
                {
                    membersStringBuilder.AppendLine(",");
                }

                var memberInitialization = ObjectInitializationFactory.CreateObjectInitialization(ExpressionsHelper.Item(variableName, i));

                membersStringBuilder.Append(string.Concat(Indentation.ToString(), memberInitialization.Initialization));
            }

            Indentation.Level--;

            return membersStringBuilder.ToString();
        }
    }
}
