using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPDemo.Main.Services
{
    public class ClassB
    {
        public virtual void ActionB()
        {
            Console.WriteLine("I'm from ClassB");
        }
    }
}
