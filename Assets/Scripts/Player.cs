using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D body;
    float horizontal;
    float vertical;
    public float runSpeed = 10.0f;

    public float playerHealth = 20f;
    public float score = 0f;

    public float GetPlayerHealth()
    {
        return playerHealth;
    }

    public float GetScore()
    {
        return score;
    }

    public void AddScore(EnemyBasic e)
    {
        score++;
        Data.onScoreChanged.Invoke();
    }


    void Awake()
    {
        Data.player = this;
        body = GetComponent<Rigidbody2D>();
        Data.enemyDestroyed.AddListener(AddScore);
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
    public void ChangedHealth(float mnozstvo){
        playerHealth+=mnozstvo;
        Data.onHealthChanged.Invoke();
        if(playerHealth<=0){
            Application.Quit();
        }
    }
    
}
