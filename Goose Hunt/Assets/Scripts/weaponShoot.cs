using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponShoot : MonoBehaviour
{
	public Camera GunCamera;
	private GameObject prefab;
	private bool trigger = false;

	void Start()
	{
		prefab = Resources.Load("Projectile") as GameObject;
	}

	void Update()
    {
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
    }

	void Shoot()
	{
		GameObject Projectile = objectPool.sharedInstance.GetPooledObject();
		if (Projectile != null)
		{
			Projectile.transform.position = transform.position + GunCamera.transform.forward * 2;
			Rigidbody rb = Projectile.GetComponent<Rigidbody>();
			rb.velocity = GunCamera.transform.forward * 40;
			Projectile.SetActive(true);
		}
	}
}
