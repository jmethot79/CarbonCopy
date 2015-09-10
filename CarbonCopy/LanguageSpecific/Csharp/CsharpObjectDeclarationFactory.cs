using System;

namespace Zinc.CarbonCopy.LanguageSpecific.Csharp
{
    class CsharpObjectDeclarationFactory : ILanguageSpecificObjectDeclarationFactory
    {
        public ObjectDeclaration CreateClassDeclaration(string variableName)
        {
            return new CsharpClassDeclaration(variableName);
        }

        public ObjectDeclaration CreatePrimitiveDeclaration(string variableName)
        {
            return new PrimitiveDeclaration(variableName);
        }

        public ObjectDeclaration CreateDatetimeDeclaration(string variableName)
        {
            return new DatetimeInitialization(variableName);
        }

        public ObjectDeclaration CreateStringInitialization(string variableName)
        {
            return new StringInitialization(variableName);
        }

        public ObjectDeclaration CreateListInitialization(string variableName)
        {
            return new CsharpListInitialization(variableName);
        }
    }
}
