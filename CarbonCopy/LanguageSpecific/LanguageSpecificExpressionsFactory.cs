using EnvDTE;
using System;

namespace Zinc.CarbonCopy.LanguageSpecific
{
    class LanguageSpecificExpressionsFactory
    {
        public static Expressions CreateExpressions(DTE dteInstance)
        {
            string codeModelLanguageConstant = dteInstance.ActiveDocument.ProjectItem.FileCodeModel.Language;

            switch (codeModelLanguageConstant)
            {
                case EnvDTE.CodeModelLanguageConstants.vsCMLanguageVB:

                    return new Zinc.CarbonCopy.LanguageSpecific.Vb.VbExpressions();

                case EnvDTE.CodeModelLanguageConstants.vsCMLanguageCSharp:

                    return new Zinc.CarbonCopy.LanguageSpecific.Csharp.CsharpExpressions();

                default:
                    throw new NotImplementedException(String.Concat("Code language not implemented: ", codeModelLanguageConstant.ToString()));
            }
        }
    }
}
