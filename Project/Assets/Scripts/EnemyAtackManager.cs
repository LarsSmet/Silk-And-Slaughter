using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtackManager : MonoBehaviour
{
    [SerializeField] private GameObject _atackTemplate = null;
     

    [SerializeField] private float _fireRate = 25.0f;
    [SerializeField] private Transform _atackSocket = null;
    private bool _TriggerPulled = false;
    //private int _currentAmmo = 50;
    private float _fireTimer = 0.0f;








    private void Update()
    {
        //handle firetimer
        if (_fireTimer > 0.0f)
        {
            _fireTimer -= Time.deltaTime;
        }

        if (_fireTimer <= 0.0f && _TriggerPulled)
        {

            FireAtack();
        }

        _TriggerPulled = false;

    }

    private void FireAtack()
    {
     

    

        //no atack to fire
        if (_atackTemplate == null)
        {
            return;
        }


        Instantiate(_atackTemplate, _atackSocket.position, _atackSocket.rotation); //create atack



        //set the time so we respect the firerate
        _fireTimer += 1.0f / _fireRate;


    }



    public void Fire()
    {
        _TriggerPulled = true;
    }



}
