using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zinc.CarbonCopy.Replication.Declaration;

namespace Zinc.CarbonCopy.Replication
{
    class Replicator
    {
        //private DTE _dteInstance;

        //public Replicator(DTE dteInstance)
        //{
        //    _dteInstance = dteInstance;
        //}
        //public Replicator()
        //{

        //}

        //private Debugger Debugger
        //{
        //    get { return _dteInstance.Debugger; }
        //}

        public string GenerateDeclaration(ReplicationObject replicationObject)
        {
            IDeclaration declaration = DeclarationFactory.MakeDeclaration(replicationObject);

            return String.Concat("Dim ", replicationObject.Name, " As ", declaration.GetDeclaration());
        }

        //private String GetDeclaration()
        //{
        //    string expressionToCopy = GetExpressionToCopy();

        //    if (string.IsNullOrEmpty(expressionToCopy))
        //    {
        //        MessageBox.Show("Make sure you select the variable to declare.", "No variable selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return string.Empty;
        //    }



        //    ObjectExpressionFactory oeFactory = new ObjectExpressionFactory(Debugger);
        //    //Objecte o = oeFactory.MakeExpressionObject(expressionToCopy);


        //   //ExpressionObject expressionObject = factory.MakeObjectDeclaration()
        //    //IDeclaration declarationObjet = factory.MakeObjectDeclaration(expressionToCopy);

        //    //string declaration = string.Concat("Dim objet As ", declarationObjet.GetDeclaration());

        //    return expressionToCopy;
        //}

        //private string GetExpressionToCopy()
        //{
        //    EnvDTE.TextDocument td = (EnvDTE.TextDocument)_dteInstance.ActiveDocument.Object("");

        //    return td.Selection.Text;
        //}
    }
}
