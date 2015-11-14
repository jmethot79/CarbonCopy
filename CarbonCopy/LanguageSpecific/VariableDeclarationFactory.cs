using EnvDTE;
using System;

namespace Zinc.CarbonCopy.LanguageSpecific
{
    class VariableDeclarationFactory
    {
        public static IVariableDeclaration CreateVariableDeclaration(DTE dteInstance)
        {
            string codeModelLanguageConstant = CodeModelLanguageHelper.GetCodeModelLanguageConstant(dteInstance);

            switch (codeModelLanguageConstant)
            {
                case EnvDTE.CodeModelLanguageConstants.vsCMLanguageVB:

                    return new Vb.VbVariableDeclaration();

                case EnvDTE.CodeModelLanguageConstants.vsCMLanguageCSharp:

                    return new Csharp.CsharpVariableDeclaration();

                default:
                    throw new NotImplementedException(String.Concat("Code language not implemented: ", codeModelLanguageConstant.ToString()));
            }
        }
    }
}
