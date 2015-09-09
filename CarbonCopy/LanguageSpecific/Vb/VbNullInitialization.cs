namespace Zinc.CarbonCopy.LanguageSpecific.Vb
{
    class VbNullInitialization : ObjectDeclaration
    {
        VbNullInitialization() : base(null) { }

        protected override string GenerateInitialization()
        {
            return "Nothing";
        }
    }
}
