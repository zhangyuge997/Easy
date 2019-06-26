using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Utility.AttributeExt
{
    /// <summary>
    /// 获取备注信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Enum)]
    public class RemarkAttribute : Attribute
    {
        private string _Remark = null;
        /// <summary>
        /// 默认带参构造函数
        /// </summary>
        /// <param name="remark">备注信息</param>
        public RemarkAttribute(string remark)
        {
            this._Remark = remark;
        }
        /// <summary>
        /// 获取备注信息
        /// </summary>
        /// <returns></returns>
        public string GetRemark()
        {
            return this._Remark;
        }
    }
}
