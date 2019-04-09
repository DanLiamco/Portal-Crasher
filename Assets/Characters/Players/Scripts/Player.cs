using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public event Death OnPlayerDeath;

    public override void Update()
    {
        base.Update();

        if (health <= 0f && OnPlayerDeath != null)
        {
            OnPlayerDeath();
        }
    }
}
