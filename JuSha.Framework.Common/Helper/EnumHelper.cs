using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;

namespace JuSha.Framework.Common.Helper
{
     public class EnumHelper
    {
         /// <summary>
         /// 获取一个枚举值的描述，当无描述时返回枚举值名称
         /// </summary>
         /// <param name="enumValue">枚举值</param>
         /// <returns></returns>
         public static string GetEnumDescription(Enum enumValue)
         {

             string value = enumValue.ToString();
             FieldInfo field = enumValue.GetType().GetField(value);
             object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);    //获取描述属性
             if (objs == null || objs.Length == 0)    //当描述属性没有时，直接返回名称
                 return value;
             DescriptionAttribute descriptionAttribute = (DescriptionAttribute)objs[0];
             return descriptionAttribute.Description;
         }
         /// <summary>
         /// 获取枚举所有描述，主要用于下拉选项绑定
         /// </summary>
         /// <typeparam name="T"></typeparam>
         public static List<Helper.ReadEnum> GetEnumAllDescription<T>()
         {
             List<Helper.ReadEnum> enums = new List<ReadEnum>();
             Type type = typeof(T);
             Array enumArray= Enum.GetValues(type);
             foreach (var enumValue in enumArray)
             {
                 enums.Add(
                     new ReadEnum
                     {
                         Description = GetEnumDescription((Enum)enumValue),
                         Value = ((int)enumValue).ToString(),
                         Name = enumValue.ToString()
                     }
                     );
             }
             return enums;
         }
     
    }
}
