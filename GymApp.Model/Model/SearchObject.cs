using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Model.Model
{
    public  class SearchObject
    {
        public string draw { set; get; }
        public string start { set; get; }
        public string length { set; get; }
        public string sortColumn { set; get; }
        public string sortColumnDir { set; get; }
        public string searchValue { set; get; }
        public int pageSize { set; get; }
        public int skip { set; get; }
        public int recordsTotal { set; get; }
    }
}
