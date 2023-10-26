using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject projectilePrefab; // The projectile to shoot
    public float shootForce = 10f; // The force at which the projectile is shot
    public List<Transform> enemies; // List of enemy transforms

    void Start(){
        Data.enemySpawned.AddListener(AddEnemy);
        Data.enemyDestroyed.AddListener(RemoveEnemy);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootAtClosestEnemy();
        }
    }

    void ShootAtClosestEnemy()
    {
        if (enemies.Count == 0)
            return;

        Transform closestEnemy = FindClosestEnemy();
        if (closestEnemy != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Vector3 direction = closestEnemy.position - transform.position;
            projectile.GetComponent<Rigidbody2D>().velocity = direction.normalized * shootForce;
        }
    }

    Transform FindClosestEnemy()
    {
        Transform closest = null;
        float closestDistance = float.MaxValue;

        foreach (Transform enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.position);
            if (distance < closestDistance)
            {
                closest = enemy;
                closestDistance = distance;
            }
        }

        return closest;
    }

    // Method to add an enemy to the enemies list
    public void AddEnemy(EnemyBasic enemyTransform)
    {
        enemies.Add(enemyTransform.gameObject.transform);
    }
    public void RemoveEnemy(EnemyBasic enemyTransform){
        enemies.Remove(enemyTransform.gameObject.transform);
    }
}
