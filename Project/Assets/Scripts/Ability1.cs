using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability1 : MonoBehaviour
{
    [SerializeField]
    private float _speed = 30.0f;
    [SerializeField]
    private float _lifeTime = 10.0f;

    const string ENEMY_TAG = "Enemy";

    //This cannot be defined const as it can only apply to a field which is known at compile time. Which is not the case for an array. so doing static readonly

    static readonly string[] RAYCAST_MASK = { "StaticLevel", "DynamicLevel" };


    private void Awake()
    {
        Invoke(KILL_METHODNAME, _lifeTime);
    }

    void FixedUpdate()
    {
        if (!WallDetection()) //move forward until wall hit
        {
            transform.position += transform.forward * Time.deltaTime * _speed;
        }
    }

   

    const string KILL_METHODNAME = "Kill";

    void Kill()
    {
        Destroy(gameObject);
    }


    bool WallDetection()
    {
        //check wall collision
        Ray collisionRay = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(collisionRay, Time.deltaTime * _speed, LayerMask.GetMask(RAYCAST_MASK)))
        {
            Kill();
            return true;
        }
        return false;
    }




    private void OnTriggerEnter(Collider other) 
    {



        //only hit the enemy
        if (other.tag != ENEMY_TAG)
            return;


        //store the enemy hit
        EnemyAntCharacter enemyAntCharacter = other.GetComponent<EnemyAntCharacter>();

        if (enemyAntCharacter == null)
            return;

        //do blind
        enemyAntCharacter.BlindedTimer = 2.0f;
        enemyAntCharacter.IsBlinded = true;
 
        //delete the ability
        Kill();

    }

}

