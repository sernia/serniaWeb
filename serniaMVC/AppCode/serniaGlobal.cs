using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace serniaMVC
{
    public class serniaGlobal
    {
        /// <summary>
        /// 多国語設定
        /// </summary>
        /// <returns>string</returns>
        public static void setCountry()
        {
            try { 
                var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;

                string setLan = routeValues["lan"].ToString();
                if (!string.IsNullOrEmpty(setLan))
                {
                    switch (setLan)
                    {
                        case "ja":
                            break;
                        case "ko":
                            break;
                        default:
                            HttpContext.Current.Response.RedirectToRoute("Index");
                            return;
                    }
                }

                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfoByIetfLanguageTag(setLan);
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfoByIetfLanguageTag(setLan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    public static class htmlHelper
    {
        /// <summary>
        /// バイト単位で文字列を返却する
        /// </summary>
        /// <param name="s">文字列</param>
        /// <param name="l">バイト数</param>
        /// <returns>string</returns>
        public static string strCut(string s, int b = 10)
        {
            Encoding e = System.Text.Encoding.GetEncoding(65001);
            string result = new string(s.TakeWhile((c, i) => e.GetByteCount(s.Substring(0, i + 1)) <= b).ToArray());
            return result + "...";
            //HttpUtility.HtmlAttributeEncode(result);
        }
    }
}
