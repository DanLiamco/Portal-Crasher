using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Manager", menuName = "Managers/Game Manager")]
public class GameManager : ScriptableObject
{
    public bool gameIsPaused = false;
    private void OnEnable()
    {
        gameIsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
