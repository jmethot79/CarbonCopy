namespace Zinc.CarbonCopy.LanguageSpecific.Vb
{
    class VbVariableDeclaration : IVariableDeclaration
    {
        public string GetDeclaration(string variableName)
        {
            var objectInitialization = ObjectDeclarationFactory.CreateObjectDeclaration(variableName);

            return string.Concat("Dim ", variableName, " = ", objectInitialization.Initialization);
        }
    }
}
