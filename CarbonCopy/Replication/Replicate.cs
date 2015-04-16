using System.Collections.Generic;

namespace Zinc.CarbonCopy.Replication
{
    abstract class Replicate
    {
        public string Name;
        public string Type;
        public string Value;
        public bool IsClass;
        public bool IsArray;
        public int ConstructorParametersCount;
        public List<Replicate> Members;
        public string MembersType;

        public abstract string Declaration { get; }
    }
}
