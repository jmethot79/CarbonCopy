using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinc.CarbonCopy.Replication.Declaration
{
    class StringDeclaration : Declaration
    {
        public StringDeclaration(ReplicationObject expressionObject) : base(expressionObject) { }

        public override string ToString()
        {
            return String.Concat(ReplicationObject.Type, " = ", "\"", ReplicationObject.Value, "\"");
        }
    }
}
