using System;

namespace Zinc.CarbonCopy.Replication
{
    class Replicator
    {
        public string GenerateDeclaration(Replicate replicate)
        {
            return String.Concat("Dim ", replicate.Name, " As ", replicate.Declaration);
        }
    }
}
