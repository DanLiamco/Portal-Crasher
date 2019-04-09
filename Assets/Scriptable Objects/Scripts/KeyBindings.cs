using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Key Bindings", menuName = "Key Bindings")]
public class KeyBindings : ScriptableObject
{
    public KeyCode jump, fire1, fire2, pause;
}
