using Zinc.CarbonCopy.LanguageSpecific;

namespace Zinc.CarbonCopy
{
    static class ObjectDeclarationFactory
    {
        public static ILanguageSpecificObjectDeclarationFactory LanguageSpecificObjectDeclarationFactory;

        public static ObjectDeclaration CreateObjectDeclaration(string variableName)
        {
            if (IsClass(variableName))
            {
                //if (IsString(variableName))
                //{
                //    replicate = new StringReplicate();
                //}
                //else if (IsArray(variableName))
                //{
                //    replicate = CreateArrayReplicate();
                    
                //}
                //else if (IsDictionary(variableName))
                //{
                //    replicate = CreateDictionaryReplicate();
                //    replicate.Members = GetDictionaryMembers(variableName);
                //    replicate.MembersType = GetDictionaryMembersType(variableName);
                //}
                //else if (IsList(variableName))
                //{
                //    replicate = CreateListReplicate();
                //    replicate.Members = GetListMembers(variableName);
                //    replicate.MembersType = Debugger.GetExpression(String.Concat(variableName, ".GetType().GenericTypeArguments.First().FullName")).Value.Replace("\"", String.Empty).Replace("+", ".");
                //}
                //else
                //{
                    return LanguageSpecificObjectDeclarationFactory.CreateClassDeclaration(variableName);
                //}
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

        private static bool IsDatetime(string variableName)
        {
            return DebuggerHelper.GetValue(ExpressionsHelper.Type(variableName)).Contains("DateTime");
        }
    }
}
