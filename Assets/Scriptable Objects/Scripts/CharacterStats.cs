using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Character Stats", menuName = "New Character Stats")]
public class CharacterStats : ScriptableObject
{
    public string characterName;
    public string characterDescription;

    public float maxHealth;

    public float defaultMoveSpeed;
}
