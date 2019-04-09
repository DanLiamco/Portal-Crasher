using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Character
{
    public bool portalActivated = false;

    public event Death OnPortalDeath;

    public override void Update()
    {
        base.Update();

        if (health <= 0f && OnPortalDeath != null)
        {
            OnPortalDeath();
        }
    }
}
