using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerObject : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject pauseScreen;
    public void PauseGame()
    {
        if (gameManager.gameIsPaused == false)
        {
            gameManager.gameIsPaused = true;
            pauseScreen.SetActive(true);
        } else
        {
            pauseScreen.SetActive(false);
            gameManager.gameIsPaused = false;
        }
    }
}
