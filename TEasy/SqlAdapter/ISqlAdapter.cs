using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TEasy
{
    public interface ISqlAdapter
    {
        string GetColumnName(MemberInfo mi);

        string GetParameterName(MemberInfo mi);
    }
}
