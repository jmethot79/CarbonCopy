using System;
using System.Collections.Generic;
using System.Text;

namespace Zinc.CarbonCopy.LanguageSpecific.Vb
{
    class VbClassDeclaration : ObjectDeclaration
    {
        public VbClassDeclaration(string variableName) : base(variableName) { }

        protected override string GenerateInitialization()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(String.Concat("New ", Type, "()"));

            var propertiesDeclaration = GetPropertiesDeclaration();
            stringBuilder.Append(propertiesDeclaration);

            return stringBuilder.ToString();
        }


        private string GetPropertiesDeclaration()
        {
            var stringBuilder = new StringBuilder();

            var classProperties = ClassDeclarationHelper.GetClassProperties(_variableName);

            if (classProperties != null)
            {
                Indentation.Level++;

                var propertyStringBuilder = new StringBuilder();

                foreach (var property in classProperties)
                {
                    if (propertyStringBuilder.Length > 0)
                    {
                        propertyStringBuilder.AppendLine(",");
                    }

                    propertyStringBuilder.Append(String.Concat(Indentation.ToString(), ".", property.Name, " = ", property.Initialization));
                }

                Indentation.Level--;

                stringBuilder.AppendLine(" With {");
                stringBuilder.Append(propertyStringBuilder.ToString());
                stringBuilder.Append("}");
            }

            return stringBuilder.ToString();
        }
    }
}