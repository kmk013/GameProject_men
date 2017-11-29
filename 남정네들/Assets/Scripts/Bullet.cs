using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;

    void Start()
    {
        transform.parent = null;
        Destroy(this.gameObject, 5.0f);
    }
	
	void Update () {
        transform.Translate(transform.forward * speed);
	}

    private void OnCollisionEnter(Collision collision)
    {

    }
}
