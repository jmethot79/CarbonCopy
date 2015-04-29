using EnvDTE;
using System;

namespace Zinc.CarbonCopy.Replication
{
    static class ReplicatorFactory
    {
        static public IReplicator CreateReplicator(DTE dteInstance)
        {
            string codeModelLanguageConstant = dteInstance.ActiveDocument.ProjectItem.FileCodeModel.Language;

            switch (codeModelLanguageConstant)
            {
                case EnvDTE.CodeModelLanguageConstants.vsCMLanguageVB:

                    return new Vb.VbReplicator();

                case EnvDTE.CodeModelLanguageConstants.vsCMLanguageCSharp:

                    return new Cs.CsReplicator();

                default:
                    throw new NotImplementedException("Replicator for code language not implemented.");
            }
        }
    }
}
