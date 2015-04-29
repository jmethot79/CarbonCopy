using System;

namespace Zinc.CarbonCopy.Replication.Vb
{
    class VbReplicator : IReplicator
    {
        public string GenerateDeclaration(Replicate replicate)
        {
            Indentation.Level = 0;

            if (replicate.Value == "Nothing")
            {
                return String.Concat("Dim ", replicate.Name, " = Nothing");
            }
            else
            {
                return String.Concat("Dim ", replicate.Name, " As ", replicate.Declaration);
            }
        }
    }
}
