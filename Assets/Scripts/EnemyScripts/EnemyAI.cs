using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyAI : MonoBehaviour,IDamagable
{
    private enum EnemyState
    {
        Idle,
        Chase,
        Attack
    }

    [SerializeField] CharacterController _character;
    [SerializeField] float _speed;
    private float _yVelocity;
    [SerializeField]private float _gravity;
    [SerializeField] private Transform _target;
    private Vector3 _velocity;
    [SerializeField] private int _health;
    [SerializeField] EnemyState _currentState = EnemyState.Chase;
    

    public int Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    // Update is called once per frame
    void Update()
    {
        if (_currentState==EnemyState.Chase) 
           Movement();
          

        if (_health<=0)
        {
            Destroy(gameObject);
        }

       // switch (_currentState)happy with current system 
      //  {
      //      case EnemyState.Attack:
       //         break;
     //   }
    }

    private void Movement()
    {
        if (_character.isGrounded==true)
        {
            Vector3 direction = _target.position - transform.position;
            direction.Normalize();
            _velocity = direction *_speed;
            direction.y = 0;
            transform.localRotation = Quaternion.LookRotation(direction);
        }

        _velocity.y -= _gravity;
        _character.Move(_velocity*Time.deltaTime);
    }

    public void Damage()
    {
        _health-=20;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _currentState = EnemyState.Attack;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Player")
        {
            _currentState = EnemyState.Chase;
        }
    }
}
