using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability3SlowZone : MonoBehaviour
{
    float _lifeTime = 10.0f;

    public List<EnemyMovementBehaviour> _enemyMovementBehaviours;

    const string KILL_METHODNAME = "Kill";
    const string ENEMY_TAG = "Enemy";

    private void Awake()
    {
        Invoke(KILL_METHODNAME, _lifeTime);
    }



    void Kill()
    {
        //for each enemy that was inside slowzone, unslow them
        foreach(EnemyMovementBehaviour enemyBehaviour in _enemyMovementBehaviours)
        {
            enemyBehaviour.SlowEnemy = false;
        }
        Destroy(gameObject);
    }

   


    private void OnTriggerEnter(Collider other)
    {
        //only hit enemy
        if (other.tag != ENEMY_TAG)
            return;

        
        //store enemy movement behaviour
        EnemyMovementBehaviour temp = other.GetComponent<EnemyMovementBehaviour>();


        if (temp == null)
            return;

        //add to the list
        _enemyMovementBehaviours.Add(temp);


        //slow enemy
        temp.SlowEnemy = true;


        
    }

    private void OnTriggerExit(Collider other)
    {
       //if enemy leaves

        if (other.tag != ENEMY_TAG)
            return;

        //store enemy
        EnemyMovementBehaviour temp = other.GetComponent<EnemyMovementBehaviour>();

        if (temp == null)
            return;

        //remove from the list
        _enemyMovementBehaviours.Remove(temp);

        //unslow enemy
        temp.SlowEnemy = false;



    }



}
