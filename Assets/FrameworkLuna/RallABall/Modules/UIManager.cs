using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace FrameworkLuna.RallABall
{
    public interface IUIManager : IModule 
    {
        
    }
    public class UIManager : IUIManager
    {
        public void InitModule()
        {
            Debug.Log("UIManager初始化成功");
        }
    }
}
