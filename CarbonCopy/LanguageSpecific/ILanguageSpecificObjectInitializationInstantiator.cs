namespace Zinc.CarbonCopy.LanguageSpecific
{
    interface ILanguageSpecificObjectInitializationInstantiator
    {
        ObjectInitialization InstantiateClassInitialization(string variableName);
        ObjectInitialization InstantiatePrimitiveInitialization(string variableName);
        ObjectInitialization InstantiateDateTimeInitialization(string variableName);
        ObjectInitialization InstantiateStringInitialization(string variableName);
        ObjectInitialization InstantiateListInitialization(string variableName);
        ObjectInitialization InstantiateArrayInitialization(string variableName);
        ObjectInitialization InstantiateDictionaryInitialization(string variableName);
    }
}
