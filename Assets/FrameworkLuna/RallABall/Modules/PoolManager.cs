using FrameworkLuna.ServiceLoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace FrameworkLuna.RallABall
{
    public interface IPoolManager : IModule 
    {
        
    }
    public class PoolManager : IPoolManager
    {
       
        public void InitModule()
        {
           
            Debug.Log("PoolManager初始化成功");
        }
        
    }
}
