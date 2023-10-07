using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyCharacter : MonoBehaviour
{
    

    protected EnemyMovementBehaviour _enemyMovementBehaviour;
    protected EnemyAtackManager _enemyAtackManager;

    protected virtual void Awake()
    {
        //store components
        _enemyMovementBehaviour = GetComponent<EnemyMovementBehaviour>();
        _enemyAtackManager = GetComponent<EnemyAtackManager>();
    }
}
