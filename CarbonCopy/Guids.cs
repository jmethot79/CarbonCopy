// Guids.cs
// MUST match guids.h
using System;

namespace Zinc.CarbonCopy
{
    static class GuidList
    {
        public const string guidCarbonCopyPkgString = "ccfde61d-76fe-4ca0-b813-fbe6a383ebf5";
        public const string guidCarbonCopyCmdSetString = "82329504-d498-4346-a2fd-eb4726bbfa93";

        public static readonly Guid guidCarbonCopyCmdSet = new Guid(guidCarbonCopyCmdSetString);
    };
}