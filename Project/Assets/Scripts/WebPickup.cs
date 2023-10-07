using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebPickup : MonoBehaviour
{
    const string KILL_METHODNAME = "Kill";

    const int _ammoIncrease = 3;

    [SerializeField] private PickupSound _pickupSoundTemplate = null;

    void Kill()
    {
   
        Destroy(gameObject);
    }

    const string FRIENDLY_TAG = "Friendly";
    const string ENEMY_TAG = "Enemy";

    private void OnTriggerEnter(Collider other)
    {
        //make sure we only hit friendly 
        if (other.tag != FRIENDLY_TAG)
            return;

        Debug.Log(other);

        //store the abilitymanager
        AbilityManager abilityManager = other.GetComponent<AbilityManager>();

        if (abilityManager == null)
            return;

        

        abilityManager.IncreaseWebAmmo(_ammoIncrease);

        Instantiate(_pickupSoundTemplate, transform.position, transform.rotation);
        Kill();

    }

      

}
