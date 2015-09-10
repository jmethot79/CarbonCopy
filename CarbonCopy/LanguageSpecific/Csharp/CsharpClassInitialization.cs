using System;
using System.Collections.Generic;
using System.Text;

namespace Zinc.CarbonCopy.LanguageSpecific.Csharp
{
    class CsharpClassInitialization : ObjectInitialization 
    {
        public CsharpClassInitialization(string variableName) : base(variableName) { }

        protected override string GenerateInitialization()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(String.Concat("new ", Type, "()"));

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

                    propertyStringBuilder.Append(String.Concat(Indentation.ToString(), property.Name, " = ", property.Initialization));
                }

                Indentation.Level--;

                stringBuilder.AppendLine(String.Concat(Indentation.ToString(), "{"));
                stringBuilder.AppendLine(propertyStringBuilder.ToString());
                stringBuilder.Append(String.Concat(Indentation.ToString(), "}"));
            }

            return stringBuilder.ToString();
        }
    }
}
