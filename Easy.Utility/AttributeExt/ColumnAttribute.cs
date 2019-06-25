using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Utility.AttributeExt
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
  public  class ColumnAttribute : Attribute
    {
        private string _ColumnName = null;
        public ColumnAttribute(string columnName)
        {
            this._ColumnName = columnName;
        }
       
        public string GetColumn()
        {
            return this._ColumnName;
        }
    }
}
