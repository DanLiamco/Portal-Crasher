using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ranged Attack", menuName = "AI Attacks/Ranged Attack")]
public class RangedAttack : AiAttack
{
    public float damage;
    public float attackRate = .5f;
    public AmmoType ammoType;
    public float maxRange = 4f;

    public override void Attack(GameObject target, Enemy attacker)
    {
        float distance = Vector2.Distance(attacker.transform.position, target.transform.position);

        if (Time.time >= attacker.nextAttack && distance <= maxRange)
        {
            Vector3 offset = (target.transform.position - attacker.transform.position);
            float zRotation = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            Vector3 newRotation = new Vector3 (0f, 0f, zRotation);
            ammoType.Fire(attacker.gameObject, Quaternion.Euler(newRotation));
            attacker.nextAttack = Time.time + attackRate;
        }
    }
}
