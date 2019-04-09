using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public AiSystem aiSystem;
    public float moveSpeed;
    public float nextAttack = 0f;
    public bool enemyActivated = false;
    public event Death OnEnemyDeath;

    public override void Awake()
    {
        base.Awake();
        moveSpeed = stats.defaultMoveSpeed;
    }

    public override void Start()
    {
        base.Start();

        if (FindObjectOfType<AchievementManager>())
        {
            FindObjectOfType<AchievementManager>().RegisterEnemy(this);
        }
    }

    public override void Update()
    {
        if (gameManager.gameIsPaused)
        {
            if (GetComponent<Rigidbody2D>())
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }

            return;
        }

        if (health <= 0f)
        {
            gameObject.SetActive(false);

            if (OnEnemyDeath !=  null)
            {
                OnEnemyDeath();
            }
        }

        base.Update();

        if (!enemyActivated)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }

        aiSystem.movement.Move(moveSpeed, GetComponent<Rigidbody2D>(), FindObjectOfType<PlayerMovement>().gameObject);
    }
}
