using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAntCharacter : BasicEnemyCharacter
{
    private GameObject _playerTarget = null;

    [SerializeField]
    private float _attackRange = 2.0f;

   

    [SerializeField]
    private Material _antMaterial;
    [SerializeField]
    private Material _webMaterial = null;



    private Color _startColor;
    private Material _attachedMaterial;

    private bool _isBlinded = false;
    private float _blindedTimer = 0.0f;

    const string COLOR_PARAMETER = "_Color";

    private void Start()
    {
      


        //find the player and store it
        PlayerCharacter player = FindObjectOfType<PlayerCharacter>();


        if (player) _playerTarget = player.gameObject;


        //change color when blinded
        Renderer renderer = transform.GetComponentInChildren<Renderer>();

        
        if (renderer == null)
             return;

        //store color material
        _attachedMaterial = renderer.material;

        if (_attachedMaterial == null)
            return;

        _startColor = _attachedMaterial.GetColor(COLOR_PARAMETER);



    }

    private void Update()
    {
   
            HandleMovement();

        if (_isBlinded == false) //if not blinded, atack player
        {
            HandleAttacking();
           
        }
        else
        {
            //do blind
            _attachedMaterial.SetColor(COLOR_PARAMETER, _webMaterial.color );

            //handle timer
            if (_blindedTimer > 0.0f)
            {
                _blindedTimer -= Time.deltaTime;
             
                
            }

            if (_blindedTimer <= 0.0f)
            {
                _isBlinded = false;

                //change color back to start after blind is over
                _attachedMaterial.SetColor(COLOR_PARAMETER, _startColor);
            }

        }
        
    }

   

    void HandleMovement()
    {
        if (_enemyMovementBehaviour == null)
            return;

        if (_isBlinded == false) // if not blinded, move
        {
            _enemyMovementBehaviour.Target = _playerTarget;
        }
        else
        {
            _enemyMovementBehaviour.Target = null;
        }
    }

    void HandleAttacking()
    {

        if (_enemyAtackManager == null) return;

        if (_playerTarget == null) return;

        //if we are in range of the player fire our atack
      
        if ((transform.position - _playerTarget.transform.position).sqrMagnitude
            < _attackRange * _attackRange)
        {
            _enemyAtackManager.Fire();

           
        }

    }




    public bool IsBlinded
    {
        get { return _isBlinded; }
        set { _isBlinded = value; }
    }



    public float BlindedTimer
    {
        get { return _blindedTimer; }
        set { _blindedTimer = value; }
    }


    private void OnDestroy()
    {
        //destroy material after the enemy died for memory purposes
        if (_attachedMaterial == null)
            return;

        
            Destroy(_attachedMaterial);
        
    }


}
