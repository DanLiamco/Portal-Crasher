using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Room Templates", menuName = "Room Templates")]
public class RoomTemplates : ScriptableObject
{
    public GameObject[] topRooms;
    public GameObject[] bottomRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject verticalPath;
    public GameObject horizontalPath;

    public GameObject[] starterRooms;

    public GameObject[] enemySets;

    public GameObject[] bossSets;
}
