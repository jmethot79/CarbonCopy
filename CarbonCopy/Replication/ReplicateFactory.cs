using System;

namespace Zinc.CarbonCopy.Replication
{
    class ReplicateFactory
    {
        static public Replicate CreateReplicate(ObjectProperties properties)
        {
            if (properties.IsClass)
            {
                if (properties.IsString) { return new StringReplicate(); };

                if (properties.IsCollection) { return new CollectionReplicate(); }

                return new ClassReplicate();
            }

            return new SimpleReplicate();

            //throw new NotImplementedException();
            //if (Replicate.IsClass)
            //{
            //    if (Replicate.Type.Equals("System.String"))
            //    {
            //        return new StringDeclaration();
            //    }

            //    //   If typeObjet.BaseType.Name = "Array" Then
            //    //      Return New ArrayDeclarationObjet(objet)
            //    //   End If
            //    if (Replicate.IsArray)
            //    {
            //        return new ArrayDeclaration(Replicate);
            //    }

            //    return new ClassDeclaration(Replicate);

            //    throw new NotImplementedException();
            //}

            //return new SimpleDeclaration(Replicate);
            

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
