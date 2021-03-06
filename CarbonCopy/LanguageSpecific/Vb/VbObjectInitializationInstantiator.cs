﻿using System;

namespace Zinc.CarbonCopy.LanguageSpecific.Vb
{
    class VbObjectInitializationInstantiator : ILanguageSpecificObjectInitializationInstantiator
    {
        public ObjectInitialization InstantiateClassInitialization(string variableName)
        {
            return new VbClassInitialization(variableName);
        }

        public ObjectInitialization InstantiatePrimitiveInitialization(string variableName)
        {
            return new PrimitiveInitialization(variableName);
        }

        public ObjectInitialization InstantiateDateTimeInitialization(string variableName)
        {
            return new PrimitiveInitialization(variableName);
        }

        public ObjectInitialization InstantiateStringInitialization(string variableName)
        {
            return new StringInitialization(variableName);
        }

        public ObjectInitialization InstantiateListInitialization(string variableName)
        {
            return new VbListInitialization(variableName);
        }

        public ObjectInitialization InstantiateArrayInitialization(string variableName)
        {
            return new VbArrayInitialization(variableName);
        }

        public ObjectInitialization InstantiateDictionaryInitialization(string variableName)
        {
            return new VbDictionaryInitialization(variableName);
        }
    }
}
