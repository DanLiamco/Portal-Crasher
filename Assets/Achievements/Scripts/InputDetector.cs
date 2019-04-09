using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetector : MonoBehaviour
{
    public delegate void AchievementTrigger();
    public event AchievementTrigger OnInputDetected;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            OnInputDetected();
        }
    }
}
