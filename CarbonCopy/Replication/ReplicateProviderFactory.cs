using EnvDTE;
using System;
using Zinc.CarbonCopy.Replication.Cs;
using Zinc.CarbonCopy.Replication.Vb;

namespace Zinc.CarbonCopy.Replication
{
    class ReplicateProviderFactory
    {
        public static IReplicateProvider CreateReplicateProvider(DTE dteInstance)
        {
            string codeModelLanguageConstant = dteInstance.ActiveDocument.ProjectItem.FileCodeModel.Language;

            switch (codeModelLanguageConstant)
            {
                case EnvDTE.CodeModelLanguageConstants.vsCMLanguageVB:

                    return new VbReplicateProvider(dteInstance.Debugger);

                case EnvDTE.CodeModelLanguageConstants.vsCMLanguageCSharp:

                    return new CsReplicateProvider(dteInstance.Debugger);

                default:
                    throw new NotImplementedException("Replication for code language not implemented.");
            }
        }
    }
}
