using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Utility.AttributeExt
{
    /// <summary>
    /// 列名特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        private string _ColumnName = null;
        /// <summary>
        /// 默认带参构造函数
        /// </summary>
        /// <param name="columnName">需要对应的列名字段</param>
        public ColumnAttribute(string columnName)
        {
            this._ColumnName = columnName;
        }
        /// <summary>
        /// 获取列名
        /// </summary>
        /// <returns></returns>
        public string GetColumn()
        {
            return this._ColumnName;
        }
    }
}
