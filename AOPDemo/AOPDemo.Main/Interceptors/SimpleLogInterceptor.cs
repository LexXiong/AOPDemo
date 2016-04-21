using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Interceptor;

namespace AOPDemo.Main.Interceptors
{
    public class SimpleLogInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine(">>" + invocation.Method.Name);
            invocation.Proceed();
        }
    }
}
