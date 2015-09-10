using System;

namespace Zinc.CarbonCopy.LanguageSpecific.Csharp
{
    class CsharpObjectInitializationInstantiator : ILanguageSpecificObjectInitializationInstantiator
    {
        public ObjectInitialization InstantiateClassInitialization(string variableName)
        {
            return new CsharpClassInitialization(variableName);
        }

        public ObjectInitialization InstantiatePrimitiveInitialization(string variableName)
        {
            return new PrimitiveInitialization(variableName);
        }

        public ObjectInitialization InstantiateDateTimeInitialization(string variableName)
        {
            return new DatetimeInitialization(variableName);
        }

        public ObjectInitialization InstantiateStringInitialization(string variableName)
        {
            return new StringInitialization(variableName);
        }

        public ObjectInitialization InstantiateListInitialization(string variableName)
        {
            return new CsharpListInitialization(variableName);
        }

        public ObjectInitialization InstantiateArrayInitialization(string variableName)
        {
            return new CsharpArrayInitialization(variableName);
        }
    }
}
