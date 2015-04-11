using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
