using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mirror Player", menuName = "AI Movement/Mirror Player")]
public class MirrorPlayer : AiMovement
{
    public override void Move(float movespeed, Rigidbody2D rigidBody, GameObject target)
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        rigidBody.velocity = new Vector2(-horizontalMovement * movespeed, -verticalMovement * movespeed);
    }
}
