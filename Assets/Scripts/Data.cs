using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Data
{

    public static Player player;

    public static UnityEvent onScoreChanged = new UnityEvent();
    public static UnityEvent onHealthChanged = new UnityEvent();
    public static UnityEvent<EnemyBasic> enemySpawned = new UnityEvent<EnemyBasic>();
    public static UnityEvent<EnemyBasic> enemyDestroyed = new UnityEvent<EnemyBasic>();
}
