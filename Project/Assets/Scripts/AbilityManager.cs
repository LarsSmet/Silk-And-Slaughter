using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] private GameObject _ability1Template = null;
    [SerializeField] private GameObject _ability2Template = null;
    [SerializeField] private GameObject _ability3Template = null;


    [SerializeField] private int _clipSize = 50;
    [SerializeField] private float _fireRate = 0.3f;
    [SerializeField] private Transform _fireSocket = null;
    private bool _TriggetPulled = false;
    private int _currentAmmo = 50; //ammo are webs
    private float _fireTimer = 0.0f;

    //ATACK
    [SerializeField] private GameObject _atackTemplate = null;
    [SerializeField] private float _atackRate = 25.0f;
    //use fire socket from ability because it is the same
    private bool _atackTriggerPulled = false;
    private float _atackTimer = 0.0f;

    public Ability _selectedAbility;

    [SerializeField] private AudioSource _atackSound = null;
    [SerializeField] private AudioSource _abilitySound = null;



    public int WebAmmo
    {
        get
        {
            return _currentAmmo;
        }
    }

    public float AbilityTimerPercentage //handle HUD AbilityCooldown
    {
        get
        {

            if (_fireTimer <= 0)
            {
                return 1;
            }
            else
            {

                return (_fireTimer / (1.0f / _fireRate));

            }
        }
    }


    public float AtackTimerPercentage //Handle HUD atackcooldown
    {
        get
        {
            if (_atackTimer <= 0)
            {
                return 1;
            }
            else
            {

                return (_atackTimer / (1.0f / _atackRate));

            }
        }



    }


    public enum Ability : int //all the abilities
    {
        Ability1 = 1,
        Ability2 = 2,
        Ability3 = 3
            

    };



    private void Awake()
    {
   
        _currentAmmo = _clipSize;
        
    }


    public int SelectedAbility
    {
   

        get { return (int)_selectedAbility; }
        set { _selectedAbility = (Ability)value; }
    }


    private void Update()
    {
        //handle fireTimer
        if (_fireTimer > 0.0f)
        {
            _fireTimer -= Time.deltaTime;
        }

        if (_fireTimer <= 0.0f && _TriggetPulled)
        {
            _fireTimer = 0;

            FireAbility();
        }

       
        _TriggetPulled = false;

        //handle atackTimer

        if (_atackTimer > 0.0f)
        {
            _atackTimer -= Time.deltaTime;
        }

        if(_atackTimer <= 0.0f && _atackTriggerPulled)
        {
            FireAtack();
        }

        _atackTriggerPulled = false;

    }

    private void FireAbility()
    {
        //no ammo, we can't fire 
        if (_currentAmmo <= 0)
        {
            return;
        }


        //fire ability depending on which one it is
        switch (_selectedAbility)
        {
            case Ability.Ability1:

                //no ability1 to fire 
                if (_ability1Template == null)
                {
                    return;
                }

                //consume a bullet
                --_currentAmmo;


                Instantiate(_ability1Template, _fireSocket.position, _fireSocket.rotation);

                break;

            case Ability.Ability2:

                //no ability2 to fire 
                if (_ability2Template == null)
                {
                    return;
                }

                //consume a bullet
                --_currentAmmo;


                Instantiate(_ability2Template, _fireSocket.position, _fireSocket.rotation);




                break;

            case Ability.Ability3:

                //Ability3 takes 3 webs
                if (_currentAmmo <= 2)
                {
                    return;
                }

                //no ability3 to fire 
                if (_ability3Template == null)
                {
                    return;
                }

                //consume a 
                _currentAmmo -= 3;


                Instantiate(_ability3Template, _fireSocket.position, _fireSocket.rotation);




                break;

              

        }


       

        //set the time so we respect the firerate
        _fireTimer += 1.0f / _fireRate;

        if (_abilitySound)
            _abilitySound.Play();

    }




    public void Fire()
    {
        _TriggetPulled = true;
    }



    private void FireAtack()
    {
        //no atack to fire 
        if (_atackTemplate == null)
        {
            return;
        }

    

        Instantiate(_atackTemplate, _fireSocket.position, _fireSocket.rotation); //create atack

        //set the time so we respect the atackrate
        _atackTimer += 1.0f / _atackRate;


        if (_atackSound)
            _atackSound.Play();
    }



    public void Atack()
    {
         _atackTriggerPulled = true;
    }

    public void IncreaseWebAmmo(int ammount)
    {
        _currentAmmo += ammount;
    }

}
