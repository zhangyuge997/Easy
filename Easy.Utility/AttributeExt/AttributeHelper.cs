using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Utility.AttributeExt
{
  public static class AttributeHelper
    {
        /// <summary>
        /// 获取枚举的备注信息
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetRemark(this Enum enumValue)
        {
            Type type = enumValue.GetType();
            FieldInfo field = type.GetField(enumValue.ToString());
            if (field.IsDefined(typeof(RemarkAttribute), true))
            {
                RemarkAttribute attribute = (RemarkAttribute)field.GetCustomAttribute(typeof(RemarkAttribute), true);
                return attribute.GetRemark();
            }
            else
            {
                return enumValue.ToString();
            }
        }
        /// <summary>
        /// 获取属性的备注信息
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static string GetRemark(this PropertyInfo prop)
        {
            if (prop.IsDefined(typeof(RemarkAttribute), true))
            {
                RemarkAttribute attribute = (RemarkAttribute)prop.GetCustomAttribute(typeof(RemarkAttribute), true);
                return attribute.GetRemark();
            }
            else
            {
                return prop.Name;
            }
        }
        /// <summary>
        /// 获取属性的备注信息
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static string GetRemark(this FieldInfo prop)
        {
            if (prop.IsDefined(typeof(RemarkAttribute), true))
            {
                RemarkAttribute attribute = (RemarkAttribute)prop.GetCustomAttribute(typeof(RemarkAttribute), true);
                return attribute.GetRemark();
            }
            else
            {
                return prop.Name;
            }
        }

        /// <summary>
        /// 获取属性的对应的列名
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static string GetColumn(this PropertyInfo prop)
        {
            if (prop.IsDefined(typeof(ColumnAttribute), true))
            {
                ColumnAttribute attribute = (ColumnAttribute)prop.GetCustomAttribute(typeof(ColumnAttribute), true);
                return attribute.GetColumn();
            }
            else
            {
                return prop.Name;
            }
        }
        /// <summary>
        /// 获取属性的对应的列名
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static string GetColumn(this FieldInfo prop)
        {
            if (prop.IsDefined(typeof(ColumnAttribute), true))
            {
                ColumnAttribute attribute = (ColumnAttribute)prop.GetCustomAttribute(typeof(ColumnAttribute), true);
                return attribute.GetColumn();
            }
            else
            {
                return prop.Name;
            }
        }

    }
}
