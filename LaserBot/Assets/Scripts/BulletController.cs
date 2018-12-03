using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed = 5f;
    public float amount = 1000f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, 2);
    }

    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.name.Contains("Wall"))
        {
            col.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 200);
        }
        Destroy(gameObject);
    }       
}
