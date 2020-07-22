using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace FrameworkLuna.RallABall
{
    public interface IPlayerInputManager : IModule
    {
        void DoSometing();
    }
    public class PlayerInputManager : IPlayerInputManager
    {
        private IMonoManager monoManager;
        private Rigidbody playerRG;
        private Vector3 speed;

        public void DoSometing()
        {
           
        }

        public void InitModule()
        {
            monoManager = ModuleManagementConfig.Container.GetModule<IMonoManager>();
            playerRG = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
            monoManager.AddUpdateAction(PlayerInputUpdate);
            monoManager.AddFixedUpdateAction(PlayerMoveFixedUpdate);
            Debug.Log("PlayerInputManager初始化成功");
        }
        private void PlayerInputUpdate()
        {
            Vector2 input;
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");
            input = Vector2.ClampMagnitude(input, 1f);
            speed.x = input.x;
            speed.z = input.y;
        }
        private void PlayerMoveFixedUpdate()
        {
            playerRG.velocity = speed * 10;
        }
    }
}
