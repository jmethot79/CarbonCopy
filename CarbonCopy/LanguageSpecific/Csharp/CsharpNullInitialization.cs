namespace Zinc.CarbonCopy.LanguageSpecific.Csharp
{
    class CsharpNullInitialization : ObjectDeclaration
    {
        CsharpNullInitialization() : base(null) { }

        protected override string GenerateInitialization()
        {
            return "null";
        }
    }
}
