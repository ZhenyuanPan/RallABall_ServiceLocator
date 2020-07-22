using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    Vector3 speed;
    Rigidbody playerRigidBody;
    // Update is called once per frame
    public void PlayerInputUpdate()
    {
        Vector2 input;
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        input = Vector2.ClampMagnitude(input,1f);
        speed.x = input.x;
        speed.z = input.y;
    }

    public void FixedUpdate()
    {
        playerRigidBody.velocity = speed*10;
    }
}
 