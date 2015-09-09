using System;

namespace Zinc.CarbonCopy.LanguageSpecific.Vb
{
    class VbObjectDeclarationFactory : ILanguageSpecificObjectDeclarationFactory
    {
        public ObjectDeclaration CreateClassDeclaration(string variableName)
        {
            return new VbClassDeclaration(variableName);
        }

        public ObjectDeclaration CreatePrimitiveDeclaration(string variableName)
        {
            return new PrimitiveDeclaration(variableName);
        }

        public ObjectDeclaration CreateDatetimeDeclaration(string variableName)
        {
            return new PrimitiveDeclaration(variableName);
        }

        public ObjectDeclaration CreateStringInitialization(string variableName)
        {
            return new StringInitialization(variableName);
        }
    }
}
