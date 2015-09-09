using System;

namespace Zinc.CarbonCopy
{
    static class Indentation
    {
        public static int IdeIndentSize = 4;
        public static int Level = 0;

        new public static string ToString()
        {
            return new String(' ', IdeIndentSize * Level);
        }
    }
}
