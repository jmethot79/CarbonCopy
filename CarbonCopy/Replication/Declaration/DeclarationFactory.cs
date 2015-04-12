using System;

namespace Zinc.CarbonCopy.Replication.Declaration
{
    class DeclarationFactory
    {
        static public Declaration CreateDeclaration(ReplicationObject replicationObject)
        {
            if (replicationObject.IsClass)
            {
                if (replicationObject.Type.Equals("System.String"))
                {
                    return new StringDeclaration(replicationObject);
                }

                return new ClassDeclaration(replicationObject);

                throw new NotImplementedException();
            }

            return new SimpleDeclaration(replicationObject);
            

            //if (_debugger.GetExpression())
      //         Dim typeObjet As Type = objet.GetType()

      //If typeObjet.IsClass Then

      //   If typeObjet.Name = "String" Then
      //      Return New SimpleDeclarationObjet(objet)
      //   End If

      //   If typeObjet.BaseType.Name = "Array" Then
      //      Return New ArrayDeclarationObjet(objet)
      //   End If

      //   Dim typeCollection = GetType(ICollection)
      //   If (typeObjet.IsGenericType AndAlso typeCollection.IsAssignableFrom(typeObjet.GetGenericTypeDefinition())) OrElse
      //      typeObjet.GetInterfaces().Any(Function(uneInterface) uneInterface.IsGenericType AndAlso uneInterface.GetGenericTypeDefinition() = typeCollection) Then

      //      If typeObjet.Name.Contains("Dictionary") Then
      //         Return New DictionnaireDeclaractionObjet(objet)
      //      Else
      //         Return New CollectionDeclarationObjet(objet)
      //      End If

      //   End If

      //   Return New ClasseDeclarationObjet(objet)

      //Else

      //   Return New SimpleDeclarationObjet(objet)

      //End If
           // return null;
        }
    }
}
