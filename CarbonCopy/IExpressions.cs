using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinc.CarbonCopy
{
    interface IExpressions
    {
        string IsClass(string variableName);
        string Type(string variableName);
    }
}
