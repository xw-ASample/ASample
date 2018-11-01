using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ASample.Permission.Service
{
    public class AutoFacConfig
    {
        //负责调用autofac框架实现业务层和数据仓储层程序集中的类型对象的创建
        //负责创建MVC控制器类的对象（调用控制器中的有参构造函数），接管DefauleContorllerFactory的工作
        public static void Register()
        {
            //1.0 实例化一个autofac的创建容器
            var builder = new ContainerBuilder();

            //2.0 告诉Autofac框架，将来要创建的控制器类存放在哪个程序集 (itcast.CRM15.Site)
            Assembly controllerAss = Assembly.Load("ASample.Permission.Service");
            builder.RegisterControllers(controllerAss);

            //3.0 告诉autofac框架注册数据仓储层所在程序集中的所有类的对象实例
            Assembly respAss = Assembly.Load("ASample.Permission.Service");
            //创建respAss中的所有类的instance以此类的实现接口存储
            builder.RegisterTypes(respAss.GetTypes()).AsImplementedInterfaces();

            //4.0 告诉autofac框架注册业务逻辑层所在程序集中的所有类的对象实例
            Assembly serAss = Assembly.Load("ASample.Permission.Service");
            //创建serAss中的所有类的instance以此类的实现接口存储
            builder.RegisterTypes(serAss.GetTypes()).AsImplementedInterfaces();

            //5.0 创建一个Autofac的容器
            var container = builder.Build();
            //5.0.1将container对象缓存到HttpRumtime。cache中，并且永久有效。
            //CacheManager.SetData(Keys.AutoFacContainer, container);
            //通过缓存管理类来对其进行操作，封装



            //从容器中拿到一个具体实现类的方法
            //container.Resolve<IsysUserInfoService>();//可以从Autofac容器中获取指定的IsysUserInfoService的具体实现类的实体对象



            // 6.0 将MVC的控制器对象实例 交由autofac来创建
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}