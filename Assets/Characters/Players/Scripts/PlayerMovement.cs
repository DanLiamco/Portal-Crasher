using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterStats stats;
    public KeyBindings keyBindings;
    GameManager gameManager;

    public float moveSpeed;

    Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        moveSpeed = stats.defaultMoveSpeed;
    }

    private void Start()
    {
        if (FindObjectOfType<GameManagerObject>())
        {
            gameManager = FindObjectOfType<GameManagerObject>().gameManager;
        }
    }

    void FixedUpdate()
    {
        PauseGame();

        if (gameManager.gameIsPaused)
        {
            return;
        }

        ProcessMovement();
    }

    void ProcessMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        rigidBody.velocity = new Vector2(horizontalMovement * moveSpeed, verticalMovement * moveSpeed);
    }

    void PauseGame()
    {
        if (Input.GetKeyDown(keyBindings.pause))
        {
            FindObjectOfType<GameManagerObject>().PauseGame();
        }
    }
}
