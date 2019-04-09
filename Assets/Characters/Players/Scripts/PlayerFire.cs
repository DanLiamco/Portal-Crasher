using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject projectileSpawner;

    public AmmoType activeAmmo;
    public KeyBindings keyBindings;

    public float nextFire = 0f;

    void Start()
    {
        activeAmmo.Prep();
    }

    void Update()
    {
        if (GetComponent<Character>().gameManager.gameIsPaused)
        {
            return;
        }

        FireProjectile();
    }

    void FireProjectile()
    {
        if (Input.GetKey(keyBindings.fire1) && Time.time >= nextFire)
        {
            activeAmmo.Fire(projectileSpawner, transform.rotation);
            nextFire = Time.time + activeAmmo.fireRate;
        }
    }
}
