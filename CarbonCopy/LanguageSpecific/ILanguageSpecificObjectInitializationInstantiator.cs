namespace Zinc.CarbonCopy.LanguageSpecific
{
    interface ILanguageSpecificObjectInitializationInstantiator
    {
        ObjectDeclaration InstantiateClassInitialization(string variableName);
        ObjectDeclaration InstantiatePrimitiveInitialization(string variableName);
        ObjectDeclaration InstantiateDateTimeInitialization(string variableName);
        ObjectDeclaration InstantiateStringInitialization(string variableName);
        ObjectDeclaration InstantiateListInitialization(string variableName);
        ObjectDeclaration InstantiateArrayInitialization(string variableName);
    }
}
