using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawner : MonoBehaviour
{
    public int openingDirection;

    public RoomTemplates roomTemplates;

    public bool spawned = false;

    public string pathsFolder = "Paths";

    void Start()
    {
        Invoke("InstantiatePaths", .2f);
    }

    void Update()
    {
        InstantiatePaths();
    }

    void InstantiatePaths()
    {
        if (spawned == true)
        {
            return;
        }

        GameObject pathPrefab = roomTemplates.verticalPath;

        if (openingDirection == 1 || openingDirection == 3)
        {
            pathPrefab = roomTemplates.verticalPath;
        }

        else if (openingDirection == 2 || openingDirection == 4)
        {
            pathPrefab = roomTemplates.horizontalPath;
        }

        GameObject path = Instantiate(pathPrefab, transform.position, pathPrefab.transform.rotation);

        if (GameObject.Find(pathsFolder))
        {
            path.transform.SetParent(GameObject.Find(pathsFolder).transform);
        }

        spawned = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Spawnpoint" && other.GetComponent<PathSpawner>().openingDirection == 0)
        {
            Destroy(gameObject);
        }
    }
}

