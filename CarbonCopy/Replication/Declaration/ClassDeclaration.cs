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

              //If ConstructeurRequiertParametre() Then
              //   resultat.Append(ObtenirDeclarationConstructeur())
              //End If

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
