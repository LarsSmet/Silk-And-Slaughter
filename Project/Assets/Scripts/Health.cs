using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _startHealth = 10;

    private int _currentHealth = 0;


    const string FRIENDLY_TAG = "Friendly";
    const string ENEMY_TAG = "Enemy";

    [SerializeField] public bool _isQueen = false;

    [SerializeField]
    private Color _flickerCOlor = Color.red;
    [SerializeField]
    private float _flickerDuration = 0.1f;

    private Color _startColor;
    private Material[] _attachedMaterial;

    const string COLOR_PARAMETER = "_Color";

    const string RESET_COLOR_METHOD = "ResetColor";

    public float HealthPercentage
    {
        get
        {
            return ((float)_currentHealth / _startHealth);
        }
    }

    public int currentHealth
    {
        get
        {
            return _currentHealth;
        }
    }

    private void Awake()
    {
        _currentHealth = _startHealth;
    }


    private void Start()
    {
        Renderer[] renderer = transform.GetComponentsInChildren<Renderer>();

        if(renderer == null)
        {
            return;
        }

        int index = 0;
        _attachedMaterial = new Material[renderer.Length];
        foreach (Renderer rendererObj in renderer)
        {
            

            _attachedMaterial[index] = rendererObj.material;
            index++;
        }



        if (_attachedMaterial == null)
            return;

                _startColor = _attachedMaterial[0].GetColor(COLOR_PARAMETER);
        


    }



    public void Damage(int amount)
    {
        _currentHealth -= amount;

        if (_attachedMaterial == null)
            return;

        foreach (Material material in _attachedMaterial)
        {
            material.SetColor(COLOR_PARAMETER, _flickerCOlor);
            Invoke(RESET_COLOR_METHOD, _flickerDuration);
        }


        if (_currentHealth <= 0)
        {
            if (this.tag == ENEMY_TAG)
            {
                

                Kill();
            }
            else if(this.tag == FRIENDLY_TAG)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        } 
    }




    void ResetColor()
    {
        if (_attachedMaterial == null)
            return;

        foreach (Material material in _attachedMaterial)
        {
            material.SetColor(COLOR_PARAMETER, _startColor);
        }
    }


    void Kill()
    {
        if(_isQueen == true)
        {
            HandleIfQueen();
          
        }

        Destroy(gameObject);


    }

    public void IncreaseHealth(int value)
    {
        int increase;

        if (_currentHealth < _startHealth) //if currenthealth is lower than start health(has taken dmg)
        {
            //increase hp with damage taken(can't get more hp than start hp), if damage taken is bigger than the heal value -> heal for the heal value
            increase = _startHealth - _currentHealth;
            if(increase > value) 
            {
                increase = value;
            }

            _currentHealth += value;

        }
        
    }

    private void HandleIfQueen()
    {
        EscapeManager escapeManager = FindObjectOfType<EscapeManager>();
        if (escapeManager == null)
            return;


        
        escapeManager.QueenKilled = true;

    }


    private void OnDestroy()
    {
        if (_attachedMaterial == null)
            return;

        foreach (Material material in _attachedMaterial)
        {
            Destroy(material);
        }
    }

}
