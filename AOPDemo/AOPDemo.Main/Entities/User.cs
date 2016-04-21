using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPDemo.Main.Entities
{
    public class User
    {
        public virtual string Name { get; set; }

        public virtual int Age { get; set; }

        public virtual string Sex { get; set; }

        public override string ToString()
        {
            return string.Format("{{ \"name\": \"{0}\", \"age\": {1}, \"sex\": \"{2}\" }}", Name, Age, Sex);
        }
    }
}
