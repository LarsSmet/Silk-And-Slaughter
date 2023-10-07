using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovementBehaviour : MonoBehaviour
{
    [SerializeField]
    protected float _movementSpeed = 5.0f;

    private float _originalMovementSpeed = 5.0f;

    protected Rigidbody _rigidBody;

    protected Vector3 _desiredMovementDirection = Vector3.zero;


    protected Vector3 _desiredLookatPoint = Vector3.zero;

    protected GameObject _target;

    //include the namsespace UnityEngine.AI
    private NavMeshAgent _navMeshAgent;

    private Vector3 _previousTargetPosition = Vector3.zero;

    [SerializeField]
    private float _detectionRadius = 10.0f;

    private bool _isBlinded = false;

    private bool _slowEnemy = false;

    protected void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        

        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _movementSpeed;
        _originalMovementSpeed = _movementSpeed;

        _previousTargetPosition = transform.position;
    }


    protected virtual void FixedUpdate()
    {

        if (_slowEnemy == true) // slow enemy
        {
            ReduceMovementSpeed();
        }
        else if(_slowEnemy == false && _navMeshAgent.speed < _originalMovementSpeed) //increase movement speed until original is restored
        {
            IncreaseMovementSpeed();
        }

     
            HandleMovement();
       


    }

    public GameObject Target
    {
        get { return _target; }
        set { _target = value; }
    }

    const float MOVEMENT_EPSILON = .25f;

    Vector3 offset = new Vector3(1, 0, 1);
    protected void HandleMovement()
    {
      //handle movement

        if (_target == null)
        {
            _navMeshAgent.isStopped = true;
            return;
        }

        if ((transform.position - _target.transform.position).sqrMagnitude < _detectionRadius * _detectionRadius)
        {

            //should the target move we should recalculate our path
            if ((_target.transform.position - _previousTargetPosition).sqrMagnitude
            > MOVEMENT_EPSILON)
            {
                _navMeshAgent.SetDestination(_target.transform.position);
                _navMeshAgent.isStopped = false;
                _previousTargetPosition = _target.transform.position;
              
            }
        }
    }




    public bool IsBlinded
    {
        get { return _isBlinded; }
        set { _isBlinded = value; }
    }

    public void ReduceMovementSpeed()
    {
        if (_movementSpeed > 0)
        {
            _navMeshAgent.speed -= 3.0f * Time.deltaTime;
    
        }
    }

    public void IncreaseMovementSpeed()
    {
        if (_navMeshAgent.speed < _originalMovementSpeed)
        {
            _navMeshAgent.speed += 1.5f * Time.deltaTime;
        }
    }



    public bool SlowEnemy
    {
        get { return _slowEnemy; }
        set { _slowEnemy = value; }

    }

 

}

