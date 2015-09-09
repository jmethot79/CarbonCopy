using EnvDTE;
using System;
using Zinc.CarbonCopy.LanguageSpecific.Csharp;
using Zinc.CarbonCopy.LanguageSpecific.Vb;

namespace Zinc.CarbonCopy.LanguageSpecific
{
    class LanguageSpecificObjectDeclarationFactoryFactory
    {
        public static ILanguageSpecificObjectDeclarationFactory CreateFactory(DTE dteInstance)
        {
            string codeModelLanguageConstant = dteInstance.ActiveDocument.ProjectItem.FileCodeModel.Language;

            switch (codeModelLanguageConstant)
            {
                case EnvDTE.CodeModelLanguageConstants.vsCMLanguageVB:

                    return new VbObjectDeclarationFactory();

                case EnvDTE.CodeModelLanguageConstants.vsCMLanguageCSharp:

                    return new CsharpObjectDeclarationFactory();

                default:
                    throw new NotImplementedException(String.Concat("Code language not implemented: ", codeModelLanguageConstant.ToString()));
            }
        }
    }
}
