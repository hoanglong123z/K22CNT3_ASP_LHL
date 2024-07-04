using System.Web;
using System.Web.Mvc;

namespace LHLK22CNT3Lesson11_2210900037
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
