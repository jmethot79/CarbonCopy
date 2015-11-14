using EnvDTE;
using System;

namespace Zinc.CarbonCopy.LanguageSpecific
{
    class CodeModelLanguageHelper
    {
        public static string GetCodeModelLanguageConstant(DTE dteInstance)
        {
            if (String.Equals("Basic", dteInstance.Debugger.CurrentStackFrame.Language, StringComparison.InvariantCultureIgnoreCase))
            {
                return EnvDTE.CodeModelLanguageConstants.vsCMLanguageVB;
            }
            else
            {
                return EnvDTE.CodeModelLanguageConstants.vsCMLanguageCSharp;
            }
        }
    }
}
