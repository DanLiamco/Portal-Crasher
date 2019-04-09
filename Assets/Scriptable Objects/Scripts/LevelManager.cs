using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Level Manager", menuName = "Managers/Level Manager")]
public class LevelManager : ScriptableObject
{
    public GameObject selectedCharacter;
    public string gameScene;

    private void OnEnable()
    {
        selectedCharacter = null;
    }

    public void LoadNextScene()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void SelectCharacter(GameObject character)
    {
        selectedCharacter = character;
    }

    public GameObject SpawnPlayer()
    {
       return Instantiate(selectedCharacter, Vector3.zero, Quaternion.identity);
    }

    public void StartGame()
    {
        if (selectedCharacter)
        SceneManager.LoadScene(gameScene);
    }

    public void Win()
    {
        LoadScene("Win Screen");
    }

    public void Lose()
    {
        LoadScene("Lose Screen");
    }
}
