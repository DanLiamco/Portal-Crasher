using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DungeonSpawner : MonoBehaviour
{
    public RoomTemplates roomTemplates;
    public LevelManager levelManager;

    public List<GameObject> rooms;
    public List<GameObject> enemySets;

    public string roomsFolder = "Rooms";

    public float waitTime = 3f;
    bool bossSpawned = false;

    private void Start()
    {
        SpawnDungeon();

        Invoke("SpawnBoss", waitTime);
    }

    public void SpawnDungeon()
    {
        if (roomTemplates.starterRooms.Length == 0)
        {
            return;
        }

        if (levelManager.selectedCharacter)
        {
            GameObject player = levelManager.SpawnPlayer();
        }



        FindObjectOfType<CinemachineVirtualCamera>().Follow = FindObjectOfType<PlayerMovement>().transform;

        GameObject[] starterRooms = roomTemplates.starterRooms;

        int randomRoom = Random.Range(0, starterRooms.Length);

        GameObject room = Instantiate(starterRooms[randomRoom], Vector3.zero, starterRooms[randomRoom].transform.rotation);

        if (GameObject.Find(roomsFolder))
        {
            room.transform.SetParent(GameObject.Find(roomsFolder).transform);
        }
    }

    void SpawnBoss()
    {
        if (bossSpawned == false)
        {
            Destroy(enemySets[enemySets.Count - 1]);

            int randomBoss = Random.Range(0, roomTemplates.bossSets.Length);

            Instantiate(roomTemplates.bossSets[randomBoss], rooms[rooms.Count - 1].transform.position, Quaternion.identity);

            bossSpawned = true;

            FindObjectOfType<Portal>().OnPortalDeath += Win;
            FindObjectOfType<Player>().OnPlayerDeath += Lose;
        } 
    }

    void Win()
    {
        levelManager.Win();
    }

    void Lose()
    {
        levelManager.Lose();
    }
}
