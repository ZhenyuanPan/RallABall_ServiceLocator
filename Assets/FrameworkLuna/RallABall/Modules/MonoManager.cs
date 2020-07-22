using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FrameworkLuna.RallABall 
{
    public interface IMonoManager : IModule
    {
        void AddUpdateAction(Action action);
        void RemoveUpdateAction(Action action);
        void AddFixedUpdateAction(Action action);
        void RemoveFixedUpdateAction(Action action);
    }
    public class MonoManager : MonoBehaviour, IMonoManager
    {
        private static Action updateAction;
        private static Action fixedUpdateAction;

        public void InitModule()
        {
            if (GameObject.Find("MonoGO"))
            {
                return;
            }
            GameObject monoGO = new GameObject("MonoManagerGO");
            monoGO.AddComponent<MonoManager>();
            Debug.Log("MonoManager初始化成功");
        }

        public void AddUpdateAction(Action action) 
        {
            updateAction += action;
        }

        public void RemoveUpdateAction(Action action) 
        {
            updateAction -= action;
        }

        public void AddFixedUpdateAction(Action action)
        {
            fixedUpdateAction += action;
        }

        public void RemoveFixedUpdateAction(Action action)
        {
            fixedUpdateAction -= action;
        }


        private void Update()
        {
           
            if (updateAction == null)
            {
                return;
            }
            updateAction();
        }

        private void FixedUpdate()
        {
            if (fixedUpdateAction == null)
            {
                return;
            }
            fixedUpdateAction();
        }
    }
}
