namespace Zinc.CarbonCopy
{
    class PrimitiveDeclaration : ObjectDeclaration
    {
        public PrimitiveDeclaration(string variableName) : base(variableName) { }

        protected override string GenerateInitialization()
        {
            return DebuggerHelper.GetValue(_variableName).Replace(",", ".");
        }
    }
}
