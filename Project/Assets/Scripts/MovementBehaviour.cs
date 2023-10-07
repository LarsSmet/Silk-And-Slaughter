using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    [SerializeField]
    protected float _movementSpeed = 1.0f;

    protected Rigidbody _rigidBody;

    protected Vector3 _desiredMovementDirection = Vector3.zero;

    Camera _cam;

    public Vector3 DesiredMovementDirection
    {
        get { return _desiredMovementDirection; }
        set { _desiredMovementDirection = value; }
    }

    protected Vector3 _desiredLookatPoint = Vector3.zero;
    
    public Vector3 DesiredLookAtPoint
    {
        get { return _desiredLookatPoint; }
        set { _desiredLookatPoint = value; }
    }

    protected GameObject _target;

    public GameObject Target
    {
        get { return _target; }
        set { _target = value;  }
    }

    protected float _rotationX;
    public float RotationX
    {
        get { return _rotationX; }
        set { _rotationX = value; }
    }

    protected float _rotationY;
    public float RotationY
    {
        get { return _rotationY; }
        set { _rotationY = value; }
    }

    protected virtual void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _cam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    protected virtual void Update()
    {
        HandleRotation();


    }
    protected virtual void FixedUpdate()
    {
        HandleMovement();

    }

    protected virtual void HandleMovement()
    {
        Vector3 movement = _desiredMovementDirection.normalized;
        movement *= _movementSpeed;
       
        _rigidBody.velocity = movement;
    }

    protected virtual void HandleRotation()
    {
        _cam.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
        transform.rotation = Quaternion.Euler(0, _rotationY, 0);

        _rotationX = Mathf.Clamp(_rotationX, -90.0f, 90.0f);
    }
}
