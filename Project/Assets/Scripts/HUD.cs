using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;
public class HUD : MonoBehaviour
{

    [SerializeField] Image _healthBar = null;
    [SerializeField] Text _webAmmo = null;
    [SerializeField] Image _cooldownBar = null;
    [SerializeField] Image _atackBar = null;
    [SerializeField] Text _escapeText = null;
    [SerializeField] Text _currentAbilityText = null;



    private Health _playerHealth = null;
    private AbilityManager _abilityManager = null;
    

    void Start()
    {
        PlayerCharacter player = FindObjectOfType<PlayerCharacter>();


        if(player != null)
        {
            _playerHealth = player.GetComponent<Health>();
            _abilityManager = player.GetComponent<AbilityManager>();
        }

    }

    void Update()
    {
        SyncData();
    }

    const string ESCAPE_STRING = "ESCAPE!";

    bool _showEscapeText = false;

    public bool ShowEscapeText
    {
        get { return _showEscapeText; }
        set { _showEscapeText = value; }
    }


    void SyncData()
    {
        //health
        if(_healthBar && _playerHealth)
        {
            _healthBar.transform.localScale = new Vector3(_playerHealth.HealthPercentage, 1.0f, 1.0f);

        }

        //web ammo
        if(_webAmmo && _abilityManager)
        {
            _webAmmo.text = _abilityManager.WebAmmo.ToString();
        }


        if(_cooldownBar && _abilityManager)
        {
            _cooldownBar.transform.localScale = new Vector3(_abilityManager.AbilityTimerPercentage, 1.0f, 1.0f);
        }

        if (_atackBar && _abilityManager)
        {
            _atackBar.transform.localScale = new Vector3(_abilityManager.AtackTimerPercentage, 1.0f, 1.0f);
        }

        if(_escapeText && _showEscapeText == true)
        {
            _escapeText.text = ESCAPE_STRING;
        }

       

        if (_currentAbilityText && _abilityManager)
        {
           _currentAbilityText.text = _abilityManager.SelectedAbility.ToString();
        }

    }

}
