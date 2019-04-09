using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityExecutor : MonoBehaviour
{
    public KeyBindings keyBindings;
    public CharacterAbilities abilitySystem;

    void Update()
    {
        if (GetComponent<Character>().gameManager.gameIsPaused)
        {
            return;
        }

        UseAbility();
    }

    void UseAbility()
    {
        if (Input.GetKeyDown(keyBindings.fire2))
        {
            abilitySystem.abilities[0].Activate(GetComponent<Character>());
        }
    }
}
