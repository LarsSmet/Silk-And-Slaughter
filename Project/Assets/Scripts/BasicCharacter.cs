using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCharacter : MonoBehaviour
{
  

    protected AbilityManager _abilityManager;
    protected MovementBehaviour _movementBehaviour;

    
     protected virtual void Awake()
    {
        //store components
        _abilityManager = GetComponent<AbilityManager>();
        _movementBehaviour = GetComponent<MovementBehaviour>();
    }
}
