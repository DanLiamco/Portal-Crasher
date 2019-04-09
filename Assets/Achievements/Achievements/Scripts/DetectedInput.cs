using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Input Detected", menuName = "Achievements/Input Detected")]
public class DetectedInput : Achievement
{
    InputDetector inputDetector;

    public override void AddAchievementOnStart()
    {
        if (achievementUnlocked == false)
        { 
            inputDetector = new GameObject().AddComponent<InputDetector>();
            inputDetector.OnInputDetected += CheckAchievement;
        }
    }

    void CheckAchievement()
    {
        if (achievementUnlocked == false)
        {
            achievementUnlocked = true;
            ChangeText(title, description);
            achievementManager.GetComponent<Animator>().SetTrigger("Show Achievement");
            Destroy(inputDetector.gameObject);
        }
    }

    public override void ResetAchievement()
    {
        base.ResetAchievement();
    }
}
