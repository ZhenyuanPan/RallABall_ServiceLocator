using FrameworkLuna.ServiceLocator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FrameworkLuna.ServiceLoctor
{
    public class ModuleContainer
    {
        private IModuleCache moduleCache;
        private IModuleFactory moduleFactory;

        public ModuleContainer(IModuleCache cache,IModuleFactory factory) 
        {
            moduleCache = cache;
            moduleFactory = factory;
        }

        public T GetModule<T>() where T : class 
        {
            ModuleSearchKeys moduleSearchKeys = ModuleSearchKeys.Allocate<T>();
            object module = moduleCache.GetModule(moduleSearchKeys);
            if (module == null)
            {
                module = moduleFactory.CreateModule(moduleSearchKeys);
                moduleCache.AddModule(moduleSearchKeys,module);
            }
            moduleSearchKeys.Release2Pool();
            return module as T;
        }

        public IEnumerable<T> GetAllModules<T>() where T : class 
        {
            var moduleSearchKeys = ModuleSearchKeys.Allocate<T>();
            var modules = moduleCache.GetAllModules() as IEnumerable<object>;
            if (modules == null || !modules.Any())
            {
                modules = moduleFactory.CreateAllModules() as IEnumerable<object>;
                foreach (var module in modules)
                {
                    moduleCache.AddModule(moduleSearchKeys, module);
                }
            }
            moduleSearchKeys.Release2Pool();
            //用select对modules 里面每个元素进行转型操作
            return modules.Select(m => m as T);
        }
    }
}

