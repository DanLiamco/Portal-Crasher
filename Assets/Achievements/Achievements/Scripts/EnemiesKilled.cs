using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Enemies Killed", menuName = "Achievements/Enemies Killed")]
public class EnemiesKilled : Achievement
{
    public float targetEnemiesKilled = 10f;
    public float enemiesKilled;

    public override void RegisterEnemy(Enemy enemy)
    {
        if (achievementUnlocked == false)
        {
            enemy.OnEnemyDeath += CheckAchievement;
        }
    }

    void CheckAchievement()
    {
        enemiesKilled++;

        if (enemiesKilled >= targetEnemiesKilled && achievementUnlocked == false)
        {
            achievementUnlocked = true;
            ChangeText(title, description);
            achievementManager.GetComponent<Animator>().SetTrigger("Show Achievement");
        }
    }

    public override void ResetAchievement()
    {
        enemiesKilled = 0f;
        base.ResetAchievement();
    }
}
