using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggs : MonoBehaviour
{

    EscapeManager _escapeManager = null;



    Health _health;

    private void Awake()
    {
        //store 
        _escapeManager = FindObjectOfType<EscapeManager>();
       _health = GetComponent<Health>();
    }

    private void Update()
    {
        if (_health == null)
            return;
        if(_health.currentHealth <= 0) 
        {
            Kill();
        }
    }
    


    const string KILL_METHOD = "Kill";

    void Kill()
    {
      
        //remove egg from escapemanager
   
            if (_escapeManager == null)
                return;
            _escapeManager.RemoveEgg();
       
            Destroy(gameObject);
        
    }

    


}
