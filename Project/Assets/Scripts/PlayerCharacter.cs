using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : BasicCharacter
{
    const string MOVEMENT_HORIZONTAL = "MovementHorizontal";
    const string MOVEMENT_VERTICAL = "MovementVertical";

    const string ABILITY_1 = "Ability1";
    const string ABILITY_2 = "Ability2";
    const string ABILITY_3 = "Ability3";



    const string GROUND_LAYER = "Ground";
    const string PRIMARY_FIRE = "PrimaryFire";
    const string SECONDARY_FIRE = "SecondaryFire";
    const string RELOAD = "Reload";

    private Plane _cursorMovementPlane;

    //rotation
    const string MOUSEX = "Mouse X";
    const string MOUSEY = "Mouse Y";

    [SerializeField]
    private float _sensivityX = 100.0f;
    [SerializeField]
    private float _sensivityY = 100.0f;

    float _mouseX;
    float _mouseY;

    float _multiplier = 0.01f;



    protected override void Awake()
    {
        base.Awake();
        _cursorMovementPlane = new Plane(Vector3.up, transform.position);
        _movementBehaviour.RotationY = transform.rotation.eulerAngles.y;
    }
    private void Update()
    {
        HandleMovementInput();
        HandleFireInput();
    }

    void HandleMovementInput()
    {
        if (_movementBehaviour == null) 
            return;

        //movement
        float horizontalMovement = Input.GetAxis(MOVEMENT_HORIZONTAL);
        float verticalMovement = Input.GetAxis(MOVEMENT_VERTICAL);

        Vector3 movement = transform.forward * verticalMovement + transform.right * horizontalMovement;


     

        _movementBehaviour.DesiredMovementDirection = movement;

        //rotation
        _mouseX = Input.GetAxis(MOUSEX);
        _mouseY = Input.GetAxis(MOUSEY);

        _movementBehaviour.RotationY += _mouseX * _sensivityX * _multiplier;
        _movementBehaviour.RotationX -= _mouseY * _sensivityY * _multiplier;

     




    }

    void HandleFireInput() //handle ability input -> select which ability
    {
        if (_abilityManager == null) return;

        if (Input.GetAxis(ABILITY_1) > 0.0f)
            _abilityManager.SelectedAbility = 1;

        if (Input.GetAxis(ABILITY_2) > 0.0f)
            _abilityManager.SelectedAbility = 2;

        if (Input.GetAxis(ABILITY_3) > 0.0f)
            _abilityManager.SelectedAbility = 3;

        if (Input.GetAxis(PRIMARY_FIRE) > 0.0f)
            _abilityManager.Atack();


        if (Input.GetAxis(SECONDARY_FIRE) > 0.0f)
            _abilityManager.Fire();

        
    }

}
