namespace Zinc.CarbonCopy
{
  internal static class ExpressionsHelper
  {
    public static Expressions LanguageSpecificExpressions;

    public static string TypeFullName(string variableName)
    {
      return ExpressionsHelper.LanguageSpecificExpressions.TypeFullName(variableName);
    }

    public static string TypeName(string variableName)
    {
      return ExpressionsHelper.LanguageSpecificExpressions.TypeName(variableName);
    }

    public static string IsClass(string variableName)
    {
      return ExpressionsHelper.LanguageSpecificExpressions.IsClass(variableName);
    }

    public static string ItemsCount(string variableName)
    {
      return ExpressionsHelper.LanguageSpecificExpressions.ItemsCount(variableName);
    }

    public static string Cast(string variableName, string type)
    {
      return ExpressionsHelper.LanguageSpecificExpressions.Cast(variableName, type);
    }

    public static string IsInitOnly(string variableName, string propertyName)
    {
      return ExpressionsHelper.LanguageSpecificExpressions.IsInitOnly(variableName, propertyName);
    }

    public static string CanWrite(string variableName, string propertyName)
    {
      return ExpressionsHelper.LanguageSpecificExpressions.CanWrite(variableName, propertyName);
    }

    public static string ListMembersType(string variableName)
    {
      return ExpressionsHelper.LanguageSpecificExpressions.ListMembersType(variableName);
    }

    public static string BaseTypeName(string variableName)
    {
      return ExpressionsHelper.LanguageSpecificExpressions.BaseTypeName(variableName);
    }

    public static string Item(string variableName, int itemIndex)
    {
      return ExpressionsHelper.LanguageSpecificExpressions.Item(variableName, itemIndex);
    }

    public static string DictionaryKeyType(string variableName)
    {
      return ExpressionsHelper.LanguageSpecificExpressions.DictionaryKeyType(variableName);
    }

    public static string DictionaryValueType(string variableName)
    {
      return ExpressionsHelper.LanguageSpecificExpressions.DictionaryValueType(variableName);
    }
  }
}