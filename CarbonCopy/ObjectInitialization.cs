using System;

namespace Zinc.CarbonCopy
{
    public abstract class ObjectInitialization
    {
        protected string _variableName;

        public ObjectInitialization(string variableName)
        {
            _variableName = variableName;
        }

        public string Initialization
        {
            get { return GenerateInitialization(); }
        }

        public string Type
        {
            get
            {
                return DebuggerHelper.GetValue(ExpressionsHelper.TypeFullName(_variableName)).Replace("\"", String.Empty).Replace("+", ".").Replace("[]", "()");
            }
        }

        public string Name
        {
            get
            {
                return _variableName.Substring(_variableName.LastIndexOf(".") + 1);
            }
        }

        public string VariableName
        {
            set
            {
                _variableName = value;
            }
        }

        abstract protected string GenerateInitialization();
    }
}
