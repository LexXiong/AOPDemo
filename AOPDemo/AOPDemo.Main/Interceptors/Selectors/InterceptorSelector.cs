using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Interceptor;

namespace AOPDemo.Main.Interceptors.Selectors
{
    public class InterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            if (method.Name.StartsWith("set_"))
            {
                return interceptors;
            }
            else
            {
                return interceptors.Where(c => c is CallingLogInterceptor).ToArray();
            }
        }
    }
}
