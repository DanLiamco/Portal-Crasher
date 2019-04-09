using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Abilities", menuName = "New Character Abilities")]
public class CharacterAbilities : ScriptableObject
{
    public Ability[] abilities;
}
