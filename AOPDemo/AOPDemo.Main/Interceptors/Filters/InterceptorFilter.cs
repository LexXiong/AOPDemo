using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace AOPDemo.Main.Interceptors.Filters
{
    public class InterceptorFilter : IProxyGenerationHook
    {
        public void MethodsInspected()
        {
        }

        public void NonVirtualMemberNotification(Type type, MemberInfo memberInfo)
        {
        }

        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            return methodInfo.IsSpecialName &&
                (methodInfo.Name.StartsWith("set_") || methodInfo.Name.StartsWith("get_"));
        }
    }
}
