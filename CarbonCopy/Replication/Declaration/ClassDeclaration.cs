using System;
using System.Text;

namespace Zinc.CarbonCopy.Replication.Declaration
{
    class ClassDeclaration : Declaration
    {
        public ClassDeclaration(ReplicationObject replicationObject) : base(replicationObject) { }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(String.Concat("New ", ReplicationObject.Type));

            var constructorDeclaration = GetConstructorDeclaration();
            stringBuilder.Append(String.Concat("(", constructorDeclaration, ")"));

            var propertiesDeclaration = GetPropertiesDeclaration();
            stringBuilder.Append(propertiesDeclaration); 
      
            return stringBuilder.ToString();
        }

        private string GetConstructorDeclaration()
        {
            var stringBuilder = new StringBuilder();

            for (int i = 1; i <= ReplicationObject.ConstructorParametersCount; i++)
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

            if (ReplicationObject.Properties != null)
            {
                var propertyStringBuilder = new StringBuilder();

                foreach (var property in ReplicationObject.Properties)
                {
                    if (propertyStringBuilder.Length > 0)
                    {
                        propertyStringBuilder.AppendLine(",");
                    }

                    var propertyDeclaration = DeclarationFactory.CreateDeclaration(property);

                    propertyStringBuilder.Append(String.Concat(property.Name, " = ", propertyDeclaration));
                }

                stringBuilder.AppendLine(" {");
                stringBuilder.Append(propertyStringBuilder.ToString());
                stringBuilder.Append("}");
            }

            return stringBuilder.ToString();
        }
    }
}
