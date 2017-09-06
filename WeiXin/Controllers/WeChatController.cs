using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeiXin.Hepler.WeChatHelper;

namespace WeiXin.Controllers
{
    public class WeChatController : Controller
    {
        // GET: WeChat
        //http://localhost:8080/wechat/index?menuName=asaj
        //[Route("menu/create")]
        public string Index(string menuName,string url)
        {
            string menu_data = "{" +
                "\"button\":[" +
                    "{" +
                        "\"type\":" +"\"view\"," +//click事件
                        "\"name\":" +"\""+menuName+"\","+
                        "\"url\":"+"\""+url+"\"" +
                    "}" +
                  "]" +
                  "}";
            return WeChatHelper.CreateMenu(menu_data);
        }

        public string Delete()
        {
            return WeChatHelper.DeleteMenu();
        }

    }
}