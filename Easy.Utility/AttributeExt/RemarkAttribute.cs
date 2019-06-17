using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Utility.AttributeExt
{
  public  class RemarkAttribute:Attribute
    {
        private string _Remark = null;
        public RemarkAttribute(string remark)
        {
            this._Remark = remark;
        }
       
        public string GetRemark()
        {
            return this._Remark;
        }
    }
}
