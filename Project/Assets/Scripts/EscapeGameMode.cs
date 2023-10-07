using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeGameMode : MonoBehaviour
{
   [SerializeField]
    private float _firstWaveStart = 5.0f;
    [SerializeField]
    private float _waveStartFrequency = 15.0f;
    [SerializeField]
    private float _waveEndFrequency = 7.0f;
    [SerializeField]
    private float _waveFrequencyIncrement = 0.5f;

    private float _CurrentFrequency = 0.0f;

    const string STARTNEWWAVE_METHOD = "StartNewWave";

    private void Awake()
    {
        _CurrentFrequency = _waveStartFrequency;

        Invoke(STARTNEWWAVE_METHOD, _firstWaveStart); //start first wave

        
    }
  

    void StartNewWave()
    {
        //increase the spawnspeed
        EscapeSpawnManager.Instance.SpawnWave(); 
        _CurrentFrequency = Mathf.Clamp(_CurrentFrequency - _waveFrequencyIncrement,
            _waveEndFrequency, _waveStartFrequency);

        Invoke(STARTNEWWAVE_METHOD, _firstWaveStart); // keep spawning new waves
    }
       
}
