using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fireshot", menuName = "Ammo Type/Fireshot")]
public class Fireshot : AmmoType
{
    public float fireDuration = 4f;

    public int damageTicks = 4;

    public Color normalColor;
    public Color burningColor;

    public override void Damage(Character target, GameObject projectile)
    {
        Destroy(projectile);

        if (!target.GetComponent<Firestarter>())
        {
            target.gameObject.AddComponent<Firestarter>();
        }

        Firestarter fireStarter = target.GetComponent<Firestarter>();

        fireStarter.StartFire(target, burningColor, normalColor, damageTicks, damage, fireDuration);
    }
}
