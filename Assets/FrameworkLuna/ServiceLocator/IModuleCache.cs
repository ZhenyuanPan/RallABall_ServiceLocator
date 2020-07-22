using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkLuna.ServiceLocator
{
    public interface IModuleCache
    {
        object GetModule(ModuleSearchKeys keys);
        object GetAllModules();
        void AddModule(ModuleSearchKeys keys,object module);
    }
}
