using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public float changeTolerance = 1f;

    void Update()
    {
        if (GetComponent<Character>().gameManager.gameIsPaused)
        {
            return;
        }

        ProcessRotation();
    }

    void ProcessRotation()
    {
        if (Mathf.Abs(Input.GetAxis("Mouse X")) < changeTolerance && Mathf.Abs(Input.GetAxis("Mouse Y")) < changeTolerance)
        {
            return;
        }

        Vector2 mousePos;
        Vector2 targetPos;
        float angle;

        // Position of the mouse pointer
        mousePos = Input.mousePosition;
        // Position of Weapons Gameobject on the screen
        targetPos = Camera.main.WorldToScreenPoint(transform.position);

        // Get difference of distance between mouse and Weapon Gameobject
        float offsetX = mousePos.x - targetPos.x;
        float offsetY = mousePos.y - targetPos.y;

        //Set rotation based on mouse position
        angle = Mathf.Atan2(offsetY, offsetX) * Mathf.Rad2Deg;
        Vector3 newAngle = new Vector3(0f, 0f, angle);
        transform.rotation = Quaternion.Euler(newAngle);
    }
}
