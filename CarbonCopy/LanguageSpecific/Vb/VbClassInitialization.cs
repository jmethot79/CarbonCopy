using System;
using System.Collections.Generic;
using System.Text;

namespace Zinc.CarbonCopy.LanguageSpecific.Vb
{
    class VbClassInitialization : ObjectInitialization
    {
        public VbClassInitialization(string variableName) : base(variableName) { }

        protected override string GenerateInitialization()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(String.Concat("New ", Type, "()"));

            stringBuilder.Append(GetPropertiesInitialization());

            return stringBuilder.ToString();
        }


        private string GetPropertiesInitialization()
        {
            var stringBuilder = new StringBuilder();

            var classProperties = ClassInitializationHelper.GetClassProperties(_variableName);

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