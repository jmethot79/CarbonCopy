using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinc.CarbonCopy.Replication.Declaration
{
    abstract class DeclarationBase
    {
        private ReplicationObject _expressionObject;

        public DeclarationBase(ReplicationObject expressionObject)
        {
            _expressionObject = expressionObject;
        }
        protected ReplicationObject ExpressionObject
        {
            get { return _expressionObject; }
        }
    }
}
