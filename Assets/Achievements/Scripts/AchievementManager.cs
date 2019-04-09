using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public AchievementTracker achievementTracker;

    public Text achievementTitle;
    public Text achievementDescription;

    private void Awake()
    {
        int numAchievementManagers = FindObjectsOfType<AchievementManager>().Length;

        if (numAchievementManagers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        foreach (Achievement achievement in achievementTracker.achievements)
        {
            achievement.AddAchievementOnStart();
            achievement.achievementManager = this;
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        foreach (Achievement achievement in achievementTracker.achievements)
        {
            achievement.AddAchievementOnLoad();
        }
    }

    public void RegisterEnemy(Enemy enemy)
    {
        foreach (Achievement achievement in achievementTracker.achievements)
        {
            achievement.RegisterEnemy(enemy);
        }
    }

    public void ChangeText(string title, string description)
    {
        achievementTitle.text = "Unlocked " + "\"" + title + "\"";
        achievementDescription.text = description;
    }
}
