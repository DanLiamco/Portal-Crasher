using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AI System", menuName = "AI System")]
public class AiSystem : ScriptableObject
{
    public AiMovement movement;
    public AiAttack attack;
}
