using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymApp.Website.Models
{
    public class BaseModel
    {
        public bool IsModelValid { get; set; }
        public bool Success { get; set; }
    }
    public class ResponseObj
    {
        public ResponseObj()
        {
            success = true;
            data = null;
        }
        public bool success { get; set; }
        public object data { get; set; }
        public string mess { get; set; }

        public ResponseObj(object _Data)
        {
            data = _Data;
        }
        public ResponseObj(bool _Success, object _Data)
        {
            success = _Success;
            data = _Data;
        }
        public ResponseObj(bool _Success, object _Data = null, string _mess = null)
        {
            success = _Success;
            data = _Data;
            mess = _mess;
        }
    }
    public class LoginResponse
    {
        public string AKey { get; set; }
        public int ETime { get; set; }
        public string RKey { get; set; }
    }

}