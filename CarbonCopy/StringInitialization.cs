namespace Zinc.CarbonCopy
{
    class StringInitialization : ObjectInitialization
    {
        public StringInitialization(string variableName) : base(variableName) { }

        protected override string GenerateInitialization()
        {
            return DebuggerHelper.GetValue(_variableName);
        }
    }
}
