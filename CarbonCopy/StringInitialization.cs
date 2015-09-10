namespace Zinc.CarbonCopy
{
    class StringInitialization : ObjectDeclaration
    {
        public StringInitialization(string variableName) : base(variableName) { }

        protected override string GenerateInitialization()
        {
            return DebuggerHelper.GetValue(_variableName);
        }
    }
}
