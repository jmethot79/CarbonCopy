using EnvDTE;
using System;
using Zinc.CarbonCopy.LanguageSpecific.Csharp;
using Zinc.CarbonCopy.LanguageSpecific.Vb;

namespace Zinc.CarbonCopy.LanguageSpecific
{
    class LanguageSpecificObjectInitializationInstantiatorFactory
    {
        public static ILanguageSpecificObjectInitializationInstantiator CreateInstantiator(DTE dteInstance)
        {
            string codeModelLanguageConstant = CodeModelLanguageHelper.GetCodeModelLanguageConstant(dteInstance);

            switch (codeModelLanguageConstant)
            {
                case EnvDTE.CodeModelLanguageConstants.vsCMLanguageVB:

                    return new VbObjectInitializationInstantiator();

                case EnvDTE.CodeModelLanguageConstants.vsCMLanguageCSharp:

                    return new CsharpObjectInitializationInstantiator();

                default:
                    throw new NotImplementedException(String.Concat("Code language not implemented: ", codeModelLanguageConstant.ToString()));
            }
        }
    }
}
