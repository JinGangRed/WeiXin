using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeiXin.Models
{
    /// <summary>
    /// 微信相关的相应和请求类
    /// </summary>
    public class WeChatModel
    {
    }
    /// <summary>
    /// 微信常用字段的数据字符串
    /// </summary>
    public class WeChatConstantData
    {
        /// <summary>
        /// openid的cookie字符串
        /// </summary>
        public static readonly string openid_cookie_str = "OPENID";
        /// <summary>
        /// 基础支持的AccessToken的cookie字符串
        /// </summary>
        public static readonly string access_cookie_str = "ACCESS_TOKEN";
        /// <summary>
        /// 网页授权支持的AccessToken的cookie字符串
        /// </summary>
        public static readonly string oauth_access_cookie_str = "OAUTH_ACCESS_TOKEN";
    }

    /// <summary>
    /// Access_Token的响应模型
    /// </summary>
    public class AccessTokenModel
    {

        public string access_token;//获取到的凭证
        public int expires_in;//凭证有效时间，单位：秒
        //错误响应
        public int errcode;//错误码
        public string errmsg;//错误信息

        //网页授权
        public string refresh_token;//用户刷新access_token
        public string openid;//用户唯一标识，请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的OpenID
        public string scope;//用户授权的作用域，使用逗号（,）分隔

    }
}