using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkLuna.ServiceLocator
{
    /// <summary>
    /// 服务定位器的储存数据结构 并且提供数据缓冲池作用 防止new过多导致gc
    /// </summary>
    public class ModuleSearchKeys
    {
        public Type Type { get; set; }

        private ModuleSearchKeys() { }

        //默认提供10个容量
        private static Stack<ModuleSearchKeys> mPool = new Stack<ModuleSearchKeys>(10);

        //提供分配方法 通过泛型T 给Type属性赋值
        public static ModuleSearchKeys Allocate<T>() 
        {
            ModuleSearchKeys outputKeys = null;
            outputKeys = mPool.Count != 0 ? mPool.Pop() : new ModuleSearchKeys();
            outputKeys.Type = typeof(T);
            return outputKeys;
        }

        //提供回收方法
        public void Release2Pool() 
        {
            Type = null;
            mPool.Push(this);
        }

    }
}
