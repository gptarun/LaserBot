using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour {

    TapFire tapFire;   
    public BulletController bullet;
    public float bulletSpeed;
    float timePerShots = 0.1f;
    private float bulletCounter;
    public Transform firePoint;

    public float fireRate = 0.15F;
    private float nextFire = 0.0F;

    // Use this for initialization
    void Start () {
        tapFire = FindObjectOfType<TapFire>();
    }
	
	// Update is called once per frame
	void Update () {
        if (tapFire.Pressed)
        {
            Shoot();
        }
	}

    private void Shoot()
    {
        bulletCounter -= Time.deltaTime;
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            newBullet.transform.rotation *= Quaternion.Euler(-90, 0, 0);
            newBullet.speed = bulletSpeed;
        }
    }
}
