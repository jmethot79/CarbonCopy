using Zinc.CarbonCopy.LanguageSpecific;

namespace Zinc.CarbonCopy
{
    static class ObjectInitializationFactory
    {
        public static ILanguageSpecificObjectInitializationInstantiator Instantiator;

        public static ObjectInitialization CreateObjectInitialization(string variableName)
        {
            //TODO: evaluer toutes les expressions en 1 seul call au debugger
            if (IsClass(variableName))
            {
                if (IsString(variableName))
                {
                    return Instantiator.InstantiateStringInitialization(variableName);
                }
                else if (IsList(variableName))
                {
                    return Instantiator.InstantiateListInitialization(variableName);
                }
                else if (IsDictionary(variableName))
                {
                    return Instantiator.InstantiateDictionaryInitialization(variableName);
                }
                else if (IsArray(variableName))
                {
                    return Instantiator.InstantiateArrayInitialization(variableName);
                }
                else
                {
                    return Instantiator.InstantiateClassInitialization(variableName);
                }
            }
            else
            {
                if (IsDatetime(variableName))
                {
                    return Instantiator.InstantiateDateTimeInitialization(variableName);
                }
                else
                {
                    return Instantiator.InstantiatePrimitiveInitialization(variableName);
                }
            }
        }

        private static bool IsClass(string variableName)
        {
            return "true" == DebuggerHelper.GetValue(ExpressionsHelper.IsClass(variableName)).ToLower();
        }

        private static bool IsString(string variableName)
        {
            return "\"System.String\"" == DebuggerHelper.GetValue(ExpressionsHelper.TypeFullName(variableName));
        }

        private static bool IsList(string variableName)
        {
            return "\"List`1\"" == DebuggerHelper.GetValue(ExpressionsHelper.TypeName(variableName));
        }

        private static bool IsArray(string variableName)
        {
            return "\"Array\"" == DebuggerHelper.GetValue(ExpressionsHelper.BaseTypeName(variableName));
        }

        private static bool IsDatetime(string variableName)
        {
            //pourrait être plus précis
            return DebuggerHelper.GetValue(ExpressionsHelper.TypeFullName(variableName)).Contains("DateTime");
        }

        private static bool IsDictionary(string variableName)
        {
            return "\"Dictionary`2\"" == DebuggerHelper.GetValue(ExpressionsHelper.TypeName(variableName));
        }
    }
}
