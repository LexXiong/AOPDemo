using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOPDemo.Main.Entities;
using AOPDemo.Main.Interceptors;
using AOPDemo.Main.Interceptors.Filters;
using AOPDemo.Main.Interceptors.Selectors;
using AOPDemo.Main.Services;
using Castle.DynamicProxy;

namespace AOPDemo.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new ProxyGenerator();

            var options = new ProxyGenerationOptions()
            {
                Hook = new InterceptorFilter(),
                Selector = new InterceptorSelector()
            };

            var entity = generator.CreateClassProxy<User>(options,
                new CallingLogInterceptor(),
                new SimpleLogInterceptor());

            entity.Name = "Lex";
            entity.Age = 28;
            entity.Sex = "Male";

            Console.WriteLine("The entity is: " + entity);

            Console.WriteLine("Type of the entity: " + entity.GetType().FullName);

            Console.ReadKey();

            var storageNode = generator.CreateInterfaceProxyWithTargetInterface<IStorageNode>(
                new StorageNode("master"),
                new DualNodeInterceptor(new StorageNode("slave")),
                new CallingLogInterceptor());

            storageNode.Save("my message"); //应该调用master对象
            storageNode.IsDead = true;
            storageNode.Save("my message"); //应该调用slave对象
            storageNode.Save("my message"); //应该调用master对象

            Console.ReadKey();

            options = new ProxyGenerationOptions();
            options.AddMixinInstance(new ClassA());
            var objB = generator.CreateClassProxy<ClassB>(options, new CallingLogInterceptor());
            objB.ActionB();
            var objA = objB as IActionA;
            objA.ActionA();

            Console.ReadKey();
        }
    }
}
