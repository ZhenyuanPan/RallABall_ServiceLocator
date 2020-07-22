using FrameworkLuna.ServiceLocator.Default;
using FrameworkLuna.ServiceLoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FrameworkLuna.RallABall
{
    public class ModuleManagementConfig 
    {
        public static ModuleContainer Container = null;

        [RuntimeInitializeOnLoadMethod]
        private static void Config() 
        {
            var baseType = typeof(IModule);
            var cache = new DefaultModuleCache();
            var factory = new DefaultModuleFactory(baseType.Assembly,baseType);

            Container = new ModuleContainer(cache,factory);

            IPoolManager poolManager = Container.GetModule<IPoolManager>();
            IPlayerInputManager playerInputManager = Container.GetModule<IPlayerInputManager>();
            IUIManager uIManager = Container.GetModule<IUIManager>();
            IMonoManager monoManager = Container.GetModule<IMonoManager>();

            IEnumerable<IModule> modules = Container.GetAllModules<IModule>();
            foreach (var module in modules)
            {
                //通过父类接口调用到它的实现类的具体方法
                module.InitModule();
            }
        }
    }
}
