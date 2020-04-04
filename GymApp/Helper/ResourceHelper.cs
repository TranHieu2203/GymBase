using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Web;

namespace GymApp.Website.Helper
{
    public class ResourceHelper
    {
        private static ResourceManager _resource;
        public static ResourceManager Resource
        {
            get
            {
                if (ReferenceEquals(_resource, null))
                {
                    var temp = new ResourceManager("Resources.App_Resource", Assembly.Load("App_GlobalResources"));
                    _resource = temp;
                }
                return _resource;
            }
        }
        public static CultureInfo Culture { get; set; }

        public static string GetText(string key)
        {
            return Resource.GetString(key, Culture);
        }
    }
}