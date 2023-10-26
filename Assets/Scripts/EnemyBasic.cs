using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBasic : MonoBehaviour
{

    public float moveSpeed;
    private float distance; 


    public float damage;

    void Start(){
        Data.enemySpawned.Invoke(this);

    }
    void Update(){

        //distance =Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = Data.player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        transform.position = Vector2.MoveTowards(this.transform.position, Data.player.transform.position, moveSpeed*Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Player")
        {
            col.gameObject.GetComponent<Player>().ChangedHealth(-damage);
            Data.enemyDestroyed.Invoke(this);
            Destroy(gameObject);
            
        }
        if(col.gameObject.CompareTag("projectile")){
            Data.enemyDestroyed.Invoke(this);
            Destroy(gameObject);
        }
    }
}