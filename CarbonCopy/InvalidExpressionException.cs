using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinc.CarbonCopy
{
    [Serializable]
    class InvalidExpressionException : Exception
    {
        public InvalidExpressionException(string message) : base(message) { }
    }
}
