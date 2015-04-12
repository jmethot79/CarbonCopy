using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinc.CarbonCopy.Replication.Declaration
{
    class ArrayDeclaration : Declaration
    {
        public ArrayDeclaration(ReplicationObject replicationObject) : base(replicationObject) { }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(String.Concat("New ", ReplicationObject.Type));

            return stringBuilder.ToString();
        }
    }
}
