namespace Zinc.CarbonCopy.LanguageSpecific.Vb
{
    class VbVariableDeclaration : IVariableDeclaration
    {
        public string GetDeclaration(string variableName)
        {
            var objectInitialization = ObjectInitializationFactory.CreateObjectInitialization(variableName);

            return string.Concat("Dim ", variableName, " = ", objectInitialization.Initialization);
        }
    }
}
