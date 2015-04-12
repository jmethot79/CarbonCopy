using System;
using Zinc.CarbonCopy.Replication.Declaration;

namespace Zinc.CarbonCopy.Replication
{
    class Replicator
    {
        public string GenerateDeclaration(ReplicationObject replicationObject)
        {
            var declaration = DeclarationFactory.CreateDeclaration(replicationObject);

            return String.Concat("Dim ", replicationObject.Name, " As ", declaration);
        }
    }
}
