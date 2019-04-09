using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Melee Attack", menuName = "AI Attacks/Melee Attack")]
public class MeleeAttack : AiAttack
{
    public float damage = 10f;
    public float attackRate = .5f;

    public override void Attack(GameObject target, Enemy attacker)
    {
        if (Time.time >= attacker.nextAttack)
        {
            target.GetComponent<Character>().health -= damage;
            attacker.nextAttack = Time.time + attackRate;
        }      
    }
}
