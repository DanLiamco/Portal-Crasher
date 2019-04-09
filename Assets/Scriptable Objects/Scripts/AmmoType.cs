using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Basic Ammo", menuName = "Ammo Type/Basic Ammo")]
public class AmmoType : ScriptableObject
{
    public string ammoName;
    public string ammoDescription;

    public float damage = 10f;
    public float projectileSpeed = 10f;
    public float fireRate = 1f;

    public GameObject projectilePrefab;

    public virtual void Fire(GameObject projectileSpawner, Quaternion playerRotation)
    {
        Instantiate(projectilePrefab, projectileSpawner.transform.position, playerRotation);
    }

    public virtual void Move(GameObject projectile)
    {
        projectile.transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed);
    }

    public virtual void Damage (Character target, GameObject projectile)
    {
        target.health -= damage;
        Destroy(projectile);
    }

    public virtual void Prep()
    {

    }

}
