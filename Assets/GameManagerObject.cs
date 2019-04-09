using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerObject : MonoBehaviour
{
    public GameManager gameManager;

    public void PauseGame()
    {
        if (gameManager.gameIsPaused == false)
        {
            gameManager.gameIsPaused = true;
        } else
        {
            gameManager.gameIsPaused = false;
        }
    }
}
