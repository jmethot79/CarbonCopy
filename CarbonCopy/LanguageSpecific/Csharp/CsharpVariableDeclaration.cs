namespace Zinc.CarbonCopy.LanguageSpecific.Csharp
{
    class CsharpVariableDeclaration : IVariableDeclaration
    {
        public string GetDeclaration(string variableName)
        {
            var objectInitialization = ObjectInitializationFactory.CreateObjectInitialization(variableName);

            return string.Concat("var ", variableName, " = ", objectInitialization.Initialization, ";");
        }
    }
}
