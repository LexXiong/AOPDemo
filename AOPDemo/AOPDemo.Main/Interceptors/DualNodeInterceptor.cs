using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOPDemo.Main.Services;
using Castle.Core.Interceptor;

namespace AOPDemo.Main.Interceptors
{
    public class DualNodeInterceptor : IInterceptor
    {
        private IStorageNode _slave;

        public DualNodeInterceptor(IStorageNode slave)
        {
            _slave = slave;
        }

        public void Intercept(IInvocation invocation)
        {
            var master = invocation.InvocationTarget as IStorageNode;
            if (master.IsDead)
            {
                var cpt = invocation as IChangeProxyTarget;
                // 仅替换本次调用
                cpt.ChangeInvocationTarget(_slave);
                // 永久替换调用，但是本次不替换。
                //cpt.ChangeProxyTarget(_slave);
                master.IsDead = false;
            }
            invocation.Proceed();
        }
    }
}
