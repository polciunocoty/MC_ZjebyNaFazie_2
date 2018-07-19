using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float _speed;
    public int _jumpSpeed;
    public Rigidbody _rigid;
    float _castDistance = 0.7f;
    RaycastHit _ray;
    float _baseSpeed;

    float _falling=1f;
    float _rising=2f;

    public int _energy;
    float _timer;
    public int _timerResetXD;
    public int _moveValue;
    public int _jumpValue;
    public bool[] _podniesioneItemki = new bool[3];
    public int i = 0;
    // Use this for initialization
    void Start()
    {
        _energy = 100;
        _timer = _timerResetXD;
        _baseSpeed = _speed;
        _rigid = this.GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {

        Move();
        Jump();
        Die();

        if (_timer <= 0) 
        {
            _energy -=_moveValue;
            _timer = _timerResetXD;
        }

    }

    void Move() 
    {

        if (Input.GetKey(KeyCode.D))
        {
            _timer -= Time.deltaTime;
            this.gameObject.transform.position += new Vector3(0, 0, 1 * _speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _timer -= Time.deltaTime;
            this.gameObject.transform.position += new Vector3(0, 0, 1 * -_speed);
        }

    }

    void Jump()
    {
        
        
            if (Physics.BoxCast(this.gameObject.transform.position, new Vector3(0.2f, 0.2f, 0.2f), new Vector3(0, -1, 0), out _ray, Quaternion.identity, _castDistance))
            {
                _speed = _baseSpeed;
               
                if (Input.GetKeyDown(KeyCode.W))
                {
                    _energy = _energy - _jumpValue;

                    _rigid.velocity = new Vector3(0, 1 * _jumpSpeed, 0) ;
                }
               
            }
            else
            {
                if (_rigid.velocity.y > 0 && !Input.GetKeyDown(KeyCode.W)) 
                {
                    _rigid.velocity += Vector3.up * Physics.gravity.y * _rising * Time.deltaTime;
                }

                if (_rigid.velocity.y < 0)
                {
                    _rigid.velocity += Vector3.up * Physics.gravity.y * _falling * Time.deltaTime;
                }

                if (_speed >= _baseSpeed)
                {
                    _speed /= 2;
                }
            }
            
        

    }

    void Die()
    {
        if (_energy <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}