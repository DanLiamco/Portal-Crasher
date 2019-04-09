using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public AmmoType ammoType;

    public GameManager gameManager;

    void Update()
    {
        if (gameManager.gameIsPaused)
        {
            return;
        }

        ammoType.Move(gameObject);
    }

    public virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            if (!collision.GetComponent<Enemy>().enemyActivated)
            {
                return;
            }
        }

        if (collision.GetComponent<Portal>())
        {
            if (!collision.GetComponent<Portal>().portalActivated)
            {
                return;
            }
        }

        if (collision.GetComponent<Character>())
        {
            ammoType.Damage(collision.GetComponent<Character>(), this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
