using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Follow Player", menuName = "AI Movement/Follow Player")]
public class FollowPlayer : AiMovement
{
    public override void Move(float movespeed, Rigidbody2D rigidBody, GameObject target)
    { 
        rigidBody.MovePosition(Vector3.MoveTowards(rigidBody.transform.position, target.transform.position, movespeed * Time.deltaTime));
    }
}
