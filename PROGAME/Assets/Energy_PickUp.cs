using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy_PickUp : MonoBehaviour
{
    public float _timer=3;
    public Movement _Player;

    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }

    void OnTriggerStay(Collider wtf)
    {
        if (wtf.gameObject.tag == "Player")
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                if (_Player.i <= 2)
                {
                    _Player._podniesioneItemki[_Player.i] = true;
                    _Player.i++;
                    Destroy(this.gameObject);  
                }

                _timer = 3;
            }

        }

    }

    void OnTriggerEnter(Collider wtf) 
    {
        if (wtf.gameObject.tag == "bullet") 
        {
            Debug.Log("Dupa");
        }
    }
}
