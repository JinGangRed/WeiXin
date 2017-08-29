using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WeiXin.App_Start
{
    /// <summary>
    /// 用于读取web.config中系统的相关配置
    /// </summary>
    public class Config
    {
        //连接字符串
        public static string ConnectionString { set; get; }

        //服务号配置

        public static string WechatAppID { set; get; }

        public static string WechatSecret { set; get; }

        public static string Environment { set; get; }

        public static string BaseUrl { set; get; }

        //网页登录配置

        public static string WeChatWebAppID { set; get; }

        public static string WeChatWebAppSecret { set; get; }

        public static string WebBaseUrl { set; get; }



        public static void Initialize()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["ProjectDBConnection"].ConnectionString;
            WechatAppID = ConfigurationManager.AppSettings["WechatAppID"];
            WechatSecret = ConfigurationManager.AppSettings["WechatSecret"];
            Environment = ConfigurationManager.AppSettings["Environment"];
            BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];

            WeChatWebAppID = ConfigurationManager.AppSettings["WeChatWebAppID"];
            WeChatWebAppSecret = ConfigurationManager.AppSettings["WeChatWebAppSecret"];
            WebBaseUrl = ConfigurationManager.AppSettings["WebBaseUrl"];
        }
    }
}