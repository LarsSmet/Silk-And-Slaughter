using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    [SerializeField]
    private float _speed = 30.0f;
    [SerializeField]
    private float _lifeTime = 1.0f;
    [SerializeField]
    private int _damage = 5;


    private void Awake()
    {
        Invoke(KILL_METHODNAME, _lifeTime);
    }

    void FixedUpdate()
    {
       
        transform.position += transform.forward * Time.deltaTime * _speed;
   
    }



    const string KILL_METHODNAME = "Kill";

    void Kill()
    {
        Destroy(gameObject);
    }

    const string FRIENDLY_TAG = "Friendly";
    const string ENEMY_TAG = "Enemy";
    const string DESTRUCTABLE_TAG = "Destructable";

    private void OnTriggerEnter(Collider other)
    {
        //make sure we only hit friendly, enemies or destructables
        if (other.tag != FRIENDLY_TAG && other.tag != ENEMY_TAG && other.tag != DESTRUCTABLE_TAG)
            return;

        //if player -> can only hit enemy or destructable
        if (this.tag == FRIENDLY_TAG && (other.tag != ENEMY_TAG && other.tag != DESTRUCTABLE_TAG))
            return;


        //if enemy, can only hit player
        if (this.tag == ENEMY_TAG && other.tag != FRIENDLY_TAG)
            return;


        //get health from other, damage if it has health

        Health otherHealth = other.GetComponent<Health>();

        if (otherHealth != null)
        {
            otherHealth.Damage(_damage);
          
            Kill();
        }

    }

}
