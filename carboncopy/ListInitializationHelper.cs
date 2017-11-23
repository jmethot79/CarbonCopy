namespace Zinc.CarbonCopy
{
  internal class ListInitializationHelper
  {
    public static string GetListMembersType(string variableName)
    {
      return DebuggerHelper.GetValue(ExpressionsHelper.ListMembersType(variableName)).Replace("\"", string.Empty).Replace("+", ".");
    }
  }
}
