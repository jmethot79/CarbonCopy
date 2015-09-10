namespace Zinc.CarbonCopy.LanguageSpecific
{
    interface ILanguageSpecificObjectDeclarationFactory
    {
        ObjectDeclaration CreateClassDeclaration(string variableName);
        ObjectDeclaration CreatePrimitiveDeclaration(string variableName);
        ObjectDeclaration CreateDatetimeDeclaration(string variableName);
        ObjectDeclaration CreateStringInitialization(string variableName);
        ObjectDeclaration CreateListInitialization(string variableName);
        ObjectDeclaration CreateArrayInitialization(string variableName);
    }
}
