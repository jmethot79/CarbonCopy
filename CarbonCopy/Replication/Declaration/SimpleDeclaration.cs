using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinc.CarbonCopy.Replication.Declaration
{
    class SimpleDeclaration : DeclarationBase, IDeclaration
    {
        public SimpleDeclaration(ReplicationObject expressionObject) : base(expressionObject) { }

        public new string GetType()
        {
            return ExpressionObject.Type;
        }

        public string GetDeclaration()
        {
            return String.Concat(ExpressionObject.Type, " = ", ExpressionObject.Value).Replace(",", ".");
        }
    }
}
