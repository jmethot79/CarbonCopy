using System;

namespace Zinc.CarbonCopy.Replication.Cs
{
    class CsReplicator : IReplicator
    {
        public string GenerateDeclaration(Replicate replicate)
        {
            Indentation.Level = 0;

            if (replicate.Value == "null")
            {
                return String.Concat(replicate.Type, " ", replicate.Name, " = null;");
            }
            else
            {
                return String.Concat(replicate.Type, " ", replicate.Name, " ", replicate.Declaration, ";");
            }
        }
    }
}
