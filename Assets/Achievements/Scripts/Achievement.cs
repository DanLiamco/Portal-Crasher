using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement : ScriptableObject
{
    public bool achievementUnlocked = false;

    public string title;
    public string description;

    public AchievementManager achievementManager;

    public virtual void AddAchievementOnStart()
    {

    }

    public virtual void AddAchievementOnLoad()
    {

    }

    public virtual void RegisterEnemy(Enemy enemy)
    {

    }

    public void ChangeText(string title, string description)
    {
        achievementManager.ChangeText(title, description);
    }

    public virtual void ResetAchievement()
    {
        achievementUnlocked = false;
    }
}
