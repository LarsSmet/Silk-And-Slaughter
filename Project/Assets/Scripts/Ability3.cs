using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability3 : MonoBehaviour
{
    [SerializeField]
    private float _speed = 30.0f;
    [SerializeField]
    private float _lifeTime = 10.0f;
    [SerializeField]
    private Ability3SlowZone _ability3SlowZoneTemplate = null;

    const string RAYCAST_FLOORMASK = "Ground";
    const string KILL_METHODNAME = "Kill";

    private void Awake()
    {
        Invoke(KILL_METHODNAME, _lifeTime);
    }

    void FixedUpdate()
    {
        //while ground isn't hit, keep moving
        if (!GroundDetection())
        {
            transform.position += transform.forward * Time.deltaTime * _speed;
        }
    }





    void Kill()
    {
        Destroy(gameObject);
    }

 

    bool GroundDetection() 
    {
        //check ground collision

        Ray collisionRay = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(collisionRay, Time.deltaTime * _speed, LayerMask.GetMask(RAYCAST_FLOORMASK)))
        {
            Instantiate(_ability3SlowZoneTemplate, transform.position, Quaternion.identity); //create slow area
            Kill();
            return true;
        }
        return false;

    }


}
