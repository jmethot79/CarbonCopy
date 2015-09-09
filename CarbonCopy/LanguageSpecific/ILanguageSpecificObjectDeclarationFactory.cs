namespace Zinc.CarbonCopy.LanguageSpecific
{
    interface ILanguageSpecificObjectDeclarationFactory
    {
        ObjectDeclaration CreateClassDeclaration(string variableName);
        ObjectDeclaration CreatePrimitiveDeclaration(string variableName);
        ObjectDeclaration CreateDatetimeDeclaration(string variableName);
    }
}
