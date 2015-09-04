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
                return String.Concat("var ", replicate.Name, " = null;");
            }
            else
            {
                return String.Concat("var ", replicate.Name, " = ", replicate.Declaration, ";");
            }
        }
    }
}
