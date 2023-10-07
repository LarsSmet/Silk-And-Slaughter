using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeSpawnPoint : MonoBehaviour
{
 [SerializeField]
    private GameObject SpawnTemplate = null;

    private void OnEnable()
    {
        //register spawnpoint
        EscapeSpawnManager.Instance.RegisterSpawnPoint(this);
    }

    private void OnDisable()
    {
        //unregister spawnpoint
        EscapeSpawnManager.Instance.UnregisterSpawnPoint(this);
    }

    public GameObject Spawn()
    {
        //instantiate spawnpoint
        return Instantiate(SpawnTemplate, transform.position, transform.rotation); 
    }
}

