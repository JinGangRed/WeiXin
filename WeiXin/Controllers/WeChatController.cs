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
        [Route("menu/create")]
        public ActionResult Index(string menuName)
        {
            string menu_data = "{" +
                "\"button\":[" +
                    "{" +
                        "\"type\":" +"\"view\"," +//click事件
                        "\"name\":" +"\""+menuName+"\","+
                        "\"url\":"+"\"https://www.baidu.com\"" +
                    "}" +
                  "]" +
                  "}";
            WeChatHelper.CreateMenu(menu_data);
            return View();
        }
    }
}