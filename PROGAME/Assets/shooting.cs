using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour 
{
    public Movement _moveScript;
    public Rigidbody _bullet;
    public float _timerReset;
    float _timer;
    public int _shootValue;

	void Update () 
    {
        _timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_timer <= 0)
            {
                Instantiate(_bullet, transform.position, transform.rotation);
                _moveScript._energy -= _shootValue;
                _timer = _timerReset;
            }
        }
      
	}

    


}
