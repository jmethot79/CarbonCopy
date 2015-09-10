using System;

namespace Zinc.CarbonCopy.LanguageSpecific.Vb
{
    class VbObjectInitializationInstantiator : ILanguageSpecificObjectInitializationInstantiator
    {
        public ObjectDeclaration InstantiateClassInitialization(string variableName)
        {
            return new VbClassDeclaration(variableName);
        }

        public ObjectDeclaration InstantiatePrimitiveInitialization(string variableName)
        {
            return new PrimitiveDeclaration(variableName);
        }

        public ObjectDeclaration InstantiateDateTimeInitialization(string variableName)
        {
            return new PrimitiveDeclaration(variableName);
        }

        public ObjectDeclaration InstantiateStringInitialization(string variableName)
        {
            return new StringInitialization(variableName);
        }

        public ObjectDeclaration InstantiateListInitialization(string variableName)
        {
            return new VbListInitialization(variableName);
        }

        public ObjectDeclaration InstantiateArrayInitialization(string variableName)
        {
            return new VbArrayInitialization(variableName);
        }
    }
}
