using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationShotProjectile : Projectile
{
    public RadiationShot radiationShot;
    public List<Character> targets = new List<Character>();

    public override void OnTriggerStay2D(Collider2D collision)
    {
        if (FindObjectOfType<GameManagerObject>())
        {
            if (FindObjectOfType<GameManagerObject>().gameManager.gameIsPaused)
            {
                return;
            }
        }

        if (collision.GetComponent<Enemy>())
        {
            if (!collision.GetComponent<Enemy>().enemyActivated)
            {
                return;
            }
        }

        if (collision.GetComponent<Character>())
        {
            if (!targets.Contains(collision.GetComponent<Character>()))
            {
                targets.Add(collision.GetComponent<Character>());
            }

            radiationShot.Damage(targets, this.gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Character>())
        {
            if (targets.Contains(collision.GetComponent<Character>()))
            {
                targets.Remove(collision.GetComponent<Character>());
            }
        }
    }
}
