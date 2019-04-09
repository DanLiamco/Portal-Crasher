using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActivator : MonoBehaviour
{
    [SerializeField]
    List<Enemy> enemies = new List<Enemy>();

    [SerializeField]
    bool hasPlayer = false;

    public Portal portal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            enemies.Add(collision.gameObject.GetComponent<Enemy>());
        }

        if (collision.GetComponent<Portal>())
        {
            portal = collision.GetComponent<Portal>();
        }

        if (collision.GetComponent<PlayerMovement>())
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.enemyActivated = true;
            }

            if (portal)
            {
                portal.portalActivated = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            if (portal)
            {
                portal.portalActivated = false;
            }
        }
    }
}
