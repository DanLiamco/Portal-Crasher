using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spreadshot", menuName = "Ammo Type/Spreadshot")]
public class Spreadshot : AmmoType
{
    public int spreadCount;
    public float spreadAngle;
    public float knockbackForce = 2f;

    public override void Fire(GameObject projectileSpawner, Quaternion playerRotation)
    {
        for (int i = 0; i < spreadCount; i++)
        {
            int rotationSign = 1;
            float currentBullet = i;
            Quaternion addedRotation;
            Quaternion newRotation = Quaternion.Euler(10f, 10f, 10f);

            if (i > 0)
            {
                if (i % 2 == 0)
                {
                    rotationSign = -1;
                    addedRotation = Quaternion.Euler(0f, 0f, (((currentBullet / 2)) * spreadAngle * rotationSign));
                } else
                {
                    rotationSign = 1;
                    addedRotation = Quaternion.Euler(0f, 0f, (((currentBullet / 2) + .5f) * spreadAngle * rotationSign));
                }

                newRotation = playerRotation * addedRotation;
                Instantiate(projectilePrefab, projectileSpawner.transform.position, newRotation);
            } else
            {
                base.Fire(projectileSpawner, playerRotation);
            }
        }
    }

    public override void Damage(Character target, GameObject projectile)
    {
        base.Damage(target, projectile);

        target.GetComponent<Rigidbody2D>().AddForce((target.transform.position - projectile.transform.position).normalized * knockbackForce);
    }
}
