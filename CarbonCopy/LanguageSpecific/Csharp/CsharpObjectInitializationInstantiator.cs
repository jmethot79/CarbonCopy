using System;

namespace Zinc.CarbonCopy.LanguageSpecific.Csharp
{
    class CsharpObjectInitializationInstantiator : ILanguageSpecificObjectInitializationInstantiator
    {
        public ObjectDeclaration InstantiateClassInitialization(string variableName)
        {
            return new CsharpClassDeclaration(variableName);
        }

        public ObjectDeclaration InstantiatePrimitiveInitialization(string variableName)
        {
            return new PrimitiveDeclaration(variableName);
        }

        public ObjectDeclaration InstantiateDateTimeInitialization(string variableName)
        {
            return new DatetimeInitialization(variableName);
        }

        public ObjectDeclaration InstantiateStringInitialization(string variableName)
        {
            return new StringInitialization(variableName);
        }

        public ObjectDeclaration InstantiateListInitialization(string variableName)
        {
            return new CsharpListInitialization(variableName);
        }

        public ObjectDeclaration InstantiateArrayInitialization(string variableName)
        {
            return new CsharpArrayInitialization(variableName);
        }
    }
}
