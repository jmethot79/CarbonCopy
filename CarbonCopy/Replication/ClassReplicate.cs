using System;
using System.Text;

namespace Zinc.CarbonCopy.Replication
{
    class ClassReplicate : Replicate
    {
        public override string Declaration
        {
            get
            {
                var stringBuilder = new StringBuilder();

                stringBuilder.Append(String.Concat("New ", Type));

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
                stringBuilder.Append("Nothing");
            }

            return stringBuilder.ToString();
        }

        private string GetPropertiesDeclaration()
        {
            var stringBuilder = new StringBuilder();

            if (Properties != null)
            {
                var propertyStringBuilder = new StringBuilder();

                foreach (var property in Properties)
                {
                    if (propertyStringBuilder.Length > 0)
                    {
                        propertyStringBuilder.AppendLine(",");
                    }

                    propertyStringBuilder.Append(String.Concat(".", property.Name, " = ", property.Declaration));
                }

                stringBuilder.AppendLine("With {");
                stringBuilder.Append(propertyStringBuilder.ToString());
                stringBuilder.Append("}");
            }

            return stringBuilder.ToString();
        }
    }
}
