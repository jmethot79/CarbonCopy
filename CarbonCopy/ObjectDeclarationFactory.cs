﻿using Zinc.CarbonCopy.LanguageSpecific;

namespace Zinc.CarbonCopy
{
    static class ObjectDeclarationFactory
    {
        public static ILanguageSpecificObjectDeclarationFactory LanguageSpecificObjectDeclarationFactory;

        public static ObjectDeclaration CreateObjectDeclaration(string variableName)
        {
            //TODO: evaluer toutes les expressions en 1 seul call au debugger
            if (IsClass(variableName))
            {
                if (IsString(variableName))
                {
                    return LanguageSpecificObjectDeclarationFactory.CreateStringInitialization(variableName);
                }
                else if (IsList(variableName))
                {
                    return LanguageSpecificObjectDeclarationFactory.CreateListInitialization(variableName);
                }
                else if (IsArray(variableName))
                {
                    return LanguageSpecificObjectDeclarationFactory.CreateArrayInitialization(variableName);
                }
                //else if (IsDictionary(variableName))
                //{
                //    replicate = CreateDictionaryReplicate();
                //    replicate.Members = GetDictionaryMembers(variableName);
                //    replicate.MembersType = GetDictionaryMembersType(variableName);
                //}
                else
                {
                    return LanguageSpecificObjectDeclarationFactory.CreateClassDeclaration(variableName);
                }
            }
            else
            {
                if (IsDatetime(variableName))
                {
                    return LanguageSpecificObjectDeclarationFactory.CreateDatetimeDeclaration(variableName);
                }
                else
                {
                    return LanguageSpecificObjectDeclarationFactory.CreatePrimitiveDeclaration(variableName);
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
    }
}