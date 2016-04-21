using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPDemo.Main.Services
{
    public class ClassA : IActionA
    {
        public void ActionA()
        {
            Console.WriteLine("I'm from ClassA");
        }
    }
}
