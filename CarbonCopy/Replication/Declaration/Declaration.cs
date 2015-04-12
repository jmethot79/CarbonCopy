using System;

namespace Zinc.CarbonCopy.Replication.Declaration
{
    abstract class Declaration
    {
        private ReplicationObject _replicationObject;

        public Declaration(ReplicationObject replicationObject)
        {
            _replicationObject = replicationObject;
        }

        protected ReplicationObject ReplicationObject
        {
            get { return _replicationObject; }
        }

        public abstract override string ToString();
    }
}
