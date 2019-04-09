using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Achievement Tracker", menuName = "Achievement Tracker")]
public class AchievementTracker : ScriptableObject
{
    public Achievement[] achievements;
}
