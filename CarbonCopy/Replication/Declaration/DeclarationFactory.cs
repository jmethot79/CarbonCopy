using EnvDTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinc.CarbonCopy.Replication.Declaration
{
    class DeclarationFactory
    {
        //private Debugger _debugger;

        //public DeclarationFactory(Debugger Debugger)
        //{
        //    _debugger = Debugger;
        //}

        static public IDeclaration MakeDeclaration(ReplicationObject replicationObject)
        {
            if (replicationObject.Type.Equals("System.String"))
            {
                return new StringDeclaration(replicationObject);
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
