using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkLuna.ServiceLocator.Default
{
    public class DefaultModuleFactory : IModuleFactory
    {
        //具体类型
        private List<Type> mConcreteTypeCache;

        private Dictionary<Type, Type> mAbstractToConcrete = new Dictionary<Type, Type>();

        public DefaultModuleFactory(Assembly assembly, Type baseModuleType) 
        {
            mConcreteTypeCache = assembly
                .GetTypes()
                //查找实现了baseModuleType的t 但t又不是抽象的(接口,抽象类)的Type[]
                .Where(t => baseModuleType.IsAssignableFrom(t) && !t.IsAbstract)
                .ToList();

            foreach (var type in mConcreteTypeCache)
            {
                //返回由当前Type实现或者继承的所有接口的Type对象数组
                var interfaces = type.GetInterfaces();
                foreach (var @interface in interfaces)
                {
                    //条件: @interface接口实现了baseModuleType 并且 @interface不是baseModuleType本身
                    if (baseModuleType.IsAssignableFrom(@interface) && @interface != baseModuleType)
                    {
                        mAbstractToConcrete.Add(@interface,type);
                    }
                }
            }
        }

        public object CreateAllModules()
        {
            return mConcreteTypeCache.Select(t => t.GetConstructors().First().Invoke(null));
        }

        public object CreateModule(ModuleSearchKeys keys)
        {
            //根据输入的接口 查找抽象类型与具体类型对应的字典，然后构造实例对象
            if (keys.Type.IsAbstract)
            {
                if (mAbstractToConcrete.ContainsKey(keys.Type))
                {
                    return mAbstractToConcrete[keys.Type].GetConstructors().First().Invoke(null);
                }
            }
            else
            {
                if (mConcreteTypeCache.Contains(keys.Type))
                {
                    return keys.Type.GetConstructors().First().Invoke(null);
                }
            }
            return null;
        }
    }
}
