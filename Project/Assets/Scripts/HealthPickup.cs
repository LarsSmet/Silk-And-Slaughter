using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    const string KILL_METHODNAME = "Kill";

    const int _healthIncrease = 5;

    [SerializeField] private PickupSound _pickupSoundTemplate = null;

    void Kill()
    {
        Destroy(gameObject);
    }

    const string FRIENDLY_TAG = "Friendly";
    



    private void OnTriggerEnter(Collider other)
    {
        //make sure we only hit friendly
        if (other.tag != FRIENDLY_TAG)
            return;

        Debug.Log(other);

        //store the health
        Health health = other.GetComponent<Health>();

        if (health == null)
            return;

        health.IncreaseHealth(_healthIncrease);


       

        Instantiate(_pickupSoundTemplate, transform.position, transform.rotation); //create sound

        Kill();

    }

  
}
