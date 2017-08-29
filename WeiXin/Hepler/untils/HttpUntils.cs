using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace WeiXin.Hepler.untils
{
    public class HttpUntils
    {
        private static ILog log = LogManager.GetLogger(typeof(HttpUntils));
        #region 发送请求
        /// <summary>
        /// 发送请求获得响应字符串
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="data">请求的数据</param>
        /// <param name="method">请求方法</param>
        /// <returns></returns>
        public string GetRequestResponseStr(string url, string data = "", string method = "GET")
        {
            Stream requestStream = null;
            Stream responseStream = null;
            StreamReader reader = null;
            HttpWebResponse response = null;
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            try
            {
                request.Method = method;
                if (!string.IsNullOrWhiteSpace(data))
                {
                    byte[] dataByte = Encoding.UTF8.GetBytes(data);
                    request.ContentType = "application/x-www-form-urlencoded";
                    requestStream = request.GetRequestStream();
                    requestStream.Write(dataByte, 0, dataByte.Length);
                    requestStream.Close();
                }
                response = request.GetResponse() as HttpWebResponse;
                string encoding = response.ContentEncoding;
                if (encoding == null || string.IsNullOrWhiteSpace(encoding))
                {
                    encoding = "UTF-8";
                }
                responseStream = response.GetResponseStream();
                reader = new StreamReader(responseStream, Encoding.GetEncoding(encoding));
                string content = reader.ReadToEnd();
                return content;
            }
            catch (Exception ex)
            {
                log.Error("Http Request Error:" + ex);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (responseStream != null)
                {
                    responseStream.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                if (requestStream != null)
                {
                    requestStream.Close();
                }
            }
            return null;
        }

        /// <summary>
        /// 获得请求响应的对象
        /// </summary>
        /// <typeparam name="T">响应的对象</typeparam>
        /// <param name="url">请求地址</param>
        /// <param name="data">请求数据</param>
        /// <param name="method">请求方法</param>
        /// <returns></returns>
        public T GetRequestResponseObject<T>(string url, string data = "", string method = "GET")
        {
            T t = default(T);
            try
            {
                var result = GetRequestResponseStr(url, data, method);
                t = JsonHelper.DeserializeObject<T>(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return t;
        }
        #endregion

    }
}