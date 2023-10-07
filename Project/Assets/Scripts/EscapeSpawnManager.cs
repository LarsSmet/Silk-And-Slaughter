using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeSpawnManager : MonoBehaviour
{
    #region SINGLETON
    private static EscapeSpawnManager _instance;

    public static EscapeSpawnManager Instance
    {
        get
        {
            if(_instance == null && !_applicationQuitting)
            {
                //find it in case it was placed in the scene
                _instance = FindObjectOfType<EscapeSpawnManager>();
                if(_instance == null)
                {
                    //none was found in the scene, create a new instance
                    GameObject newObject = new GameObject("Singleton_SpawnManager");
                    _instance = newObject.AddComponent<EscapeSpawnManager>();

                }

            }
            return _instance;

        }
    }

    private static bool _applicationQuitting = false;
    public void OnApplicationQuit()
    {
        _applicationQuitting = true;
    }

    private void Awake()
    {
        //we want this object to persist when a scene changes
        DontDestroyOnLoad(gameObject);
        if(_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private List<EscapeSpawnPoint> _spawnPoints = new List<EscapeSpawnPoint>();

    public void RegisterSpawnPoint(EscapeSpawnPoint spawnPoint)
    {
        //add spawnpoints to list
        if (!_spawnPoints.Contains(spawnPoint))
            _spawnPoints.Add(spawnPoint);
    }

    public void UnregisterSpawnPoint(EscapeSpawnPoint spawnPoint)
    {
        //remove spawnpoints from list
        _spawnPoints.Remove(spawnPoint);

    }



    private void Update()
    {
        //remove any objects that are null
        _spawnPoints.RemoveAll(s => s == null);



    }

    public void SpawnWave()
    {
        //spawn each spawnpoint 
        foreach(EscapeSpawnPoint point in _spawnPoints)
        {
            point.Spawn();
        }
    }
}
