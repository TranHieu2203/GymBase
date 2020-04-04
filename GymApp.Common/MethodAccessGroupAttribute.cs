using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Common
{
    public class MethodAccessGroupAttribute : Attribute
    {
        public MethodAccessGroupAttribute(string name, bool allowSelect)
        {
            Name = name;
            AllowSelect = allowSelect;
        }

        public MethodAccessGroupAttribute(string name, string nameNext, bool allowSelect)
        {
            Name = name;
            NameNext = NameNext;
            AllowSelect = allowSelect;
        }

        public string NameNext { get; private set; }
        public string Name { get; private set; }
        public bool AllowSelect { get; private set; }
    }
}
