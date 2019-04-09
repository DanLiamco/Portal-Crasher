using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public override void Update()
    {
        if (gameManager.gameIsPaused)
        {
            if (GetComponent<Rigidbody2D>())
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }

            return;
        }

        base.Update();

        if (!enemyActivated)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }
        
        aiSystem.movement.Move(moveSpeed, GetComponent<Rigidbody2D>(), FindObjectOfType<PlayerMovement>().gameObject);
        aiSystem.attack.Attack(FindObjectOfType<PlayerMovement>().gameObject, this);
    }
}
