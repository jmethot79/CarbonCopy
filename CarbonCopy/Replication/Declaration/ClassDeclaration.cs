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

            if (ReplicationObject.ConstructorParametersCount > 0)
            {
                var constructorStringBuilder = new StringBuilder();

                for (int i = 1; i <= ReplicationObject.ConstructorParametersCount; i++)
                {
                    if (constructorStringBuilder.Length > 0)
                    {
                        constructorStringBuilder.Append(", ");
                    }
                    constructorStringBuilder.Append("Nothing");
                }

                stringBuilder.Append(String.Concat(" (", constructorStringBuilder.ToString(), ")"));
            }

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
