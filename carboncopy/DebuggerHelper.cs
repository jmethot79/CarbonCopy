using EnvDTE;
using System.Collections.Generic;

namespace Zinc.CarbonCopy
{
  internal class DebuggerHelper
  {
    public static Dictionary<string, object> KnownValues;
    public static Debugger Debugger;

    public static string GetValue(string expression)
    {
      string key = nameof (GetValue) + expression;
      if (DebuggerHelper.KnownValues.ContainsKey(key))
        return DebuggerHelper.KnownValues[key].ToString();
      DebuggerHelper.KnownValues.Add(key, (object) string.Empty);
      string str = DebuggerHelper.Debugger.GetExpression(expression, false, -1).Value;
      DebuggerHelper.KnownValues[key] = (object) str;
      return str;
    }

    public static List<string> GetMembersName(string expression)
    {
      string key = nameof (GetMembersName) + expression;
      if (DebuggerHelper.KnownValues.ContainsKey(key))
        return (List<string>) DebuggerHelper.KnownValues[key];
      DebuggerHelper.KnownValues.Add(key, (object) null);
      EnvDTE.Expressions dataMembers = DebuggerHelper.Debugger.GetExpression(expression, false, -1).DataMembers;
      List<string> stringList = new List<string>();
      foreach (Expression expression1 in dataMembers)
        stringList.Add(expression1[]);
      DebuggerHelper.KnownValues[key] = (object) stringList;
      return stringList;
    }
  }
}