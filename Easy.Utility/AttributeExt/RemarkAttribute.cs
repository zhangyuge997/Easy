using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Utility.AttributeExt
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class RemarkAttribute : Attribute
    {
        private string _Remark = null;
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
