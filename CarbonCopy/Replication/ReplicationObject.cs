using System.Collections.Generic;

namespace Zinc.CarbonCopy.Replication
{
    class ReplicationObject
    {
        public string Name;
        public string Type;
        public string Value;
        public bool IsClass;
        public int ConstructorParametersCount;
        public List<ReplicationObject> Properties;
    }
}
