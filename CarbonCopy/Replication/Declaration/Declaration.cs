using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinc.CarbonCopy.Replication.Declaration
{
    abstract class Declaration
    {
        private ReplicationObject _expressionObject;

        public Declaration(ReplicationObject expressionObject)
        {
            _expressionObject = expressionObject;
        }

        protected ReplicationObject ExpressionObject
        {
            get { return _expressionObject; }
        }

        public abstract override string ToString();
    }
}
