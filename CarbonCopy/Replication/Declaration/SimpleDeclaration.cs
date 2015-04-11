using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinc.CarbonCopy.Replication.Declaration
{
    class SimpleDeclaration : Declaration
    {
        public SimpleDeclaration(ReplicationObject expressionObject) : base(expressionObject) { }

        //public string GetDeclaration()
        //{
        //    return String.Concat(ExpressionObject.Type, " = ", ExpressionObject.Value).Replace(",", ".");
        //}
        public override string ToString()
        {
            return String.Concat(ExpressionObject.Type, " = ", ExpressionObject.Value).Replace(",", ".");
        }
    }
}
