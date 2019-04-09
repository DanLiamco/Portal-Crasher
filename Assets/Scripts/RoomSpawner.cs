using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;

    public RoomTemplates roomTemplates;

    public bool spawned = false;

    public string roomsFolder = "Rooms";
    public string enemySetsFolder = "Enemy Sets";

    void Start()
    {
        Invoke("InstantiateRooms", .1f);
    }

    void InstantiateRooms()
    {
        if (spawned == true)
        {
            return;
        }

        GameObject[] roomSelection = new GameObject[0];

        if (openingDirection == 1)
        {
            roomSelection = roomTemplates.bottomRooms;
        }

        else if (openingDirection == 2)
        {
            roomSelection = roomTemplates.leftRooms;
        }

        else if (openingDirection == 3)
        {
            roomSelection = roomTemplates.topRooms;
        }

        else if (openingDirection == 4)
        {
            roomSelection = roomTemplates.rightRooms;
        }

        int randomRoom = Random.Range(0, roomSelection.Length);

        GameObject room = Instantiate(roomSelection[randomRoom], transform.position, roomSelection[randomRoom].transform.rotation);
        FindObjectOfType<DungeonSpawner>().rooms.Add(room);

        if (GameObject.Find(roomsFolder))
        {
            room.transform.SetParent(GameObject.Find(roomsFolder).transform);
        }

        int randomSet = Random.Range(0, roomTemplates.enemySets.Length);

        GameObject enemySet = Instantiate(roomTemplates.enemySets[randomSet], transform.position, roomTemplates.enemySets[randomSet].transform.rotation);
        FindObjectOfType<DungeonSpawner>().enemySets.Add(enemySet);

        if (GameObject.Find(roomsFolder))
        {
            enemySet.transform.SetParent(GameObject.Find(enemySetsFolder).transform);
        }

        spawned = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Spawnpoint" && other.GetComponent<RoomSpawner>().openingDirection == 0)
        {
            Destroy(gameObject);
        }
    }
}
