using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

     void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("wall")){
            Destroy(gameObject);
        }
        if(col.gameObject.CompareTag("enemy")){
            Destroy(gameObject);
        }
    }
}
