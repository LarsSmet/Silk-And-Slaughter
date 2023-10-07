using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAtack : MonoBehaviour
{
    [SerializeField]
    private float _speed = 30.0f;
    [SerializeField]
    private float _lifeTime = 1.0f;
    [SerializeField]
    private int _damage = 5;

    const string KILL_METHODNAME = "Kill";

    const string FRIENDLY_TAG = "Friendly";
    const string ENEMY_TAG = "Enemy";


    private void Awake()
    {
        Invoke(KILL_METHODNAME, _lifeTime);
    }

    void FixedUpdate()
    {
       //movement of atack
        transform.position += transform.forward * Time.deltaTime * _speed;
       
    }



  

    void Kill()
    {
        Destroy(gameObject);
    }



    private void OnTriggerEnter(Collider other)
    {
        //make sure we only hit friendly or enemies
        if (other.tag != FRIENDLY_TAG && other.tag != ENEMY_TAG)
            return;

        //only hit the opposing team
        if (other.tag == tag)
            return;

     
        //get health from enemy hit

        Health otherHealth = other.GetComponent<Health>();

        if (otherHealth != null)
        {
            //if enemy has health, damage enemy
            otherHealth.Damage(_damage);

            Kill();
        }

    }

}
