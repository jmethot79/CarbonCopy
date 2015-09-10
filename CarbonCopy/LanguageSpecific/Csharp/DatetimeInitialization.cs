using System;

namespace Zinc.CarbonCopy.LanguageSpecific.Csharp
{
    class DatetimeInitialization : ObjectInitialization
    {
        public DatetimeInitialization(string variableName) : base(variableName) { }

        protected override string GenerateInitialization()
        {
            var ticks = DebuggerHelper.GetValue(string.Concat(_variableName, ".Ticks"));

            var date = new DateTime(long.Parse(ticks));

            return string.Concat("new System.DateTime(", date.Year.ToString(), ", ", date.Month.ToString(), ", ", date.Day.ToString(), ", ", date.Hour.ToString(), ", ", date.Minute.ToString(), ", ", date.Second.ToString(), ", ", date.Millisecond.ToString(), ")");
        }
    }
}
