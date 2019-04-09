using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Radiation Shot", menuName = "Ammo Type/Radiation Shot")]
public class RadiationShot : AmmoType
{
    public float damageRate = 1f;
    public float nextDamage = 0f;

    public float radiationDistance = 1f;

    public Vector3 radiationPoolLocation = new Vector3(100f, 100f, 100f);
    GameObject projectile;


    public KeyBindings keyBindings;

    private void OnEnable()
    {
        nextDamage = 0;
    }

    public override void Fire(GameObject projectileSpawner, Quaternion playerRotation)
    {
        if (projectile == null)
        {
            projectile = Instantiate(projectilePrefab, radiationPoolLocation, Quaternion.identity);
        }

        projectile.SetActive(true);
        projectile.transform.position = projectileSpawner.transform.position + projectileSpawner.transform.right * radiationDistance;
    }

    public override void Move(GameObject projectile)
    {
        if (Input.GetKeyUp(keyBindings.fire1))
        {
            projectile.SetActive(false);
        }
    }

    public void Damage(List<Character> targets, GameObject projectile)
    {
        if (Time.time >= nextDamage)
        {
            foreach (Character target in targets)
            {
                target.health -= damage;
            }

            nextDamage = Time.time + damageRate;
        }
    }
}
