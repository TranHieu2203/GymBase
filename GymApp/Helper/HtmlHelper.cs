using System.Linq;
using System;
using GymApp.Model.Model;
using System.Web;

namespace GymApp.Website.Helper
{
    public class HtmlHelper
    {
      public static SearchObject GetSearchObject()
        {

            var draw = HttpContext.Current.Request.Form.GetValues("draw").FirstOrDefault();
            var start = HttpContext.Current.Request.Form.GetValues("start").FirstOrDefault();
            var length = HttpContext.Current.Request.Form.GetValues("length").FirstOrDefault();
            var sortColumn = HttpContext.Current.Request.Form.GetValues("columns[" + HttpContext.Current.Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = HttpContext.Current.Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            var searchValue = HttpContext.Current.Request.Form.GetValues("search[value]").FirstOrDefault();

            //Paging Size (10,20,50,100)    
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            var objSearch = new SearchObject();
            objSearch.draw = draw;
            objSearch.start = start;
            objSearch.sortColumn = sortColumn;
            objSearch.sortColumnDir = sortColumnDir;
            objSearch.searchValue = searchValue;
            objSearch.pageSize = pageSize;
            objSearch.skip = skip;
            objSearch.recordsTotal = recordsTotal;
            return objSearch;
        }
    }
}