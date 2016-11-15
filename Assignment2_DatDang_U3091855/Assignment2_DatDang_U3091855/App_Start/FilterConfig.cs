using System.Web;
using System.Web.Mvc;

namespace Assignment2_DatDang_U3091855
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}