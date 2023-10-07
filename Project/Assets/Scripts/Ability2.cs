using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability2 : MonoBehaviour
{
    [SerializeField]
    private float _speed = 50.0f;
    [SerializeField]
    private float _lifeTime = 10.0f;

  

    [SerializeField]
    private GameObject _webMarker = null;

    const string KILL_METHODNAME = "Kill";

    //This cannot be defined const as it can only apply to a field which is known at compile time. Which is not the case for an array. so doing static readonly
    static readonly string[] RAYCAST_MASK = { "StaticLevel", "DynamicLevel" };

    private void Awake()
    {
        Invoke(KILL_METHODNAME, _lifeTime);
    }

    void FixedUpdate()
    {
        if (!WallDetection()) //move forward until wall is hit
        {
            transform.position += transform.forward * Time.deltaTime * _speed;
        }
    }

  

    bool WallDetection() 
    {
        //check wall collision
        Ray collisionRay = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(collisionRay, Time.deltaTime * _speed, LayerMask.GetMask(RAYCAST_MASK)))
        {
            Instantiate(_webMarker, transform.position, transform.rotation); //create the webmarker

            Kill();
            return true;
        }
        return false;
    }



    void Kill()
    {
        Destroy(gameObject);
    }




}
