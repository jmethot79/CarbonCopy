using System;

namespace Zinc.CarbonCopy.Replication.Declaration
{
    class SimpleDeclaration : Declaration
    {
        public SimpleDeclaration(ReplicationObject expressionObject) : base(expressionObject) { }

        public override string ToString()
        {
            return String.Concat(ExpressionObject.Type, " = ", ExpressionObject.Value).Replace(",", ".");
        }
    }
}
