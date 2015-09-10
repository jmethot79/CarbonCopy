namespace Zinc.CarbonCopy.LanguageSpecific.Vb
{
    class VbNullInitialization : ObjectInitialization
    {
        VbNullInitialization() : base(null) { }

        protected override string GenerateInitialization()
        {
            return "Nothing";
        }
    }
}
