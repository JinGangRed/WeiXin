using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeiXin.App_Start;
using WeiXin.Hepler.untils;
using WeiXin.Models;

namespace WeiXin.Hepler.WeChatHelper
{
    /// <summary>
    /// 完成微信的相关请求
    /// </summary>
    public class WeChatHelper
    {
        private static HttpUntils http = new HttpUntils();
        /// <summary>
        /// 获得AccessToken
        /// </summary>
        /// <returns></returns>
        public static string GetAccessToken()
        {
            string token = string.Empty;
            string token_url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}",
                Config.WechatAppID, Config.WechatSecret);
            if(HttpContext.Current.Request.Cookies[WeChatConstantData.access_cookie_str] == null)
            {
                AccessTokenModel access = http.GetRequestResponseObject<AccessTokenModel>(token_url);
                if(access.access_token != null)
                {
                    token = access.access_token;
                    HttpCookie access_cookie = new HttpCookie(WeChatConstantData.access_cookie_str, token);
                    access_cookie.Expires = DateTime.Now.AddSeconds(access.expires_in);
                    HttpContext.Current.Response.Cookies.Add(access_cookie);
                }
            }
            else
            {
                token = HttpContext.Current.Request.Cookies[WeChatConstantData.access_cookie_str].Value;
            }
            return token;
        }
        /// <summary>
        /// 网页授权获得Access_Token,可以同时获得OpenID和Access_token
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetAccessToken(string code,out string OpenID)
        {
            string token = string.Empty;
            string openid = string.Empty;
            string token_url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code",
                Config.WechatAppID, Config.WechatSecret, code);
            if(HttpContext.Current.Request.Cookies[WeChatConstantData.openid_cookie_str] == null)
            {
                if (HttpContext.Current.Request.Cookies[WeChatConstantData.oauth_access_cookie_str] == null)
                {
                    AccessTokenModel access = http.GetRequestResponseObject<AccessTokenModel>(token_url);
                    if (access != null)
                    {
                        openid = access.openid;
                        //将AccessToken压入Cookie中
                        HttpCookie access_cookie = new HttpCookie(WeChatConstantData.oauth_access_cookie_str, token);
                        access_cookie.Expires = DateTime.Now.AddSeconds(access.expires_in);
                        //将OpenID压入Cookie中
                        HttpCookie openid_cookie = new HttpCookie(WeChatConstantData.openid_cookie_str, access.openid);
                        HttpContext.Current.Response.Cookies.Add(access_cookie);
                        HttpContext.Current.Response.Cookies.Add(openid_cookie);
                    }
                    else
                    {
                        openid = "";
                        //请求URL出错了
                    }
                }
            }
            else
            {
                openid = HttpContext.Current.Request.Cookies[WeChatConstantData.openid_cookie_str].Value;
                if(HttpContext.Current.Request.Cookies[WeChatConstantData.oauth_access_cookie_str] != null)
                {
                    token = HttpContext.Current.Request.Cookies[WeChatConstantData.oauth_access_cookie_str].Value;
                }
                else
                {
                    //说明token已过期
                }
            }
            OpenID = openid;
            return token;
        }




        #region 自定义菜单(已完成接口:创建菜单、查询菜单、删除菜单)
        /// <summary>
        /// 创建自定义菜单
        /// </summary>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public static string CreateMenu(string jsonData)
        {
            string create_url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}",
                GetAccessToken());
            var result = http.GetRequestResponseObject<SimpleResponseModel>(create_url, jsonData, "POST");
            if (result != null)
            {
                if (result.errcode == 0)
                {
                    return "OK";
                }
                else
                {
                    return result.errmsg;
                }
            }
            else
            {
                return "响应出现问题";
            }
        }

        /// <summary>
        /// 菜单查询
        /// </summary>
        /// <returns></returns>
        public static string GetMenu()
        {
            string getmeun_url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}",
                GetAccessToken());
            var result = http.GetRequestResponseStr(getmeun_url);
            return result;
        }

        /// <summary>
        /// 删除菜单,请注意，删除菜单时，调用此接口会删除默认菜单及全部个性化菜单。
        /// </summary>
        /// <returns></returns>
        public static string DeleteMenu()
        {
            string delete_url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}",
                GetAccessToken());
            var result = http.GetRequestResponseObject<SimpleResponseModel>(delete_url);
            if(result != null)
            {
                return result.errmsg;
            }
            else
            {
                return "请求错误";
            }
        }



        #endregion



    }
}