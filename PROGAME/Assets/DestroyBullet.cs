using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour {

    public Rigidbody _bullet;
    public SphereCollider _SCol;
    public float _timer;
    
    void Start() 
    {
        Vector3 fwd = transform.TransformDirection(Vector3.right);
        _bullet.AddForce(fwd * 1500f);
    }
    
    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            Destroy(this.gameObject);
        }


    }

    void OnTriggerExit(Collider col)
    {
        _SCol.isTrigger = false;
    }

    void OnCollisionEnter(Collision col)
    {
        Destroy(this.gameObject);
    }
}
