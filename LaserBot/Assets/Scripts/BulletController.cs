using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed = 5f;
    public float amount = 1000f;
    public bool isCollided = false;
    ShootEnemy shootEnemy;
    void Start () {
        shootEnemy = FindObjectOfType<ShootEnemy>();
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
            col.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 300);
            shootEnemy.launchParticle(transform.position);
        }
        Destroy(gameObject);
    }       
}
