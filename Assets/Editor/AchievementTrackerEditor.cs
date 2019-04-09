using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AchievementTracker), true)]
public class AchievementTrackerEditor : Editor
{
    AchievementTracker achievementTracker;

    private void OnEnable()
    {
        achievementTracker = ((AchievementTracker)target);
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);

        if (GUILayout.Button("Reset Achievements"))
        {
            foreach (Achievement achievement in achievementTracker.achievements)
            {
                achievement.ResetAchievement();
            }
        }

        EditorGUI.EndDisabledGroup();
    }
}
