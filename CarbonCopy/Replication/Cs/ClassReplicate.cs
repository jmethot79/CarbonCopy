using System;
using System.Text;

namespace Zinc.CarbonCopy.Replication.Cs
{
    class ClassReplicate : Replicate
    {
        public override string Declaration
        {
            get
            {
                var stringBuilder = new StringBuilder();

                stringBuilder.Append(String.Concat("new ", Type));

                var constructorDeclaration = GetConstructorDeclaration();
                stringBuilder.Append(String.Concat("(", constructorDeclaration, ") "));

                var propertiesDeclaration = GetPropertiesDeclaration();
                stringBuilder.Append(propertiesDeclaration);

                return stringBuilder.ToString();
            }
        }

        private string GetConstructorDeclaration()
        {
            var stringBuilder = new StringBuilder();

            for (int i = 1; i <= ConstructorParametersCount; i++)
            {
                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Append(", ");
                }
                stringBuilder.Append("null");
            }

            return stringBuilder.ToString();
        }

        private string GetPropertiesDeclaration()
        {
            var stringBuilder = new StringBuilder();

            if (Members != null)
            {
                Indentation.Level++;

                var propertyStringBuilder = new StringBuilder();

                foreach (var property in Members)
                {
                    if (propertyStringBuilder.Length > 0)
                    {
                        propertyStringBuilder.AppendLine(",");
                    }

                    propertyStringBuilder.Append(String.Concat(Indentation.ToString(), property.Name, " = ", property.Declaration));
                }

                Indentation.Level--;

                stringBuilder.AppendLine("{");
                stringBuilder.Append(propertyStringBuilder.ToString());
                stringBuilder.Append("}");
            }

            return stringBuilder.ToString();
        }
    }
}
