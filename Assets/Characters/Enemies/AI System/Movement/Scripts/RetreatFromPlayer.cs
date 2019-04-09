using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Retreat From Player", menuName = "AI Movement/Retreat From Player")]
public class RetreatFromPlayer : AiMovement
{
    public override void Move(float movespeed, Rigidbody2D rigidBody, GameObject target)
    {
        rigidBody.MovePosition(Vector3.MoveTowards(rigidBody.transform.position, target.transform.position, -movespeed * Time.deltaTime));
    }
}
