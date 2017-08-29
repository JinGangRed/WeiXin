using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeiXin.Hepler.untils
{
    public class JsonHelper
    {
        #region 将JSon字符串转换为对象
        /// <summary>
        /// 将JSon字符串转换为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string jsonStr)
        {
            return JsonConvert.DeserializeObject<T>(jsonStr);
        }
        #endregion

        #region 将对象转化成JSON字符串
        /// <summary>
        /// 将对象转化成Json字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string SerializeObject<T>(T t)
        {
            return JsonConvert.SerializeObject(t);
        }
        #endregion
    }
}