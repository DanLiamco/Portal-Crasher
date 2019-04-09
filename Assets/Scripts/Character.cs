using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField]
    Text healthText;

    public CharacterStats stats;

    public float health;

    public delegate void Death();

    public GameManager gameManager;

    // Start is called before the first frame update

    public virtual void Awake()
    {
        name = stats.characterName;
        health = stats.maxHealth;
    }

    public virtual void Start()
    {
        if (FindObjectOfType<GameManagerObject>())
        {
            gameManager = FindObjectOfType<GameManagerObject>().gameManager;
        }
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (gameManager.gameIsPaused)
        {
            if (GetComponent<Rigidbody2D>())
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }

            return;
        }

        healthText.text = Mathf.RoundToInt(health).ToString();
    }
}
