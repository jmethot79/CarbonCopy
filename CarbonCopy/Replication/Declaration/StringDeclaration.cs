using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinc.CarbonCopy.Replication.Declaration
{
    class StringDeclaration : DeclarationBase, IDeclaration
    {
        public StringDeclaration(ReplicationObject expressionObject) : base(expressionObject) { }

        public new string GetType()
        {
            return ExpressionObject.Type;
        }

        public string GetDeclaration()
        {
            return String.Concat(ExpressionObject.Type, " = ", "\"", ExpressionObject.Value, "\"");
        }
    }
}
