using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firestarter : MonoBehaviour
{
    public void StartFire(Character target, Color burningColor, Color normalColor, int damageTicks, float damage, float fireDuration)
    {
        StopAllCoroutines();
        StartCoroutine(FireDamage(target, burningColor, normalColor, damageTicks, damage, fireDuration));
    }

    public IEnumerator FireDamage(Character target, Color burningColor, Color normalColor, int damageTicks, float damage, float fireDuration)
    {
        target.GetComponent<SpriteRenderer>().color = burningColor;

        target.health -= damage * .6f;

        for (int i = 0; i < damageTicks; i++)
        {
            float ticks = damageTicks;

            target.health -= damage *.4f / ticks;

            if (i == damageTicks - 1)
            {
                target.GetComponent<SpriteRenderer>().color = normalColor;
            }
            else
            {
                yield return new WaitForSeconds(fireDuration / (ticks - 1f));
            }
        }

        Destroy(this);
    }
}
