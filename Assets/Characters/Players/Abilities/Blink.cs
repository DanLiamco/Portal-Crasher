using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Blink", menuName = "Abilities/Blink")]
public class Blink : Ability
{
    public float dashDistance;
    public override void Activate(Character caster)
    {
        caster.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontalMovement) > 0f || Mathf.Abs(verticalMovement) > 0f)
        {
            caster.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalMovement, verticalMovement) * dashDistance);
        } else
        {
            caster.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * dashDistance);
        }

    }
}
