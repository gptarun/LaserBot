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
        if (col.gameObject.name.Contains("Cube"))
        {
            var force = transform.position - col.transform.position;            
            force.Normalize();
            col.gameObject.GetComponent<Rigidbody>().AddForce(-force * 5000f);
            //col.gameObject.GetComponent<Rigidbody>().transform.rotation *= Quaternion.Euler(-35, 0, 0);
            //col.gameObject.GetComponent<Rigidbody>().AddForce(dir * amount);
        }
        Destroy(gameObject);
    }       
}
