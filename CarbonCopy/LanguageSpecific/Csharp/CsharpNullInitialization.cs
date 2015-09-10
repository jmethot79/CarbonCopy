namespace Zinc.CarbonCopy.LanguageSpecific.Csharp
{
    class CsharpNullInitialization : ObjectInitialization
    {
        CsharpNullInitialization() : base(null) { }

        protected override string GenerateInitialization()
        {
            return "null";
        }
    }
}
