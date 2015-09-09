using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinc.CarbonCopy.LanguageSpecific.Vb
{
    class VbExpressions : Expressions
    {
        public override string Cast(string variableName, string type)
        {
            return String.Concat("DirectCast(", variableName, ",", type, ")");
        }
    }
}
