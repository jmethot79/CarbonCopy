using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinc.CarbonCopy.Replication
{
    static class Indentation
    {
        public static int IdeIndentSize = 4;
        public static int Level;

        new public static string ToString()
        {
            return new String(' ', IdeIndentSize * Level);
        }
    }
}
