using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSound : MonoBehaviour
{

    [SerializeField] AudioSource _pickupSound = null;

    void Awake()
    {
        //play sound
        if (_pickupSound)
            _pickupSound.Play();

    }

    
    void Update()
    {
        if(_pickupSound.isPlaying == false) //destroy when done playing
        {
            Destroy(gameObject);
        }
    }


}
