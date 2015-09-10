namespace Zinc.CarbonCopy
{
    class PrimitiveInitialization : ObjectInitialization
    {
        public PrimitiveInitialization(string variableName) : base(variableName) { }

        protected override string GenerateInitialization()
        {
            return DebuggerHelper.GetValue(_variableName).Replace(",", ".");
        }
    }
}
